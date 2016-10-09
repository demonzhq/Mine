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
            System.Windows.Forms.TreeNode treeNode99 = new System.Windows.Forms.TreeNode("当品类别");
            System.Windows.Forms.TreeNode treeNode100 = new System.Windows.Forms.TreeNode("件数");
            System.Windows.Forms.TreeNode treeNode101 = new System.Windows.Forms.TreeNode("重量");
            System.Windows.Forms.TreeNode treeNode102 = new System.Windows.Forms.TreeNode("金额");
            System.Windows.Forms.TreeNode treeNode103 = new System.Windows.Forms.TreeNode("（1）期初在当", new System.Windows.Forms.TreeNode[] {
            treeNode100,
            treeNode101,
            treeNode102});
            System.Windows.Forms.TreeNode treeNode104 = new System.Windows.Forms.TreeNode("件数");
            System.Windows.Forms.TreeNode treeNode105 = new System.Windows.Forms.TreeNode("重量");
            System.Windows.Forms.TreeNode treeNode106 = new System.Windows.Forms.TreeNode("金额");
            System.Windows.Forms.TreeNode treeNode107 = new System.Windows.Forms.TreeNode("（2）期初未清", new System.Windows.Forms.TreeNode[] {
            treeNode104,
            treeNode105,
            treeNode106});
            System.Windows.Forms.TreeNode treeNode108 = new System.Windows.Forms.TreeNode("件数");
            System.Windows.Forms.TreeNode treeNode109 = new System.Windows.Forms.TreeNode("重量");
            System.Windows.Forms.TreeNode treeNode110 = new System.Windows.Forms.TreeNode("金额");
            System.Windows.Forms.TreeNode treeNode111 = new System.Windows.Forms.TreeNode("（3）期内已清", new System.Windows.Forms.TreeNode[] {
            treeNode108,
            treeNode109,
            treeNode110});
            System.Windows.Forms.TreeNode treeNode112 = new System.Windows.Forms.TreeNode("件数");
            System.Windows.Forms.TreeNode treeNode113 = new System.Windows.Forms.TreeNode("重量");
            System.Windows.Forms.TreeNode treeNode114 = new System.Windows.Forms.TreeNode("金额");
            System.Windows.Forms.TreeNode treeNode115 = new System.Windows.Forms.TreeNode("（4）期内新建", new System.Windows.Forms.TreeNode[] {
            treeNode112,
            treeNode113,
            treeNode114});
            System.Windows.Forms.TreeNode treeNode116 = new System.Windows.Forms.TreeNode("件数");
            System.Windows.Forms.TreeNode treeNode117 = new System.Windows.Forms.TreeNode("重量");
            System.Windows.Forms.TreeNode treeNode118 = new System.Windows.Forms.TreeNode("金额");
            System.Windows.Forms.TreeNode treeNode119 = new System.Windows.Forms.TreeNode("（5）期内赎当", new System.Windows.Forms.TreeNode[] {
            treeNode116,
            treeNode117,
            treeNode118});
            System.Windows.Forms.TreeNode treeNode120 = new System.Windows.Forms.TreeNode("件数");
            System.Windows.Forms.TreeNode treeNode121 = new System.Windows.Forms.TreeNode("重量");
            System.Windows.Forms.TreeNode treeNode122 = new System.Windows.Forms.TreeNode("金额");
            System.Windows.Forms.TreeNode treeNode123 = new System.Windows.Forms.TreeNode("（6）期内续当", new System.Windows.Forms.TreeNode[] {
            treeNode120,
            treeNode121,
            treeNode122});
            System.Windows.Forms.TreeNode treeNode124 = new System.Windows.Forms.TreeNode("件数");
            System.Windows.Forms.TreeNode treeNode125 = new System.Windows.Forms.TreeNode("重量");
            System.Windows.Forms.TreeNode treeNode126 = new System.Windows.Forms.TreeNode("金额");
            System.Windows.Forms.TreeNode treeNode127 = new System.Windows.Forms.TreeNode("（7）期内绝当", new System.Windows.Forms.TreeNode[] {
            treeNode124,
            treeNode125,
            treeNode126});
            System.Windows.Forms.TreeNode treeNode128 = new System.Windows.Forms.TreeNode("件数");
            System.Windows.Forms.TreeNode treeNode129 = new System.Windows.Forms.TreeNode("重量");
            System.Windows.Forms.TreeNode treeNode130 = new System.Windows.Forms.TreeNode("金额");
            System.Windows.Forms.TreeNode treeNode131 = new System.Windows.Forms.TreeNode("（8）期末在期", new System.Windows.Forms.TreeNode[] {
            treeNode128,
            treeNode129,
            treeNode130});
            System.Windows.Forms.TreeNode treeNode132 = new System.Windows.Forms.TreeNode("件数");
            System.Windows.Forms.TreeNode treeNode133 = new System.Windows.Forms.TreeNode("重量");
            System.Windows.Forms.TreeNode treeNode134 = new System.Windows.Forms.TreeNode("金额");
            System.Windows.Forms.TreeNode treeNode135 = new System.Windows.Forms.TreeNode("（9）期末过期", new System.Windows.Forms.TreeNode[] {
            treeNode132,
            treeNode133,
            treeNode134});
            System.Windows.Forms.TreeNode treeNode136 = new System.Windows.Forms.TreeNode("件数");
            System.Windows.Forms.TreeNode treeNode137 = new System.Windows.Forms.TreeNode("重量");
            System.Windows.Forms.TreeNode treeNode138 = new System.Windows.Forms.TreeNode("金额");
            System.Windows.Forms.TreeNode treeNode139 = new System.Windows.Forms.TreeNode("（10）期末在当", new System.Windows.Forms.TreeNode[] {
            treeNode136,
            treeNode137,
            treeNode138});
            System.Windows.Forms.TreeNode treeNode140 = new System.Windows.Forms.TreeNode("件数");
            System.Windows.Forms.TreeNode treeNode141 = new System.Windows.Forms.TreeNode("重量");
            System.Windows.Forms.TreeNode treeNode142 = new System.Windows.Forms.TreeNode("金额");
            System.Windows.Forms.TreeNode treeNode143 = new System.Windows.Forms.TreeNode("（11）期末未清", new System.Windows.Forms.TreeNode[] {
            treeNode140,
            treeNode141,
            treeNode142});
            System.Windows.Forms.TreeNode treeNode144 = new System.Windows.Forms.TreeNode("件数");
            System.Windows.Forms.TreeNode treeNode145 = new System.Windows.Forms.TreeNode("重量");
            System.Windows.Forms.TreeNode treeNode146 = new System.Windows.Forms.TreeNode("金额");
            System.Windows.Forms.TreeNode treeNode147 = new System.Windows.Forms.TreeNode("（12）期末库存", new System.Windows.Forms.TreeNode[] {
            treeNode144,
            treeNode145,
            treeNode146});
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
            this.MyPrintDocument = new System.Drawing.Printing.PrintDocument();
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
            treeNode99.Name = "NodeClass";
            treeNode99.Text = "当品类别";
            treeNode100.Name = "Node12";
            treeNode100.Text = "件数";
            treeNode101.Name = "Node13";
            treeNode101.Text = "重量";
            treeNode102.Name = "Node14";
            treeNode102.Text = "金额";
            treeNode103.Name = "Node0";
            treeNode103.Text = "（1）期初在当";
            treeNode104.Name = "Node15";
            treeNode104.Text = "件数";
            treeNode105.Name = "Node16";
            treeNode105.Text = "重量";
            treeNode106.Name = "Node18";
            treeNode106.Text = "金额";
            treeNode107.Name = "Node1";
            treeNode107.Text = "（2）期初未清";
            treeNode108.Name = "Node19";
            treeNode108.Text = "件数";
            treeNode109.Name = "Node20";
            treeNode109.Text = "重量";
            treeNode110.Name = "Node21";
            treeNode110.Text = "金额";
            treeNode111.Name = "Node2";
            treeNode111.Text = "（3）期内已清";
            treeNode112.Name = "Node22";
            treeNode112.Text = "件数";
            treeNode113.Name = "Node23";
            treeNode113.Text = "重量";
            treeNode114.Name = "Node24";
            treeNode114.Text = "金额";
            treeNode115.Name = "Node3";
            treeNode115.Text = "（4）期内新建";
            treeNode116.Name = "Node25";
            treeNode116.Text = "件数";
            treeNode117.Name = "Node26";
            treeNode117.Text = "重量";
            treeNode118.Name = "Node27";
            treeNode118.Text = "金额";
            treeNode119.Name = "Node4";
            treeNode119.Text = "（5）期内赎当";
            treeNode120.Name = "Node28";
            treeNode120.Text = "件数";
            treeNode121.Name = "Node29";
            treeNode121.Text = "重量";
            treeNode122.Name = "Node30";
            treeNode122.Text = "金额";
            treeNode123.Name = "Node5";
            treeNode123.Text = "（6）期内续当";
            treeNode124.Name = "Node31";
            treeNode124.Text = "件数";
            treeNode125.Name = "Node32";
            treeNode125.Text = "重量";
            treeNode126.Name = "Node33";
            treeNode126.Text = "金额";
            treeNode127.Name = "Node6";
            treeNode127.Text = "（7）期内绝当";
            treeNode128.Name = "Node34";
            treeNode128.Text = "件数";
            treeNode129.Name = "Node35";
            treeNode129.Text = "重量";
            treeNode130.Name = "Node36";
            treeNode130.Text = "金额";
            treeNode131.Name = "Node7";
            treeNode131.Text = "（8）期末在期";
            treeNode132.Name = "Node37";
            treeNode132.Text = "件数";
            treeNode133.Name = "Node38";
            treeNode133.Text = "重量";
            treeNode134.Name = "Node39";
            treeNode134.Text = "金额";
            treeNode135.Name = "Node8";
            treeNode135.Text = "（9）期末过期";
            treeNode136.Name = "Node40";
            treeNode136.Text = "件数";
            treeNode137.Name = "Node41";
            treeNode137.Text = "重量";
            treeNode138.Name = "Node42";
            treeNode138.Text = "金额";
            treeNode139.Name = "Node9";
            treeNode139.Text = "（10）期末在当";
            treeNode140.Name = "Node43";
            treeNode140.Text = "件数";
            treeNode141.Name = "Node44";
            treeNode141.Text = "重量";
            treeNode142.Name = "Node45";
            treeNode142.Text = "金额";
            treeNode143.Name = "Node10";
            treeNode143.Text = "（11）期末未清";
            treeNode144.Name = "Node46";
            treeNode144.Text = "件数";
            treeNode145.Name = "Node47";
            treeNode145.Text = "重量";
            treeNode146.Name = "Node48";
            treeNode146.Text = "金额";
            treeNode147.Name = "Node11";
            treeNode147.Text = "（12）期末库存";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode99,
            treeNode103,
            treeNode107,
            treeNode111,
            treeNode115,
            treeNode119,
            treeNode123,
            treeNode127,
            treeNode131,
            treeNode135,
            treeNode139,
            treeNode143,
            treeNode147});
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
            // MyPrintDocument
            // 
            this.MyPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.MyPrintDocument_PrintPage);
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
        private System.Drawing.Printing.PrintDocument MyPrintDocument;
        private Timer timer1;
    }
}