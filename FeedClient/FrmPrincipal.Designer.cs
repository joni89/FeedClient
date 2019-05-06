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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("ABC");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Fuentes", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.wBNews = new System.Windows.Forms.WebBrowser();
            this.txtNews = new System.Windows.Forms.TextBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // wBNews
            // 
            this.wBNews.Location = new System.Drawing.Point(214, 320);
            this.wBNews.MinimumSize = new System.Drawing.Size(20, 20);
            this.wBNews.Name = "wBNews";
            this.wBNews.Size = new System.Drawing.Size(1228, 346);
            this.wBNews.TabIndex = 0;
            // 
            // txtNews
            // 
            this.txtNews.Location = new System.Drawing.Point(214, 12);
            this.txtNews.Multiline = true;
            this.txtNews.Name = "txtNews";
            this.txtNews.ReadOnly = true;
            this.txtNews.Size = new System.Drawing.Size(1228, 286);
            this.txtNews.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(27, 26);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Nodo1";
            treeNode1.Text = "ABC";
            treeNode2.BackColor = System.Drawing.Color.Transparent;
            treeNode2.ForeColor = System.Drawing.Color.Black;
            treeNode2.Name = "Nodo0";
            treeNode2.Text = "Fuentes";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.treeView1.Size = new System.Drawing.Size(121, 97);
            this.treeView1.TabIndex = 2;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1454, 678);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.txtNews);
            this.Controls.Add(this.wBNews);
            this.Name = "FrmPrincipal";
            this.Text = "Principal";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser wBNews;
        private System.Windows.Forms.TextBox txtNews;
        private System.Windows.Forms.TreeView treeView1;
    }
}

