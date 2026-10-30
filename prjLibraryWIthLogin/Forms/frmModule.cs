using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjLibraryWIthLogin.Forms
{
    public partial class frmModule : Form
    {
        private int UserId { get; set; }

        public frmModule(int userId)
        {
            UserId = userId;

            InitializeComponent();
        }



        private void btnUsers_Click(object sender, EventArgs e)
        {
            new frmUserManage().ShowDialog();
        }

        private void btnBooks_Click(object sender, EventArgs e)
        {
            new frmMain(UserId).ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
