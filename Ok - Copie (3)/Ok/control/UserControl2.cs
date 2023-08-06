using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ok
{
    public partial class UserControl2 : UserControl
    {
        MySqlConnection cn;
        MySqlCommand cm;
        MySqlDataReader rd;
        Class1 database = new Class1();
        public UserControl2()
        {
            InitializeComponent();
            cn = new MySqlConnection(database.dbconnect());
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        public void generer()
        {
            /* pnl.Controls.Clear();
             UserControl5[] liste = new UserControl5[5];
             string[]nom_produit = new string[5] {"paracetamol"," amoxyciline","vitamine C","CAC 1000 sans dose","Dolyprane"};

             for(int i = 0; i < liste.Length; i++)
             {
                 liste[i] = new UserControl5();
                 liste[i].Nom_produit = nom_produit[i];
                 pnl.Controls.Add(liste[i]);

                 liste[i].Click += new System.EventHandler(this.user_clic);

             }
         }

         void user_clic(object sender, EventArgs e)
         {
             UserControl5 obj = (UserControl5)sender;
             lbl_nom.Text = obj.Nom_produit;
             showpanel();
         }

         public void showpanel()
         {
            panel1.Visible = true;*/
        }

        private void UserControl2_Load(object sender, EventArgs e)
        {

            cn.Open();
            cm = new MySqlCommand("SELECT * FROM para",cn);
            rd = cm.ExecuteReader();
            while (rd.Read())
            {
                generation(rd["nom_medoc"].ToString(), int.Parse(rd["prix_unit"].ToString())); 
            }
            rd.Close();
            cn.Close();




            // generer();
        }

 
        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
            foreach(var item in pnl.Controls)
            {
                var wdg = (UserControl5)item;
                wdg.Visible = wdg.lbl_nom.Text.ToLower().ToLower().Contains(rechercher.Text.ToLower());

            }
        }



        public void generation( string titre,double prix)
        {
            var w = new UserControl5()
            {
                Titre = titre
                , Prix = prix
            };
            pnl.Controls.Add(w);
            try
            {
                int i = 0;
                w.Onselect += (ss, ee) =>
                {
                    var wdg = (UserControl5)ss;
                    foreach (DataGridViewRow item in grid.Rows)
                    {
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
                        if (item.Cells[0].Value == wdg.lbl_nom)
                        {
                            item.Cells[1].Value = i + 1;
                            item.Cells[2].Value = wdg.Prix;
                            total.Text = item.Cells[2].Value.ToString();
                            return;
                        }
                    }
                    grid.Rows.Add(new object[] { wdg.Titre, 1, wdg.Prix});
                };
            }
            catch(Exception ex)
            {
                MessageBox.Show("warning : " + ex.Message, "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        void calculate()
        {
            double tot = 0;
            foreach (DataGridViewRow item in grid.Rows)
            {
                tot += double.Parse(item.Cells[2].Value.ToString().Replace("$", ""));
            }
            total.Text = tot.ToString();

        }


    }
}
