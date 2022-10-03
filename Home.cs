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

namespace University_Management_System
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            CountCollege();
            CountDepatment();
            CountProfessor();
            CountStudents();
            CountFinance();
            SumSalary();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Goral\Source\Repos\vishakhajp\University_Management_System\AppData\RK.mdf;Integrated Security=True");

        private void SumSalary()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Sum(PrSalary) from Salary", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Salary.Text = "Rs" + dt.Rows[0][0].ToString();
            con.Close();
        }
        private void CountFinance()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Sum(Famount) from Fees", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Facult.Text = "Rs" +dt.Rows[0][0].ToString();
            con.Close();
        }
        private void CountStudents()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from Student", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Std.Text = dt.Rows[0][0].ToString();
            con.Close();
        }

        private void CountProfessor()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from Professor", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Facult.Text = dt.Rows[0][0].ToString();
            con.Close();
        }
        private void CountDepatment()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from Department", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Dep.Text = dt.Rows[0][0].ToString();
            con.Close();
        }
        private void CountCollege()
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from College", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Colle.Text = dt.Rows[0][0].ToString();
            con.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {
            Students obj = new Students();
            obj.Show();
            this.Hide();
        }

        private void Label68_Click(object sender, EventArgs e)
        {
            Departments obj = new Departments();
            obj.Show();
            this.Hide();
        }

        private void Label4_Click(object sender, EventArgs e)
        {

            Professor obj = new Professor();
            obj.Show();
            this.Hide();
        }

        private void Label5_Click(object sender, EventArgs e)
        {
            Cources obj = new Cources();
            obj.Show();
            this.Hide();
        }

        private void Label7_Click(object sender, EventArgs e)
        {
            Fees obj = new Fees();
            obj.Show();
            this.Hide();
        }

        private void Fees_Click(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }
    }
}
