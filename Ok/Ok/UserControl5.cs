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
    public partial class UserControl5 : UserControl
    {
        private string _titre;
        /*private string _nom_produit;

        [Category("Custom Props")]

        public string Nom_produit
        {
            get { return _nom_produit; }
            set { _nom_produit = value;lbl_nom.Text = value; }
        }*/


        public string Titre { get => lbl_nom.Text; set => lbl_nom.Text= value; }



        public event EventHandler Onselect = null;
        public UserControl5()
        {
            InitializeComponent();
        }

        private void UserControl5_Load(object sender, EventArgs e)
        {

        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {
            /*Form3 frm = new Form3();
            frm.ShowDialog();*/
            Onselect?.Invoke(this, e);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Onselect?.Invoke(this, e);
        }
    }
}
