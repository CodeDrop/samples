namespace WebView2Sample
{
    partial class AppWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Browser = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.Browser)).BeginInit();
            this.SuspendLayout();
            // 
            // Browser
            // 
            this.Browser.AllowExternalDrop = true;
            this.Browser.CreationProperties = null;
            this.Browser.DefaultBackgroundColor = System.Drawing.Color.White;
            this.Browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Browser.Location = new System.Drawing.Point(0, 0);
            this.Browser.Name = "Browser";
            this.Browser.Size = new System.Drawing.Size(800, 450);
            this.Browser.TabIndex = 0;
            this.Browser.ZoomFactor = 1D;
            // 
            // AppWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Browser);
            this.Name = "AppWindow";
            this.Text = "WebView2 Sample";
            this.Shown += new System.EventHandler(this.AppWindow_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.Browser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 Browser;
    }
}