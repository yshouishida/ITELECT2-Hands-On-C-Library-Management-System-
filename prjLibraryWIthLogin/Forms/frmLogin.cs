using System;
using MySqlConnector;
using prjLibraryWIthLogin.Database;
using System.Windows.Forms;

namespace prjLibraryWIthLogin.Forms
{
    public partial class frmLogin : Form
    {
        public int UserId { get; set; }

        public frmLogin()
        {
            InitializeComponent();
        }

        private void checkBoxShowPwd_CheckedChanged(object sender, EventArgs e) => 
            txtPassword.UseSystemPasswordChar = checkBoxShowPwd.Checked ? false : true;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Email and password are required.");
                return;
            }

            try
            {
                if (!DbConnection.GetConnection()) return;

                using (MySqlCommand cmd = DbConnection.Connection.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT 
                            id,
                            email,
                            password
                        FROM tblUsers
                        WHERE email = @email AND password = @password
                    ";
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            UserId = Convert.ToInt32(reader["id"]);
                        }
                        else
                        {
                            MessageBox.Show("Invalid email or password.");
                            return;
                        }
                    }

                    this.Hide();

                    using (frmModule main = new frmModule(UserId))
                    {
                        main.ShowDialog();
                    }

                    txtEmail.Clear();
                    txtPassword.Clear();                    

                    this.Show();
                    txtEmail.Focus();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DbConnection.ConnClose();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
