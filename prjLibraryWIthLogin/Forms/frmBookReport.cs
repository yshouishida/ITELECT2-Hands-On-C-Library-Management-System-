using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prjLibraryWIthLogin.Report;
using MySqlConnector;
using prjLibraryWIthLogin.Database;
using System.Windows.Forms;

namespace prjLibraryWIthLogin.Forms
{
    public partial class frmBookReport : Form
    {
        private const string ReportResource = "prjLibraryWIthLogin.Report.bookReport.rdlc";

        public frmBookReport()
        {
            InitializeComponent();
        }

        private void reportViewerBook_Load()
        {

        }

        private void LoadReport()
        {
            DataTable dt = GetBookReport();

            if (dt == null) return;

            rvBook.LocalReport.DataSources.Clear();
            rvBook.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("bookDataSet", dt));

            rvBook.LocalReport.ReportEmbeddedResource = ReportResource;

            rvBook.RefreshReport();
            rvBook.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
        }


        private DataTable GetBookReport()
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
                        year,
                        category,
                        description
                    FROM tblBooks
                ";

                DataTable dt = new DataTable();

                using (MySqlDataAdapter da = new MySqlDataAdapter(sql, DbConnection.Connection))
                {
                    da.Fill(dt);
                }
                return dt;

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
