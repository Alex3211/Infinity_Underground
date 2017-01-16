namespace InfinityUndergroundLauncher
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_play = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btn_website = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_play
            // 
            resources.ApplyResources(this.btn_play, "btn_play");
            this.btn_play.Name = "btn_play";
            this.btn_play.UseVisualStyleBackColor = true;
            this.btn_play.Click += new System.EventHandler(this.btn_play_Click);
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.progressBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(104)))), ((int)(((byte)(105)))));
            this.progressBar.Name = "progressBar";
            this.progressBar.Click += new System.EventHandler(this.progressBar_Click);
            // 
            // webBrowser1
            // 
            resources.ApplyResources(this.webBrowser1, "webBrowser1");
            this.webBrowser1.AllowWebBrowserDrop = false;
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Url = new System.Uri("http://www.alexandrepicard.fr/InfinityUnderground/", System.UriKind.Absolute);
            this.webBrowser1.WebBrowserShortcutsEnabled = false;
            // 
            // btn_website
            // 
            resources.ApplyResources(this.btn_website, "btn_website");
            this.btn_website.BackColor = System.Drawing.Color.White;
            this.btn_website.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_website.Name = "btn_website";
            this.btn_website.UseVisualStyleBackColor = false;
            this.btn_website.Click += new System.EventHandler(this.btn_website_Click);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btn_website);
            this.Controls.Add(this.btn_play);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_play;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button btn_website;
    }
}

