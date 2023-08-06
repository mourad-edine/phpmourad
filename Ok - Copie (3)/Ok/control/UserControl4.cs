using MySql.Data.MySqlClient;
using Ok.control;
using Org.BouncyCastle.Asn1.Ocsp;
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
    public partial class UserControl4 : UserControl
    {
        MySqlConnection cn;
        MySqlCommand cm;
        MySqlDataReader rd;
        Class1 database = new Class1();
        public static UserControl4 instance;
        public Label id,nom, prenom,cin,adresse,status;

        

        public UserControl4()
        {
            InitializeComponent();
            cn = new MySqlConnection(database.dbconnect());
            instance = this;
            id = label14;
            nom = label4;
            prenom = label5;
            cin = label7;
            adresse = label9;
            status = label11;
            
        }

        private void UserControl4_Load(object sender, EventArgs e)
        {
            afficher_info();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserControl6 frm = new UserControl6();
            addcontroller(frm);
        }
        public void addcontroller(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(userControl);
            userControl.BringToFront();

        }

        public void loaddata()
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            UserControl10 frm = new UserControl10();
            panel1.Controls.Clear();
            frm.Dock = DockStyle.Fill;
            UserControl10.instance.nom.Text = label4.Text;
            UserControl10.instance.id.Text = label14.Text;


            panel1.Controls.Add(frm);
        }
        public void afficher_info()
        {
            int id = int.Parse(label14.Text);
            cn.Open();
            cm = new MySqlCommand("SELECT salle.salle as salle, salle.etage as etage FROM utilisateur,reserve_salle,salle WHERE utilisateur.id = reserve_salle.id_utilisateur AND reserve_salle.id_salle = salle.id AND utilisateur.id = '"+id+"'", cn);
            rd = cm.ExecuteReader();
            if(rd.Read())
            {
                label20.Text = rd["salle"].ToString();
                label21.Text = rd["etage"].ToString();
            }
            rd.Close();
            cn.Close();
        }
    }
}
