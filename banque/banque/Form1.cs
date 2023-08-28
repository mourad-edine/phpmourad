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
    public partial class Banquiz : Form
    {
        MySqlConnection cn;
        MySqlCommand cm;
        MySqlDataReader rd;
        Class1 database = new Class1();
        public Banquiz()
        {
            InitializeComponent();
            cn = new MySqlConnection(database.dbconnect());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            User frm = new User();
            changer(frm);
        }
        public void changer(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel3.Controls.Clear();
            panel3.Controls.Add(userControl);
            userControl.BringToFront();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            PageTransaction frm = new PageTransaction();
            changer(frm);
        }

        public void calcul()
        {
            cn.Open();
            cm = new MySqlCommand("SELECT SUM(solde) as somme FROM soldes", cn);
            rd = cm.ExecuteReader();
            if (rd.Read())
            {
                label6.Text = rd["somme"].ToString();
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

        private void Form1_Load(object sender, EventArgs e)
        {
            calcul(); 
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Stat frm = new Stat();
            changer(frm);
        }
    }
}
