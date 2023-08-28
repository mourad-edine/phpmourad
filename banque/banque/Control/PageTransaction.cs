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
    public partial class PageTransaction : UserControl
    {
        public PageTransaction()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Transfert frm = new Transfert();
            changer(frm);
        }
        public void changer(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(userControl);
            userControl.BringToFront();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Retrait frm = new Retrait();
            changer(frm);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Depot frm = new Depot();
            changer(frm);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            historique frm = new historique();
            changer(frm);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Accueil frm = new Accueil();
            changer(frm);
        }
    }
}
