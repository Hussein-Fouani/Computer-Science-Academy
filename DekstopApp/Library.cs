using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DekstopApp
{
    public partial class Library : Form
    {
        SqlConnection sqlconnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\admin lenovo\Documents\LibraryProject.mdf;Integrated Security = True; Connect Timeout = 30");
        public Library()
        {
            InitializeComponent();
        }

        private void Library_Load(object sender, EventArgs e)
        {
            searchBook();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            comboBox1.SelectedItem = -1;
            searchBook();
            ;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0 || textBox2.Text.Length != 0 || textBox3.Text.Length != 0 || textBox4.Text.Length != 0 || textBox5.Text.Length != 0 || textBox6.Text.Length != 0 || textBox7.Text.Length != 0)
            {


                try
                {
                    string isbn = textBox1.Text;
                    string bkname = textBox2.Text;
                    string subject = textBox3.Text;
                    string author = textBox4.Text;
                    string publisher = textBox5.Text;
                    string quantity = textBox6.Text;
                    string pricee = textBox7.Text;
                    string branch = comboBox1.SelectedItem.ToString();

                    sqlconnection.Open();
                    string query = "Insert into UserInfo(Branch,Book_Name,Subject,Author,Price,quantity publisher,Branch) values('" + isbn + "','" + bkname + "','" + subject + "','" + author + "','" + pricee + "','" + quantity + "','" + publisher + "','" + Branch + "')";
                    SqlCommand command = new SqlCommand(query, sqlconnection);
                    int i = command.ExecuteNonQuery();
                    if (i > 1)
                    {
                        MessageBox.Show(i + "Number of User Inserte Books " + bkname);
                    }
                    else
                    {
                        MessageBox.Show("Insertion Failed" + bkname);
                    }
                    sqlconnection.Close();
                    searchBook();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    comboBox1.SelectedItem = -1;
                }
                catch (Exception et)
                {
                    MessageBox.Show("Inserting Book hadn't been completed {0}", et.StackTrace);
                }
            }
            else
            {
                MessageBox.Show("Empty Credientals are Detected");
            }

        }
        public void searchBook()
        {
            sqlconnection.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("select * from BookInfo", sqlconnection);

            DataTable dataTable = new DataTable();
            sqlData.Fill(dataTable);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dataTable.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item.ToString();
                dataGridView1.Rows[n].Cells[1].Value = item.ToString();
                dataGridView1.Rows[n].Cells[2].Value = item.ToString();
                dataGridView1.Rows[n].Cells[3].Value = item.ToString();
                dataGridView1.Rows[n].Cells[4].Value = item.ToString();
                dataGridView1.Rows[n].Cells[5].Value = item.ToString();
                dataGridView1.Rows[n].Cells[6].Value = item.ToString();
                dataGridView1.Rows[n].Cells[7].Value = item.ToString();
                sqlconnection.Close();
            }

        }

        private void datagridview1_Mouse_click(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            comboBox1.SelectedItem = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0 || textBox2.Text.Length != 0 || textBox3.Text.Length != 0 || textBox4.Text.Length != 0 || textBox5.Text.Length != 0 || textBox6.Text.Length != 0 || textBox7.Text.Length != 0)
            {


                try
                {
                    int isbn = Int32.Parse(textBox1.Text);
                    string bkname = textBox2.Text;
                    string subject = textBox3.Text;
                    string author = textBox4.Text;
                    string publisher = textBox5.Text;
                    string quantity = textBox6.Text;
                    string pricee = textBox7.Text;
                    string branch = comboBox1.SelectedItem.ToString();

                    sqlconnection.Open();
                    string query = "update BookInfo set ISBN='" + isbn + "', Book_Name='" + bkname + "', Subject='" + subject + "', Author='" + author + "', Price='" + pricee + "', quantity='" + quantity + "', publisher='" + publisher + "', Branch= +branch";
                    SqlCommand command = new SqlCommand(query, sqlconnection);
                    int i = command.ExecuteNonQuery();
                    if (i > 1)
                    {
                        MessageBox.Show(i + "Number of User Updated " + bkname);
                    }
                    else
                    {
                        MessageBox.Show("Updating Failed" + bkname);
                    }
                    sqlconnection.Close();
                    searchBook();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    comboBox1.SelectedItem = -1;
                }
                catch (Exception et)
                {
                    MessageBox.Show("Inserting Book hadn't been completed {0}", et.StackTrace);
                }
            }
            else
            {
                MessageBox.Show("Empty Credientals are Detected");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length != 0)
            {


                try
                {
                    string isbn = textBox1.Text;


                    sqlconnection.Open();
                    string query = "delete from BookInfo where ISBN= '" + isbn;
                    SqlCommand command = new SqlCommand(query, sqlconnection);
                    int i = command.ExecuteNonQuery();
                    if (i > 1)
                    {
                        MessageBox.Show(i + "Number of User Deleted Books " + isbn);
                    }
                    else
                    {
                        MessageBox.Show("Insertion Failed" + isbn);
                    }
                    sqlconnection.Close();
                    searchBook();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    comboBox1.SelectedItem = -1;
                }
                catch (Exception et)
                {
                    MessageBox.Show("Deleting Book hadn't been completed {0}", et.StackTrace);
                }
            }
            else
            {
                MessageBox.Show("Empty Credientals are Detected");
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            try {
                sqlconnection.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("select * from BookInfo where (Book_Name like '%" + textBox8.Text + "%' or Subject like '%" + textBox8.Text + "%' or like Auhtor '%" + textBox8.Text+"')",sqlconnection);
                DataTable table = new DataTable();
                sqlData.Fill(table);
                dataGridView1.Rows.Clear();
                foreach (DataRow item in table.Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item.ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item.ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item.ToString();
                    dataGridView1.Rows[n].Cells[3].Value = item.ToString();
                    dataGridView1.Rows[n].Cells[4].Value = item.ToString();
                    dataGridView1.Rows[n].Cells[5].Value = item.ToString();
                    dataGridView1.Rows[n].Cells[6].Value = item.ToString();
                    dataGridView1.Rows[n].Cells[7].Value = item.ToString();
                    
                }
                sqlconnection.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Element Not Found ");
            }
            } 
    }
}
