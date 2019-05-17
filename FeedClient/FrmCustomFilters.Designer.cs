namespace FeedClient
{
    partial class FrmCustomFilters
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCustomFilters));
            this.btnApply = new System.Windows.Forms.Button();
            this.managementList = new ManagementList.ManagementList();
            this.SuspendLayout();
            // 
            // btnApply
            // 
            this.btnApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.Location = new System.Drawing.Point(294, 218);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(80, 26);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Aplicar";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // managementList
            // 
            this.managementList.Items = ((System.Collections.Generic.List<object>)(resources.GetObject("managementList.Items")));
            this.managementList.Location = new System.Drawing.Point(0, 2);
            this.managementList.Name = "managementList";
            this.managementList.Size = new System.Drawing.Size(406, 314);
            this.managementList.TabIndex = 11;
            this.managementList.ButtonClickEvent += new System.EventHandler<ManagementList.ButtonClickEventArgs>(this.ManagementList_ButtonClickEvent);
            // 
            // FrmCustomFilters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 318);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.managementList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmCustomFilters";
            this.Text = "Gestión de filtros";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnApply;
        private ManagementList.ManagementList managementList;
    }
}