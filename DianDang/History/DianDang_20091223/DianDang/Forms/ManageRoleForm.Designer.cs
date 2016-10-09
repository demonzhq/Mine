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
            this.treeModules = new System.Windows.Forms.TreeView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tbxRoleName = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.treeRoles = new System.Windows.Forms.TreeView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.treeModules);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.tbxRoleName);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.treeRoles);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(802, 588);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // treeModules
            // 
            this.treeModules.BackColor = System.Drawing.Color.White;
            this.treeModules.CheckBoxes = true;
            this.treeModules.Location = new System.Drawing.Point(274, 11);
            this.treeModules.Name = "treeModules";
            this.treeModules.Size = new System.Drawing.Size(507, 571);
            this.treeModules.TabIndex = 4;
            this.treeModules.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeModules_AfterCheck);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(18, 350);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "删除角色";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tbxRoleName
            // 
            this.tbxRoleName.Location = new System.Drawing.Point(18, 313);
            this.tbxRoleName.Name = "tbxRoleName";
            this.tbxRoleName.Size = new System.Drawing.Size(90, 21);
            this.tbxRoleName.TabIndex = 3;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(132, 350);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(88, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "更新权限";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // treeRoles
            // 
            this.treeRoles.BackColor = System.Drawing.Color.White;
            this.treeRoles.Location = new System.Drawing.Point(18, 14);
            this.treeRoles.Name = "treeRoles";
            this.treeRoles.Size = new System.Drawing.Size(202, 287);
            this.treeRoles.TabIndex = 0;
            this.treeRoles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeRoles_AfterSelect);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(132, 313);
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
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "ManageRoleForm";
            this.TabText = "权限管理";
            this.Text = "权限管理";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
    }
}