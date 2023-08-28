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
    public partial class User : UserControl
    {
        MySqlConnection cn;

        Class1 database = new Class1();
        public User()
        {
            InitializeComponent();
            cn = new MySqlConnection(database.dbconnect());
        }
        public void recherche(string valeur)
        {
            string requette = "SELECT * FROM utilisateur WHERE CONCAT(cin) LIKE '%" + valeur + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(requette, cn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            Grid.DataSource = table;
        }

        private void User_Load(object sender, EventArgs e)
        {
            recherche("");
        }

        private void bunifuTextBox1_TextChange(object sender, EventArgs e)
        {
            recherche(bunifuTextBox1.Text);
        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Information frm = new Information();
            panel1.Controls.Clear();
            frm.Dock = DockStyle.Fill;
            Information.instance.identifiant.Text = Grid.Rows[e.RowIndex].Cells["cin"].Value.ToString();
            Information.instance.nom.Text = Grid.Rows[e.RowIndex].Cells["nom"].Value.ToString();
            Information.instance.prenom.Text = Grid.Rows[e.RowIndex].Cells["prenom"].Value.ToString();
            Information.instance.proffession.Text = Grid.Rows[e.RowIndex].Cells["profession"].Value.ToString();
            Information.instance.numero.Text = Grid.Rows[e.RowIndex].Cells["id"].Value.ToString();
            Information.instance.adresse.Text = Grid.Rows[e.RowIndex].Cells["adresse"].Value.ToString();

            panel1.Controls.Add(frm);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Accueil frm = new Accueil();
            changer(frm);
        }
        public void changer(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(userControl);
            userControl.BringToFront();

        }
    }
}
