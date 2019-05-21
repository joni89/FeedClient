namespace FeedClient
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Todas las fuentes");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.wvNews = new System.Windows.Forms.WebBrowser();
            this.treeFeeds = new System.Windows.Forms.TreeView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.feedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRssToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlFeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlFiltersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listNews = new System.Windows.Forms.ListBox();
            this.cmNewsItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miOpenInBrowser = new System.Windows.Forms.ToolStripMenuItem();
            this.miMarkRead = new System.Windows.Forms.ToolStripMenuItem();
            this.miMarkUnread = new System.Windows.Forms.ToolStripMenuItem();
            this.miAddFavorite = new System.Windows.Forms.ToolStripMenuItem();
            this.miRemoveFavorite = new System.Windows.Forms.ToolStripMenuItem();
            this.miDeleteNewsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRefreshNews = new System.Windows.Forms.Button();
            this.lblFilterLabel = new System.Windows.Forms.Label();
            this.lblFilterName = new System.Windows.Forms.Label();
            this.lblFeedLabel = new System.Windows.Forms.Label();
            this.lblFeedName = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.cmNewsItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // wvNews
            // 
            this.wvNews.Location = new System.Drawing.Point(214, 346);
            this.wvNews.MinimumSize = new System.Drawing.Size(20, 20);
            this.wvNews.Name = "wvNews";
            this.wvNews.ScriptErrorsSuppressed = true;
            this.wvNews.Size = new System.Drawing.Size(958, 403);
            this.wvNews.TabIndex = 0;
            // 
            // treeFeeds
            // 
            this.treeFeeds.Location = new System.Drawing.Point(12, 36);
            this.treeFeeds.Name = "treeFeeds";
            treeNode1.BackColor = System.Drawing.Color.Transparent;
            treeNode1.ForeColor = System.Drawing.Color.Black;
            treeNode1.Name = "nodeAllFeeds";
            treeNode1.Tag = "";
            treeNode1.Text = "Todas las fuentes";
            this.treeFeeds.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeFeeds.Size = new System.Drawing.Size(183, 713);
            this.treeFeeds.TabIndex = 2;
            this.treeFeeds.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeFeeds_AfterSelect);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.feedToolStripMenuItem,
            this.filtersToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "&Archivo";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeToolStripMenuItem.Text = "&Salir";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItem_Click);
            // 
            // feedToolStripMenuItem
            // 
            this.feedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addRssToolStripMenuItem,
            this.controlFeedToolStripMenuItem});
            this.feedToolStripMenuItem.Name = "feedToolStripMenuItem";
            this.feedToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.feedToolStripMenuItem.Text = "&Fuentes";
            // 
            // addRssToolStripMenuItem
            // 
            this.addRssToolStripMenuItem.Name = "addRssToolStripMenuItem";
            this.addRssToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.addRssToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.addRssToolStripMenuItem.Text = "&Añadir fuente";
            this.addRssToolStripMenuItem.Click += new System.EventHandler(this.AddRssToolStripMenuItem_Click);
            // 
            // controlFeedToolStripMenuItem
            // 
            this.controlFeedToolStripMenuItem.Name = "controlFeedToolStripMenuItem";
            this.controlFeedToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.controlFeedToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.controlFeedToolStripMenuItem.Text = "&Gestionar fuentes";
            this.controlFeedToolStripMenuItem.Click += new System.EventHandler(this.ControlFeedToolStripMenuItem_Click);
            // 
            // filtersToolStripMenuItem
            // 
            this.filtersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.controlFiltersToolStripMenuItem});
            this.filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
            this.filtersToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.filtersToolStripMenuItem.Text = "Fil&tros";
            // 
            // controlFiltersToolStripMenuItem
            // 
            this.controlFiltersToolStripMenuItem.Name = "controlFiltersToolStripMenuItem";
            this.controlFiltersToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.controlFiltersToolStripMenuItem.Text = "&Gestionar filtros";
            this.controlFiltersToolStripMenuItem.Click += new System.EventHandler(this.ControlFiltersToolStripMenuItem_Click);
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercadeToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ay&uda";
            // 
            // acercadeToolStripMenuItem
            // 
            this.acercadeToolStripMenuItem.Name = "acercadeToolStripMenuItem";
            this.acercadeToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.acercadeToolStripMenuItem.Text = "&Acerca de...";
            this.acercadeToolStripMenuItem.Click += new System.EventHandler(this.AcercadeToolStripMenuItem_Click);
            // 
            // listNews
            // 
            this.listNews.ContextMenuStrip = this.cmNewsItem;
            this.listNews.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listNews.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listNews.FormattingEnabled = true;
            this.listNews.ItemHeight = 20;
            this.listNews.Location = new System.Drawing.Point(214, 70);
            this.listNews.Name = "listNews";
            this.listNews.Size = new System.Drawing.Size(958, 264);
            this.listNews.TabIndex = 4;
            this.listNews.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListNews_DrawItem);
            this.listNews.SelectedIndexChanged += new System.EventHandler(this.ListNews_SelectedIndexChanged);
            // 
            // cmNewsItem
            // 
            this.cmNewsItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miOpenInBrowser,
            this.miMarkRead,
            this.miMarkUnread,
            this.miAddFavorite,
            this.miRemoveFavorite,
            this.miDeleteNewsItem});
            this.cmNewsItem.Name = "contextMenuStrip1";
            this.cmNewsItem.Size = new System.Drawing.Size(191, 136);
            this.cmNewsItem.Text = "Pepe";
            this.cmNewsItem.Opening += new System.ComponentModel.CancelEventHandler(this.CmNewsItem_Opening);
            // 
            // miOpenInBrowser
            // 
            this.miOpenInBrowser.Enabled = false;
            this.miOpenInBrowser.Name = "miOpenInBrowser";
            this.miOpenInBrowser.Size = new System.Drawing.Size(190, 22);
            this.miOpenInBrowser.Text = "Abrir en el navegador";
            this.miOpenInBrowser.Click += new System.EventHandler(this.MiOpenInBrowser_Click);
            // 
            // miMarkRead
            // 
            this.miMarkRead.Enabled = false;
            this.miMarkRead.Name = "miMarkRead";
            this.miMarkRead.Size = new System.Drawing.Size(190, 22);
            this.miMarkRead.Text = "Marcar como leída";
            this.miMarkRead.Click += new System.EventHandler(this.MiMarkRead_Click);
            // 
            // miMarkUnread
            // 
            this.miMarkUnread.Enabled = false;
            this.miMarkUnread.Name = "miMarkUnread";
            this.miMarkUnread.Size = new System.Drawing.Size(190, 22);
            this.miMarkUnread.Text = "Marcar como no leída";
            this.miMarkUnread.Visible = false;
            this.miMarkUnread.Click += new System.EventHandler(this.MiMarkUnread_Click);
            // 
            // miAddFavorite
            // 
            this.miAddFavorite.Enabled = false;
            this.miAddFavorite.Name = "miAddFavorite";
            this.miAddFavorite.Size = new System.Drawing.Size(190, 22);
            this.miAddFavorite.Text = "Añadir a favoritas";
            this.miAddFavorite.Click += new System.EventHandler(this.MiAddFavorite_Click);
            // 
            // miRemoveFavorite
            // 
            this.miRemoveFavorite.Enabled = false;
            this.miRemoveFavorite.Name = "miRemoveFavorite";
            this.miRemoveFavorite.Size = new System.Drawing.Size(190, 22);
            this.miRemoveFavorite.Text = "Eliminar de favoritos";
            this.miRemoveFavorite.Visible = false;
            this.miRemoveFavorite.Click += new System.EventHandler(this.MiRemoveFavorite_Click);
            // 
            // miDeleteNewsItem
            // 
            this.miDeleteNewsItem.Name = "miDeleteNewsItem";
            this.miDeleteNewsItem.Size = new System.Drawing.Size(190, 22);
            this.miDeleteNewsItem.Text = "Eliminar noticia";
            this.miDeleteNewsItem.Click += new System.EventHandler(this.MiDeleteNewsItem_Click);
            // 
            // btnRefreshNews
            // 
            this.btnRefreshNews.Location = new System.Drawing.Point(1052, 36);
            this.btnRefreshNews.Name = "btnRefreshNews";
            this.btnRefreshNews.Size = new System.Drawing.Size(120, 23);
            this.btnRefreshNews.TabIndex = 5;
            this.btnRefreshNews.Text = "Refrescar noticias";
            this.btnRefreshNews.UseVisualStyleBackColor = true;
            this.btnRefreshNews.Click += new System.EventHandler(this.BtnRefreshNews_Click);
            // 
            // lblFilterLabel
            // 
            this.lblFilterLabel.AutoSize = true;
            this.lblFilterLabel.Location = new System.Drawing.Point(214, 36);
            this.lblFilterLabel.Name = "lblFilterLabel";
            this.lblFilterLabel.Size = new System.Drawing.Size(75, 13);
            this.lblFilterLabel.TabIndex = 6;
            this.lblFilterLabel.Text = "Filtro aplicado:";
            this.lblFilterLabel.Visible = false;
            // 
            // lblFilterName
            // 
            this.lblFilterName.AutoSize = true;
            this.lblFilterName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilterName.Location = new System.Drawing.Point(289, 36);
            this.lblFilterName.Name = "lblFilterName";
            this.lblFilterName.Size = new System.Drawing.Size(106, 13);
            this.lblFilterName.TabIndex = 7;
            this.lblFilterName.Text = "[nombre del filtro]";
            this.lblFilterName.Visible = false;
            // 
            // lblFeedLabel
            // 
            this.lblFeedLabel.AutoSize = true;
            this.lblFeedLabel.Location = new System.Drawing.Point(214, 36);
            this.lblFeedLabel.Name = "lblFeedLabel";
            this.lblFeedLabel.Size = new System.Drawing.Size(109, 13);
            this.lblFeedLabel.TabIndex = 8;
            this.lblFeedLabel.Text = "Fuente seleccionada:";
            this.lblFeedLabel.Visible = false;
            // 
            // lblFeedName
            // 
            this.lblFeedName.AutoSize = true;
            this.lblFeedName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFeedName.Location = new System.Drawing.Point(320, 36);
            this.lblFeedName.Name = "lblFeedName";
            this.lblFeedName.Size = new System.Drawing.Size(128, 13);
            this.lblFeedName.TabIndex = 9;
            this.lblFeedName.Text = "[nombre de la fuente]";
            this.lblFeedName.Visible = false;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.lblFeedName);
            this.Controls.Add(this.lblFeedLabel);
            this.Controls.Add(this.lblFilterName);
            this.Controls.Add(this.lblFilterLabel);
            this.Controls.Add(this.btnRefreshNews);
            this.Controls.Add(this.listNews);
            this.Controls.Add(this.treeFeeds);
            this.Controls.Add(this.wvNews);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FrmPrincipal";
            this.Text = "Principal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.cmNewsItem.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser wvNews;
        private System.Windows.Forms.TreeView treeFeeds;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem feedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlFeedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filtersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlFiltersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRssToolStripMenuItem;
        private System.Windows.Forms.ListBox listNews;
        private System.Windows.Forms.ContextMenuStrip cmNewsItem;
        private System.Windows.Forms.ToolStripMenuItem miOpenInBrowser;
        private System.Windows.Forms.ToolStripMenuItem miMarkRead;
        private System.Windows.Forms.ToolStripMenuItem miMarkUnread;
        private System.Windows.Forms.ToolStripMenuItem miAddFavorite;
        private System.Windows.Forms.ToolStripMenuItem miRemoveFavorite;
        private System.Windows.Forms.ToolStripMenuItem miDeleteNewsItem;
        private System.Windows.Forms.Button btnRefreshNews;
        private System.Windows.Forms.Label lblFilterLabel;
        private System.Windows.Forms.Label lblFilterName;
        private System.Windows.Forms.Label lblFeedLabel;
        private System.Windows.Forms.Label lblFeedName;
    }
}

