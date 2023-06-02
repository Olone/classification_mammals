namespace WindowsFormsApp5
{
    partial class FormInfo
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
            this.WebBrowserInfo = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // WebBrowserInfo
            // 
            this.WebBrowserInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WebBrowserInfo.Location = new System.Drawing.Point(0, 0);
            this.WebBrowserInfo.MinimumSize = new System.Drawing.Size(20, 20);
            this.WebBrowserInfo.Name = "WebBrowserInfo";
            this.WebBrowserInfo.Size = new System.Drawing.Size(1208, 689);
            this.WebBrowserInfo.TabIndex = 0;
            // 
            // FormInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 689);
            this.Controls.Add(this.WebBrowserInfo);
            this.Name = "FormInfo";
            this.Text = "FormInfo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormInfo_FormClosing);
            this.Load += new System.EventHandler(this.FormInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser WebBrowserInfo;
    }
}