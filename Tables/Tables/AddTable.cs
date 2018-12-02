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
    public partial class AddTable : Form
    {
        private Hall H;
        private List<Table> Tables = new List<Table>();

        public AddTable(Hall hall)
        {
            InitializeComponent();
            H = hall;
            
            this.Text = "Добавить стол в " + H.name + " зал";

            TWidth.Minimum = 50;
            TWidth.Maximum = H.width / 2;

            TLength.Minimum = 50;
            TLength.Maximum = H.length / 2;

            UpdateChairsCountBorders();
        }

        private void UpdateChairsCountBorders()
        {
            CCount.Minimum = 0;
            CCount.Maximum = TCPL.Value * 2 + TCPW.Value * 2;

            int MarPad = Convert.ToInt32(TMargin.Value) + Convert.ToInt32(TPadding.Value);

            TX.Minimum = MarPad;
            TX.Maximum = H.width - Convert.ToInt32(TWidth.Value) - MarPad;

            TY.Minimum = MarPad;
            TY.Maximum = H.length - Convert.ToInt32(TLength.Value) - MarPad;
        }

        private void AddTable_Load(object sender, EventArgs e)
        {
            UpdateTables();
        }

        private void TCP_ValueChanged(object sender, EventArgs e)
        {
            UpdateChairsCountBorders();
        }

        private void UpdateTables()
        {
            TablesInfo.Rows.Clear();

            Tables = Server.Deserialize<Table>(Server.PostQuery(Constants.QueryURL, "query=SELECT * FROM TBL WHERE hall_id=" + H.id + "&pas=Delishes228"));

            foreach (Table table in Tables) {

                TablesInfo.Rows.Add();
                TablesInfo.Rows[TablesInfo.RowCount - 1].Cells["id"].Value = table.id;
                TablesInfo.Rows[TablesInfo.RowCount - 1].Cells["hall_id"].Value = table.hall_id;
                TablesInfo.Rows[TablesInfo.RowCount - 1].Cells["chairCount"].Value = table.chair_count;
                TablesInfo.Rows[TablesInfo.RowCount - 1].Cells["can_move"].Value = table.moveable;
                TablesInfo.Rows[TablesInfo.RowCount - 1].Cells["tableW"].Value = table.width;
                TablesInfo.Rows[TablesInfo.RowCount - 1].Cells["tableL"].Value = table.length;
                TablesInfo.Rows[TablesInfo.RowCount - 1].Cells["tableX"].Value = table.x;
                TablesInfo.Rows[TablesInfo.RowCount - 1].Cells["tableY"].Value = table.y;
                TablesInfo.Rows[TablesInfo.RowCount - 1].Cells["Margin"].Value = table.margin;
                TablesInfo.Rows[TablesInfo.RowCount - 1].Cells["Padding"].Value = table.padding;
                TablesInfo.Rows[TablesInfo.RowCount - 1].Cells["CPW"].Value = table.chair_per_width;
                TablesInfo.Rows[TablesInfo.RowCount - 1].Cells["CPL"].Value = table.chair_per_height;
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Table NT = new Table(0, H.id, Convert.ToInt32(CCount.Value), Convert.ToInt32(MoveAble.Checked), 
                                 Convert.ToInt32(TWidth.Value), Convert.ToInt32(TLength.Value), Convert.ToInt32(TX.Value), 
                                 Convert.ToInt32(TY.Value), Convert.ToInt32(TMargin.Value), Convert.ToInt32(TPadding.Value), 
                                 Convert.ToInt32(TCPW.Value), Convert.ToInt32(TCPL.Value));

            foreach(Table T in Tables)
                if (Table.Intersects(T, NT) || Table.Intersects(NT, T))
                {
                    MessageBox.Show("Новый стол пересекается с одним из старых! Стол не добавлен!");
                    return;
                }

            Server.PostQuery(Constants.QueryURL, "query=INSERT INTO TBL VALUES(0," + H.id + "," + Convert.ToInt32(CCount.Value) + "," + MoveAble.Checked + "," + 
                                                 Convert.ToInt32(TWidth.Value) + "," + Convert.ToInt32(TLength.Value) + "," + Convert.ToInt32(TX.Value) + "," + 
                                                 Convert.ToInt32(TY.Value) + "," + Convert.ToInt32(TMargin.Value) + "," + Convert.ToInt32(TPadding.Value) + "," + 
                                                 Convert.ToInt32(TCPW.Value) + "," + Convert.ToInt32(TCPL.Value) + ")&pas=Delishes228");

            UpdateTables();

            MessageBox.Show("Стол успешно добавлен");
        }
    }
}
