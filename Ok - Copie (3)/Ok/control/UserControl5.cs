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
        private double _prix;
        private double _reference;


        /*private string _nom_produit;

        [Category("Custom Props")]

        public string Nom_produit
        {
            get { return _nom_produit; }
            set { _nom_produit = value;lbl_nom.Text = value; }
        }*/

        public double Reference { get => _reference; set { _reference = value; label1.Text = _reference.ToString(); } }
        public string Titre { get => lbl_nom.Text; set => lbl_nom.Text= value; }
        public double Prix { get => _prix; set { _prix = value; lbl_prix.Text = _prix.ToString(); } }

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
            
            Onselect?.Invoke(this, e);
        }

        private void label1_Click(object sender, EventArgs e)
        {
           Onselect?.Invoke(this, e);
        }

        private void lbl_prix_Click(object sender, EventArgs e)
        {
            Onselect?.Invoke(this, e);
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            Onselect?.Invoke(this, e);
        }
    }
}
