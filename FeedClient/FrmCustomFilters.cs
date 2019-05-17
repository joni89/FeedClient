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
    public partial class FrmCustomFilters : Form
    {

        private Controller controller;
        public FrmCustomFilters(Controller controller)
        {
            this.controller = controller;
            InitializeComponent();
        }

        private void ManagementList_ButtonClickEvent(object sender, ManagementList.ButtonClickEventArgs e)
        {
            switch (e.Button)
            {
                case ManagementList.ActionButton.ADD:
                    new FrmNewFilter(controller).ShowDialog();
                    break;
                case ManagementList.ActionButton.EDIT:
                    break;
                case ManagementList.ActionButton.DELETE:
                    break;
            }
        }
    }
}
