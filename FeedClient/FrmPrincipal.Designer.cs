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
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("ABC");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Fuentes", new System.Windows.Forms.TreeNode[] {
            treeNode5});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.wBNews = new System.Windows.Forms.WebBrowser();
            this.txtNews = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.feedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlFeedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlFiltersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRssToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // wBNews
            // 
            this.wBNews.Location = new System.Drawing.Point(214, 336);
            this.wBNews.MinimumSize = new System.Drawing.Size(20, 20);
            this.wBNews.Name = "wBNews";
            this.wBNews.Size = new System.Drawing.Size(1228, 346);
            this.wBNews.TabIndex = 0;
            // 
            // txtNews
            // 
            this.txtNews.Location = new System.Drawing.Point(214, 44);
            this.txtNews.Multiline = true;
            this.txtNews.Name = "txtNews";
            this.txtNews.ReadOnly = true;
            this.txtNews.Size = new System.Drawing.Size(1228, 286);
            this.txtNews.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(24, 44);
            this.treeView1.Name = "treeView1";
            treeNode5.Name = "Nodo1";
            treeNode5.Text = "ABC";
            treeNode6.BackColor = System.Drawing.Color.Transparent;
            treeNode6.ForeColor = System.Drawing.Color.Black;
            treeNode6.Name = "Nodo0";
            treeNode6.Text = "Fuentes";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6});
            this.treeView1.Size = new System.Drawing.Size(121, 97);
            this.treeView1.TabIndex = 2;
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
            this.menuStrip1.Size = new System.Drawing.Size(1464, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeSesionToolStripMenuItem,
            this.toolStripSeparator2,
            this.closeToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "&Archivo";
            // 
            // closeSesionToolStripMenuItem
            // 
            this.closeSesionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("closeSesionToolStripMenuItem.Image")));
            this.closeSesionToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.closeSesionToolStripMenuItem.Name = "closeSesionToolStripMenuItem";
            this.closeSesionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.closeSesionToolStripMenuItem.Text = "&Cerrar sesión";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
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
            this.saveFilterToolStripMenuItem,
            this.controlFiltersToolStripMenuItem});
            this.filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
            this.filtersToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.filtersToolStripMenuItem.Text = "Fil&tros";
            // 
            // saveFilterToolStripMenuItem
            // 
            this.saveFilterToolStripMenuItem.Name = "saveFilterToolStripMenuItem";
            this.saveFilterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveFilterToolStripMenuItem.Text = "&Guardar filtro actual";
            this.saveFilterToolStripMenuItem.Click += new System.EventHandler(this.SaveFilterToolStripMenuItem_Click);
            // 
            // controlFiltersToolStripMenuItem
            // 
            this.controlFiltersToolStripMenuItem.Name = "controlFiltersToolStripMenuItem";
            this.controlFiltersToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
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
            this.acercadeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.acercadeToolStripMenuItem.Text = "&Acerca de...";
            this.acercadeToolStripMenuItem.Click += new System.EventHandler(this.AcercadeToolStripMenuItem_Click);
            // 
            // addRssToolStripMenuItem
            // 
            this.addRssToolStripMenuItem.Name = "addRssToolStripMenuItem";
            this.addRssToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.addRssToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.addRssToolStripMenuItem.Text = "&Añadir fuente";
            this.addRssToolStripMenuItem.Click += new System.EventHandler(this.AddRssToolStripMenuItem_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1464, 694);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.txtNews);
            this.Controls.Add(this.wBNews);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmPrincipal";
            this.Text = "Principal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser wBNews;
        private System.Windows.Forms.TextBox txtNews;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeSesionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem feedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlFeedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filtersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlFiltersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRssToolStripMenuItem;
    }
}

