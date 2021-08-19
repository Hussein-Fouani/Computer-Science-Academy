using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace DekstopApp
{
    
    public partial class Form1 : Form
    {
         
        SqlConnection sqlconnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\admin lenovo\Documents\LibraryProject.mdf;Integrated Security = True; Connect Timeout = 30");
        
        public Form1()
        {
            InitializeComponent();
        }

      

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            this.textBox2.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Length == 0 || this.textBox2.Text.Length == 0)
            {
                MessageBox.Show("Empty  Credential Detected!! ");
            }
            string usr_name = textBox1.Text.ToString();
            string usr_passwd = textBox2.Text.ToString();
            string qry = $"select *  from RegistrationInfo where UserName='"+usr_name+"'and Password='"+usr_passwd+"'";
            sqlconnection.Open();

            SqlDataAdapter sqlData = new SqlDataAdapter(qry ,sqlconnection);
            DataTable data = new DataTable();
            sqlData.Fill(data);
            if (data.Rows.Count == 1)
            {
                MessageBox.Show("Login sucseed");
                button2_Click(sender,e);
                this.Hide();
                MDIParent1 mDI = new MDIParent1();
                mDI.Show();
            }
            else
            {
                MessageBox.Show("Invalid Credentials");
            }
            sqlconnection.Close();
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration_Form form = new Registration_Form();
            form.Show();
        }
    }
}
