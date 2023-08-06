using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Ok
{
    public partial class UserControl1 : UserControl
    {
        MySqlConnection cn;
        Class1 database = new Class1();
        public UserControl1()
        {
            InitializeComponent();
            cn = new MySqlConnection(database.dbconnect());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            rechercher("");
            /*for(int i  = 0; i < 30; i++)
            {
                Grid.Rows.Add(
                    new object[]
                    {
                        Faker.NumberFaker.Number(),
                        Faker.NameFaker.FirstName(),
                        Faker.PhoneFaker.InternationalPhone(),
                        Faker.CompanyFaker.BS(),
                        Faker.CompanyFaker.Name(),
                        Faker.DateTimeFaker.BirthDay(),
                    }
                    ) ;
            }*/
            
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        public void rechercher(string valeur)
        {
            string requette = "SELECT * FROM para WHERE CONCAT(nom_medoc,prix_unit) LIKE '%"+valeur+"%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(requette, cn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            Grid.DataSource = table;
        }

        public void addcontroller(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(userControl);
            userControl.BringToFront();

        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {
            rechercher(textBox1.Text);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserControl3 frm = new UserControl3();
            addcontroller(frm);
        }

        private void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
