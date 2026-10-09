using System;
using MySqlConnector;
using prjLibraryWIthLogin.Database;
using prjLibraryWIthLogin.Forms;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjLibraryWIthLogin.Forms
{

    public partial class frmBookDE : Form
    {
        private int BookId { get; set; }
        private int UserId { get; set; }
        private bool IsEdit { get; set; }
       

        public frmBookDE(int userId)
        {
            BookId = 0;
            UserId = userId;
            IsEdit = false;

            InitializeComponent();
        }

        // For Edit
        public frmBookDE(int bookId, int userId)
        {
            BookId = bookId;
            UserId = userId;
            IsEdit = true;

            InitializeComponent();
        }

        private void frmBookDE_Load(object sender, EventArgs e)
        {
            btnSaveAdd.Text = IsEdit ? "Save" : "Add";

            if (IsEdit) LoadBookById();

            //MessageBox.Show($"UserID: {UserId}");


        }

        private void LoadBookById()
        {
            try
            {
                if (!DbConnection.GetConnection()) return;

                using (MySqlCommand cmd = DbConnection.Connection.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT
                            id,
                            title,
                            author,
                            ISBN,
                            year,
                            category,
                            description
                        FROM tblBooks 
                        WHERE id = @id
                    ";
                    cmd.Parameters.AddWithValue("@id", BookId);
                    
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtTitle.Text = reader["title"].ToString();
                            txtAuthor.Text = reader["author"].ToString();
                            txtISBN.Text = reader["ISBN"].ToString();
                            dtpYear.Value = Convert.ToDateTime(reader["year"]);
                            cbCategory.SelectedItem = reader["category"].ToString();
                            txtDesc.Text = reader["description"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Unable to load book.");
                            return;
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

        private void btnSaveAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!DbConnection.GetConnection()) return;

                using (MySqlCommand cmd = DbConnection.Connection.CreateCommand())
                {
                    cmd.CommandText = IsEdit ?
                        @"
                        UPDATE tblBooks
                        SET
                            title       = @title,
                            author      = @author,
                            isbn        = @isbn,
                            year        = @year,
                            category    = @category,
                            description = @description
                        WHERE id        = @id 
                        AND   user_id   = @user_id
                        "
                        :
                        @"
                        INSERT INTO tblBooks 
                            (title, author, isbn, year, category, description, user_id)
                        VALUES (@title, @author, @isbn, @year, @category, @description, @user_id)
                        ";

                    cmd.Parameters.AddWithValue("@title", txtTitle.Text.Trim());
                    cmd.Parameters.AddWithValue("@author", txtAuthor.Text.Trim());
                    cmd.Parameters.AddWithValue("@isbn", txtISBN.Text.Trim());
                    cmd.Parameters.AddWithValue("@year", Convert.ToDateTime(dtpYear.Value));
                    cmd.Parameters.AddWithValue("@category", cbCategory.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@description", txtDesc.Text.Trim());
                    cmd.Parameters.AddWithValue("@user_id", UserId);

                    if (IsEdit) cmd.Parameters.AddWithValue("@id", BookId);

                    cmd.ExecuteNonQuery();

                    this.DialogResult = DialogResult.OK;

                    MessageBox.Show(IsEdit ? "Updated successfully." : "Added successfully.");

                    this.Close();
                    

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
    }
}
