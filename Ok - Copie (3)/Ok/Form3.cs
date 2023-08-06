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
    public partial class Form3 : Form
    {
        MySqlConnection cn;
        MySqlCommand cm;
        Class1 database = new Class1();
        public Form3()
        {
            InitializeComponent();
            cn = new MySqlConnection(database.dbconnect());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int id_salle, id_user;
                id_salle = int.Parse(label3.Text);
                id_user = int.Parse(label8.Text);
                cn.Open();
                cm = new MySqlCommand("INSERT INTO reserve_salle(id_utilisateur,id_salle) VALUES('" + id_user + "','" + id_salle + "')",cn);
                cm.ExecuteNonQuery();
                cn.Close();
                cn.Open();
                cm = new MySqlCommand("UPDATE salle SET etat = 1 WHERE id = '"+id_salle+"'",cn);
                cm.ExecuteNonQuery();
                cn.Close();
                this.Dispose();
                MessageBox.Show("Ajouté avec succes", "register info", MessageBoxButtons.OK);


            }
            catch (Exception ex)
            {
                cn.Close();
                MessageBox.Show("warning : " + ex.Message, "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
