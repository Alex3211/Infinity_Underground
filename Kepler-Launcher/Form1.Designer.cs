namespace Kepler_Launcher
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
            this.btn_website = new System.Windows.Forms.Button();
            this.btn_newParty = new System.Windows.Forms.Button();
            this.btn_loadSave = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btn_website
            // 
            this.btn_website.Location = new System.Drawing.Point(625, 12);
            this.btn_website.Name = "btn_website";
            this.btn_website.Size = new System.Drawing.Size(170, 67);
            this.btn_website.TabIndex = 0;
            this.btn_website.Text = "Website";
            this.btn_website.UseVisualStyleBackColor = true;
            this.btn_website.Click += new System.EventHandler(this.btn_website_Click);
            // 
            // btn_newParty
            // 
            this.btn_newParty.Location = new System.Drawing.Point(12, 12);
            this.btn_newParty.Name = "btn_newParty";
            this.btn_newParty.Size = new System.Drawing.Size(170, 67);
            this.btn_newParty.TabIndex = 1;
            this.btn_newParty.Text = "New Party";
            this.btn_newParty.UseVisualStyleBackColor = true;
            this.btn_newParty.Click += new System.EventHandler(this.btn_newParty_Click);
            // 
            // btn_loadSave
            // 
            this.btn_loadSave.Location = new System.Drawing.Point(309, 12);
            this.btn_loadSave.Name = "btn_loadSave";
            this.btn_loadSave.Size = new System.Drawing.Size(170, 67);
            this.btn_loadSave.TabIndex = 2;
            this.btn_loadSave.Text = "Load Save";
            this.btn_loadSave.UseVisualStyleBackColor = true;
            this.btn_loadSave.Click += new System.EventHandler(this.btn_loadSave_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 97);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(783, 23);
            this.progressBar.TabIndex = 3;
            this.progressBar.Click += new System.EventHandler(this.progressBar_Click);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 29;
            this.listBox1.Items.AddRange(new object[] {
            "SAVE 1",
            "SAVE 2",
            "SAVE 3",
            "SAVE 4",
            "SAVE 5",
            "SAVE 6",
            "SAVE 7",
            "SAVE 8",
            "SAVE 9",
            "SAVE 10"});
            this.listBox1.Location = new System.Drawing.Point(13, 170);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(782, 294);
            this.listBox1.TabIndex = 4;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 491);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btn_loadSave);
            this.Controls.Add(this.btn_newParty);
            this.Controls.Add(this.btn_website);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_website;
        private System.Windows.Forms.Button btn_newParty;
        private System.Windows.Forms.Button btn_loadSave;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ListBox listBox1;
    }
}

