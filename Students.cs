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
            ShowStudent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Goral\Source\Repos\vishakhajp\University_Management_System\AppData\RK.mdf;Integrated Security=True");
        private void ShowStudent()
        {
            con.Open();
            string query = "select * from Student";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            //Student.DataSource = ds.Tables[0];
            con.Close();
        }

        private void Reset()
        {
            //DepName.Text = "",;;;;
            //stdTb.Text = "";
            //stdGencb.SelectedIndex = - 1;
            //PhoneTb.Text = "";
            //StdAddTb.Text = "";
            //depIdCb.selectedIndex = -1;

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
