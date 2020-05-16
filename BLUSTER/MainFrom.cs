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
    public partial class MainFrom : Form
        {
        public string tress;
        public MainFrom(string a)
        {
            this.tress = a;
            InitializeComponent();
            MySqlCommand command;
            MySqlDataReader mdr;
            string ConnectString = "datasource = localhost; username = root; password=; database = bluster";
            MySqlConnection DBconnect = new MySqlConnection(ConnectString);
            DBconnect.Open();
            string query = "SELECT * FROM info WHERE username = '" + tress + "';";
            command = new MySqlCommand(query, DBconnect);
            mdr = command.ExecuteReader();
            if (mdr.Read())
            {
                textBoxHighScore.Text = (mdr["score"].ToString());
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainFrom_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bluster mainform = new Bluster(tress);
            mainform.Show();
        }
    }
}
