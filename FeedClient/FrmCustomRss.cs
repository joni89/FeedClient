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
    public partial class FrmCustomRss : Form
    {
        FrmNewRss frmNewRss = new FrmNewRss();
        public FrmCustomRss()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            frmNewRss.ShowDialog();
        }
    }
}
