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
    public partial class Students : Form
    {
        public Students()
        {
            InitializeComponent();
            ShowStudents();
            GetDepId();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Goral\Source\Repos\vishakhajp\University_Management_System\AppData\RK.mdf;Integrated Security=True");
        int Key = 0;
        private void GetDepId()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select DepId from Department", con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("DepId", typeof(int));
            dt.Load(Rdr);
            DepIdCb.ValueMember = "DepId";
            DepIdCb.DataSource = dt;
            con.Close();
        }
        private void GetDepName()
        {
            con.Open();
            string query = "select * from Department where DepId=" + DepIdCb.SelectedValue.ToString();
            SqlCommand cmd = new SqlCommand(query, con);

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                DepNameTb.Text = dr["DepName"].ToString();
            }

            con.Close();

        }
        private void ShowStudents()
        {
            con.Open();
            string query = "select * from Student";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            StdDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void Reset()
        {
            DepNameTb.Text = "";
            StdTb.Text = "";
            StdGenCb.SelectedIndex = -1;
            PhoneTb.Text = "";
            StdAddTb.Text = "";
            DepIdCb.SelectedIndex = -1;

        }



       

        private void Label12_Click(object sender, EventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (StdTb.Text == "" || StdAddTb.Text == "" || DepNameTb.Text == "" || DepIdCb.SelectedIndex == -1 || PhoneTb.Text == "" || Sem.SelectedIndex == -1 || StdGenCb.SelectedIndex == -1)
            {
                MessageBox.Show("Information Missing");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "Insert into Student (StName,StDOB,StGen,StAddress,StDepId,StDepName,StPhone,stSem) values(@SN,@SD,@SG,@SA,@SDI,@SDN,@SP,@SS)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@SN", StdTb.Text);
                    cmd.Parameters.AddWithValue("@SD", DOB.Value.Date);
                    cmd.Parameters.AddWithValue("@SG", StdGenCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@SA", StdAddTb.Text);
                    cmd.Parameters.AddWithValue("@SDI", DepIdCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@SDN", DepNameTb.Text);
                    cmd.Parameters.AddWithValue("@SP", PhoneTb.Text);
                    cmd.Parameters.AddWithValue("@SS", Sem.Text);



                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Information Added");
                    con.Close();
                    ShowStudents();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DepIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetDepName();
        }

        private void Students_Load(object sender, EventArgs e)
        {

        }


        private void StdDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            StdTb.Text = StdDGV.Rows[e.RowIndex].Cells[1].Value.ToString();
            DOB.Text = StdDGV.Rows[e.RowIndex].Cells[2].Value.ToString();
            StdGenCb.SelectedItem = StdDGV.Rows[e.RowIndex].Cells[3].Value.ToString();
            StdAddTb.Text = StdDGV.Rows[e.RowIndex].Cells[4].Value.ToString();
            DepIdCb.SelectedValue = StdDGV.Rows[e.RowIndex].Cells[5].Value.ToString();
            DepNameTb.Text = StdDGV.Rows[e.RowIndex].Cells[6].Value.ToString();
            PhoneTb.Text = StdDGV.Rows[e.RowIndex].Cells[7].Value.ToString();
            Sem.SelectedItem = StdDGV.Rows[e.RowIndex].Cells[8].Value.ToString();

            if (StdTb.Text == "")
            {
                Key = 0;
                /*DepName.Text = "";
                DepFees.Text = "";
                Intake.Text = "";*/
            }
            else
            {
                Key = Convert.ToInt32(StdDGV.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (StdTb.Text == "" || StdAddTb.Text == "" || DepNameTb.Text == "" || DepIdCb.SelectedIndex == -1 || PhoneTb.Text == "" || Sem.SelectedIndex == -1 || StdGenCb.SelectedIndex == -1)
            {
                MessageBox.Show("Information Missing");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = " Update Student set StName=@SN, StDOB=@SD, StGen=@SG ,StAddress=@SA,StDepId=@SDI,StDepName=@SDN,StPhone=@SP,StSem=@SS where StNum=@SK";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@SN", StdTb.Text);
                    cmd.Parameters.AddWithValue("@SD", DOB.Value.Date);
                    cmd.Parameters.AddWithValue("@SG", StdGenCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@SA", StdAddTb.Text);
                    cmd.Parameters.AddWithValue("@SDI", DepIdCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@SDN", DepNameTb.Text);
                    cmd.Parameters.AddWithValue("@SP", PhoneTb.Text);
                    cmd.Parameters.AddWithValue("@SS", Sem.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@SK", Key);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student Updated");
                    con.Close();
                    ShowStudents();
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
            if (Key == 0)
            {
                MessageBox.Show("Select The Student");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = " Delete from Student where StNum=@Key";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Key", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student Deleted");
                    con.Close();
                    ShowStudents();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            Home obj = new Home();
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

        private void Label8_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }
    }
}



