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
    
   
    public partial class Form5 : Form
    {
       /* private static Form5 instance;
        public static Form5 Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Form5();
                    
                }
                return instance;
            }
        }

        public Panel pnlContain
        {
            get
            {
                return pnlContain;
            }

            set 
            { 
                pnlContain = value;
            }
        }*/
        MySqlConnection cn;

        Class1 database = new Class1();
        public Form5()
        {
            InitializeComponent();
            cn = new MySqlConnection(database.dbconnect());
        }
        public void recherche(string valeur)
        {
            string requette = "SELECT * FROM utilisateur WHERE CONCAT(nom,prenom) LIKE '%" + valeur + "%' AND status='patient'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(requette, cn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            Grid1.DataSource = table;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            recherche(textBox1.Text);
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            recherche("");
        }



        private void Grid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           /* Form6 frm = new Form6();
            frm.label2.Text = Grid1.Rows[e.RowIndex].Cells["nom"].Value.ToString();
            frm.ShowDialog();*/

            UserControl4 frm = new UserControl4();
            panel3.Controls.Clear();
            frm.Dock = DockStyle.Fill;
            UserControl4.instance.id.Text = Grid1.Rows[e.RowIndex].Cells["id"].Value.ToString();
            UserControl4.instance.nom.Text = Grid1.Rows[e.RowIndex].Cells["nom"].Value.ToString();
            UserControl4.instance.prenom.Text = Grid1.Rows[e.RowIndex].Cells["prenom"].Value.ToString();
            UserControl4.instance.cin.Text = Grid1.Rows[e.RowIndex].Cells["CIN"].Value.ToString();
            UserControl4.instance.status.Text = Grid1.Rows[e.RowIndex].Cells["status"].Value.ToString();
            UserControl4.instance.adresse.Text = Grid1.Rows[e.RowIndex].Cells["adresse"].Value.ToString();

            panel3.Controls.Add(frm);
            
        }
        public void addcontroller(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel3.Controls.Clear();
            panel3.Controls.Add(userControl);
            userControl.BringToFront();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserControl6 frm = new UserControl6();
            addcontroller(frm);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserControl7 frm = new UserControl7();
            addcontroller(frm);
        }
    }

    
}
