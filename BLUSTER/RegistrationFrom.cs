using System;
using System.Drawing;
using System.Windows.Forms;
using WMPLib;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLUSTER
{
    public partial class RegistrationFrom : Form
    {
        public RegistrationFrom()
        {
            InitializeComponent();
        }

        private void textBoxFirstname_Enter(object sender, EventArgs e)
        {
            String fname = textBoxFirstname.Text;
            if (fname.ToLower().Trim().Equals("First Name"))
            {
                textBoxFirstname.Text = "";
                textBoxFirstname.ForeColor = Color.White;
            }
        }

        private void textBoxFirstname_Leave(object sender, EventArgs e)
        {
            String fname = textBoxFirstname.Text;
            if (fname.ToLower().Trim().Equals("First Name") || fname.Trim().Equals(""))
            {
                textBoxFirstname.Text = "First Name";
                textBoxFirstname.ForeColor = Color.Gray;
            }

        }

        private void textBoxFirstname_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegistrationFrom_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;

        }

        private void textBoxLastname_Enter(object sender, EventArgs e)


        {     String lname = textBoxLastname.Text;
            if (lname.ToLower().Trim().Equals("Last Name"))
            {
                textBoxLastname.Text = "";
                textBoxLastname.ForeColor = Color.White;
            }


        }

        private void textBoxLastname_Leave(object sender, EventArgs e)
        {
            String lname = textBoxLastname.Text;
            if (lname.ToLower().Trim().Equals("Last name") || lname.Trim().Equals(""))
            {
                textBoxLastname.Text = "Last name";
                textBoxLastname.ForeColor = Color.Gray;
            }

        }

        private void textBoxEmail_Enter(object sender, EventArgs e)
        {
            String email = textBoxEmail.Text;
            if (email.ToLower().Trim().Equals("Email Address"))
            {
                textBoxEmail.Text = "";
                textBoxEmail.ForeColor = Color.White;
            }

        }

        private void textBoxEmail_Leave(object sender, EventArgs e)
        {
            String email = textBoxEmail.Text;
            if (email.ToLower().Trim().Equals("Email Address") || email.Trim().Equals(""))
            {
                textBoxEmail.Text = "Email Address";
                textBoxEmail.ForeColor = Color.Gray;
            }

        }

        private void textBoxUsername_Enter(object sender, EventArgs e)
        {
            String username = textBoxUsername.Text;
            if (username.ToLower().Trim().Equals("User Name"))
            {
                textBoxUsername.Text = "";
                textBoxUsername.ForeColor = Color.White;
            }

        }

        private void textBoxUsername_Leave(object sender, EventArgs e)
        {
            String username = textBoxUsername.Text;
            if (username.ToLower().Trim().Equals("User Name") || username.Trim().Equals(""))
            {
                textBoxUsername.Text = "User Name";
                textBoxUsername.ForeColor = Color.Gray;
            }

        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            String password = textBoxPassword.Text;
            if (password.ToLower().Trim().Equals("Password"))
            {
                textBoxPassword.Text = "";
                textBoxPassword.UseSystemPasswordChar = true;
                textBoxPassword.ForeColor = Color.White;
            }

        }

        private void textBoxPassword_Leave(object sender, EventArgs e)
        {
            String password = textBoxPassword.Text;
            if (password.ToLower().Trim().Equals("Password") || password.Trim().Equals(""))
            {
                textBoxPassword.Text = "Password";
                textBoxPassword.UseSystemPasswordChar = false;
                textBoxPassword.ForeColor = Color.Gray;
            }
        }

        private void textBoxPasswordConfirm_Enter(object sender, EventArgs e)
        {
            String cpassword = textBoxPasswordConfirm.Text;
            if (cpassword.ToLower().Trim().Equals("Confirm Password"))
            {
                textBoxPasswordConfirm.Text = "";
                textBoxPasswordConfirm.UseSystemPasswordChar = true;
                textBoxPasswordConfirm.ForeColor = Color.White;
            }

        }

        private void textBoxPasswordConfirm_Leave(object sender, EventArgs e)
        {
            String cpassword = textBoxPasswordConfirm.Text;
            if (cpassword.ToLower().Trim().Equals("Confirm Password") ||
                cpassword.ToLower().Trim().Equals("password") ||
                cpassword.Trim().Equals(""))
            {
                textBoxPasswordConfirm.Text = "Confirm Password";
                textBoxPasswordConfirm.UseSystemPasswordChar = false;
                textBoxPasswordConfirm.ForeColor = Color.Gray;
            }

        }

        private void labelGoToLogIn_MouseEnter(object sender, EventArgs e)
        {
            labelGoToLogIn.ForeColor = Color.Red;
        }

        private void labelGoToLogIn_MouseLeave(object sender, EventArgs e)
        {
            labelGoToLogIn.ForeColor = Color.Gold;
        }

        private void labelGoToLogIn_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginform = new LoginForm();
            loginform.Show();
        }

        private void labelClose_Mouse_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void labelClose_Mouse_MouseEnter(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.Red;
        }

        private void labelClose_Mouse_MouseLeave(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.White;
        }
       
        private void buttonCreataccount_Click(object sender, EventArgs e)
        {
            MySqlCommand command;
            MySqlDataReader mdr;
            string ConnectString = "datasource = localhost; username = root; password=; database = bluster";
            MySqlConnection DBconnect = new MySqlConnection(ConnectString);
            DBconnect.Open();
            string checkquery = "INSERT INTO `info` (`fname`, `lname`, `email`, `username`, `password`, `score`, `tress`) VALUES ('" + textBoxFirstname.Text + "', '" + textBoxLastname.Text + "', '" + textBoxEmail.Text + "', '" + textBoxUsername.Text + "', '" + textBoxPassword.Text + "', '0', NULL);";
            command = new MySqlCommand(checkquery, DBconnect);
            mdr = command.ExecuteReader();
            if (mdr.Read())
            {
                MessageBox.Show("Incorrect Input Information! Try again.");
            }
            else
            {
                MessageBox.Show("Sign Up Successfull!!!");

            }

            DBconnect.Close();

            if (string.IsNullOrEmpty(textBoxUsername.Text) || string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Please another Username and Password", "Error");
            }
        }





    }
}
