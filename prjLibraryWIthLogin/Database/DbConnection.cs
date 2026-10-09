using System;
using MySqlConnector;
using System.Windows.Forms;

namespace prjLibraryWIthLogin.Database
{

    class DbConnection
    {
        public static  MySqlConnection Connection;

        public static bool GetConnection()
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

        public static void ConnClose()
        {
            Connection?.Close();
        }
    }
}
