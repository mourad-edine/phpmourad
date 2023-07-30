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
    
    public partial class Form1 : Form
    {
        MySqlConnection cn;
        MySqlCommand cm;
        MySqlDataReader rd;
        Class1 database = new Class1();
        public void addcontroller(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel3.Controls.Clear();
            panel3.Controls.Add(userControl);
            userControl.BringToFront();

        }
        public Form1()
        {
            InitializeComponent();
            cn = new MySqlConnection(database.dbconnect());
        }



        private void button1_Click(object sender, EventArgs e)
        {
            UserControl1 user1 = new UserControl1();
            addcontroller(user1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserControl2 user2 = new UserControl2();
            addcontroller(user2);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            UserControl3 user3 = new UserControl3();
            addcontroller(user3);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
