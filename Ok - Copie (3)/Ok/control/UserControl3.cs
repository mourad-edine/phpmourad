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
    public partial class UserControl3 : UserControl
    {
        public UserControl3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }


        private void UserControl3_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }


        public void addcontroller(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(userControl);
            userControl.BringToFront();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            UserControl1 frm1 = new UserControl1();
            addcontroller(frm1);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 test = new Form2();
            test.ShowDialog();
        }
    }
}
