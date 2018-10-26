//Search window 
//contains sql connection from search button

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
    public partial class btn : Form
    {
        public btn()
        {
            InitializeComponent();
             
        }
        private void ClearData()
        {
            textBox1.Text = "";
            textBox2.Text = "";

        }
     
    
        private void search_btn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Students.mdf;Integrate" +
          "d Security=True");

            DataTable dt = new DataTable();
            SqlDataAdapter SDA = new SqlDataAdapter("SELECT * FROM Patients Where pid = " + int.Parse(textBox1.Text), con);
            SDA.Fill(dt);
            dataGridView1.DataSource = dt;
            ClearData();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn_search2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Students.mdf;Integrate" +
         "d Security=True");

            DataTable dtm = new DataTable();
            SqlDataAdapter SD = new SqlDataAdapter("SELECT * FROM Donors Where did = " + int.Parse(textBox2.Text), con);
            SD.Fill(dtm);
            dataGridView1.DataSource = dtm;
            ClearData();
        }
    }
}
 