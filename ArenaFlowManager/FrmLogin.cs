using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArenaFlowManager
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            TxtUsername.Focus();
            LblLoginError.Visible = false;

        }

        private void BtnEntra_Click(object sender, EventArgs e)
        {
            if (TxtUsername.Text == "admin" && TxtPassword.Text == "admin")
            {
                FrmMain main = new FrmMain();
                main.Show();
                this.Hide();
            }
            else
            {
                LblLoginError.Visible = true;
            }
        }

        //private void TxtUsername_KeyDown(object sender, KeyEventArgs e)
        //{

        //}
    }
}
