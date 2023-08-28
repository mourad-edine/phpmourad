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
    public partial class Depot : UserControl
    {
        MySqlConnection cn;
        MySqlCommand cm;
        MySqlDataReader rd;
        Class1 database = new Class1();
        public int montants, sommes, nouveau,num;
        public Depot()
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

        private void button4_Click(object sender, EventArgs e)
        {
            deposer();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            PageTransaction frm = new PageTransaction();
            changer(frm);
        }

        public void deposer()
        {
            try
            {
                if (montant.Text == string.Empty || numeroid.Text == string.Empty || numerocin.Text == string.Empty)
                {
                    MessageBox.Show("veuillez tout remplir svp!", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    clear();
                    return;

                }
                cn.Open();
                string requette = "SELECT * FROM utilisateur WHERE id = '" + numeroid.Text + "' AND cin = '" + numerocin.Text + "'";
                cm = new MySqlCommand(requette, cn);
                rd = cm.ExecuteReader();

                if (rd.HasRows)
                {
                    rd.Close();
                    cn.Close();
                    cn.Open();
                    int id = int.Parse(numeroid.Text);
                    cm = new MySqlCommand("SELECT id,solde FROM soldes WHERE id_utilisateur = '" + id + "'", cn);
                    rd = cm.ExecuteReader();
                    if (rd.Read())
                    {
                        sommes = int.Parse(rd["solde"].ToString());
                        num = int.Parse(rd["id"].ToString());
                    }

                    rd.Close();
                    cn.Close();
                    montants = int.Parse(montant.Text);
                    if (montants > 0)
                    {
                        nouveau = sommes + montants;

                        cn.Open();
                        cm = new MySqlCommand("UPDATE soldes SET solde = '" + nouveau + "' WHERE id = '" + id + "'", cn);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("transaction de depot effectué avec succès", "succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();


                        string transaction = "retrait";
                        cn.Open();
                        cm = new MySqlCommand("INSERT into historique (transaction,id_soldes,montant) VALUES('" + transaction + "','" + num + "','" + montants + "')", cn);
                        cm.ExecuteNonQuery();
                        cn.Close();
                    }
                    else
                    {
                        cn.Close();
                        MessageBox.Show("echec ! solde insuffisant", "echec", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    cn.Close() ;
                    MessageBox.Show("les information ne correspondent pas", "echec", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }




            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show("warning : " + ex.Message, "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void clear()
        {
            montant.Clear();
            numeroid.Clear();
            numerocin.Clear();
        }
    }
}
