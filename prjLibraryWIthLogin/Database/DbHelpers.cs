using System;
using System.Data;
using MySqlConnector;
using System.Windows.Forms;


namespace prjLibraryWIthLogin.Database
{
    public class DbHelpers
    {
        public static void DgvDataLoader(string sql, DataGridView dgv)
        {
            try
            {
                if (!DbConnection.GetConnection()) return;


                using (MySqlDataAdapter da = new MySqlDataAdapter(sql, DbConnection.Connection))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgv.DataSource = null;
                    dgv.DataSource = dt;

                    dgv.AutoGenerateColumns = false;

                    dgv.ClearSelection();
                    dgv.CurrentCell = null;

                    dgv.Columns["id"].Visible = false;
                    dgv.Columns["user_id"].Visible = false;
                    dgv.Columns["created_at"].Visible = false;
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
