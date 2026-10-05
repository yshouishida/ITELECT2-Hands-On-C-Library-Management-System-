using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Windows.Forms;

namespace prjLibraryWIthLogin.Forms
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void checkBoxShowPwd_CheckedChanged(object sender, EventArgs e) => txtPassword.UseSystemPasswordChar = checkBoxShowPwd.Checked ? false : true;
    }
}
