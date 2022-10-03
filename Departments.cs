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
            Dep();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Goral\Source\Repos\vishakhajp\University_Management_System\AppData\RK.mdf;Integrated Security=True");
        int Key = 0;

        private void Dep()
        {
           

            con.Open();
            string query = "select  * from department";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder build = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DepDGV.DataSource = ds.Tables[0];

            con.Close();
        }

        private void Reset()
        {
            DepName.Text = "";
            Intake.Text = "";
            DepFees.Text = "";

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {
            
            if (DepName.Text == "" || Intake.Text == "" || DepFees.Text == "") 
            {
                MessageBox.Show("Information Missing");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "Insert into Department (DepName,DepIntake,DepFees) values(@DN,@DI,@DF)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@DN", DepName.Text);
                    cmd.Parameters.AddWithValue("@DI", Intake.Text);
                    cmd.Parameters.AddWithValue("@DF", DepFees.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Information Added");
                    con.Close();
                    Dep();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DepDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DepName.Text = DepDGV.Rows[e.RowIndex].Cells[1].Value.ToString();
            Intake.Text = DepDGV.Rows[e.RowIndex].Cells[2].Value.ToString();
            DepFees.Text = DepDGV.Rows[e.RowIndex].Cells[3].Value.ToString();
            if(DepName.Text == "")
            {
                Key = 0;
                /*DepName.Text = "";
                DepFees.Text = "";
                Intake.Text = "";*/
            }
            else
            {
                Key = Convert.ToInt32(DepDGV.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (DepName.Text == "" || Intake.Text == "" || DepFees.Text == "")
            {
                MessageBox.Show("Information Missing");
            }
            else
            {
                try
                {
                    con.Open();
                    string query =" Update Department set DepName=@DN, DepIntake=@DI, DepFees=@DF where DepId=@Key";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@DN", DepName.Text);
                    cmd.Parameters.AddWithValue("@DI", Intake.Text);
                    cmd.Parameters.AddWithValue("@DF", DepFees.Text);
                    cmd.Parameters.AddWithValue("@Key", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Department Updated");
                    con.Close();
                    Dep();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (Key==0)
            {
                MessageBox.Show("Select The Department");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = " Delete from Department where DepId=@Key";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Key", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Deparment Deleted");
                    con.Close();
                    Dep();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            Students obj = new Students();
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

        private void Label6_Click(object sender, EventArgs e)
        {
            
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            Home obj = new Home();
            obj.Show();
            this.Hide();
        }

        private void Label8_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }
    }
}
    
    
