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
        private void GetDepId()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select DepNum from Department", con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("DepNum", typeof(int));
            dt.Load(Rdr);
            DepIdCb.ValueMember = "DepNum";
            DepIdCb.DataSource = dt;
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
            StdTb.Text = "";.
            StdGenCb.Selected.Index = - 1;
            PhoneTb.Text = "";
            StdAddTb.Text = "";
            DepIdCb.SelectedIndex = -1;

        }



        private void Button2_Click(object sender, EventArgs e)
        {

        }

        private void Label12_Click(object sender, EventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {

        }
    }
}
