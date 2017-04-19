namespace _160X_Ray
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.niMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DisplayStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.isDisplaytoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mTimer = new System.Windows.Forms.Timer(this.components);
            this.MainMinute = new System.Windows.Forms.NumericUpDown();
            this.pnlSetting = new System.Windows.Forms.Panel();
            this.btnMainStop = new System.Windows.Forms.Button();
            this.btnMainOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.she = new System.Windows.Forms.Label();
            this.MainSecond = new System.Windows.Forms.NumericUpDown();
            this.cmsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainMinute)).BeginInit();
            this.pnlSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSecond)).BeginInit();
            this.SuspendLayout();
            // 
            // niMain
            // 
            this.niMain.ContextMenuStrip = this.cmsMain;
            this.niMain.Icon = ((System.Drawing.Icon)(resources.GetObject("niMain.Icon")));
            this.niMain.Text = "160X-Ray";
            this.niMain.Visible = true;
            this.niMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.niMain_MouseClick);
            // 
            // cmsMain
            // 
            this.cmsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingToolStripMenuItem,
            this.DisplayStripMenuItem,
            this.toolStripSeparator1,
            this.isDisplaytoolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.cmsMain.Name = "cmsMain";
            this.cmsMain.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cmsMain.Size = new System.Drawing.Size(137, 104);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.settingToolStripMenuItem.Text = "设置时间";
            this.settingToolStripMenuItem.Visible = false;
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // DisplayStripMenuItem
            // 
            this.DisplayStripMenuItem.Name = "DisplayStripMenuItem";
            this.DisplayStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.DisplayStripMenuItem.Text = "计时未开始";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // isDisplaytoolStripMenuItem
            // 
            this.isDisplaytoolStripMenuItem.Checked = true;
            this.isDisplaytoolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isDisplaytoolStripMenuItem.Name = "isDisplaytoolStripMenuItem";
            this.isDisplaytoolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.isDisplaytoolStripMenuItem.Text = "显示计时";
            this.isDisplaytoolStripMenuItem.Click += new System.EventHandler(this.isDisplaytoolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(133, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // mTimer
            // 
            this.mTimer.Interval = 1000;
            this.mTimer.Tick += new System.EventHandler(this.mTimer_Tick);
            // 
            // MainMinute
            // 
            this.MainMinute.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainMinute.Location = new System.Drawing.Point(50, 35);
            this.MainMinute.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.MainMinute.Name = "MainMinute";
            this.MainMinute.Size = new System.Drawing.Size(40, 23);
            this.MainMinute.TabIndex = 1;
            this.MainMinute.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // pnlSetting
            // 
            this.pnlSetting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlSetting.Controls.Add(this.btnMainStop);
            this.pnlSetting.Controls.Add(this.btnMainOK);
            this.pnlSetting.Controls.Add(this.label2);
            this.pnlSetting.Controls.Add(this.label1);
            this.pnlSetting.Controls.Add(this.she);
            this.pnlSetting.Controls.Add(this.MainSecond);
            this.pnlSetting.Controls.Add(this.MainMinute);
            this.pnlSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSetting.Location = new System.Drawing.Point(0, 0);
            this.pnlSetting.Name = "pnlSetting";
            this.pnlSetting.Size = new System.Drawing.Size(232, 111);
            this.pnlSetting.TabIndex = 2;
            // 
            // btnMainStop
            // 
            this.btnMainStop.Location = new System.Drawing.Point(118, 74);
            this.btnMainStop.Name = "btnMainStop";
            this.btnMainStop.Size = new System.Drawing.Size(75, 23);
            this.btnMainStop.TabIndex = 7;
            this.btnMainStop.Text = "停止测试";
            this.btnMainStop.UseVisualStyleBackColor = true;
            this.btnMainStop.Click += new System.EventHandler(this.btnMainStop_Click);
            // 
            // btnMainOK
            // 
            this.btnMainOK.Location = new System.Drawing.Point(37, 74);
            this.btnMainOK.Name = "btnMainOK";
            this.btnMainOK.Size = new System.Drawing.Size(75, 23);
            this.btnMainOK.TabIndex = 6;
            this.btnMainOK.Text = "开始测试";
            this.btnMainOK.UseVisualStyleBackColor = true;
            this.btnMainOK.Click += new System.EventHandler(this.btnMainOK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(172, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "秒";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(96, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "分";
            // 
            // she
            // 
            this.she.AutoSize = true;
            this.she.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.she.Location = new System.Drawing.Point(56, 7);
            this.she.Name = "she";
            this.she.Size = new System.Drawing.Size(119, 14);
            this.she.TabIndex = 3;
            this.she.Text = "设置延时关闭时间";
            // 
            // MainSecond
            // 
            this.MainSecond.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainSecond.Location = new System.Drawing.Point(123, 35);
            this.MainSecond.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.MainSecond.Name = "MainSecond";
            this.MainSecond.Size = new System.Drawing.Size(43, 23);
            this.MainSecond.TabIndex = 2;
            this.MainSecond.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 111);
            this.Controls.Add(this.pnlSetting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "160X-Ray";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.cmsMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainMinute)).EndInit();
            this.pnlSetting.ResumeLayout(false);
            this.pnlSetting.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSecond)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon niMain;
        private System.Windows.Forms.ContextMenuStrip cmsMain;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DisplayStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Timer mTimer;
        private System.Windows.Forms.ToolStripMenuItem isDisplaytoolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.NumericUpDown MainMinute;
        private System.Windows.Forms.Panel pnlSetting;
        private System.Windows.Forms.Label she;
        private System.Windows.Forms.NumericUpDown MainSecond;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMainOK;
        private System.Windows.Forms.Button btnMainStop;
    }
}

