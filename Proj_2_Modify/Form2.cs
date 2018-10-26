//Form 2
//set up connection from windows application to sql database
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
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Students.mdf;Integrate" +
           "d Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapt;
        public Form2()
        {
            InitializeComponent();
            DisplayData(); 
        }
        private void DisplayData()
        {
            con.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from Samples", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        //Clear Textbox's data
        private void ClearData()
        {
            textBox1.Text = "";
            textBox3.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
             try
            {
                // check if the textbox is empty.
                if (textBox1.Text != "" && textBox3.Text != "" && textBox2.Text != "" && textBox4.Text != "" && textBox5.Text != "")
                {
cmd = new SqlCommand("insert into Samples(Bank_ID,Bank_Name,Bank_State, Bank_Address,Bank_phoneNumber) values(@Bank_ID,@Bank_Name,@Bank_State,@Bank_Address,@PhoneNumber)", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@Bank_ID", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Bank_name", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Bank_state", textBox2.Text);
                    cmd.Parameters.AddWithValue("@Bank_Address", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Bank_phoneNumber", textBox5.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Inserted Successfully");
                     
                }
                else
                {
                    MessageBox.Show("Please Provide Your Information!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
                DisplayData();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'viewsOnly.Bank' table. You can move, or remove it, as needed.
            this.bankTableAdapter4.Fill(this.viewsOnly.Bank);
            // TODO: This line of code loads data into the 'studentsDataSet6.Bank' table. You can move, or remove it, as needed.
            this.bankTableAdapter3.Fill(this.studentsDataSet6.Bank);
            // TODO: This line of code loads data into the 'studentsDataSet5.Bank' table. You can move, or remove it, as needed.
            this.bankTableAdapter2.Fill(this.studentsDataSet5.Bank);
            // TODO: This line of code loads data into the 'studentsDataSet4.Bank' table. You can move, or remove it, as needed.
            this.bankTableAdapter1.Fill(this.studentsDataSet4.Bank);
            // TODO: This line of code loads data into the 'studentsDataSet3.Samples' table. You can move, or remove it, as needed.
            this.samplesTableAdapter1.Fill(this.studentsDataSet3.Samples);
            // TODO: This line of code loads data into the 'studentsDataSet2.Samples' table. You can move, or remove it, as needed.
            this.samplesTableAdapter.Fill(this.studentsDataSet2.Samples);
            // TODO: This line of code loads data into the 'studentsDataSet1.Bank' table. You can move, or remove it, as needed.
            this.bankTableAdapter.Fill(this.studentsDataSet1.Bank);

        }

        private void button3_Click(object sender, EventArgs e)
        {
             if (textBox3.Text != "" && textBox2.Text != "")
            {
 cmd = new SqlCommand("update Samples set Bank_Name=@Bank_Name,Bank_State=@state, ) values(@BankID,@Bank_Name,@Bank_State, ,Bank_Address=@Bank_Address, Bank_phoneNumber=@PhoneNumber where Bank_ID=@BankID", con);
                con.Open();
                cmd.Parameters.AddWithValue("@Bank_ID", textBox1.Text);
                cmd.Parameters.AddWithValue("@Bank_name", textBox3.Text);
                cmd.Parameters.AddWithValue("@Bank_state", textBox2.Text);
                cmd.Parameters.AddWithValue("@Bank_Address", textBox4.Text);
                cmd.Parameters.AddWithValue("@Bank_phoneNumber", textBox5.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updated Successfully");
                con.Close();
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Update");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
             if (textBox1.Text != null)
            {
                cmd = new SqlCommand("delete Samples where Bank_ID=@BankID", con);
                con.Open();
                cmd.Parameters.AddWithValue("@Bank_ID", textBox1.Text);
                cmd.Parameters.AddWithValue("@Bank_name", textBox3.Text);
                cmd.Parameters.AddWithValue("@Bank_state", textBox2.Text);
                cmd.Parameters.AddWithValue("@Bank_Address", textBox4.Text);
                cmd.Parameters.AddWithValue("@Bank_phoneNumber", textBox5.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully!");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Input the ID to Delete");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        }
        }
        
    

