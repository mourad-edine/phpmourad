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

namespace banque
{
    public partial class Information : UserControl
    {
        MySqlConnection cn;
        MySqlCommand cm;
        MySqlDataReader rd;
        Class1 database = new Class1();
        public static Information instance;
        public Label nom, prenom, identifiant, numero, adresse, proffession;
        public int idt;

        private void Information_Load(object sender, EventArgs e)
        {
            afficher_info();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            User frm = new User();
            changer(frm);
        }

        public Information()
        {
            cn = new MySqlConnection(database.dbconnect());
            InitializeComponent();
            instance = this;
            nom = label17;
            prenom = label16;
            identifiant = label15;
            numero = label14;
            adresse = label13;
            proffession = label12;
        }

        public void changer(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(userControl);
            userControl.BringToFront();
        }
        public void afficher_info()
        {
            int id = int.Parse(label14.Text);
            cn.Open();
            cm = new MySqlCommand("SELECT soldes.id as id, soldes.solde as solde FROM utilisateur,soldes WHERE utilisateur.id = soldes.id_utilisateur AND utilisateur.id = '" + id + "'", cn);
            rd = cm.ExecuteReader();
            if (rd.Read())
            {
                label10.Text = rd["solde"].ToString();
                idt = int.Parse(rd["id"].ToString());
            }
            rd.Close();
            cn.Close();

            string requette = "SELECT id,transaction,montant,created_at FROM historique WHERE id_soldes = '"+idt+"'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(requette, cn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            grid.DataSource = table;
        }


    }
}
