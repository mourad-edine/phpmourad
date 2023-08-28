using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace banque
{
    public partial class Stat : UserControl
    {
        MySqlConnection cn;
        MySqlCommand cm;
        MySqlDataReader rd;
        Class1 database = new Class1();
        public Stat()
        {
            InitializeComponent();
            cn = new MySqlConnection(database.dbconnect());
        }

        public void afficher()
        {
            string requette = "SELECT transaction,montant FROM historique";
            MySqlDataAdapter adapter = new MySqlDataAdapter(requette, cn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            chart1.DataSource = table;
            chart1.Series["Depot"].XValueMember = "transaction";
            chart1.Series["Depot"].YValueMembers = "montant";
            chart1.Titles.Add("profit journalier");


        }

        private void Stat_Load(object sender, EventArgs e)
        {
            afficher();
        }

        public void changer(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Accueil frm = new Accueil();
            changer(frm);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Stat2 frm = new Stat2();
            changer(frm);
        }
    }
}
