using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using prjLibraryWIthLogin.Database;
using MySqlConnector;

namespace prjLibraryWIthLogin.Forms
{
    public partial class frmChangePassword : Form
    {
        private int UserId { get; set; }
        public frmChangePassword(int userId)
        {
            UserId = userId;

            InitializeComponent();
        }

        private void checkBoxPwd_CheckedChanged(object sender, EventArgs e)
        {
            txtCurrentPwd.UseSystemPasswordChar = checkBoxPwd.Checked ? false : true;
            txtNewPwd.UseSystemPasswordChar = checkBoxPwd.Checked ? false : true;
            txtReEnterPwd.UseSystemPasswordChar = checkBoxPwd.Checked ? false : true;
        }

        private void btnChangePwd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!DbConnection.GetConnection()) return;

                using (MySqlCommand cmd = DbConnection.Connection.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT 1 
                        FROM tblUsers 
                        WHERE password = @password
                        ";

                    cmd.Parameters.AddWithValue("@password", txtCurrentPwd.Text);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            MessageBox.Show("Invalid current password.");
                            return;
                        }
                    }
                }

                if (txtNewPwd.Text != txtReEnterPwd.Text)
                {
                    MessageBox.Show("The new password and re-entered password do not match.");
                    return;
                }

                using (MySqlCommand cmd = DbConnection.Connection.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE tblUsers
                        SET 
                            password = @password
                        WHERE id = @id
                    ";
                    cmd.Parameters.AddWithValue("@password", txtReEnterPwd.Text);
                    cmd.Parameters.AddWithValue("@id", UserId);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Password has changed successfully.");
                this.DialogResult = DialogResult.OK;
                this.Close();
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
    }
}
