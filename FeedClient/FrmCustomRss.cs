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

            UpdateListItems();

        }

        private void UpdateListItems()
        {
            managementList.Items = feeds.Select(f => f.Name).ToList<object>();
        }

        private void ManagementList_ButtonClickEvent(object sender, ManagementList.ButtonClickEventArgs e)
        {
            switch(e.Button)
            {
                case ManagementList.ActionButton.ADD:
                    AddFeed();
                    break;
                case ManagementList.ActionButton.EDIT:
                    EditFeed(e.SelectedIndex);
                    break;
                case ManagementList.ActionButton.DELETE:
                    DeleteFeeds(e.SelectedIndices);
                    break;
            }
        }

        private void AddFeed()
        {
            FrmNewRss frmNewRss = new FrmNewRss(controller);
            var answer = frmNewRss.ShowDialog();

            if(answer == DialogResult.OK) {
                feeds.Add(frmNewRss.feed);
                UpdateListItems();
            }
        }

        private void EditFeed(int selectedIndex)
        {
            Feed selectedFeed = feeds[selectedIndex];

            var frmNewRss = new FrmNewRss(controller, selectedFeed);
            var answer = frmNewRss.ShowDialog();

            if(answer == DialogResult.OK)
            {
                UpdateListItems();
            }
        }

        private void DeleteFeeds(int[] selectedIndices)
        {
            List<Feed> selectedFeeds = selectedIndices.Select(i => feeds[i]).ToList();

            try
            {
                controller.DeleteFeeds(selectedFeeds);

                foreach(var feed in selectedFeeds)
                {
                    feeds.Remove(feed);
                }

            } catch(Exception)
            {
                MessageBox.Show("Ha ocurrido un error eliminando las fuentes.", "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Fuentes eliminadas satisfactoriamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            UpdateListItems();
        }
    }
}
