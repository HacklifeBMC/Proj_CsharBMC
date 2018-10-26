//This is the form one of the windows application
//user enter username and password that match infos stored into database login infos
//if failed, no access is granted

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

namespace Proj_2_Modify
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void txt_Password_TextChanged(object sender, EventArgs e)
        {
            // The password character is an asterisk.  
            txt_Password.PasswordChar = '*';
            // The control will allow no more than 25 characters.  
            txt_Password.MaxLength = 25; 
        }

        private void txt_UserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void btn_Submit_Click(object sender, EventArgs e)
        {
              // check if the username or password are empty
            if (txt_UserName.Text == "" || txt_Password.Text == "")
            {
                //throw out a message if they are empty
                MessageBox.Show("Please provide UserName and Password!");
                return;
            }
            // try: catch the error in your code
            try
            {

                // connection string, it is the path/value used to find the database.
                string connectionString = @"Data Source = (LocalDB)\v11.0;; AttachDbFilename = |DataDirectory|\Students.mdf; Integrated Security = True";


         

                //create sql connection called "con", used to connect to Students database
                SqlConnection con = new SqlConnection(connectionString);
                // the sql command you want to execute i    n DBMS
                SqlCommand cmd = new SqlCommand("Select * from stu_login where stu_username = @username and stu_password = @password", con);

                //Give TextBox: username -> @username; TextBox: password-> @password
                cmd.Parameters.AddWithValue("@username", txt_UserName.Text);
                cmd.Parameters.AddWithValue("@password", txt_Password.Text);

                //open the connection to DB
                con.Open();

                //select records from a database and populate a DataSet with the selected rows.
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                //add rows in data adapter
                adapt.Fill(ds);

                // close the connection after query
                con.Close();

                //get the collection of tables in the DataSet.
                int count = ds.Tables[0].Rows.Count;

                //if count is equal to 1, that means the SQL query get the record., then show frmMain form
                if (count == 1)
                {
                    MessageBox.Show("Login Successful!");
                    this.Hide();
                    frmMain fm = new frmMain();
                    fm.Show();
                }
                else
                {
                    MessageBox.Show("Login Failed: Could Not Find Your Account!");
                }
            }
            // catch trow out error message if there is an error
            catch (Exception ex)
            {
                //show the error message
                MessageBox.Show(ex.Message);
            }
        }
        }
    }

