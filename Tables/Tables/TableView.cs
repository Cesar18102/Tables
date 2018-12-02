using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Tables
{
    public class TableView
    {
        public Button TBL;
        public PictureBox P;
        public PictureBox M;
        public Table T;

        private int MW = 1920;
        private int MH = 1080;

        private double RW = Screen.PrimaryScreen.Bounds.Width;
        private double RH = Screen.PrimaryScreen.Bounds.Height;

        private bool Moving = false;
        private bool Focused = false;
        private Point MoveByPoint = new Point();

        public delegate int Move(TableView T);
        public event Move TableMove;

        public delegate void Moved(Table T);
        public event Moved TableMoved;

        public delegate void Destroy(TableView T);
        public event Destroy Destroyed;

        public delegate TableSystem Offered(TableView T);
        public event Offered Reserve;

        public TableView[] Connected = new TableView[4] { null, null, null, null }; // bottom, left, right, top 

        public TableView(Table T, bool edit_mode)
        {
            this.T = T;

            TBL = new Button();
            TBL.Font = new Font("Sans Serif", 8);
            TBL.Text = "ID: " + T.id.ToString() + "\nСтульев: " + GetChairsCounts().Sum();
            TBL.Size = new Size((int)(RW * T.width / MW), (int)(RH * T.length / MH));
            TBL.Location = new Point((int)(RW * T.x / MW), (int)(RH * T.y / MH));

            if (edit_mode)
            {
                TBL.MouseDown += TBL_MouseDown;
                TBL.MouseUp += TBL_MouseUp;
                TBL.MouseMove += TBL_MouseMove;
                TBL.GotFocus += TBL_GotFocus;
                TBL.LostFocus += TBL_LostFocus;
            }
            else
                TBL.Click += TBL_Click;

            P = new PictureBox();
            P.BackColor = Color.Green;
            P.Size = new Size((int)(RW * (T.width + T.padding * 2) / MW), (int)(RH * (T.length + T.padding * 2) / MH));
            P.Location = new Point((int)(RW * (T.x - T.padding) / MW), (int)(RH * (T.y - T.padding) / MH));

            M = new PictureBox();
            M.BackColor = Color.Red;
            M.Size = new Size((int)(RW * (T.width + T.margin * 2 + T.padding * 2) / MW), (int)(RH * (T.length + T.margin * 2 + T.padding * 2) / MH));
            M.Location = new Point((int)(RW * (T.x - T.padding - T.margin) / MW), (int)(RH * (T.y - T.padding - T.margin) / MH));
        }

        private void TBL_Click(object sender, EventArgs e)
        {
            TableSystem TS = null;
            if (Reserve != null)
                TS = Reserve(this);
                    
            Offer OF = new Offer(TS);
            OF.ShowDialog();
        }

        private void TBL_LostFocus(object sender, EventArgs e)
        {
            Focused = false;
        }

        private void TBL_GotFocus(object sender, EventArgs e)
        {
            Focused = true;
        }

        private void MoveTo(int X, int Y) {

            if (!Moving || T.moveable == 0)
                return;

            int x = T.x;
            int y = T.y;

            T.x = X - MoveByPoint.X + (M.Width - TBL.Width) / 2;
            T.y = Y - MoveByPoint.Y + (M.Height - TBL.Height) / 2;

            int valid = TableMove(this);

            if (valid == 1)
                return;

            if (TableMove == null || valid == -1)
            {

                T.x = x;
                T.y = y;
                return;
            }

            M.Location = new Point(X - MoveByPoint.X, Y - MoveByPoint.Y);
            P.Location = new Point(X - MoveByPoint.X + (M.Width - P.Width) / 2, Y - MoveByPoint.Y + (M.Height - P.Height) / 2);
            TBL.Location = new Point(X - MoveByPoint.X + (M.Width - TBL.Width) / 2, Y - MoveByPoint.Y + (M.Height - TBL.Height) / 2);
        }

        private void TBL_MouseDown(object sender, MouseEventArgs e) {

            Moving = true;
            MoveByPoint = new Point(Cursor.Position.X - M.Location.X, Cursor.Position.Y - M.Location.Y);
        }

        private void TBL_MouseMove(object sender, MouseEventArgs e) {

            MoveTo(Cursor.Position.X, Cursor.Position.Y);
        }

        private void TBL_MouseUp(object sender, MouseEventArgs e) {

            Moving = false;
            MoveByPoint = new Point();

            if (TableMoved != null)
                TableMoved(this.T);
        }

        /// <summary>
        /// 0 - bottom, 1 - left, 2 - right, 3 - top 
        /// </summary>
        /// <returns></returns>
        public int[] GetChairsCounts() {

            int ChairsGiven = T.chair_count;
            int[] res = new int[4] { 0, 0, 0, 0 };

            for (int i = 0; i < 4; i++) {

                if (Connected[i] == null) {

                    int chairs_per_side = i == 0 || i == 3 ? T.chair_per_height : T.chair_per_width;
                    int count = Math.Min(chairs_per_side, ChairsGiven);
                    ChairsGiven -= count;
                    res[i] = count;
                }
            }

            return res;
        }

        public static void MakeSuitable(TableView T1, TableView T2, int SideFromT1)
        {

            switch (SideFromT1)
            {
                case 2:
                    T1.M.Height -= T1.T.margin + T1.T.padding;
                    T1.P.Height -= T1.T.padding;

                    T1.M.Location = new Point(T1.M.Location.X, T1.M.Location.Y + T1.T.margin + T1.T.padding + T2.T.margin + T2.T.padding);
                    T1.P.Location = new Point(T1.P.Location.X, T1.P.Location.Y + T1.T.margin + T1.T.padding + T2.T.margin + T2.T.padding);
                    T1.TBL.Location = new Point(T1.TBL.Location.X, T1.TBL.Location.Y + T1.T.margin + T1.T.padding + T2.T.margin + T2.T.padding);

                    T1.T.y += T1.T.margin + T1.T.padding + T2.T.margin + T2.T.padding;

                    T2.M.Height -= T2.T.margin + T2.T.padding;
                    T2.P.Height -= T2.T.padding;

                    T2.M.Location = new Point(T2.M.Location.X, T2.M.Location.Y + T2.T.padding + T2.T.margin);
                    T2.P.Location = new Point(T2.P.Location.X, T2.P.Location.Y + T2.T.padding);
                    break;
                case 8:
                    T1.M.Height -= T1.T.margin + T1.T.padding;
                    T1.P.Height -= T1.T.padding;

                    T1.M.Location = new Point(T1.M.Location.X, T1.M.Location.Y - T2.T.margin - T2.T.padding);
                    T1.P.Location = new Point(T1.P.Location.X, T1.P.Location.Y - T1.T.margin - T2.T.margin - T2.T.padding);
                    T1.TBL.Location = new Point(T1.TBL.Location.X, T1.TBL.Location.Y - T1.T.margin - T1.T.padding - T2.T.margin - T2.T.padding);

                    T1.T.y +=  -T2.T.margin - T2.T.padding;

                    T2.M.Height -= T2.T.margin + T2.T.padding;
                    T2.P.Height -= T2.T.padding;
                    break;
                case 4:
                    T1.M.Width -= T1.T.margin + T1.T.padding;
                    T1.P.Width -= T1.T.padding;

                    T1.M.Location = new Point(T1.M.Location.X - T2.T.margin - T2.T.padding, T1.M.Location.Y);
                    T1.P.Location = new Point(T1.P.Location.X - T1.T.margin - T2.T.margin - T2.T.padding, T1.P.Location.Y);
                    T1.TBL.Location = new Point(T1.TBL.Location.X - T1.T.margin - T1.T.padding - T2.T.margin - T2.T.padding, T1.TBL.Location.Y);

                    T1.T.x += -T1.T.margin - T1.T.padding - T2.T.margin - T2.T.padding;

                    T2.M.Width -= T2.T.margin + T2.T.padding;
                    T2.P.Width -= T2.T.padding;
                    break;
                case 6:
                    T1.M.Width -= T1.T.margin + T1.T.padding;
                    T1.P.Width -= T1.T.padding;
                    
                    T1.M.Location = new Point(T1.M.Location.X + T2.T.margin + T2.T.padding + T1.T.padding + T1.T.margin, T1.M.Location.Y);
                    T1.P.Location = new Point(T1.P.Location.X + T2.T.margin + T2.T.padding + T1.T.padding + T1.T.margin, T1.P.Location.Y);
                    T1.TBL.Location = new Point(T1.TBL.Location.X + T2.T.margin + T2.T.padding + T1.T.padding + T1.T.margin, T1.TBL.Location.Y);

                    T1.T.x += T2.T.margin + T2.T.padding + T1.T.margin + T1.T.padding;

                    T2.M.Width -= T2.T.margin + T2.T.padding;
                    T2.P.Width -= T2.T.padding;

                    T2.M.Location = new Point(T2.M.Location.X + T2.T.margin + T2.T.padding, T2.M.Location.Y);
                    T2.P.Location = new Point(T2.P.Location.X + T2.T.padding, T2.P.Location.Y);
                    break;
                default: break;
            }

            T1.TBL.Text = "ID: " + T1.T.id.ToString() + "\nСтульев: " + T1.GetChairsCounts().Sum();
            T2.TBL.Text = "ID: " + T2.T.id.ToString() + "\nСтульев: " + T2.GetChairsCounts().Sum();
        }

        public static void ReMakeSuitable(TableView T1, TableView T2, int SideFromT1)
        {

            switch (SideFromT1)
            {
                case 2:
                    T1.M.Height -= T1.T.margin + T1.T.padding;
                    T1.P.Height -= T1.T.padding;

                    T2.M.Height -= T2.T.margin + T2.T.padding;
                    T2.P.Height -= T2.T.padding;

                    T2.M.Location = new Point(T2.M.Location.X, T2.M.Location.Y + T2.T.padding + T2.T.margin);
                    T2.P.Location = new Point(T2.P.Location.X, T2.P.Location.Y + T2.T.padding);
                    break;
                case 8:
                    T1.M.Height -= T1.T.margin + T1.T.padding;
                    T1.P.Height -= T1.T.padding;

                    T1.M.Location = new Point(T1.M.Location.X, T1.M.Location.Y + T1.T.margin + T1.T.padding);
                    T1.P.Location = new Point(T1.P.Location.X, T1.P.Location.Y + T1.T.padding);

                    T2.M.Height -= T2.T.margin + T2.T.padding;
                    T2.P.Height -= T2.T.padding;
                    break;
                case 4:
                    T1.M.Width -= T1.T.margin + T1.T.padding;
                    T1.P.Width -= T1.T.padding;

                    T1.M.Location = new Point(T1.M.Location.X + T1.T.margin + T1.T.padding, T1.M.Location.Y);
                    T1.P.Location = new Point(T1.P.Location.X + T1.T.padding, T1.P.Location.Y);

                    T2.M.Width -= T2.T.margin + T2.T.padding;
                    T2.P.Width -= T2.T.padding;
                    break;
                case 6:
                    T1.M.Width -= T1.T.margin + T1.T.padding;
                    T1.P.Width -= T1.T.padding;

                    T2.M.Width -= T2.T.margin + T2.T.padding;
                    T2.P.Width -= T2.T.padding;

                    T2.M.Location = new Point(T2.M.Location.X + T2.T.margin + T2.T.padding, T2.M.Location.Y);
                    T2.P.Location = new Point(T2.P.Location.X + T2.T.padding, T2.P.Location.Y);
                    break;
                default: break;
            }

            T1.TBL.Text = "ID: " + T1.T.id.ToString() + "\nСтульев: " + T1.GetChairsCounts().Sum();
            T2.TBL.Text = "ID: " + T2.T.id.ToString() + "\nСтульев: " + T2.GetChairsCounts().Sum();
        }

        public void UnSuiteTable() {

            TBL.Size = new Size((int)(RW * T.width / MW), (int)(RH * T.length / MH));
            TBL.Location = new Point((int)(RW * T.x / MW), (int)(RH * T.y / MH));

            P.Size = new Size((int)(RW * (T.width + T.padding * 2) / MW), (int)(RH * (T.length + T.padding * 2) / MH));
            P.Location = new Point((int)(RW * (T.x - T.padding) / MW), (int)(RH * (T.y - T.padding) / MH));

            M.Size = new Size((int)(RW * (T.width + T.margin * 2 + T.padding * 2) / MW), (int)(RH * (T.length + T.margin * 2 + T.padding * 2) / MH));
            M.Location = new Point((int)(RW * (T.x - T.padding - T.margin) / MW), (int)(RH * (T.y - T.padding - T.margin) / MH));
        }

        public void KeyDown(object sender, KeyEventArgs e) {

            if (e.KeyCode == Keys.Delete && Focused) {

                Server.PostQuery(Constants.QueryURL, "query=DELETE FROM TBL WHERE id=" + T.id + "&pas=Delishes228");
                if (Destroyed != null)
                    Destroyed(this);
            }
        }
    }
}