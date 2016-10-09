using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using SubSonic;
using ZedGraph;

namespace DianDang
{
    public partial class QueryByTakingForm : DockContent
    {
        private int Type = 0;
        private int m_ClassType;
        public QueryByTakingForm(int type)
        {
            InitializeComponent();
            InitTabText(type);
            InitClassTable();
            Type = type;
        }

        DataTable m_ClassTakingTable = new DataTable();
        private void InitClassTable()
        {            
            //set columns names
            m_ClassTakingTable.Columns.Add("ClassName", typeof(System.String));
            m_ClassTakingTable.Columns.Add("ServiceFee", typeof(System.String));
            m_ClassTakingTable.Columns.Add("ReturnFee", typeof(System.String));
            m_ClassTakingTable.Columns.Add("OverdueFee", typeof(System.String));
            m_ClassTakingTable.Columns.Add("InterestFee", typeof(System.String));
            m_ClassTakingTable.Columns.Add("TotalFee", typeof(System.String));
            m_ClassTakingTable.Columns.Add("ReckoningPL", typeof(System.String));
        }

        private void InitStandardTakingClassSource()
        {
            DateTime startDate = Convert.ToDateTime(this.tbxStartDate.Text.Trim());
            DateTime endDate = Convert.ToDateTime(this.tbxEndDate.Text.Trim());

            Query queryClass=new Query(DDPawnageClass.Schema);
            queryClass.AddWhere("ParentID",0);
            DataTable dtClass=queryClass.ExecuteDataSet().Tables[0];
            if(dtClass.Rows.Count>0)
            {
                int parentClassID;
                string parentClassName;
                double serviceFee = 0;
                double returnFee = 0;
                double overdueFee = 0;
                double interestFee = 0;
                double totalFee = 0;
                double reckonPL = 0;
               
                int operationType=0;
                for(int i=0;i<dtClass.Rows.Count;i++)
                {
                    parentClassID=Convert.ToInt32(dtClass.Rows[i]["ClassID"]);
                    parentClassName=dtClass.Rows[i]["ClassName"].ToString();
                    serviceFee = 0;
                    returnFee = 0;
                    overdueFee = 0;
                    interestFee = 0;
                    totalFee = 0;
                    reckonPL = 0;

                    Query query = new Query(DDPawnageInfo.Schema);
                    query.AddWhere("ParentID",parentClassID);                    
                    DataTable dt = query.ExecuteDataSet().Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            Query queryOperation = new Query(DDOperation.Schema);
                            queryOperation.AddBetweenAnd("OperationDate", startDate, endDate);
                            queryOperation.AddWhere("PawnageID",Convert.ToInt32(dt.Rows[j]["PawnageID"]));
                            DataTable dtOperation = queryOperation.ExecuteDataSet().Tables[0];
                            if (dtOperation.Rows.Count > 0)
                            {
                                for (int k = 0; k < dtOperation.Rows.Count; k++)
                                {
                                    operationType=Convert.ToInt32(dtOperation.Rows[k]["OperationType"]);
                                    if (operationType == 1 || operationType == 2 || operationType == 3)
                                    {
                                        serviceFee += Convert.ToDouble(dtOperation.Rows[k]["ServiceFee"]);
                                        returnFee += Convert.ToDouble(dtOperation.Rows[k]["ReturnFee"]);
                                        overdueFee += Convert.ToDouble(dtOperation.Rows[k]["OverdueFee"]);
                                        interestFee += Convert.ToDouble(dtOperation.Rows[k]["InterestFee"]);
                                    }
                                    if (operationType == 7)
                                    {
                                        reckonPL =Convert.ToDouble(dtOperation.Rows[k]["ReckonAmount"])-Convert.ToDouble(dtOperation.Rows[k]["Amount"]);
                                    }
                                }
                            }
                        }
                        totalFee = serviceFee - returnFee + overdueFee + interestFee;                        
                    }

                    DataRow drow = m_ClassTakingTable.NewRow();
                    drow["ClassName"] = parentClassName;
                    drow["ServiceFee"] = serviceFee;
                    drow["ReturnFee"] = returnFee;
                    drow["OverdueFee"] = overdueFee;
                    drow["InterestFee"] = interestFee;
                    drow["TotalFee"] = totalFee;
                    drow["ReckoningPL"] = reckonPL;
                    m_ClassTakingTable.Rows.Add(drow);
                }
            }
        }

        private void InitStatisticTakingClassSource()
        {
            DateTime startDate = Convert.ToDateTime(this.tbxStartDate.Text.Trim());
            DateTime endDate = Convert.ToDateTime(this.tbxEndDate.Text.Trim());

            Query queryStatisticClass = new Query(DDStatisticClass.Schema);
            DataTable dtStatisticClass = queryStatisticClass.ExecuteDataSet().Tables[0];
            if (dtStatisticClass.Rows.Count > 0)
            {
                int statisticClassID;
                string statisticClassName;
                int parentClassID;
                double serviceFee = 0;
                double returnFee = 0;
                double overdueFee = 0;
                double interestFee = 0;
                double totalFee = 0;
                double reckonPL = 0;

                for(int k=0;k<dtStatisticClass.Rows.Count;k++)
                {
                    statisticClassID=Convert.ToInt32(dtStatisticClass.Rows[k]["ClassID"]);
                    statisticClassName = dtStatisticClass.Rows[k]["ClassName"].ToString(); 
                    serviceFee = 0;
                    returnFee = 0;
                    overdueFee = 0;
                    interestFee = 0;
                    totalFee = 0;
                    reckonPL = 0;

                    int operationType = 0;

                    Query queryClass = new Query(DDPawnageClass.Schema);
                    queryClass.AddWhere("StatisticClassID", statisticClassID);
                    DataTable dtClass = queryClass.ExecuteDataSet().Tables[0];
                    
                    if (dtClass.Rows.Count > 0)
                    {
                        for (int i = 0; i < dtClass.Rows.Count; i++)
                        {
                            parentClassID = Convert.ToInt32(dtClass.Rows[i]["ClassID"]);          
                            Query query = new Query(DDPawnageInfo.Schema);
                            query.AddWhere("ParentID", parentClassID);
                            DataTable dt = query.ExecuteDataSet().Tables[0];
                            if (dt.Rows.Count > 0)
                            {
                                for (int j = 0; j < dt.Rows.Count; j++)
                                {
                                    Query queryOperation = new Query(DDOperation.Schema);
                                    queryOperation.AddBetweenAnd("OperationDate", startDate, endDate);
                                    queryOperation.AddWhere("PawnageID", Convert.ToInt32(dt.Rows[j]["PawnageID"]));
                                    DataTable dtOperation = queryOperation.ExecuteDataSet().Tables[0];
                                    if (dtOperation.Rows.Count > 0)
                                    {
                                        for (int m = 0; m < dtOperation.Rows.Count; m++)
                                        {
                                            operationType = Convert.ToInt32(dtOperation.Rows[m]["OperationType"]);
                                            if (operationType == 1 || operationType == 2 || operationType == 3)
                                            {
                                                serviceFee += Convert.ToDouble(dtOperation.Rows[m]["ServiceFee"]);
                                                returnFee += Convert.ToDouble(dtOperation.Rows[m]["ReturnFee"]);
                                                overdueFee += Convert.ToDouble(dtOperation.Rows[m]["OverdueFee"]);
                                                interestFee += Convert.ToDouble(dtOperation.Rows[m]["InterestFee"]);
                                            }
                                            if (operationType == 7)
                                            {
                                                reckonPL = Convert.ToDouble(dtOperation.Rows[m]["ReckonAmount"]) - Convert.ToDouble(dtOperation.Rows[m]["Amount"]);
                                            }
                                        }
                                    }
                                }
                                totalFee = serviceFee - returnFee + overdueFee + interestFee;
                            }
                        }
                    }
                    DataRow drow = m_ClassTakingTable.NewRow();
                    drow["ClassName"] = statisticClassName;
                    drow["ServiceFee"] = serviceFee;
                    drow["ReturnFee"] = returnFee;
                    drow["OverdueFee"] = overdueFee;
                    drow["InterestFee"] = interestFee;
                    drow["TotalFee"] = totalFee;
                    drow["ReckoningPL"] = reckonPL;
                    m_ClassTakingTable.Rows.Add(drow);
                }
            }
        }

        private void InitTabText(int type)
        {
            m_ClassType = type;
            switch (type)
            {
                case 0:
                    this.TabText = "营收标准分类统计";
                    this.Text = "营收标准分类统计";
                    break;
                case 1:
                    this.TabText = "营收统计分类统计";
                    this.Text = "营收统计分类统计";
                    break;
                default:
                    break;
            }
        }

        private int textBoxNumber;

        private void tbxStartDate_Click(object sender, EventArgs e)
        {
            textBoxNumber = 1;
            this.monthCalendar1.Visible = true;
        }

        private void tbxEndDate_Click(object sender, EventArgs e)
        {
            textBoxNumber = 2;
            this.monthCalendar1.Visible = true;
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            //将用户在MonthCalendar上点击的坐标转换程用户区坐标，并根据坐标获得点击类型
            string s = System.Convert.ToString(monthCalendar1.HitTest(this.PointToClient(MonthCalendar.MousePosition)).HitArea);

            string _year, _month, _day, _date;
            //如果用户点中了日期则对文本框进行赋值并退出
            if (s.Equals("Nowhere"))
            {
                //以下记录选中的日期的各个值
                _year = System.Convert.ToString(e.Start.Year);
                _month = System.Convert.ToString(e.Start.Month);
                _day = System.Convert.ToString(e.Start.Day);
                _date = _year + "-" + _month + "-" + _day;
                switch (textBoxNumber)
                {
                    case 1:
                        this.tbxStartDate.Text = _date;
                        break;
                    case 2:
                        this.tbxEndDate.Text = _date;
                        break;
                    default:
                        break;
                }
                //如果选中日期就自动隐藏MonthCalendar控件
                monthCalendar1.Hide();
            }
        }

        private void ClearDataGridView()
        {
            for (int i = dataGridView1.Rows.Count-1; i > -1; i--)
            {
                DataGridViewRow dgr = dataGridView1.Rows[i];
                dataGridView1.Rows.Remove(dgr);
            }
        }
        // Call this method from the Form_Load method, passing your ZedGraphControl
        private void CreateGraphBars(ZedGraphControl z1)
        {
            z1.GraphPane.CurveList.Clear();

            GraphPane myPane = z1.GraphPane;
            myPane.Title.Text = "营收标准分类";
            myPane.XAxis.Title.Text = "当品分类";
            myPane.YAxis.Title.Text = "费用总计";

            PointPairList list = new PointPairList();
            int barCount = this.dataGridView1.Rows.Count;
            string [] strClassName=new string[barCount];
            double x, y, z;

            for (int i = 0; i < barCount; i++)
            {
                x = (double)i + 1;
                y = Convert.ToDouble(this.dataGridView1.Rows[i].Cells["TotalFee"].Value);
                z = i / 4.0;
                strClassName[i]=this.dataGridView1.Rows[i].Cells["ClassName"].Value.ToString();
                list.Add(x, y, z);
            }
 
            BarItem myCurve = myPane.AddBar("颜色示例", list, Color.Blue);
            Color[] colors = { Color.Red, Color.Yellow, Color.Green, Color.Blue, Color.Purple };
            myCurve.Bar.Fill = new Fill(colors);
            myCurve.Bar.Fill.Type = FillType.GradientByZ;
            myCurve.Bar.Fill.RangeMin = 0;
            myCurve.Bar.Fill.RangeMax = 4;

            // Set the XAxis labels
            myPane.XAxis.Scale.TextLabels = strClassName;
            // Set the XAxis to Text type
            myPane.XAxis.Type = AxisType.Text;

            myPane.Chart.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45);
            myPane.Fill = new Fill(Color.White, Color.FromArgb(255, 255, 225), 45);
            // Tell ZedGraph to calculate the axis ranges
            z1.AxisChange();
            z1.Refresh();
            z1.Visible = true;
        }

        // Call this method from the Form_Load method, passing your ZedGraphControl
        public void CreateGraphPies(ZedGraphControl zgc)
        {
            zgc.GraphPane.CurveList.Clear();

            GraphPane myPane = zgc.GraphPane;

            // Set the GraphPane title
            myPane.Title.Text = "营收统计分类";
            myPane.Title.FontSpec.IsItalic = true;
            myPane.Title.FontSpec.Size = 24f;
            myPane.Title.FontSpec.Family = "Times New Roman";

            // Fill the pane background with a color gradient
            myPane.Fill = new Fill(Color.White, Color.Goldenrod, 45.0f);
            // No fill for the chart background
            myPane.Chart.Fill.Type = FillType.None;

            // Set the legend to an arbitrary location
            myPane.Legend.Position = LegendPos.Float;
            myPane.Legend.Location = new Location(0.95f, 0.15f, CoordType.PaneFraction,
                           AlignH.Right, AlignV.Top);
            myPane.Legend.FontSpec.Size = 20f;
            myPane.Legend.IsHStack = false;

            // Add some pie slices
            int pieCount = this.dataGridView1.Rows.Count;
            double[] pies = new double[5] { 0,0,0,0,0};
            for (int i = 0; i < pieCount;i++ )
            {
                pies[i] = Convert.ToDouble(this.dataGridView1.Rows[i].Cells["TotalFee"].Value);
                PieItem Segment = myPane.AddPieSlice(pies[i], GetColor(i), Color.White, 45f, 0, this.dataGridView1.Rows[i].Cells["ClassName"].Value.ToString());
                Segment.LabelDetail.IsVisible = false;
            }


            /*
            PieItem segment1 = myPane.AddPieSlice(pies[0], Color.Navy, Color.White, 45f, 0, "汽车");
            PieItem segment2 = myPane.AddPieSlice(pies[1], Color.Purple, Color.White, 45f, .0, "房产");
            PieItem segment3 = myPane.AddPieSlice(pies[2], Color.LimeGreen, Color.White, 45f, 0, "证券");
            PieItem segment4 = myPane.AddPieSlice(pies[3], Color.SandyBrown, Color.White, 45f, 0.2, "民品");
            PieItem segment5 = myPane.AddPieSlice(pies[4], Color.Red, Color.White, 45f, 0, "其他");
            //PieItem segment7 = myPane.AddPieSlice(1500, Color.Blue, Color.White, 45f, 0.2, "Pac Rim");
            //PieItem segment8 = myPane.AddPieSlice(400, Color.Green, Color.White, 45f, 0, "South America");
            //PieItem segment9 = myPane.AddPieSlice(50, Color.Yellow, Color.White, 45f, 0.2, "Africa");

            //segment1.Label.IsVisible = false;
            segment1.LabelDetail.IsVisible = false;
            segment2.LabelDetail.IsVisible = false;
            segment3.LabelDetail.IsVisible = false;
            segment4.LabelDetail.IsVisible = false;
            segment5.LabelDetail.IsVisible = false;
            */


            // Sum up the pie values                                                               
            CurveList curves = myPane.CurveList;
            double total = 0;
            for (int x = 0; x < curves.Count; x++)
                total += ((PieItem)curves[x]).Value;

            // Make a text label to highlight the total value
            //TextObj text = new TextObj("Total 2004 Sales\n" + "$" + total.ToString() + "M",0.18F, 0.40F, CoordType.PaneFraction);
            //text.Location.AlignH = AlignH.Center;
            //text.Location.AlignV = AlignV.Bottom;
            //text.FontSpec.Border.IsVisible = false;
            //text.FontSpec.Fill = new Fill(Color.White, Color.FromArgb(255, 100, 100), 45F);
            //text.FontSpec.StringAlignment = StringAlignment.Center;
            //myPane.GraphObjList.Add(text);

            // Create a drop shadow for the total value text item
            //TextObj text2 = new TextObj(text);
            //text2.FontSpec.Fill = new Fill(Color.Black);
            //text2.Location.X += 0.008f;
            //text2.Location.Y += 0.01f;
            //myPane.GraphObjList.Add(text2);

            // Calculate the Axis Scale Ranges
            zgc.AxisChange();
            zgc.Refresh();
            zgc.Visible = true;
        }


        private Color GetColor(int Num)
        {
            Color Result=new Color();
            switch (Num)
            {
                case 0:
                    Result = Color.Navy;
                    break;
                case 1:
                    Result = Color.Purple;
                    break;
                case 2:
                    Result = Color.LimeGreen;
                    break;
                case 3:
                    Result = Color.SandyBrown;
                    break;
                case 4:
                    Result = Color.Red;
                    break;
                case 5:
                    Result = Color.Blue;
                    break;
                case 6:
                    Result = Color.Green;
                    break;
                case 7:
                    Result = Color.Yellow;
                    break;


            }
            return Result;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (this.tbxStartDate.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "请选择起始日期！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.tbxEndDate.Text.Trim().Length == 0)
            {
                MessageBox.Show(this, "请选择终止日期！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ClearDataGridView();
            switch (m_ClassType)
            {
                case 0:
                    InitStandardTakingClassSource();
                    this.dataGridView1.DataSource = m_ClassTakingTable;
                    CreateGraphBars(zedGraphControl2);
                    break;
                case 1:
                    InitStatisticTakingClassSource();
                    this.dataGridView1.DataSource = m_ClassTakingTable;
                    CreateGraphPies(zedGraphControl1);
                    break;
                default:
                    break;
            }            
            
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow CurrentRow = this.dataGridView1.Rows[e.RowIndex];
            CurrentRow.HeaderCell.Value = Convert.ToString(e.RowIndex + 1);
        }

        private DataGridViewPrinter MyDataGridViewPrinter;

        private bool SetupThePrinting()
        {
            PrintDialog MyPrintDialog = new PrintDialog();
            MyPrintDialog.AllowCurrentPage = false;
            MyPrintDialog.AllowPrintToFile = false;
            MyPrintDialog.AllowSelection = false;
            MyPrintDialog.AllowSomePages = false;
            MyPrintDialog.PrintToFile = false;
            MyPrintDialog.ShowHelp = false;
            MyPrintDialog.ShowNetwork = false;

            if (MyPrintDialog.ShowDialog() != DialogResult.OK)
                return false;

            MyPrintDocument.DocumentName = this.TabText;
            MyPrintDocument.PrinterSettings =
                                MyPrintDialog.PrinterSettings;
            MyPrintDocument.DefaultPageSettings =
            MyPrintDialog.PrinterSettings.DefaultPageSettings;
            MyPrintDocument.DefaultPageSettings.Margins =
                             new Margins(40, 40, 40, 40);
            
            string strTitle = this.TabText+"(" + this.tbxStartDate.Text + "至" + this.tbxEndDate.Text+")";
            MyDataGridViewPrinter = new DataGridViewPrinter(dataGridView1, MyPrintDocument, true, true, strTitle, new Font("Tahoma", 12, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            return true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            
            //if (SetupThePrinting())
            //{
            //    MyPrintDocument.Print();
            //}


            DataGridView DataSource = new DataGridView();
            List<int> Columns = new List<int>();
            string Title = "";

            DataSource = dataGridView1;


            Title += "查询日期：" + DateTime.Now.ToShortDateString();
            Title += "    ";

            DDUser newUser = new DDUser("AccountName", MainForm.AccountName);
            Title += "查询人：" + newUser.UserName;

            Columns.Add(dataGridView1.Columns["ClassName"].Index);
            Columns.Add(dataGridView1.Columns["ServiceFee"].Index);
            Columns.Add(dataGridView1.Columns["ReturnFee"].Index);
            Columns.Add(dataGridView1.Columns["OverdueFee"].Index);
            Columns.Add(dataGridView1.Columns["InterestFee"].Index);
            Columns.Add(dataGridView1.Columns["TotalFee"].Index);
            Columns.Add(dataGridView1.Columns["Reckoning"].Index);


            if (Type == 0)
            {
                PrintDataGrid frmPrintDataGrid = new PrintDataGrid(Title, DataSource, Columns, "QueryByTaking1.dd");
            }
            else if (Type == 1)
            {
                PrintDataGrid frmPrintDataGrid = new PrintDataGrid(Title, DataSource, Columns, "QueryByTaking2.dd");
            }

        }

        private void MyPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            bool more = MyDataGridViewPrinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;

        }
    }
}