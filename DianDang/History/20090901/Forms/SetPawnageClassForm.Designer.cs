namespace DianDang
{
    partial class SetPawnageClassForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.treeClass = new System.Windows.Forms.TreeView();
            this.dgvClassInfo = new System.Windows.Forms.DataGridView();
            this.ClassID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParentClass = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.UnitName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.FeeRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InterestRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operation = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.treeClass);
            this.groupBox1.Controls.Add(this.dgvClassInfo);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(801, 384);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "类别设定";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(77, 351);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(547, 351);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(634, 351);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "更新所选";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(720, 351);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "删除所选";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // treeClass
            // 
            this.treeClass.Location = new System.Drawing.Point(6, 20);
            this.treeClass.Name = "treeClass";
            this.treeClass.Size = new System.Drawing.Size(146, 325);
            this.treeClass.TabIndex = 3;
            this.treeClass.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeClass_AfterSelect);
            // 
            // dgvClassInfo
            // 
            this.dgvClassInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClassInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClassID,
            this.ClassName,
            this.ParentClass,
            this.UnitName,
            this.FeeRate,
            this.InterestRate,
            this.Operation});
            this.dgvClassInfo.Location = new System.Drawing.Point(158, 20);
            this.dgvClassInfo.Name = "dgvClassInfo";
            this.dgvClassInfo.RowTemplate.Height = 23;
            this.dgvClassInfo.Size = new System.Drawing.Size(637, 325);
            this.dgvClassInfo.TabIndex = 2;
            this.dgvClassInfo.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvClassInfo_DataError);
            // 
            // ClassID
            // 
            this.ClassID.DataPropertyName = "ClassID";
            this.ClassID.HeaderText = "ClassID";
            this.ClassID.Name = "ClassID";
            this.ClassID.Visible = false;
            // 
            // ClassName
            // 
            this.ClassName.DataPropertyName = "ClassName";
            this.ClassName.HeaderText = "类别名称";
            this.ClassName.Name = "ClassName";
            // 
            // ParentClass
            // 
            this.ParentClass.DataPropertyName = "ParentID";
            this.ParentClass.HeaderText = "上级分类";
            this.ParentClass.Name = "ParentClass";
            this.ParentClass.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ParentClass.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // UnitName
            // 
            this.UnitName.DataPropertyName = "UnitID";
            this.UnitName.HeaderText = "计量单位";
            this.UnitName.Name = "UnitName";
            this.UnitName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.UnitName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // FeeRate
            // 
            this.FeeRate.DataPropertyName = "MonthFeeRate";
            this.FeeRate.HeaderText = "月费率";
            this.FeeRate.Name = "FeeRate";
            this.FeeRate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FeeRate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // InterestRate
            // 
            this.InterestRate.DataPropertyName = "InterestRate";
            this.InterestRate.HeaderText = "月利率";
            this.InterestRate.Name = "InterestRate";
            this.InterestRate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.InterestRate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Operation
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = false;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.Operation.DefaultCellStyle = dataGridViewCellStyle1;
            this.Operation.FalseValue = "0";
            this.Operation.HeaderText = "操作";
            this.Operation.Name = "Operation";
            this.Operation.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Operation.TrueValue = "1";
            this.Operation.Width = 94;
            // 
            // SetPawnageClassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 409);
            this.Controls.Add(this.groupBox1);
            this.Name = "SetPawnageClassForm";
            this.TabText = "当品类别设定";
            this.Text = "当品类别设定";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClassInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvClassInfo;
        private System.Windows.Forms.TreeView treeClass;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassName;
        private System.Windows.Forms.DataGridViewComboBoxColumn ParentClass;
        private System.Windows.Forms.DataGridViewComboBoxColumn UnitName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FeeRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn InterestRate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Operation;
    }
}