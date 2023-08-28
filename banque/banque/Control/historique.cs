using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
namespace banque
{
    public partial class historique : UserControl
    {
        MySqlConnection cn;

        Class1 database = new Class1();
        public historique()
        {
            InitializeComponent();
            cn = new MySqlConnection(database.dbconnect());
        }

        public void recherche(string valeur)
        {
            string requette = "SELECT * FROM historique WHERE CONCAT(transaction,created_at) LIKE '%" + valeur + "%'";
            MySqlDataAdapter adapter = new MySqlDataAdapter(requette, cn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            grid.DataSource = table;
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            recherche("");
        }

        private void bunifuTextBox1_TextChange(object sender, EventArgs e)
        {
            recherche(bunifuTextBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PageTransaction frm = new PageTransaction();
            changer(frm);
        }
        public void changer(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panel1.Controls.Clear();
            panel1.Controls.Add(userControl);
            userControl.BringToFront();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (grid.Rows.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF (*.pdf)|*.pdf";
                save.FileName = "Result.pdf";
                bool ErrorMessage = false;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(save.FileName))
                    {
                        try
                        {
                            File.Delete(save.FileName);
                        }
                        catch (Exception ex)
                        {
                            ErrorMessage = true;
                            MessageBox.Show("Unable to wride data in disk" + ex.Message);
                        }
                    }
                    if (!ErrorMessage)
                    {
                        try
                        {
                            PdfPTable pTable = new PdfPTable(grid.Columns.Count);
                            pTable.DefaultCell.Padding = 2;
                            pTable.WidthPercentage = 100;
                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;
                            foreach (DataGridViewColumn col in grid.Columns)
                            {
                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));
                                pTable.AddCell(pCell);
                            }
                            foreach (DataGridViewRow viewRow in grid.Rows)
                            {
                                foreach (DataGridViewCell dcell in viewRow.Cells)
                                {
                                    pTable.AddCell(dcell.Value.ToString());
                                }
                            }
                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))
                            {
                                Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);
                                PdfWriter.GetInstance(document, fileStream);
                                document.Open();
                                document.Add(pTable);
                                document.Close();
                                fileStream.Close();
                            }
                            MessageBox.Show("Exporté avec success", "info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("erreur lors de l'exportation" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("pas d'enregistrement", "Info");
            }
            /*if(grid.Rows.Count > 0)
            {
                SaveFileDialog  save = new SaveFileDialog();
                save.Filter = "PDF (*.pdf)|*.pdf";
                save.FileName = "result";
                bool ErrMess = false;
                if(save.ShowDialog() == DialogResult.OK)
                {
                    if(File.Exists(save.FileName))
                    {
                        try
                        {
                            File.Delete(save.FileName);

                        }catch (Exception ex)
                        {
                           ErrMess = true;
                            MessageBox.Show("incapable d'écrire sur le disque",ex.Message);
                        }
                    }
                    if (!ErrMess)
                    {
                        try
                        {
                            PdfPTable ptable = new PdfPTable(grid.Columns.Count);
                            ptable.DefaultCell.Padding = 2;
                            ptable.WidthPercentage = 100;
                            ptable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach(DataGridViewColumn col in grid.Columns)
                            {
                                PdfPCell pdell = new PdfPCell(new Phrase(col.HeaderText));
                                ptable.AddCell(pdell);

                            }
                            foreach (DataGridViewRow vierow in grid.Rows)
                            {
                                foreach(DataGridViewCell dcell in vierow.Cells)
                                {
                                    ptable.AddCell(dcell.Value.ToString());
                                }

                            }
                            using(FileStream fileStream = new FileStream(save.FileName, FileMode.Create))
                            {
                                Document document = new Document(PageSize.A4,8f,16f,16f,8f);
                                document.Open();
                                document.Add(ptable);
                                document.Close();
                                fileStream.Close();


                            }
                            MessageBox.Show("exporté avec success !");

                        }
                        catch(Exception ex) 
                        {
                            MessageBox.Show("erreur lors de l'exportation !"+ex.Message);
                        }
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("pas d'enregistrement!","info");

            }*/
        }
    }
}
