namespace RecordSound
{
    partial class RecordSoundWithPcm
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
            this.components = new System.ComponentModel.Container();
            this.lblDisplayTime = new System.Windows.Forms.Label();
            this.BtnSaveStop = new System.Windows.Forms.Button();
            this.BtnStart = new System.Windows.Forms.Button();
            this.txtTranscript = new System.Windows.Forms.TextBox();
            this.StopWatchTimer = new System.Windows.Forms.Timer(this.components);
            this.lblWait = new System.Windows.Forms.Label();
            this.cmbLanguageCode = new System.Windows.Forms.ComboBox();
            this.showGooglemapBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDisplayTime
            // 
            this.lblDisplayTime.AutoSize = true;
            this.lblDisplayTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayTime.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDisplayTime.Location = new System.Drawing.Point(515, 87);
            this.lblDisplayTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDisplayTime.Name = "lblDisplayTime";
            this.lblDisplayTime.Size = new System.Drawing.Size(96, 17);
            this.lblDisplayTime.TabIndex = 9;
            this.lblDisplayTime.Text = "Stop Watch ";
            // 
            // BtnSaveStop
            // 
            this.BtnSaveStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSaveStop.Location = new System.Drawing.Point(395, 122);
            this.BtnSaveStop.Margin = new System.Windows.Forms.Padding(4);
            this.BtnSaveStop.Name = "BtnSaveStop";
            this.BtnSaveStop.Size = new System.Drawing.Size(351, 38);
            this.BtnSaveStop.TabIndex = 8;
            this.BtnSaveStop.Text = "Save/Stop";
            this.BtnSaveStop.UseVisualStyleBackColor = true;
            this.BtnSaveStop.Click += new System.EventHandler(this.BtnSaveStop_Click);
            // 
            // BtnStart
            // 
            this.BtnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnStart.Location = new System.Drawing.Point(395, 26);
            this.BtnStart.Margin = new System.Windows.Forms.Padding(4);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(351, 44);
            this.BtnStart.TabIndex = 7;
            this.BtnStart.Text = "Start";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // txtTranscript
            // 
            this.txtTranscript.Location = new System.Drawing.Point(16, 233);
            this.txtTranscript.Margin = new System.Windows.Forms.Padding(4);
            this.txtTranscript.Multiline = true;
            this.txtTranscript.Name = "txtTranscript";
            this.txtTranscript.Size = new System.Drawing.Size(749, 232);
            this.txtTranscript.TabIndex = 10;
            // 
            // StopWatchTimer
            // 
            this.StopWatchTimer.Enabled = true;
            this.StopWatchTimer.Interval = 50;
            this.StopWatchTimer.Tick += new System.EventHandler(this.StopWatchTimer_Tick);
            // 
            // lblWait
            // 
            this.lblWait.AutoSize = true;
            this.lblWait.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWait.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblWait.Location = new System.Drawing.Point(32, 191);
            this.lblWait.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWait.Name = "lblWait";
            this.lblWait.Size = new System.Drawing.Size(620, 39);
            this.lblWait.TabIndex = 11;
            this.lblWait.Text = "Processing your file, Please wait........";
            // 
            // cmbLanguageCode
            // 
            this.cmbLanguageCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbLanguageCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLanguageCode.FormattingEnabled = true;
            this.cmbLanguageCode.Location = new System.Drawing.Point(16, 26);
            this.cmbLanguageCode.Margin = new System.Windows.Forms.Padding(4);
            this.cmbLanguageCode.Name = "cmbLanguageCode";
            this.cmbLanguageCode.Size = new System.Drawing.Size(351, 33);
            this.cmbLanguageCode.TabIndex = 12;
            // 
            // showGooglemapBtn
            // 
            this.showGooglemapBtn.Location = new System.Drawing.Point(39, 87);
            this.showGooglemapBtn.Name = "showGooglemapBtn";
            this.showGooglemapBtn.Size = new System.Drawing.Size(148, 47);
            this.showGooglemapBtn.TabIndex = 13;
            this.showGooglemapBtn.Text = "Show Google map";
            this.showGooglemapBtn.UseVisualStyleBackColor = true;
            this.showGooglemapBtn.Click += new System.EventHandler(this.showGooglemapBtn_Click);
            // 
            // RecordSoundWithPcm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(784, 480);
            this.Controls.Add(this.showGooglemapBtn);
            this.Controls.Add(this.cmbLanguageCode);
            this.Controls.Add(this.lblWait);
            this.Controls.Add(this.txtTranscript);
            this.Controls.Add(this.lblDisplayTime);
            this.Controls.Add(this.BtnSaveStop);
            this.Controls.Add(this.BtnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "RecordSoundWithPcm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sound Record";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RecordSoundWithPcm_FormClosing);
            this.Load += new System.EventHandler(this.RecordSoundWithPcm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDisplayTime;
        internal System.Windows.Forms.Button BtnSaveStop;
        internal System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.TextBox txtTranscript;
        private System.Windows.Forms.Timer StopWatchTimer;
        private System.Windows.Forms.Label lblWait;
        private System.Windows.Forms.ComboBox cmbLanguageCode;
        private System.Windows.Forms.Button showGooglemapBtn;
    }
}