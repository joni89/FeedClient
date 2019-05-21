namespace FeedClient
{
    partial class FrmCustomRss
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomRss));
            this.managementList = new ManagementList.ManagementList();
            this.SuspendLayout();
            // 
            // managementList
            // 
            this.managementList.Items = ((System.Collections.Generic.List<object>)(resources.GetObject("managementList.Items")));
            this.managementList.Location = new System.Drawing.Point(0, 0);
            this.managementList.Name = "managementList";
            this.managementList.Size = new System.Drawing.Size(406, 314);
            this.managementList.TabIndex = 0;
            this.managementList.ButtonClickEvent += new System.EventHandler<ManagementList.ButtonClickEventArgs>(this.ManagementList_ButtonClickEvent);
            // 
            // FrmCustomRss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 315);
            this.Controls.Add(this.managementList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmCustomRss";
            this.Text = "Gestión de fuentes";
            this.ResumeLayout(false);

        }

        #endregion

        private ManagementList.ManagementList managementList;
    }
}