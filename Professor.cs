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
    public partial class Professor : Form
    {
        public Professor()
        {
            InitializeComponent();
            Pro();
            GetDepId();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Goral\Source\Repos\vishakhajp\University_Management_System\AppData\RK.mdf;Integrated Security=True");
        int Key = 0;
    

        private void Pro()
        {


            con.Open();
            string query = "select  * from Professor";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder build = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ProDGV.DataSource = ds.Tables[0];

            con.Close();
        }
        private void Reset()
        {
            DepName.Text = "";
            ProAdd.Text = "";
            PrGender.SelectedIndex = -1;
            ProExpe.Text = "";
            Salary.Text = "";
            ProQuali.SelectedIndex = -1;
            ProName.Text = "";
        }

        private void GetDepId()
        {
            con.Open();
            string query= "select  DepId from Department";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("DepId", typeof(int));
            dt.Load(rdr);
            DepId.ValueMember = "DepId";
            ProDGV.DataSource = dt;

            con.Close();
        
    }

        private void GetDepName()
        {
            con.Open();
            string query = "select * from Department where DepId= '+DepId.SelectedValue.ToString()'";
            SqlCommand cmd = new SqlCommand(query, con);

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                DepName.Text = dr["DepName"].ToString();
            }

            con.Close();

        }

        private void Label11_Click(object sender, EventArgs e)
        {

        }

        private void Label16_Click(object sender, EventArgs e)
        {

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select The Professor");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = " Delete from Professor where PrId=@PrKey";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@PrKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Professor Deleted");
                    con.Close();
                    Pro();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DepId_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetDepName();
        }

        private void Label68_Click(object sender, EventArgs e)
        {
            Departments obj = new Departments();
            obj.Show();
            this.Hide();
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

       

        private void ProDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ProName.Text = ProDGV.SelectedRows[0].Cells[1].Value.ToString();
            ProDOB.Text =ProDGV.SelectedRows[0].Cells[2].Value.ToString();
            PrGender.SelectedItem =ProDGV.SelectedRows[0].Cells[3].Value.ToString();
            ProAdd.Text = ProDGV.SelectedRows[0].Cells[4].Value.ToString();
            ProQuali.SelectedItem = ProDGV.SelectedRows[0].Cells[5].Value.ToString();
            ProExpe.Text = ProDGV.SelectedRows[0].Cells[6].Value.ToString();
            DepId.SelectedValue = ProDGV.SelectedRows[0].Cells[7].Value.ToString();
            DepName.Text = ProDGV.SelectedRows[0].Cells[8].Value.ToString();
            Salary.Text = ProDGV.SelectedRows[0].Cells[9].Value.ToString();
            if (ProName.Text == "")
            {
                Key = 0;
                /*DepName.Text = "";
                DepFees.Text = "";
                Intake.Text = "";*/
            }
            else
            {
                Key = Convert.ToInt32(ProDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (ProName.Text == "" || ProAdd.Text == "" || DepName.Text == "" || PrGender.SelectedIndex == -1 || ProAdd.Text == "" || ProQuali.SelectedIndex == -1 || DepId.SelectedIndex == -1)
            {
                MessageBox.Show("Information Missing");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "Update Professor set PrName=@PN,PrDOB=@PDOB,PrGen=@PG,PrAdd=@PA,PrQual=@PQ,PrExp=@PE,PrDepId@PD,PrDepName=@PDN,PrSalary=@PS where PrId=@PrKey";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@PN", ProName.Text);
                    cmd.Parameters.AddWithValue("@PDOB", ProDOB.Value.Date);
                    cmd.Parameters.AddWithValue("@PG", PrGender.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PA", ProAdd.Text);
                    cmd.Parameters.AddWithValue("@PQ", ProQuali.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PE", ProExpe.Text);
                    cmd.Parameters.AddWithValue("@PD", DepId.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@PDN", DepName.Text);
                    cmd.Parameters.AddWithValue("@PS", Salary.Text);
                    cmd.Parameters.AddWithValue("@PrKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Professor Updated");
                    con.Close();
                    Pro();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

       

        private void Save_Click_1(object sender, EventArgs e)
        {
            if (ProName.Text == "" || ProAdd.Text == "" || DepName.Text == "" || PrGender.SelectedIndex == -1 || ProAdd.Text == "" || ProQuali.SelectedIndex == -1 || DepId.SelectedIndex == -1)
            {
                MessageBox.Show("Information Missing");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "Insert into Professor (PrName,PrDOB,PrGen,PrAdd,PrQual,PrExp,PrDepId,PrDepName,PrSalary) values(@PN,@PDOB,@PG,@PA,@PQ,@PE,@PD,@PDN,@PS)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@PN", ProName.Text);
                    cmd.Parameters.AddWithValue("@PDOB", ProDOB.Value.Date);
                    cmd.Parameters.AddWithValue("@PG", PrGender.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PA", ProAdd.Text);
                    cmd.Parameters.AddWithValue("@PQ", ProQuali.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PE", ProExpe.Text);
                    cmd.Parameters.AddWithValue("@PD", DepId.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@PDN", DepName.Text);
                    cmd.Parameters.AddWithValue("@PS", Salary.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Professor Added");
                    con.Close();
                    Pro();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
