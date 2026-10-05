using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Windows.Forms;

namespace prjLibraryWIthLogin.Database
{

    class DbConnection
    {
        public static  MySqlConnection Connection;

        public static bool DbConnect()
        {
            try
            {
                Connection = new MySqlConnection("Server=localhost;Database=dbLibrary;Uid=root;Pwd=");
                Connection.Open();

                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
