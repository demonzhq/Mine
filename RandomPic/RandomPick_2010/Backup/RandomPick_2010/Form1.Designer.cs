namespace RandomPick_2010
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAwardName = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblNextPage = new System.Windows.Forms.Label();
            this.lblPrePage = new System.Windows.Forms.Label();
            this.lblRoll = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.lblExit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft YaHei", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(209, 45);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(702, 72);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "2010年冠东公司春节联欢会";
            // 
            // lblAwardName
            // 
            this.lblAwardName.AutoSize = true;
            this.lblAwardName.BackColor = System.Drawing.Color.Transparent;
            this.lblAwardName.Font = new System.Drawing.Font("Microsoft YaHei", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAwardName.ForeColor = System.Drawing.Color.White;
            this.lblAwardName.Location = new System.Drawing.Point(55, 153);
            this.lblAwardName.Name = "lblAwardName";
            this.lblAwardName.Size = new System.Drawing.Size(183, 52);
            this.lblAwardName.TabIndex = 1;
            this.lblAwardName.Text = "三等奖：";
            // 
            // lblResult
            // 
            this.lblResult.BackColor = System.Drawing.Color.Transparent;
            this.lblResult.Font = new System.Drawing.Font("Microsoft YaHei", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblResult.ForeColor = System.Drawing.Color.White;
            this.lblResult.Location = new System.Drawing.Point(134, 224);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(183, 535);
            this.lblResult.TabIndex = 2;
            this.lblResult.Text = "三等奖：";
            // 
            // lblNextPage
            // 
            this.lblNextPage.AutoSize = true;
            this.lblNextPage.BackColor = System.Drawing.Color.Transparent;
            this.lblNextPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNextPage.Font = new System.Drawing.Font("Microsoft YaHei", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblNextPage.ForeColor = System.Drawing.Color.White;
            this.lblNextPage.Location = new System.Drawing.Point(806, 153);
            this.lblNextPage.Name = "lblNextPage";
            this.lblNextPage.Size = new System.Drawing.Size(183, 52);
            this.lblNextPage.TabIndex = 3;
            this.lblNextPage.Text = "下一奖项";
            this.lblNextPage.Click += new System.EventHandler(this.lblNextPage_Click);
            // 
            // lblPrePage
            // 
            this.lblPrePage.AutoSize = true;
            this.lblPrePage.BackColor = System.Drawing.Color.Transparent;
            this.lblPrePage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPrePage.Font = new System.Drawing.Font("Microsoft YaHei", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPrePage.ForeColor = System.Drawing.Color.White;
            this.lblPrePage.Location = new System.Drawing.Point(617, 153);
            this.lblPrePage.Name = "lblPrePage";
            this.lblPrePage.Size = new System.Drawing.Size(183, 52);
            this.lblPrePage.TabIndex = 3;
            this.lblPrePage.Text = "上一奖项";
            this.lblPrePage.Click += new System.EventHandler(this.lblPrePage_Click);
            // 
            // lblRoll
            // 
            this.lblRoll.AutoSize = true;
            this.lblRoll.BackColor = System.Drawing.Color.Transparent;
            this.lblRoll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRoll.Font = new System.Drawing.Font("Microsoft YaHei", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRoll.ForeColor = System.Drawing.Color.White;
            this.lblRoll.Location = new System.Drawing.Point(356, 153);
            this.lblRoll.Name = "lblRoll";
            this.lblRoll.Size = new System.Drawing.Size(183, 52);
            this.lblRoll.TabIndex = 4;
            this.lblRoll.Text = "开始抽奖";
            this.lblRoll.Click += new System.EventHandler(this.lblRoll_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // lblExit
            // 
            this.lblExit.AutoSize = true;
            this.lblExit.BackColor = System.Drawing.Color.Transparent;
            this.lblExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblExit.Font = new System.Drawing.Font("Microsoft YaHei", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExit.ForeColor = System.Drawing.Color.White;
            this.lblExit.Location = new System.Drawing.Point(920, 707);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(103, 52);
            this.lblExit.TabIndex = 5;
            this.lblExit.Text = "退出";
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.lblExit);
            this.Controls.Add(this.lblRoll);
            this.Controls.Add(this.lblPrePage);
            this.Controls.Add(this.lblNextPage);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblAwardName);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAwardName;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblNextPage;
        private System.Windows.Forms.Label lblPrePage;
        private System.Windows.Forms.Label lblRoll;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label lblExit;
    }
}

