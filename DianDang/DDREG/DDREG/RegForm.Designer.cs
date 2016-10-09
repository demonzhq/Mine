namespace DDReg
{
    partial class RegForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxMachineCode = new System.Windows.Forms.TextBox();
            this.tbxRegCode = new System.Windows.Forms.TextBox();
            this.btnGetRegCode = new System.Windows.Forms.Button();
            this.btnReg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "»úÆ÷Âë£º";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "×¢²áÂë£º";
            // 
            // tbxMachineCode
            // 
            this.tbxMachineCode.Location = new System.Drawing.Point(189, 62);
            this.tbxMachineCode.Name = "tbxMachineCode";
            this.tbxMachineCode.Size = new System.Drawing.Size(212, 21);
            this.tbxMachineCode.TabIndex = 2;
            // 
            // tbxRegCode
            // 
            this.tbxRegCode.Location = new System.Drawing.Point(189, 98);
            this.tbxRegCode.Name = "tbxRegCode";
            this.tbxRegCode.Size = new System.Drawing.Size(212, 21);
            this.tbxRegCode.TabIndex = 2;
            // 
            // btnGetRegCode
            // 
            this.btnGetRegCode.Location = new System.Drawing.Point(189, 149);
            this.btnGetRegCode.Name = "btnGetRegCode";
            this.btnGetRegCode.Size = new System.Drawing.Size(75, 23);
            this.btnGetRegCode.TabIndex = 3;
            this.btnGetRegCode.Text = "»ñÈ¡×¢²áÂë";
            this.btnGetRegCode.UseVisualStyleBackColor = true;
            this.btnGetRegCode.Click += new System.EventHandler(this.btnGetRegCode_Click);
            // 
            // btnReg
            // 
            this.btnReg.Location = new System.Drawing.Point(326, 149);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(75, 23);
            this.btnReg.TabIndex = 3;
            this.btnReg.Text = "×¢²á";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // RegForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(572, 224);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.btnGetRegCode);
            this.Controls.Add(this.tbxRegCode);
            this.Controls.Add(this.tbxMachineCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RegForm";
            this.Text = "Èí¼þ×¢²á";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbxMachineCode;
        private System.Windows.Forms.TextBox tbxRegCode;
        private System.Windows.Forms.Button btnGetRegCode;
        private System.Windows.Forms.Button btnReg;
    }
}