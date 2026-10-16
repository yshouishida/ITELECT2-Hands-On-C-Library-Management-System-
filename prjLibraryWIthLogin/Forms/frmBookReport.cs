using System;
using System.Data;
using MySqlConnector;
using prjLibraryWIthLogin.Database;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace prjLibraryWIthLogin.Forms
{
    public partial class frmBookReport : Form
    {
 
        public frmBookReport()
        {
            InitializeComponent();
        }

        private void LoadReport()
        {
            try
            {
                DataTable dt = GetBookDT();
                if (dt == null) return;

                rvBook.LocalReport.DataSources.Clear();
                rvBook.LocalReport.DataSources.Add(new ReportDataSource("bookDataSet", dt));
                rvBook.LocalReport.ReportEmbeddedResource = "prjLibraryWIthLogin.Report.bookReport.rdlc";

                rvBook.RefreshReport();
                rvBook.SetDisplayMode(DisplayMode.PrintLayout);
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

        private DataTable GetBookDT()
        {
            if (!DbConnection.GetConnection()) return null;
            try
            {
                string sql = @"
                    SELECT
                        id,
                        user_id,
                        title,
                        author,
                        ISBN,
                        DATE_FORMAT(year, '%Y') AS year,
                        category,
                        description
                    FROM tblBooks
                ";

                using (MySqlDataAdapter da = new MySqlDataAdapter(sql, DbConnection.Connection))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                DbConnection.ConnClose();
            }
        }

        private void frmBookReport_Load(object sender, EventArgs e)
        {
            LoadReport();
        }
    }
}
