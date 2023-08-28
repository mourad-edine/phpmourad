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

namespace banque
{
    public partial class Stat2 : UserControl
    {
        MySqlConnection cn;
        MySqlCommand cm;
        MySqlDataReader rd;
        Class1 database = new Class1();
        public Stat2()
        {
            InitializeComponent();
            cn = new MySqlConnection(database.dbconnect());

        }

        public void afficher()
        {
            string requette = "SELECT id,montant FROM historique";
            MySqlDataAdapter adapter = new MySqlDataAdapter(requette, cn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            chart1.DataSource = table;
            chart1.Series["Depot1"].XValueMember = "id";
            chart1.Series["Depot1"].YValueMembers = "montant";
            chart1.Titles.Add("profit journalier");


        }

        public void changer(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stat frm = new Stat();
            changer(frm);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Accueil frm = new Accueil();
            changer(frm);
        }
    }
}
