namespace DianDang
{
    partial class SearchHouseForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TicketNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompactNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Area = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegisterDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InsuranceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NotarizationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(802, 242);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "近期公正到期房产";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TicketNumber,
            this.CustomerName,
            this.Address,
            this.CompactNumber,
            this.Area,
            this.RegisterDate,
            this.InsuranceDate,
            this.NotarizationDate});
            this.dataGridView1.Location = new System.Drawing.Point(6, 20);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(790, 216);
            this.dataGridView1.TabIndex = 0;
            // 
            // TicketNumber
            // 
            this.TicketNumber.HeaderText = "当票号";
            this.TicketNumber.Name = "TicketNumber";
            this.TicketNumber.Width = 100;
            // 
            // CustomerName
            // 
            this.CustomerName.HeaderText = "客户姓名";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.Width = 80;
            // 
            // Address
            // 
            this.Address.HeaderText = "房产地址";
            this.Address.Name = "Address";
            this.Address.Width = 200;
            // 
            // CompactNumber
            // 
            this.CompactNumber.HeaderText = "合同号";
            this.CompactNumber.Name = "CompactNumber";
            // 
            // Area
            // 
            this.Area.HeaderText = "建筑面积";
            this.Area.Name = "Area";
            // 
            // RegisterDate
            // 
            this.RegisterDate.HeaderText = "登记到期日";
            this.RegisterDate.Name = "RegisterDate";
            this.RegisterDate.Width = 120;
            // 
            // InsuranceDate
            // 
            this.InsuranceDate.HeaderText = "保险到期日";
            this.InsuranceDate.Name = "InsuranceDate";
            this.InsuranceDate.Width = 120;
            // 
            // NotarizationDate
            // 
            this.NotarizationDate.HeaderText = "公正到期日";
            this.NotarizationDate.Name = "NotarizationDate";
            this.NotarizationDate.Width = 120;
            // 
            // SearchHouseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 266);
            this.Controls.Add(this.groupBox1);
            this.Name = "SearchHouseForm";
            this.TabText = "到期房产查询";
            this.Text = "到期房产查询";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TicketNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompactNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Area;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegisterDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn InsuranceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn NotarizationDate;
    }
}