using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace banque
{
    public partial class Accueil : UserControl
    {
        MySqlConnection cn;
        MySqlCommand cm;
        MySqlDataReader rd;
        Class1 database = new Class1();
        public Accueil()
        {
            InitializeComponent();
            cn = new MySqlConnection(database.dbconnect());

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
            User frm = new User();
            changer(frm);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PageTransaction frm = new PageTransaction();
            changer(frm) ;
        }

        public void calcul()
        {
            cn.Open();
            cm = new MySqlCommand("SELECT SUM(solde) as somme FROM soldes", cn);
            rd = cm.ExecuteReader();
            if (rd.Read())
            {
                label3.Text = rd["somme"].ToString();
            }
            rd.Close();
            cn.Close();

            cn.Open();
            cm = new MySqlCommand("SELECT COUNT(id) as id FROM utilisateur", cn);
            rd = cm.ExecuteReader();
            if (rd.Read())
            {
                label1.Text = rd["id"].ToString();
            }
            rd.Close();
            cn.Close();
        }

        private void Accueil_Load(object sender, EventArgs e)
        {
            calcul();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Stat frm = new Stat();
            changer(frm);
        }
    }
}
