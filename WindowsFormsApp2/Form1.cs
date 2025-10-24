using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtbUsername.Text.Trim();
            string password = txtbPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username dan Password tidak boleh kosong!");
                return;
            }

            using (SqlConnection con = new SqlConnection(
                @"Data Source=MYPCPRO;Initial Catalog=loremipsum; Integrated Security=True; TrustServerCertificate=True"))
            {
                con.Open();
                string query = "SELECT * FROM Login WHERE Username = @nama AND Password = @password";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@nama", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Home f2 = new Home();
                        f2.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Username atau Password salah!");
                        txtbUsername.Clear();
                        txtbPassword.Focus();
                    }
                }
            }
        }
    }
}
