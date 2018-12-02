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
    public partial class Offer : Form
    {
        private TableSystem TS;

        public Offer(TableSystem TS)
        {
            InitializeComponent();
            this.TS = TS;

            PeopleCount.Maximum = TS.ChairCount;
        }

        private void Reserve_Click(object sender, EventArgs e)
        {
            DateTime ND = DateSatrt.Value;
            DateTime NT = TimeStart.Value;

            string DS = ND.Year + "-" + ND.Month + "-" + ND.Day + " " + NT.Hour + ":" + NT.Minute + ":" + NT.Second;

            ND.AddSeconds(NT.Hour * 3600  + NT.Minute * 60 + NT.Second);
            DateTime END = ND.AddHours(Convert.ToDouble(Duration.Value));

            string DE = END.Year + "-" + END.Month + "-" + END.Day + " " + END.Hour + ":" + END.Minute + ":" + END.Second;


            List<Table> Reserved = Server.Deserialize<Table>(Server.PostQuery(Constants.QueryURL,
                                        "query=SELECT T.id FROM " +
                                        "offer O, TBL T, tbl_offer TOF " +
                                        "WHERE T.id = TOF.tbl_id AND TOF.offer_id = O.id AND ('" +
                                        DS + "' BETWEEN " +
                                        "O.time_start AND O.time_end OR '" + 
                                        DE + "' BETWEEN " +
                                        "O.time_start AND O.time_end)&pas=Delishes228"));

            for(int i = 0; i < TS.Tables.Count; i++)
                for(int j = 0; j < Reserved.Count; j++)
                    if(TS.Tables[i].T.id == Reserved[j].id) {

                        MessageBox.Show("Этот столик уже забронирован на это время!");
                        return;
                    }

            int people = Convert.ToInt32(PeopleCount.Value);

            if (people > TS.ChairCount) {

                MessageBox.Show("За этим столиком не хватает мест!");
                return;
            }

            Count id = Server.Deserialize<Count>(Server.PostQuery(Constants.QueryURL, "query=SELECT MAX(id) AS count FROM offer;&pas=Delishes228"))[0];
            int mid = id.count == ""? 1 : Convert.ToInt32(id.count) + 1;

            Server.PostQuery(Constants.QueryURL, "query=INSERT INTO offer VALUES(" + mid + ", " + people + ", '" + DS + "', '" + DE + "');&pas=Delishes228");

            foreach (TableView T in TS.Tables)
                Server.PostQuery(Constants.QueryURL, "query=INSERT INTO tbl_offer VALUES(" + mid + ", " + T.T.id + ");&pas=Delishes228");

            Update();
        }

        private void RemoveReserve_Click(object sender, EventArgs e)
        {
            Server.PostQuery(Constants.QueryURL, "query=DELETE FROM tbl_offer WHERE offer_id = " + Convert.ToInt32(IDDEL.Value) + ";&pas=Delishes228");
            Server.PostQuery(Constants.QueryURL, "query=DELETE FROM offer WHERE id = " + Convert.ToInt32(IDDEL.Value) + ";&pas=Delishes228");
            Update();
        }

        private void Offer_Load(object sender, EventArgs e)
        {

            Update();
        }

        private void Update() {

            Offers.Rows.Clear();

            List<Reservation> offers = Server.Deserialize<Reservation>(Server.PostQuery(Constants.QueryURL, "query=SELECT * FROM offer;&pas=Delishes228"));
            foreach (Reservation offer in offers) {

                Offers.Rows.Add();
                Offers.Rows[Offers.RowCount - 1].Cells[0].Value = offer.id;
                Offers.Rows[Offers.RowCount - 1].Cells[1].Value = offer.people_count;
                Offers.Rows[Offers.RowCount - 1].Cells[2].Value = offer.time_start.ToString();
                Offers.Rows[Offers.RowCount - 1].Cells[3].Value = offer.time_end.ToString() ;
            }
        }
    }
}
