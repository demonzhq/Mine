namespace DianDang
{
    partial class ManageRoleForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxAmountLimit = new System.Windows.Forms.TextBox();
            this.tbxRoleName = new System.Windows.Forms.TextBox();
            this.treeModules = new System.Windows.Forms.TreeView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.treeRoles = new System.Windows.Forms.TreeView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.treeModules);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.treeRoles);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(802, 588);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tbxAmountLimit);
            this.groupBox2.Controls.Add(this.tbxRoleName);
            this.groupBox2.Location = new System.Drawing.Point(24, 307);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(278, 100);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "详情";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "金额限制";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "角色名称";
            // 
            // tbxAmountLimit
            // 
            this.tbxAmountLimit.Location = new System.Drawing.Point(86, 61);
            this.tbxAmountLimit.Name = "tbxAmountLimit";
            this.tbxAmountLimit.Size = new System.Drawing.Size(142, 21);
            this.tbxAmountLimit.TabIndex = 3;
            // 
            // tbxRoleName
            // 
            this.tbxRoleName.Location = new System.Drawing.Point(86, 26);
            this.tbxRoleName.Name = "tbxRoleName";
            this.tbxRoleName.Size = new System.Drawing.Size(142, 21);
            this.tbxRoleName.TabIndex = 3;
            // 
            // treeModules
            // 
            this.treeModules.BackColor = System.Drawing.Color.White;
            this.treeModules.CheckBoxes = true;
            this.treeModules.Location = new System.Drawing.Point(335, 11);
            this.treeModules.Name = "treeModules";
            this.treeModules.Size = new System.Drawing.Size(446, 571);
            this.treeModules.TabIndex = 4;
            this.treeModules.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeModules_AfterCheck);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(118, 434);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "删除角色";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(214, 434);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(88, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // treeRoles
            // 
            this.treeRoles.BackColor = System.Drawing.Color.White;
            this.treeRoles.Location = new System.Drawing.Point(18, 14);
            this.treeRoles.Name = "treeRoles";
            this.treeRoles.Size = new System.Drawing.Size(284, 287);
            this.treeRoles.TabIndex = 0;
            this.treeRoles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeRoles_AfterSelect);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(24, 434);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(88, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "添加新角色";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ManageRoleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 606);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "ManageRoleForm";
            this.TabText = "权限管理";
            this.Text = "权限管理";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView treeRoles;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox tbxRoleName;
        private System.Windows.Forms.TreeView treeModules;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxAmountLimit;
    }
}