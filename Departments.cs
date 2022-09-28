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
    public partial class Departments : Form
    {
        public Departments()
        {
            InitializeComponent();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {
            string con = @"Data Source=DESKTOP-4T7S6O5\SQLEXPRESS;Initial Catalog=E:\VISHAKHAJP\UNIVERSITY_MANAGEMENT_SYSTEM\APPDATA\RK.MDF;Integrated Security=True";
            SqlConnection sql = new SqlConnection(con);

            if (DepName.Text == "" || Intake.Text == "" || DepFees.Text == "") 
            {
                MessageBox.Show("Information Missing");
            }
            else
            {
                try
                {
                    sql.Open();
                    string query = "Insert into Departments (Depname,DepIntake,DepFees) values(@DN,@DI,@DF)";

                    SqlCommand cmd = new SqlCommand(query, sql);
                    cmd.Parameters.AddWithValue("@DN", DepName.Text);
                    cmd.Parameters.AddWithValue("@DI", Intake.Text);
                    cmd.Parameters.AddWithValue("@DF", DepFees.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Information Added");
                    sql.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
