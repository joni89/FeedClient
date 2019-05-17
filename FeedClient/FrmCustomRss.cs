using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FeedClient.Model;

namespace FeedClient
{
    public partial class FrmCustomRss : Form
    {
        private Controller controller;
        private List<Feed> feeds;

        public FrmCustomRss(Controller controller)
        {
            this.controller = controller;
            InitializeComponent();

            feeds = controller.FindUserFeeds();
            managementList.Items = feeds.Select(f => f.Name).ToList<object>();

        }

        private void ManagementList_ButtonClickEvent(object sender, ManagementList.ButtonClickEventArgs e)
        {
            switch(e.Button)
            {
                case ManagementList.ActionButton.ADD:
                    new FrmNewRss(controller).ShowDialog();
                    break;
                case ManagementList.ActionButton.EDIT:
                    break;
                case ManagementList.ActionButton.DELETE:
                    break;
            }
        }
    }
}
