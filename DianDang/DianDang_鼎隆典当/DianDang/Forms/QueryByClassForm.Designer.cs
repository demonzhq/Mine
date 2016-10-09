using System.Windows.Forms;

namespace DianDang
{
    partial class QueryByClassForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("当品类别");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("件数");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("重量");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("金额");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("（1）期初在当", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("件数");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("重量");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("金额");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("（2）期初未清", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("件数");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("重量");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("金额");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("（3）期内已清", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("件数");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("重量");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("金额");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("（4）期内新建", new System.Windows.Forms.TreeNode[] {
            treeNode14,
            treeNode15,
            treeNode16});
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("件数");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("重量");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("金额");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("（5）期内赎当", new System.Windows.Forms.TreeNode[] {
            treeNode18,
            treeNode19,
            treeNode20});
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("件数");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("重量");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("金额");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("（6）期内续当", new System.Windows.Forms.TreeNode[] {
            treeNode22,
            treeNode23,
            treeNode24});
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("件数");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("重量");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("金额");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("（7）期内绝当", new System.Windows.Forms.TreeNode[] {
            treeNode26,
            treeNode27,
            treeNode28});
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("件数");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("重量");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("金额");
            System.Windows.Forms.TreeNode treeNode33 = new System.Windows.Forms.TreeNode("（8）期末在期", new System.Windows.Forms.TreeNode[] {
            treeNode30,
            treeNode31,
            treeNode32});
            System.Windows.Forms.TreeNode treeNode34 = new System.Windows.Forms.TreeNode("件数");
            System.Windows.Forms.TreeNode treeNode35 = new System.Windows.Forms.TreeNode("重量");
            System.Windows.Forms.TreeNode treeNode36 = new System.Windows.Forms.TreeNode("金额");
            System.Windows.Forms.TreeNode treeNode37 = new System.Windows.Forms.TreeNode("（9）期末过期", new System.Windows.Forms.TreeNode[] {
            treeNode34,
            treeNode35,
            treeNode36});
            System.Windows.Forms.TreeNode treeNode38 = new System.Windows.Forms.TreeNode("件数");
            System.Windows.Forms.TreeNode treeNode39 = new System.Windows.Forms.TreeNode("重量");
            System.Windows.Forms.TreeNode treeNode40 = new System.Windows.Forms.TreeNode("金额");
            System.Windows.Forms.TreeNode treeNode41 = new System.Windows.Forms.TreeNode("（10）期末在当", new System.Windows.Forms.TreeNode[] {
            treeNode38,
            treeNode39,
            treeNode40});
            System.Windows.Forms.TreeNode treeNode42 = new System.Windows.Forms.TreeNode("件数");
            System.Windows.Forms.TreeNode treeNode43 = new System.Windows.Forms.TreeNode("重量");
            System.Windows.Forms.TreeNode treeNode44 = new System.Windows.Forms.TreeNode("金额");
            System.Windows.Forms.TreeNode treeNode45 = new System.Windows.Forms.TreeNode("（11）期末未清", new System.Windows.Forms.TreeNode[] {
            treeNode42,
            treeNode43,
            treeNode44});
            System.Windows.Forms.TreeNode treeNode46 = new System.Windows.Forms.TreeNode("件数");
            System.Windows.Forms.TreeNode treeNode47 = new System.Windows.Forms.TreeNode("重量");
            System.Windows.Forms.TreeNode treeNode48 = new System.Windows.Forms.TreeNode("金额");
            System.Windows.Forms.TreeNode treeNode49 = new System.Windows.Forms.TreeNode("（12）期末库存", new System.Windows.Forms.TreeNode[] {
            treeNode46,
            treeNode47,
            treeNode48});
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.multiColHeaderDgv1 = new myMultiColHeaderDgv.MultiColHeaderDgv();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tbxEndDate = new System.Windows.Forms.TextBox();
            this.tbxStartDate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.btnPrint = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.multiColHeaderDgv1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.multiColHeaderDgv1);
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(802, 367);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "当品分类统计";
            // 
            // multiColHeaderDgv1
            // 
            this.multiColHeaderDgv1.AllowUserToAddRows = false;
            this.multiColHeaderDgv1.AllowUserToDeleteRows = false;
            this.multiColHeaderDgv1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.multiColHeaderDgv1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.multiColHeaderDgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.multiColHeaderDgv1.DefaultCellStyle = dataGridViewCellStyle2;
            this.multiColHeaderDgv1.EnableHeadersVisualStyles = false;
            this.multiColHeaderDgv1.Location = new System.Drawing.Point(6, 17);
            this.multiColHeaderDgv1.myColHeaderTreeView = this.treeView1;
            this.multiColHeaderDgv1.Name = "multiColHeaderDgv1";
            this.multiColHeaderDgv1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.multiColHeaderDgv1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.multiColHeaderDgv1.RowTemplate.Height = 23;
            this.multiColHeaderDgv1.Size = new System.Drawing.Size(790, 344);
            this.multiColHeaderDgv1.TabIndex = 0;
            this.multiColHeaderDgv1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.multiColHeaderDgv1_Scroll);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 412);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "NodeClass";
            treeNode1.Text = "当品类别";
            treeNode2.Name = "Node12";
            treeNode2.Text = "件数";
            treeNode3.Name = "Node13";
            treeNode3.Text = "重量";
            treeNode4.Name = "Node14";
            treeNode4.Text = "金额";
            treeNode5.Name = "Node0";
            treeNode5.Text = "（1）期初在当";
            treeNode6.Name = "Node15";
            treeNode6.Text = "件数";
            treeNode7.Name = "Node16";
            treeNode7.Text = "重量";
            treeNode8.Name = "Node18";
            treeNode8.Text = "金额";
            treeNode9.Name = "Node1";
            treeNode9.Text = "（2）期初未清";
            treeNode10.Name = "Node19";
            treeNode10.Text = "件数";
            treeNode11.Name = "Node20";
            treeNode11.Text = "重量";
            treeNode12.Name = "Node21";
            treeNode12.Text = "金额";
            treeNode13.Name = "Node2";
            treeNode13.Text = "（3）期内已清";
            treeNode14.Name = "Node22";
            treeNode14.Text = "件数";
            treeNode15.Name = "Node23";
            treeNode15.Text = "重量";
            treeNode16.Name = "Node24";
            treeNode16.Text = "金额";
            treeNode17.Name = "Node3";
            treeNode17.Text = "（4）期内新建";
            treeNode18.Name = "Node25";
            treeNode18.Text = "件数";
            treeNode19.Name = "Node26";
            treeNode19.Text = "重量";
            treeNode20.Name = "Node27";
            treeNode20.Text = "金额";
            treeNode21.Name = "Node4";
            treeNode21.Text = "（5）期内赎当";
            treeNode22.Name = "Node28";
            treeNode22.Text = "件数";
            treeNode23.Name = "Node29";
            treeNode23.Text = "重量";
            treeNode24.Name = "Node30";
            treeNode24.Text = "金额";
            treeNode25.Name = "Node5";
            treeNode25.Text = "（6）期内续当";
            treeNode26.Name = "Node31";
            treeNode26.Text = "件数";
            treeNode27.Name = "Node32";
            treeNode27.Text = "重量";
            treeNode28.Name = "Node33";
            treeNode28.Text = "金额";
            treeNode29.Name = "Node6";
            treeNode29.Text = "（7）期内绝当";
            treeNode30.Name = "Node34";
            treeNode30.Text = "件数";
            treeNode31.Name = "Node35";
            treeNode31.Text = "重量";
            treeNode32.Name = "Node36";
            treeNode32.Text = "金额";
            treeNode33.Name = "Node7";
            treeNode33.Text = "（8）期末在期";
            treeNode34.Name = "Node37";
            treeNode34.Text = "件数";
            treeNode35.Name = "Node38";
            treeNode35.Text = "重量";
            treeNode36.Name = "Node39";
            treeNode36.Text = "金额";
            treeNode37.Name = "Node8";
            treeNode37.Text = "（9）期末过期";
            treeNode38.Name = "Node40";
            treeNode38.Text = "件数";
            treeNode39.Name = "Node41";
            treeNode39.Text = "重量";
            treeNode40.Name = "Node42";
            treeNode40.Text = "金额";
            treeNode41.Name = "Node9";
            treeNode41.Text = "（10）期末在当";
            treeNode42.Name = "Node43";
            treeNode42.Text = "件数";
            treeNode43.Name = "Node44";
            treeNode43.Text = "重量";
            treeNode44.Name = "Node45";
            treeNode44.Text = "金额";
            treeNode45.Name = "Node10";
            treeNode45.Text = "（11）期末未清";
            treeNode46.Name = "Node46";
            treeNode46.Text = "件数";
            treeNode47.Name = "Node47";
            treeNode47.Text = "重量";
            treeNode48.Name = "Node48";
            treeNode48.Text = "金额";
            treeNode49.Name = "Node11";
            treeNode49.Text = "（12）期末库存";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode5,
            treeNode9,
            treeNode13,
            treeNode17,
            treeNode21,
            treeNode25,
            treeNode29,
            treeNode33,
            treeNode37,
            treeNode41,
            treeNode45,
            treeNode49});
            this.treeView1.Size = new System.Drawing.Size(173, 92);
            this.treeView1.TabIndex = 1;
            this.treeView1.Visible = false;
            // 
            // tbxEndDate
            // 
            this.tbxEndDate.Location = new System.Drawing.Point(316, 12);
            this.tbxEndDate.Name = "tbxEndDate";
            this.tbxEndDate.Size = new System.Drawing.Size(142, 21);
            this.tbxEndDate.TabIndex = 4;
            this.tbxEndDate.Click += new System.EventHandler(this.tbxEndDate_Click);
            // 
            // tbxStartDate
            // 
            this.tbxStartDate.Location = new System.Drawing.Point(84, 12);
            this.tbxStartDate.Name = "tbxStartDate";
            this.tbxStartDate.Size = new System.Drawing.Size(142, 21);
            this.tbxStartDate.TabIndex = 5;
            this.tbxStartDate.Click += new System.EventHandler(this.tbxStartDate_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(245, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "终止日期：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Location = new System.Drawing.Point(13, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "起始日期：";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(486, 10);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 7;
            this.btnQuery.Text = "统计";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(279, 161);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 27;
            this.monthCalendar1.TitleBackColor = System.Drawing.Color.SandyBrown;
            this.monthCalendar1.Visible = false;
            this.monthCalendar1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateSelected);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(733, 412);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 28;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 400;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // QueryByClassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 507);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.tbxEndDate);
            this.Controls.Add(this.tbxStartDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "QueryByClassForm";
            this.TabText = "当品分类统计";
            this.Text = "当品分类统计";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.multiColHeaderDgv1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxEndDate;
        private System.Windows.Forms.TextBox tbxStartDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private myMultiColHeaderDgv.MultiColHeaderDgv multiColHeaderDgv1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button btnPrint;
        private Timer timer1;
    }
}