using FeedClient.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeedClient
{
    public partial class FrmPrincipal : Form
    {
        private FrmLogin frmLogin = new FrmLogin();
        private Controller controller;
        private User user = null;

        public FrmPrincipal(Controller controller)
        {
            this.controller = controller;
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            bool cancel = false;
            do
            {
                var answer = frmLogin.ShowDialog();
                switch (answer)
                {
                    case DialogResult.OK:
                        user = controller.Login(frmLogin.txtUsername.Text, frmLogin.txtPassword.Text);
                        break;
                    case DialogResult.Cancel:
                        cancel = true;
                        break;
                }
            } while (user == null && !cancel);

            if (cancel)
            {
                this.Dispose();
            }
        }
    }
}
