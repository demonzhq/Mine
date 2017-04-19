namespace TestForm
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
            this.SSFooter = new System.Windows.Forms.StatusStrip();
            this.FooterLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbxData = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SSFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // SSFooter
            // 
            this.SSFooter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FooterLabel});
            this.SSFooter.Location = new System.Drawing.Point(0, 437);
            this.SSFooter.Name = "SSFooter";
            this.SSFooter.Size = new System.Drawing.Size(749, 22);
            this.SSFooter.TabIndex = 0;
            this.SSFooter.Text = "statusStrip1";
            // 
            // FooterLabel
            // 
            this.FooterLabel.Name = "FooterLabel";
            this.FooterLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // tbxData
            // 
            this.tbxData.Location = new System.Drawing.Point(12, 12);
            this.tbxData.Multiline = true;
            this.tbxData.Name = "tbxData";
            this.tbxData.Size = new System.Drawing.Size(354, 350);
            this.tbxData.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(596, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(596, 97);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 459);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbxData);
            this.Controls.Add(this.SSFooter);
            this.Name = "Form1";
            this.Text = "Form1";
            this.SSFooter.ResumeLayout(false);
            this.SSFooter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip SSFooter;
        private System.Windows.Forms.ToolStripStatusLabel FooterLabel;
        private System.Windows.Forms.TextBox tbxData;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

