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
    public partial class index2 : Form
    {
        MySqlConnection cn;
        MySqlDataReader rd;
        MySqlCommand cm;
        Class1 database = new Class1();
        public index2()
        {
            InitializeComponent();
            cn = new MySqlConnection(database.dbconnect());
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Close();
            frm.Show();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            try {
                string nom, mot;
                nom = nom_champ.Text;
                mot = mo_passe.Text;
                cn.Open();
                string requette = "SELECT * FROM utilisateur WHERE nom = '" + nom_champ.Text + "' AND mot = '" + mo_passe.Text + "'";
                cm = new MySqlCommand(requette, cn);
                rd = cm.ExecuteReader();

                if (rd.HasRows)
                {
                        rd.Read();
                    if (rd["status"].ToString() == "docteur")
                    {
                        Form4 frm4 = new Form4();
                        this.Hide();
                        frm4.Show();
                        this.Close();
                        cn.Close();
                    }else if (rd["status"].ToString() == "pharmacien")
                    {
                        Form1 frm1 = new Form1();
                        this.Hide();
                        frm1.Show();
                        cn.Close();
                    }
                    else if (rd["status"].ToString() == "reception")
                    {
                        Form5 frm5 = new Form5();
                        this.Hide();
                        frm5.Show();
                        cn.Close();
                    }
                    else
                    {
                        MessageBox.Show("humm.......tsy haiko aloha", "Avertissment", MessageBoxButtons.OK);

                    }


                    /*else if (rd["status"].ToString() == "pharmacien")
                    {
                        Form4 frm4 = new Form4();
                        this.Hide();
                        frm4.Show();
                        cn.Close();
                    }
                    else
                    {
                        MessageBox.Show("tsy misy le olombelona", "Avertissment", MessageBoxButtons.OK);
                    }*/
                }
                else
                {
                    MessageBox.Show("mot de passe ou nom incorrect", "Avertissment", MessageBoxButtons.OK);
                    vider();

                }
                cn.Close();
            } catch(Exception ex) {
                MessageBox.Show("warning : " + ex.Message, "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }




        }
        public void vider()
        {
            nom_champ.Clear();
            mo_passe.Clear();
        }
    }
}
