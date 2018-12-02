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
    public partial class NewHall : Form
    {
        public NewHall()
        {
            InitializeComponent();
        }

        private List<Hall> HallList = new List<Hall>();
        private List<int> HallIDs = new List<int>();

        private void NewHall_Load(object sender, EventArgs e)
        {
            UpdateTables();
        }

        private void AddHall_Click(object sender, EventArgs e) {

            if (HallNameInput.Text == null || HallNameInput.Text == "") {

                MessageBox.Show("Название зала не может быть пустым");
                return;
            }

            try {

                Server.PostQuery(Constants.QueryURL, "query=INSERT INTO HALLS VALUES(0,'" + HallNameInput.Text + "'," +
                                                     Convert.ToInt32(HallWidthInput.Value) + "," +
                                                     Convert.ToInt32(HallLengthInput.Value) + ")&pas=Delishes228");

                MessageBox.Show("Зал успешно добавлен");
            }
            catch {

                MessageBox.Show("Произошла ошибка! Зал НЕ добавлен!");
            }

            UpdateTables();
        }

        private void UpdateTables() {

            HallTable.Rows.Clear();

            HallList = Server.Deserialize<Hall>(Server.PostQuery(Constants.QueryURL, "query=SELECT * FROM HALLS ORDER BY ID ASC&pas=Delishes228"));

            foreach (Hall hall in HallList)
            {

                HallTable.Rows.Add();
                HallTable.Rows[HallTable.RowCount - 1].Cells["id"].Value = hall.id;
                HallTable.Rows[HallTable.RowCount - 1].Cells["HallName"].Value = hall.name;
                HallTable.Rows[HallTable.RowCount - 1].Cells["HallWidth"].Value = hall.width;
                HallTable.Rows[HallTable.RowCount - 1].Cells["HallLength"].Value = hall.length;
            }

            HallIDs = HallList.Select(hall => hall.id).ToList();
            IDDelete.Minimum = HallIDs.Min();
            IDDelete.Maximum = HallIDs.Max();
        }

        private void DeleteHall_Click(object sender, EventArgs e)
        {
            int iddel = Convert.ToInt32(IDDelete.Value);

            if (!HallIDs.Contains(iddel)) {

                MessageBox.Show("Зала с таким ID не существует!");
                return;
            }

            Server.PostQuery(Constants.QueryURL, "query=DELETE FROM HALLS WHERE id=" + iddel + "&pas=Delishes228");
            UpdateTables();
        }
    }
}
