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

namespace Ok.control
{
    public partial class UserControl10 : UserControl
    {

        MySqlConnection cn;
        MySqlCommand cm;
        MySqlDataReader rd;
        Class1 database = new Class1();
        public static UserControl10 instance;
        public Label id, nom;
        public UserControl10()
        {
            InitializeComponent();
            cn = new MySqlConnection(database.dbconnect());
            instance = this;
            id = label18;
            nom = label5;
        }

        private void UserControl10_Load(object sender, EventArgs e)
        {
            cn.Open();
            cm = new MySqlCommand("SELECT * FROM salle WHERE etage = 1 AND etat = 0", cn);
            rd = cm.ExecuteReader();
            while (rd.Read())
            {
                generation(int.Parse(rd["id"].ToString()), int.Parse(rd["salle"].ToString()), rd["type"].ToString(), chose);
            }
            rd.Close();
            cn.Close();

            cn.Open();
            cm = new MySqlCommand("SELECT * FROM salle WHERE etage = 2 AND etat = 0", cn);
            rd = cm.ExecuteReader();
            while (rd.Read())
            {
                generation(int.Parse(rd["id"].ToString()), int.Parse(rd["salle"].ToString()), rd["type"].ToString(), chose1);
            }
            rd.Close();
            cn.Close();

            cn.Open();
            cm = new MySqlCommand("SELECT * FROM salle WHERE etage = 3 AND etat = 0", cn);
            rd = cm.ExecuteReader();
            while (rd.Read())
            {
                generation(int.Parse(rd["id"].ToString()),int.Parse(rd["salle"].ToString()), rd["type"].ToString(), chose2);
            }
            rd.Close();
            cn.Close();
        }

        public void generation(double numero,double reference, string occupant, Panel panel)
        {
            var w = new UserControl5()
            {
                Titre = occupant
                ,
                Prix =numero,

                Reference = reference
            };
            panel.Controls.Add(w);
            w.Onselect += (ss, ee) =>
            {
                var wdg = (UserControl5)ss;

                    /*item.Cells[0].Value = wdg.Titre;
                    item.Cells[1].Value = item.Cells[1].Value.ToString() + 1;
                    item.Cells[2].Value = wdg.Prix ;
                    calculate();
                    return;

                     item.Cells[0].Value =wdg.Titre;

                    item.Cells[1].Value = wdg.Prix;
                    item.Cells[2].Value = wdg.Prix;
                    calculate();
                    return;*/
              
                Form3 l = new Form3();
                l.label4.Text = occupant;
                l.label3.Text = numero.ToString();
                l.label6.Text = reference.ToString();
                l.label8.Text = label18.Text;
                l.ShowDialog();
            };

        }   


    }
}
