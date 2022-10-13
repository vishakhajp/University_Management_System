using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace University_Management_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            UserName.Text = "";
            password.Text = "";
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if(UserName.Text == "" || password.Text == "")
            {
                MessageBox.Show("Please Enter your details");
            }else if(UserName.Text == "Admin" && password.Text == "Password")
            {
                Home obj = new Home();
                obj.Show();
                this.Hide();
            }else
            {
                MessageBox.Show("Wrong Details");
                UserName.Text = "";
                password.Text = "";
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
