using Google.Protobuf.WellKnownTypes;
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
    public partial class Transfert : UserControl
    {
        MySqlConnection cn;
        MySqlCommand cm;
        MySqlDataReader rd;
        Class1 database = new Class1();
        public int montants, sommes, nouveau, num, montants2, sommes2, nouveau2, num2;

        private void button4_Click(object sender, EventArgs e)
        {
            transferer();
        }

        public Transfert()
        {
            InitializeComponent();
            cn = new MySqlConnection(database.dbconnect());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PageTransaction frm = new PageTransaction();
            changer(frm);
        }
        public void changer(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(userControl);
            userControl.BringToFront();

        }

        public void transferer()
        {
            try
            {
                if (montant.Text == string.Empty || compte1.Text == string.Empty || compte2.Text == string.Empty || numerocin.Text == string.Empty)
                {
                    MessageBox.Show("veuillez tout remplir svp!", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    clear();
                    return;

                }
                int idx = int.Parse(compte1.Text);
                cm = new MySqlCommand("SELECT id,solde FROM soldes WHERE id_utilisateur = '" + idx + "'", cn);
                rd = cm.ExecuteReader();
                if (rd.Read())
                {
                    sommes = int.Parse(rd["solde"].ToString());
                    num = int.Parse(rd["id"].ToString());
                }

                rd.Close();
                cn.Close();
                montants = int.Parse(montant.Text);
                if (montants > sommes)
                {
                    cn.Open();
                    string requette = "SELECT * FROM utilisateur WHERE id = '" + compte1.Text + "' AND cin = '" + numerocin.Text + "'";
                    cm = new MySqlCommand(requette, cn);
                    rd = cm.ExecuteReader();

                    if (rd.HasRows)
                    {
                        rd.Close();
                        cn.Close();

                        cn.Open();
                        string requett = "SELECT * FROM utilisateur WHERE id = '" + compte2.Text + "'";
                        cm = new MySqlCommand(requett, cn);
                        rd = cm.ExecuteReader();

                        if (rd.HasRows)
                        {
                            rd.Close();
                            cn.Close();

                            int id = int.Parse(compte1.Text);
                            cn.Open();
                            cm = new MySqlCommand("SELECT id,solde FROM soldes WHERE id_utilisateur = '" + id + "'", cn);
                            rd = cm.ExecuteReader();
                            if (rd.Read())
                            {
                                sommes = int.Parse(rd["solde"].ToString());
                                num = int.Parse(rd["id"].ToString());
                            }

                            rd.Close();
                            cn.Close();

                            nouveau = sommes - montants;

                            cn.Open();
                            cm = new MySqlCommand("UPDATE soldes SET solde = '" + nouveau + "' WHERE id = '" + id + "'", cn);
                            cm.ExecuteNonQuery();
                            cn.Close();


                            string transaction = "transfert";
                            cn.Open();
                            cm = new MySqlCommand("INSERT into historique (transaction,id_soldes,montant) VALUES('" + transaction + "','" + num + "','" + montants + "')", cn);
                            cm.ExecuteNonQuery();
                            cn.Close();
                            /*partie 1 */


                            int idt = int.Parse(compte2.Text);
                            cn.Open();
                            cm = new MySqlCommand("SELECT id,solde FROM soldes WHERE id_utilisateur = '" + idt + "'", cn);
                            rd = cm.ExecuteReader();
                            if (rd.Read())
                            {
                                sommes2 = int.Parse(rd["solde"].ToString());
                                num2 = int.Parse(rd["id"].ToString());
                            }
                            rd.Close();
                            cn.Close();
                            nouveau2 = sommes2 + montants;

                            cn.Open();
                            cm = new MySqlCommand("UPDATE soldes SET solde = '" + nouveau2 + "' WHERE id = '" + idt + "'", cn);
                            cm.ExecuteNonQuery();
                            cn.Close();
                            clear();

                            string transactio = "depot";
                            cn.Open();
                            cm = new MySqlCommand("INSERT into historique (transaction,id_soldes,montant) VALUES('" + transactio + "','" + num2 + "','" + montants + "')", cn);
                            cm.ExecuteNonQuery();
                            cn.Close();
                            MessageBox.Show("transaction de transfert effectué avec succès", "succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            /*partie 2 */

                        }
                        else
                        {
                            cn.Close() ;
                            MessageBox.Show("echec ! solde insuffisant", "echec", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }


                    }
                    else
                    {
                        cn.Close() ;
                        MessageBox.Show("echec! les informations du destinataire ne correspondent pas", "echec", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }


                }
                else
                {
                    cn.Close();
                    MessageBox.Show("echec! les informations de l'expediteur ne correspondent pas", "echec", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            compte1.Clear();
            numerocin.Clear();
            compte2.Clear();
        }
    }
}
