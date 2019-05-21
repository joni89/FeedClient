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

        private List<Feed> feeds = new List<Feed>();
        private List<NewsItem> news = new List<NewsItem>();

        private Feed selectedFeed = null;
        private Filter appliedFilter = null;

        private Font unreadFont;

        public FrmPrincipal(Controller controller)
        {
            this.controller = controller;
            InitializeComponent();

            unreadFont = new Font(listNews.Font.FontFamily, listNews.Font.Size, FontStyle.Bold, listNews.Font.Unit);
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin(controller);
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

            ReloadFeeds();
            UpdateFeedsTreeViewNodes();

            ReloadNews(true);
            UpdateNewsListItems();
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
            wvNews.DocumentText = "";

            FrmNewRss frmNewRss = new FrmNewRss(controller);
            var  answer = frmNewRss.ShowDialog();

            switch (answer)
            {
                case DialogResult.OK:

                    feeds.Add(frmNewRss.feed);
                    UpdateFeedsTreeViewNodes();

                    ReloadNews(true);
                    UpdateNewsListItems();

                    break;

                case DialogResult.Cancel:
                    break;
                default:
                    break;
            }
        }

        private void ControlFeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wvNews.DocumentText = "";

            new FrmCustomRss(controller).ShowDialog();

            ReloadFeeds();
            UpdateFeedsTreeViewNodes();

            ReloadNews(true);
            UpdateNewsListItems();
        }

        private void ControlFiltersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wvNews.DocumentText = "";

            FrmCustomFilters frmCustomFilters = new FrmCustomFilters(controller, appliedFilter);
            frmCustomFilters.ShowDialog();

            SetAppliedFilter(frmCustomFilters.appliedFilter);

            ReloadNews(false);
        }

        private void AcercadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Autor: Jonatan \nVersión: 1.0", "Acerca de ...");
        }

        private void ReloadFeeds()
        {
            feeds = controller.FindUserFeeds();

            if (selectedFeed != null)
            {
                Feed newSelectedFeed = feeds.Find(feed => feed.Id.Value == selectedFeed.Id.Value);

                if (newSelectedFeed == null) {
                    UnsetSelectedFeed(true);
                } else
                {
                    SetSelectedFeed(newSelectedFeed);
                }
            }
        }

        private void UpdateFeedsTreeViewNodes()
        {
            TreeNode[] nodes = feeds.Select(feed => new TreeNode(feed.Name)).ToArray();

            treeFeeds.Nodes[0].Nodes.Clear();
            treeFeeds.Nodes[0].Nodes.AddRange(nodes);
            treeFeeds.Refresh();
        }

        private void ReloadNews(bool refreshFeeds)
        {

            btnRefreshNews.Enabled = false;
            listNews.Enabled = false;
            treeFeeds.Enabled = false;
            try
            {
                if (refreshFeeds)
                {
                    controller.ReadNewsFromFeeds();
                }

                if (selectedFeed != null)
                {
                    Console.WriteLine("SE RECARGAN LAS NOTICIAS DEL FEED: " + selectedFeed.Name);
                    news = controller.FindUserNewsByFeed(selectedFeed);
                } else if(appliedFilter != null)
                {
                    Console.WriteLine("SE RECARGAN LAS NOTICIAS APLICANDO EL FILTRO: " + appliedFilter.Name);
                    news = controller.FindUserNewsByFilter(appliedFilter);
                } else
                {
                    Console.WriteLine("SE RECARGAN LAS NOTICIAS");
                    news = controller.FindUserNews();
                }

                UpdateNewsListItems();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
                MessageBox.Show("Ha ocurrido un error consultando las noticias.", "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnRefreshNews.Enabled = true;
                listNews.Enabled = true;
                treeFeeds.Enabled = true;
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

            try
            {
                controller.MarkAsUnread(selected, false);
                listNews.Refresh();
            } catch(Exception)
            {
                MessageBox.Show("Ha ocurrido un error al marcar la noticia como leída.", "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if(e.Index < 0)
            {
                return;
            }

            NewsItem newsItem = (NewsItem) listNews.Items[e.Index];

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

        private void MiAddFavorite_Click(object sender, EventArgs e)
        {
            NewsItem selected = GetSelectedNewsItem();
            if (selected != null)
            {
                controller.MarkAsFavorite(selected, true);
                listNews.Refresh();
            }
        }

        private void MiRemoveFavorite_Click(object sender, EventArgs e)
        {
            NewsItem selected = GetSelectedNewsItem();
            if (selected != null)
            {
                controller.MarkAsFavorite(selected, false);
                listNews.Refresh();
            }
        }

        private void MiDeleteNewsItem_Click(object sender, EventArgs e)
        {
            NewsItem selected = GetSelectedNewsItem();

            if (selected == null)
            {
                return;
            }

            if (MessageBox.Show("¿Desea eliminar la noticia seleccionada?"
                , "Salir"
                , MessageBoxButtons.OKCancel
                , MessageBoxIcon.Question)
                != DialogResult.OK)
            {
                return;
            }

            try
            {
                controller.DeleteNewsItem(selected);
                news.Remove(selected);

                wvNews.DocumentText = "";
            } catch(Exception)
            {
                MessageBox.Show("Ha ocurrido un error eliminando la noticia.", "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Noticia eliminada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            UpdateNewsListItems();
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

        private void BtnRefreshNews_Click(object sender, EventArgs e)
        {
            ReloadNews(true);
            UpdateNewsListItems();
        }

        private void TreeFeeds_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode rootNode = treeFeeds.Nodes[0];
            TreeNode selectedNode = e.Node;

            if (selectedNode == rootNode)
            {
                SetSelectedFeed(null);
            } else
            {
                int nodeIndex = rootNode.Nodes.IndexOf(selectedNode);
                SetSelectedFeed(feeds[nodeIndex]);
            }

            ReloadNews(false);
            UpdateNewsListItems();
        }

        private void SetSelectedFeed(Feed feed)
        {
            wvNews.DocumentText = "";

            if (feed == null)
            {
                UnsetSelectedFeed(false);
                UnsetAppliedFilter();
                return;
            }

            selectedFeed = feed;

            lblFeedName.Text = feed.Name;

            lblFeedLabel.Visible = true;
            lblFeedName.Visible = true;

            UnsetAppliedFilter();

        }

        private void UnsetSelectedFeed(bool deselectTreeNode)
        {
            selectedFeed = null;

            if (deselectTreeNode)
            {
                treeFeeds.SelectedNode = null;
            }

            lblFeedLabel.Visible = false;
            lblFeedName.Visible = false;
        }

        private void SetAppliedFilter(Filter filter)
        {
            if(filter == null)
            {
                UnsetAppliedFilter();
                return;

            }

            appliedFilter = filter;

            lblFilterName.Text = filter.Name;

            lblFilterLabel.Visible = true;
            lblFilterName.Visible = true;

            UnsetSelectedFeed(true);
        }

        private void UnsetAppliedFilter()
        {
            appliedFilter = null;
            lblFilterLabel.Visible = false;
            lblFilterName.Visible = false;
        }
    }
}
