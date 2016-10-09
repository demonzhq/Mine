namespace DianDang
{
    partial class CapturePicForm
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
            this.panelPreview = new System.Windows.Forms.Panel();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPic = new System.Windows.Forms.Button();
            this.picShow = new System.Windows.Forms.PictureBox();
            this.panelPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picShow)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPreview
            // 
            this.panelPreview.BackColor = System.Drawing.SystemColors.Control;
            this.panelPreview.Controls.Add(this.picShow);
            this.panelPreview.Location = new System.Drawing.Point(13, 13);
            this.panelPreview.Name = "panelPreview";
            this.panelPreview.Size = new System.Drawing.Size(359, 322);
            this.panelPreview.TabIndex = 0;
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(13, 355);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "播放";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.b_play_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(143, 355);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.b_stop_Click);
            // 
            // btnPic
            // 
            this.btnPic.Location = new System.Drawing.Point(288, 355);
            this.btnPic.Name = "btnPic";
            this.btnPic.Size = new System.Drawing.Size(75, 23);
            this.btnPic.TabIndex = 1;
            this.btnPic.Text = "抓图";
            this.btnPic.UseVisualStyleBackColor = true;
            this.btnPic.Click += new System.EventHandler(this.b_pic_Click);
            // 
            // picShow
            // 
            this.picShow.Location = new System.Drawing.Point(1, 2);
            this.picShow.Name = "picShow";
            this.picShow.Size = new System.Drawing.Size(355, 320);
            this.picShow.TabIndex = 0;
            this.picShow.TabStop = false;
            this.picShow.Visible = false;
            // 
            // CapturePicForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 434);
            this.Controls.Add(this.btnPic);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.panelPreview);
            this.Name = "CapturePicForm";
            this.Text = "拍摄当品";
            this.Load += new System.EventHandler(this.CapturePicForm_Load);
            this.panelPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picShow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPreview;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPic;
        private System.Windows.Forms.PictureBox picShow;
    }
}