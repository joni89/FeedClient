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
        private FrmNewRss frmNewRss = new FrmNewRss();
        private FrmCustomRss frmCustomRss = new FrmCustomRss();
        private FrmNewFilter frmNewFilter = new FrmNewFilter();
        private FrmCustomFilters frmCustomFilter = new FrmCustomFilters();
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

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Seguro que desea salir?"
                                , "Salir"
                                , MessageBoxButtons.OKCancel
                                , MessageBoxIcon.Question)
                                == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void AddRssToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewRss.ShowDialog();
        }

        private void ControlFeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomRss.ShowDialog();
        }

        private void SaveFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewFilter.ShowDialog();
        }

        private void ControlFiltersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomFilter.ShowDialog();
        }

        private void AcercadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Autor: Jonatan \nVersión: 1.0", "Acerca de ...");
        }
    }
}
