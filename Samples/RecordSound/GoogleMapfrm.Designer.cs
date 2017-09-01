namespace RecordSound
{
    partial class GoogleMapfrm
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
            this.webBrowserGoogleMap = new System.Windows.Forms.WebBrowser();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // webBrowserGoogleMap
            // 
            this.webBrowserGoogleMap.Location = new System.Drawing.Point(12, 55);
            this.webBrowserGoogleMap.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserGoogleMap.Name = "webBrowserGoogleMap";
            this.webBrowserGoogleMap.Size = new System.Drawing.Size(1338, 820);
            this.webBrowserGoogleMap.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1185, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 37);
            this.button1.TabIndex = 1;
            this.button1.Text = "Close Map";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GoogleMapfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1376, 887);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.webBrowserGoogleMap);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "GoogleMapfrm";
            this.Text = "GoogleMapfrm";
            this.Load += new System.EventHandler(this.GoogleMapfrm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowserGoogleMap;
        private System.Windows.Forms.Button button1;
    }
}