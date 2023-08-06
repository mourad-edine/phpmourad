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
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        public void generer()
        {
            pnl.Controls.Clear();
            UserControl5[] liste = new UserControl5[5];
            string[]nom_produit = new string[5] {"paracetamol"," amoxyciline","vitamine C","CAC 1000 sans dose","Dolyprane"};

            for(int i = 0; i < liste.Length; i++)
            {
                liste[i] = new UserControl5();
                liste[i].Nom_produit = nom_produit[i];
                pnl.Controls.Add(liste[i]);

            }

            
            pnl.Controls.Add(w);
            w.OnSelect += (ss,ee) =>
            {
                var wdg = (UserControl5)ss;
                foreach(DataGridView item in grid.Rows)
                {
                    if (item.Cells[0].Value.ToString() == wdg.lbl_nom.Text){
                        item.Cells[1].Value = wdg.lbl_nom.Text;
                        item.Cells[2].Value = wdg.lbl_nom.Text;
                        return;
                    }
                }
                grid.Rows.Add(new object[] { wdg.lbl_nom,1,wdg.lbl_nom });
            }
        }


        private void UserControl2_Load(object sender, EventArgs e)
        {
            generer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible=false;
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
            foreach(var item in pnl.Controls)
            {
                var wdg = (UserControl5)item;
                wdg.Visible = wdg.lbl_nom.Text.ToLower().ToLower().Contains(rechercher.Text.ToLower());

            }
        }
    }
}
