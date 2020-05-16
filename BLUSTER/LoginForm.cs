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
    public partial class LoginForm : Form
    {
        public string tress;
        public LoginForm()
        {
            InitializeComponent();
        }

        private string getTress()
        {
            MySqlCommand command;
            MySqlDataReader mdr;
            string ConnectString = "datasource = localhost; username = root; password=; database = bluster";
            MySqlConnection DBconnect = new MySqlConnection(ConnectString);
            DBconnect.Open();
            string checkquery = "Select * from info WHERE username= '" + textBoxUsername.Text + "' AND password = '" + textBoxPassword.Text + "';";
            command = new MySqlCommand(checkquery, DBconnect);
            mdr = command.ExecuteReader();
            if (mdr.Read())
            {
                tress = textBoxUsername.Text;
            }
            else
            {
                MessageBox.Show("Incorrect Login Information! Try again.");

            }

            DBconnect.Close();

            if (string.IsNullOrEmpty(textBoxUsername.Text) || string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Please input Username and Password", "Error");
            }
            return tress;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelClose_MouseEnter(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.Red;

        }

        private void labelClose_MouseLeave(object sender, EventArgs e)
        {
            labelClose.ForeColor = Color.White;
        }

        private void labelClose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void labelGoToSignUp_MouseEnter(object sender, EventArgs e)
        {
            labelGoToSignUp.ForeColor = Color.Red;
        }

        private void labelGoToSignUp_MouseLeave(object sender, EventArgs e)
        {
            labelGoToSignUp.ForeColor = Color.Gold;
        }

        private void labelGoToSignUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationFrom registerform = new RegistrationFrom();
            registerform.Show();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            MySqlCommand command;
            MySqlDataReader mdr;
            string ConnectString = "datasource = localhost; username = root; password=; database = bluster";
            MySqlConnection DBconnect = new MySqlConnection(ConnectString);
            DBconnect.Open();
            string checkquery = "Select * from info WHERE username= '"+ textBoxUsername.Text +"' AND password = '"+ textBoxPassword.Text +"';";
            command = new MySqlCommand(checkquery, DBconnect);
            mdr = command.ExecuteReader();
            if(mdr.Read())
            {
                MessageBox.Show("Login Successfull!!!");
                this.Hide();
                this.getTress();
                MainFrom mainform = new MainFrom(tress);
                mainform.Show();
            }
            else
            {
                MessageBox.Show("Incorrect Login Information! Try again.");

            }

            DBconnect.Close();

            if (string.IsNullOrEmpty(textBoxUsername.Text) || string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Please input Username and Password", "Error");
            }
            
        }
    }
}
