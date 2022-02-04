using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gestion_des_reservations
{

    public partial class ReservationForm : Form
    {
        DataRaidDataContext dataRaid = new DataRaidDataContext();
        Database db = new Database(); 
        public ReservationForm()
        {
            InitializeComponent();
        }

        private void ReservationForm_Load(object sender, EventArgs e)
        {
            comboBox2.DataSource = dataRaid.Clients.Select(x => new { code = x.CodeClient, name = x.Prenom+" "+x.Nom }).ToList();
            comboBox2.DisplayMember = "name";
            comboBox2.ValueMember = "code";

            comboBox1.DataSource = dataRaid.TypeHebergements.Select(x => new { code = x.NumeroType, name = x.LibelleType }).ToList();
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "code";

            Refrech();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = dataRaid.Reservations.FirstOrDefault(row => row.NumRes == int.Parse(textBox1.Text.Trim()));
            if (textBox1.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && result == null)
            {
                Reservation reservation = new Reservation
                {
                    NumRes = int.Parse(textBox1.Text.Trim()),
                    CodeClient = int.Parse(comboBox1.ValueMember),
                    NumeroType = int.Parse(comboBox2.ValueMember),
                    DateDebut = dateTimePicker1.Value,
                    DateFin = dateTimePicker2.Value
                };
                dataRaid.Reservations.InsertOnSubmit(reservation);
                dataRaid.SubmitChanges();
                MessageBox.Show("Reservation est ajouter", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }


        private void Refrech()
        {
            dataGridView1.Rows.Clear();
            var result = dataRaid.Reservations.Select(row => row).ToList();
            dataGridView1.DataSource = result;
        }
    }
}
