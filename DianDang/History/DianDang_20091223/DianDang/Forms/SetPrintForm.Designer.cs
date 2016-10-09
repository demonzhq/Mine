namespace DianDang
{
    partial class SetPrintForm
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
            this.cbxPrintCreateTicket = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxPrintRedeemReceipt = new System.Windows.Forms.CheckBox();
            this.cbxPrintRenewTicket = new System.Windows.Forms.CheckBox();
            this.btnSet = new System.Windows.Forms.Button();
            this.cbxPrintPartRedeemReceipt = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxPrintCreateTicket
            // 
            this.cbxPrintCreateTicket.AutoSize = true;
            this.cbxPrintCreateTicket.Location = new System.Drawing.Point(78, 33);
            this.cbxPrintCreateTicket.Name = "cbxPrintCreateTicket";
            this.cbxPrintCreateTicket.Size = new System.Drawing.Size(132, 16);
            this.cbxPrintCreateTicket.TabIndex = 1;
            this.cbxPrintCreateTicket.Text = "建当时是否打印票据";
            this.cbxPrintCreateTicket.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxPrintPartRedeemReceipt);
            this.groupBox1.Controls.Add(this.cbxPrintRedeemReceipt);
            this.groupBox1.Controls.Add(this.cbxPrintRenewTicket);
            this.groupBox1.Controls.Add(this.cbxPrintCreateTicket);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(802, 129);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "打印设定";
            // 
            // cbxPrintRedeemReceipt
            // 
            this.cbxPrintRedeemReceipt.AutoSize = true;
            this.cbxPrintRedeemReceipt.Location = new System.Drawing.Point(78, 78);
            this.cbxPrintRedeemReceipt.Name = "cbxPrintRedeemReceipt";
            this.cbxPrintRedeemReceipt.Size = new System.Drawing.Size(132, 16);
            this.cbxPrintRedeemReceipt.TabIndex = 1;
            this.cbxPrintRedeemReceipt.Text = "赎当时是否打印票据";
            this.cbxPrintRedeemReceipt.UseVisualStyleBackColor = true;
            // 
            // cbxPrintRenewTicket
            // 
            this.cbxPrintRenewTicket.AutoSize = true;
            this.cbxPrintRenewTicket.Location = new System.Drawing.Point(418, 33);
            this.cbxPrintRenewTicket.Name = "cbxPrintRenewTicket";
            this.cbxPrintRenewTicket.Size = new System.Drawing.Size(132, 16);
            this.cbxPrintRenewTicket.TabIndex = 1;
            this.cbxPrintRenewTicket.Text = "续当时是否打印票据";
            this.cbxPrintRenewTicket.UseVisualStyleBackColor = true;
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(739, 147);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.TabIndex = 3;
            this.btnSet.Text = "保存设定";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // cbxPrintPartRedeemReceipt
            // 
            this.cbxPrintPartRedeemReceipt.AutoSize = true;
            this.cbxPrintPartRedeemReceipt.Location = new System.Drawing.Point(418, 78);
            this.cbxPrintPartRedeemReceipt.Name = "cbxPrintPartRedeemReceipt";
            this.cbxPrintPartRedeemReceipt.Size = new System.Drawing.Size(132, 16);
            this.cbxPrintPartRedeemReceipt.TabIndex = 1;
            this.cbxPrintPartRedeemReceipt.Text = "赎当时是否打印票据";
            this.cbxPrintPartRedeemReceipt.UseVisualStyleBackColor = true;
            // 
            // SetPrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 266);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "SetPrintForm";
            this.Text = "打印设定";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox cbxPrintCreateTicket;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbxPrintRenewTicket;
        private System.Windows.Forms.CheckBox cbxPrintRedeemReceipt;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.CheckBox cbxPrintPartRedeemReceipt;
    }
}