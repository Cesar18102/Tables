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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<Hall> HallList = new List<Hall>();

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateHalls();
        }

        private void AddHall_Click(object sender, EventArgs e)
        {
            NewHall NH = new NewHall();
            NH.ShowDialog();
            UpdateHalls();
        }

        private void EditHall_Click(object sender, EventArgs e)
        {
            EditHallForm EHF = new EditHallForm(HallList[Halls.SelectedIndex], true);
            EHF.ShowDialog();
            UpdateHalls();
        }

        private void UpdateHalls()
        {
            Halls.Items.Clear();

            HallList = Server.Deserialize<Hall>(Server.PostQuery(Constants.QueryURL, "query=SELECT * FROM HALLS ORDER BY ID ASC&pas=Delishes228"));

            foreach (Hall hall in HallList)
                Halls.Items.Add(hall.name);

            if (Halls.Items.Count != 0)
                Halls.SelectedIndex = 0;
            else
                EditHall.Enabled = false;
        }

        private void AddOffer_Click(object sender, EventArgs e)
        {
            EditHallForm EHF = new EditHallForm(HallList[Halls.SelectedIndex], false);
            EHF.ShowDialog();
            UpdateHalls();
        }
    }
}
