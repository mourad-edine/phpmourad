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

namespace Ok
{
    public partial class UserControl9 : UserControl
    {
        MySqlConnection cn;
        MySqlCommand cm;
        MySqlDataReader rd;
        Class1 database = new Class1();
        public UserControl9()
        {
            InitializeComponent();
            cn = new MySqlConnection(database.dbconnect());
        }

        public void generation(double numero, string occupant, Panel panel)
        {
            var w = new UserControl5()
            {
                Prix = numero,

                Titre = occupant
            };
            w.BackColor = Color.FromArgb(255, 96, 0);
            panel.Controls.Add(w);
           

        }

        private void UserControl9_Load_1(object sender, EventArgs e)
        {
            cn.Open();
            cm = new MySqlCommand("SELECT * FROM salle WHERE etage = 1 AND etat = 1", cn);
            rd = cm.ExecuteReader();
            while (rd.Read())
            {
                generation(int.Parse(rd["salle"].ToString()), rd["type"].ToString(), chose);
            }
            rd.Close();
            cn.Close();

            cn.Open();
            cm = new MySqlCommand("SELECT * FROM salle WHERE etage = 2 AND etat = 1", cn);
            rd = cm.ExecuteReader();
            while (rd.Read())
            {
                generation(int.Parse(rd["salle"].ToString()), rd["type"].ToString(), chose1);
            }
            rd.Close();
            cn.Close();

            cn.Open();
            cm = new MySqlCommand("SELECT * FROM salle WHERE etage = 3 AND etat = 1", cn);
            rd = cm.ExecuteReader();
            while (rd.Read())
            {
                generation(int.Parse(rd["salle"].ToString()), rd["type"].ToString(), chose2);
            }
            rd.Close();
            cn.Close();
        }
        public void modifpan(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserControl7 frm = new UserControl7();
            modifpan(frm);
        }
    }
}
