using System;
using System.Data;
using MySqlConnector;
using prjLibraryWIthLogin.Database;
using prjLibraryWIthLogin.Forms;
using System.Windows.Forms;

namespace prjLibraryWIthLogin
{
    public partial class frmMain : Form
    {
        public int UserId { get; set; }

        public frmMain(int userId)
        {
            UserId = userId;
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadUser();
            LoadBooks();

        }

        private void LoadBooks()
        {
            string sql = @"
                SELECT
                    id,
                    user_id,
                    title,
                    author,
                    ISBN,
                    year,
                    category,
                    description,
                    created_at
                FROM tblBooks
            ";
            DbHelpers.DgvDataLoader(sql, dgvBooks);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBooks();
        }

        private void LoadUser()
        {
            try
            {
                if (!DbConnection.GetConnection()) return;

                string sql = @"
                    SELECT 
                        email
                    FROM tblUsers
                    WHERE id = @id
                ";

                using (MySqlCommand cmd = DbConnection.Connection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@id", UserId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblUser.Text = $"Email: {reader["email"].ToString()}";
                        }
                        else
                        {
                            MessageBox.Show("UNable to load user label");
                        }
                    }
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

        private void btnDelete_Click(object sender, EventArgs e)
        {


            if (dgvBooks.CurrentRow == null)
            {
                MessageBox.Show("Please select a record to delete.");
                return;
            }

            if (MessageBox.Show(
                "Do you want to delete this record?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
                ) == DialogResult.No) return;

            int book_id = Convert.ToInt32(dgvBooks.CurrentRow.Cells["id"].Value);

            try
            {
                if (!DbConnection.GetConnection()) return;

                string sql = "DELETE FROM tblBooks WHERE id = @id";

                using (MySqlCommand cmd = DbConnection.Connection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@id", book_id);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Deleted successfully.");
                LoadBooks();
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvBooks.CurrentRow == null)
            {
                MessageBox.Show("Please select a book to edit.");
                return;
            }

            int bookId = Convert.ToInt32(dgvBooks.CurrentRow.Cells["id"].Value);

            using (frmBookDE book = new frmBookDE(bookId, UserId))
            {
                book.ShowDialog();



                if (book.DialogResult == DialogResult.OK)
                {
                    LoadBooks();
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            using (frmBookDE book = new frmBookDE(UserId))
            {
                book.ShowDialog();

                if (book.DialogResult == DialogResult.OK)
                {
                    LoadBooks();
                }
            }


        }

        private void dgvBooks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                btnDelete.PerformClick();
            }
        }

        private void btnChangePwd_Click(object sender, EventArgs e)
        {
            using (frmChangePassword changePwd = new frmChangePassword(UserId))
            {
                changePwd.ShowDialog();

                if (changePwd.DialogResult == DialogResult.OK)
                {
                    this.Close();
                }
            }


        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Do you want to logout?",
                "Confirmation",
                MessageBoxButtons.YesNo,

                MessageBoxIcon.Information) == DialogResult.No) return;

            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (!DbConnection.GetConnection()) return;

                string sql = @"
                    SELECT
                        id,
                        user_id,
                        title,
                        author,
                        ISBN,
                        year,
                        category,
                        description,
                        created_at
                    FROM tblBooks
                    WHERE title LIKE @title;
                ";

                using (MySqlCommand cmd = DbConnection.Connection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.Parameters.AddWithValue("@title", "%" + txtSearch.Text.Trim() + "%");

                    using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvBooks.DataSource = null;
                        dgvBooks.DataSource = dt;

                        dgvBooks.ClearSelection();
                        dgvBooks.CurrentCell = null;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
            } 
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            using (frmBookReport report = new frmBookReport())
            {
                report.ShowDialog();
            }
        }
    }
}
