namespace _160X_Ray
{
    partial class TimeSettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeSettingForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.setting_Minute = new System.Windows.Forms.NumericUpDown();
            this.btn_setting_OK = new System.Windows.Forms.Button();
            this.btn_setting_Cancel = new System.Windows.Forms.Button();
            this.Setting_Second = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.setting_Minute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Setting_Second)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "分";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Location = new System.Drawing.Point(116, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "秒";
            // 
            // setting_Minute
            // 
            this.setting_Minute.Location = new System.Drawing.Point(28, 24);
            this.setting_Minute.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.setting_Minute.Name = "setting_Minute";
            this.setting_Minute.Size = new System.Drawing.Size(44, 21);
            this.setting_Minute.TabIndex = 1;
            // 
            // btn_setting_OK
            // 
            this.btn_setting_OK.Location = new System.Drawing.Point(12, 51);
            this.btn_setting_OK.Name = "btn_setting_OK";
            this.btn_setting_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_setting_OK.TabIndex = 2;
            this.btn_setting_OK.Text = "确定";
            this.btn_setting_OK.UseVisualStyleBackColor = true;
            this.btn_setting_OK.Click += new System.EventHandler(this.btn_setting_OK_Click);
            // 
            // btn_setting_Cancel
            // 
            this.btn_setting_Cancel.Location = new System.Drawing.Point(93, 51);
            this.btn_setting_Cancel.Name = "btn_setting_Cancel";
            this.btn_setting_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_setting_Cancel.TabIndex = 3;
            this.btn_setting_Cancel.Text = "取消";
            this.btn_setting_Cancel.UseVisualStyleBackColor = true;
            this.btn_setting_Cancel.Click += new System.EventHandler(this.btn_setting_Cancel_Click);
            // 
            // Setting_Second
            // 
            this.Setting_Second.Location = new System.Drawing.Point(105, 24);
            this.Setting_Second.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.Setting_Second.Name = "Setting_Second";
            this.Setting_Second.Size = new System.Drawing.Size(44, 21);
            this.Setting_Second.TabIndex = 1;
            // 
            // TimeSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 85);
            this.ControlBox = false;
            this.Controls.Add(this.btn_setting_Cancel);
            this.Controls.Add(this.btn_setting_OK);
            this.Controls.Add(this.Setting_Second);
            this.Controls.Add(this.setting_Minute);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TimeSettingForm";
            this.ShowInTaskbar = false;
            this.Text = "设置延时时间";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.setting_Minute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Setting_Second)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown setting_Minute;
        private System.Windows.Forms.Button btn_setting_OK;
        private System.Windows.Forms.Button btn_setting_Cancel;
        private System.Windows.Forms.NumericUpDown Setting_Second;
    }
}