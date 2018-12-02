using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tables
{
    public partial class EditHallForm : Form
    {
        private Hall H;
        private int MW = 1920;
        private int MH = 1080;

        private List<Table> Tables = new List<Table>();
        private List<TableView> TableViews = new List<TableView>();
        public List<TableSystem> TableSystems = new List<TableSystem>();

        private double RW = Screen.PrimaryScreen.Bounds.Width;
        private double RH = Screen.PrimaryScreen.Bounds.Height;

        public delegate void TablesMerged(int id1, int S1, int id2, int S2);
        public event TablesMerged TablesMerge;

        public bool edit_mode = false;

        public EditHallForm(Hall hall, bool emode)
        {
            InitializeComponent();
            KeyPreview = true;

            edit_mode = emode;

            H = hall;
            this.Text = edit_mode? "Редактировать " + H.name + " зал" : "Внести бронь:" + H.name + " зал";

            this.Width = (int)(RW * H.width / MW);
            this.Height = (int)(RH * H.length / MH) + 50;

            if (edit_mode) {

                Button AddTable = new Button();
                AddTable.Size = new Size(this.Width - 20, 50);
                AddTable.Location = new Point(0, this.Height - 90);
                AddTable.Text = "Добавить стол";
                AddTable.Click += AddTable_Click;
                this.Controls.Add(AddTable);
            }
        }

        private void AddTable_Click(object sender, EventArgs e)
        {
            AddTable AT = new AddTable(H);
            AT.ShowDialog();
            UpdateLocations();
        }

        private void EditHallForm_Load(object sender, EventArgs e)
        {
            UpdateLocations();
        }

        private void UpdateLocations() {

            foreach (TableView TW in TableViews) {

                this.Controls.Remove(TW.TBL);
                this.Controls.Remove(TW.P);
                this.Controls.Remove(TW.M);
            }
            TableViews.Clear();

            Tables = Server.Deserialize<Table>(Server.PostQuery(Constants.QueryURL, "query=SELECT * FROM TBL WHERE hall_id=" + H.id + "&pas=Delishes228"));
            
            DateTime N = DateTime.Now;

            List<Table> Reserved = Server.Deserialize<Table>(Server.PostQuery(Constants.QueryURL, 
                                        "query=SELECT T.id FROM " + 
                                        "offer O, TBL T, tbl_offer TOF " + 
                                        "WHERE T.id = TOF.tbl_id AND TOF.offer_id = O.id AND '" + 
                                        N.Year + "-" + N.Month + "-" + N.Day + " " + N.Hour + ":" + N.Minute + ":" + N.Second + "' BETWEEN " + 
                                        "O.time_start AND O.time_end;&pas=Delishes228"));


            foreach (Table T in Tables) {

                TableView TW = new TableView(T, edit_mode);

                this.Controls.Add(TW.TBL);
                this.Controls.Add(TW.P);
                this.Controls.Add(TW.M);
                TableViews.Add(TW);

                if (edit_mode) {

                    TW.TableMove += Validate;
                    TW.TableMoved += TW_TableMoved;
                    TW.Destroyed += TW_Destroyed;
                    this.KeyDown += TW.KeyDown;
                }
                else {

                    TW.Reserve += TW_Reserve;

                    foreach (Table R in Reserved)
                        if (R.id == T.id) {

                            TW.TBL.BackColor = Color.Red;
                            TW.T.moveable = 0;
                        }
                }
                TableSystem TS = new TableSystem();
                TS.Tables.Add(TW);
                TableSystems.Add(TS);

                foreach(TableView TWW in TableViews)
                    if (TW.T.id != TWW.T.id && Table.Intersects(TW.T, TWW.T) && Table.Intersects(TWW.T, TW.T)) {

                        int T2Side = Table.GetIntersectionSide(TW.T, TWW.T);
                        int OP = Table.GetIntersectionSide(TWW.T, TW.T);

                        if (TW.Connected[T2Side / 2 - 1] != null || TWW.Connected[OP / 2 - 1] != null)
                            continue;

                        ReMergeTables(TW, TWW, T2Side, OP);
                    }
            }
        }

        private TableSystem TW_Reserve(TableView T)
        {
            foreach (TableSystem TS in TableSystems)
                if (TS.Contains(T) != -1)
                    return TS;

            return null;
        }

        private void TW_Destroyed(TableView T)
        {
            for(int i = 0; i < 4; i++) {

                if (T.Connected[i] == null)
                    continue;

                int OP = i == 0? 3 : (i == 1? 2 : (i == 2? 1 : 0));

                T.Connected[i].UnSuiteTable();
                T.Connected[i].Connected[OP] = null;
                T.Connected[i].TBL.Text = "ID: " + T.Connected[i].T.id.ToString() + "\nСтульев: " + T.Connected[i].GetChairsCounts().Sum();
            }

            for (int i = 0; i < TableSystems.Count; i++) {

                int index = TableSystems[i].Contains(T);
                if (index != -1)
                {
                    TableSystems[i].Tables.RemoveAt(index);
                    if (TableSystems[i].Tables.Count == 0)
                        TableSystems.RemoveAt(i);
                }
            }

            this.Controls.Remove(T.M);
            this.Controls.Remove(T.P);
            this.Controls.Remove(T.TBL);
            Tables.Remove(T.T);
            TableViews.Remove(T);
        }

        private void TW_TableMoved(Table T) {

            Server.PostQuery(Constants.QueryURL, "query=UPDATE TBL SET x=" + T.x + ", y=" + T.y + " WHERE id=" + T.id + "&pas=Delishes228");
        }

        public int Validate(TableView T) {

            if (T.T.x - T.T.padding - T.T.margin < 0 || 
                T.T.y - T.T.padding - T.T.margin < 0 || 
                T.T.x + T.T.width + T.T.padding + T.T.margin >= this.Width || 
                T.T.y + T.T.length + T.T.padding + T.T.margin >= this.Height)
                return -1;

            foreach (TableView TBLV in TableViews)
                if (TBLV.T.id != T.T.id && Table.Intersects(T.T, TBLV.T) && Table.Intersects(TBLV.T, T.T)) {

                    int T2Side = Table.GetIntersectionSide(T.T, TBLV.T);
                    int OP = Table.GetIntersectionSide(TBLV.T, T.T);

                    if (T.Connected[T2Side / 2 - 1] != null || TBLV.Connected[OP / 2 - 1] != null)
                        return -1;

                    if (T.T.moveable == 1 && TBLV.T.moveable == 1 && MessageBox.Show("Вы хотите совместить столы " + T.T.id + " и " + TBLV.T.id + "?", "Совмещение", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) {

                        MergeTables(T, TBLV, T2Side, OP);
                        TW_TableMoved(T.T);
                        TW_TableMoved(TBLV.T);
                        return 1;
                    }
                    else
                        return -1;
                }

            return 0;
        }

        public void MergeTables(TableView T1, TableView T2, int T2Side, int OP){

            T1.Connected[T2Side / 2 - 1] = T2;
            T2.Connected[OP / 2 - 1] = T1;

            int i = 0;

            for (; i < TableSystems.Count; i++)
                if (TableSystems[i].Contains(T1) != -1)
                    break;

            for (int j = 0; j < TableSystems.Count; j++)
                if (TableSystems[j].Contains(T2) != -1 && i != j) {

                    for (int k = 0; k < TableSystems[i].Tables.Count; k++ )
                        TableSystems[j].Tables.Add(TableSystems[i].Tables[k]);

                    TableSystems.RemoveAt(i);
                    break;
                }

            TableView.MakeSuitable(T1, T2, T2Side);
        }

        public void ReMergeTables(TableView T1, TableView T2, int T2Side, int OP)
        {

            T1.Connected[T2Side / 2 - 1] = T2;
            T2.Connected[OP / 2 - 1] = T1;

            int i = 0;

            for (; i < TableSystems.Count; i++)
                if (TableSystems[i].Contains(T1) != -1)
                    break;

            for (int j = 0; j < TableSystems.Count; j++)
                if (TableSystems[j].Contains(T2) != -1 && i != j)
                {

                    for (int k = 0; k < TableSystems[i].Tables.Count; k++)
                        TableSystems[j].Tables.Add(TableSystems[i].Tables[k]);

                    
                    TableSystems.RemoveAt(i);
                    break;
                }

            TableView.ReMakeSuitable(T1, T2, T2Side);
        }
    }
}
