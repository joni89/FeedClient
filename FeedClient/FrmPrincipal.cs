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

        private Controller controller;

        private List<Feed> feeds;
        private List<NewsItem> news;

        private Font unreadFont;

        public FrmPrincipal(Controller controller)
        {
            this.controller = controller;
            InitializeComponent();

            unreadFont = new Font(listNews.Font.FontFamily, listNews.Font.Size, FontStyle.Bold, listNews.Font.Unit);
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            bool cancel = false;
            bool loginSuccessful = false;
            do
            {
                var answer = frmLogin.ShowDialog();
                switch (answer)
                {
                    case DialogResult.OK:
                        loginSuccessful = controller.Login(frmLogin.txtUsername.Text, frmLogin.txtPassword.Text);
                        break;
                    case DialogResult.Cancel:
                        cancel = true;
                        break;
                }
            } while (!loginSuccessful && !cancel);

            if (cancel)
            {
                this.Dispose();
                return;
            }

            ReloadFeeds(true);
            ReloadNews(true);
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
            new FrmNewRss(controller).ShowDialog();
        }

        private void ControlFeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmCustomRss(controller).ShowDialog();
        }

        private void SaveFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmNewFilter(controller).ShowDialog();
        }

        private void ControlFiltersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmCustomFilters(controller).ShowDialog();
        }

        private void AcercadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Autor: Jonatan \nVersión: 1.0", "Acerca de ...");
        }

        private void ReloadFeeds(bool reloadTreeView)
        {
            feeds = controller.FindUserFeeds();

            if (reloadTreeView)
            {
                UpdateFeedsTreeViewNodes();
            }
        }

        private void UpdateFeedsTreeViewNodes()
        {
            TreeNode[] nodes = feeds.Select(feed => new TreeNode(feed.Name)).ToArray();

            treeFeeds.Nodes[0].Nodes.Clear();
            treeFeeds.Nodes[0].Nodes.AddRange(nodes);
            treeFeeds.Refresh();
        }

        private void ReloadNews(bool reloadList)
        {
            news = controller.FindUserNews();

            if(reloadList)
            {
                UpdateNewsListItems();
            }
        }

        private void UpdateNewsListItems()
        {
            listNews.Items.Clear();
            listNews.Items.AddRange(news.ToArray());
            listNews.Refresh();
        }

        private NewsItem GetSelectedNewsItem()
        {
            return listNews.SelectedIndex != -1 ? news[listNews.SelectedIndex] : null;
        }

        private void ListNews_SelectedIndexChanged(object sender, EventArgs e)
        {
            NewsItem selected = GetSelectedNewsItem();

            wvNews.DocumentText = selected != null ? selected.Contents : "";
        }

        private void SetContextMenuItemsEnabled(bool enabled)
        {
            foreach (var menuItem in cmNewsItem.Items)
            {
                ((ToolStripMenuItem)menuItem).Enabled = enabled;
            }
        }

        private void ListNews_DrawItem(object sender, DrawItemEventArgs e)
        {
            NewsItem newsItem = news[e.Index];

            e.DrawBackground();

            e.Graphics.DrawString(newsItem.Title, newsItem.Unread ? unreadFont : listNews.Font, newsItem.Favorite ? Brushes.Orange : Brushes.Black, e.Bounds);
            e.DrawFocusRectangle();
        }

        private void MiOpenInBrowser_Click(object sender, EventArgs e)
        {
            NewsItem selected = GetSelectedNewsItem();

            if(selected != null)
            {
                System.Diagnostics.Process.Start(selected.Url);
            }
        }
        
        private void MiMarkRead_Click(object sender, EventArgs e)
        {
            NewsItem selected = GetSelectedNewsItem();
            if(selected != null)
            {
                controller.MarkAsUnread(selected, false);
                listNews.Refresh();
            }
        }

        private void MiMarkUnread_Click(object sender, EventArgs e)
        {
            NewsItem selected = GetSelectedNewsItem();
            if (selected != null)
            {
                controller.MarkAsUnread(selected, true);
                listNews.Refresh();
            }
        }

        private void MiMarkFavorite_Click(object sender, EventArgs e)
        {
            NewsItem selected = GetSelectedNewsItem();
            if (selected != null)
            {
                controller.MarkAsFavorite(selected, false);
                listNews.Refresh();
            }
        }

        private void MiMarkUnFavorite_Click(object sender, EventArgs e)
        {
            NewsItem selected = GetSelectedNewsItem();
            if (selected != null)
            {
                controller.MarkAsFavorite(selected, true);
                listNews.Refresh();
            }
        }

        private void CmNewsItem_Opening(object sender, CancelEventArgs e)
        {
            NewsItem selected = GetSelectedNewsItem();

            if (selected != null)
            {
                SetContextMenuItemsEnabled(true);

                miMarkRead.Visible = selected.Unread;
                miMarkUnread.Visible = !selected.Unread;

                miAddFavorite.Visible = !selected.Favorite;
                miRemoveFavorite.Visible = selected.Favorite;
            }
            else
            {
                SetContextMenuItemsEnabled(false);
                miMarkUnread.Visible = false;
                miRemoveFavorite.Visible = false;
            }
        }
    }
}
