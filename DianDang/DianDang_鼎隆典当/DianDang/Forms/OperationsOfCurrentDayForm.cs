using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using SubSonic;
using MSExcel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;

namespace DianDang
{
    public partial class OperationsOfCurrentDayForm : DockContent
    {
        public OperationsOfCurrentDayForm()
        {
            InitializeComponent();
        }

        private void OperationCount()
        {
            try
            {
                int operationType = 0, totalCount = 0, newPawn = 0, redeemPawn = 0, renewPawn = 0, closePawn = 0, deletePawn = 0, clearPawn = 0;
                string selectList = string.Format("{0},{1}", DDOperation.OperationNumberColumn.ColumnName,DDOperation.OperationTypeColumn.ColumnName);
                Query q = new Query(DDOperation.Schema).SetSelectList(selectList).DISTINCT().ORDER_BY(DDOperation.OperationNumberColumn.ColumnName);
                string strDate = this.tbxOperationDate.Text.Trim();
                q.AddWhere("OperationDate", strDate);
                //q.AddWhere("Deleted", 0);
                DataTable dt = q.ExecuteDataSet().Tables[0];
                if (dt.Rows.Count > 0)
                {                    
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        operationType = Convert.ToInt32(dt.Rows[i]["OperationType"]);
                        switch (operationType)
                        {
                            case 1:
                                newPawn++;
                                break;
                            case 2:
                                redeemPawn++;
                                break;
                            case 3:
                                renewPawn++;
                                break;
                            case 4:
                                closePawn ++;
                                break;
                            case 6:
                                deletePawn++;
                                break;
                            case 7:
                                clearPawn++;
                                break;
                            default:
                                break;
                        }
                    }
                    totalCount = newPawn + redeemPawn + renewPawn + closePawn + deletePawn + clearPawn;
                }
                this.lblTotalCount.Text = totalCount.ToString();
                this.lblNewPawnCount.Text = newPawn.ToString();
                this.lblRedeemPawnCount.Text = redeemPawn.ToString();
                this.lblRenewPawnCount.Text = renewPawn.ToString();
                this.lblClosePawnCount.Text = closePawn.ToString();
                this.lblClearPawnCount.Text = clearPawn.ToString();
                this.lblDeletePawnCount.Text = deletePawn.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void OperationAmount()
        {
            int operationType = 0;
            double amount = 0, totalAmount = 0, newPawnAmount = 0, redeemPawnAmount = 0, renewPawnAmount = 0, closePawnAmount = 0, clearPawnAmount = 0;
            double serviceFee = 0, interestFee = 0, overdueFee = 0, returnFee = 0;
            double moneyRL = 0;

            string strDate = this.tbxOperationDate.Text.Trim();
            Query query = new Query(DDOperation.Schema);
            query.AddWhere("OperationDate",strDate);
            //query.AddWhere("Deleted", 0);
            DataTable dataTable = query.ExecuteDataSet().Tables[0];
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    operationType = Convert.ToInt32(dataTable.Rows[i]["OperationType"]);
                    amount = Convert.ToDouble(dataTable.Rows[i]["Amount"]);
                    serviceFee = Convert.ToDouble(dataTable.Rows[i]["ServiceFee"]);
                    interestFee = Convert.ToDouble(dataTable.Rows[i]["InterestFee"]);
                    overdueFee = Convert.ToDouble(dataTable.Rows[i]["OverdueFee"]);
                    returnFee = Convert.ToDouble(dataTable.Rows[i]["ReturnFee"]);

                    switch (operationType)
                    {
                        case 1:
                            newPawnAmount = newPawnAmount + amount;
                            moneyRL = moneyRL - amount + serviceFee;
                            break;
                        case 2:
                            redeemPawnAmount = redeemPawnAmount + amount;
                            moneyRL = moneyRL + amount + overdueFee+interestFee - returnFee;
                            break;
                        case 3:
                            renewPawnAmount=renewPawnAmount+amount;
                            moneyRL = moneyRL + serviceFee;
                            break;
                        case 4:
                            closePawnAmount=closePawnAmount+amount;
                            break;
                        case 7:
                            clearPawnAmount=clearPawnAmount+amount;
                            break;
                        default:
                            break;
                    }
                }

                totalAmount = newPawnAmount + renewPawnAmount + redeemPawnAmount + closePawnAmount + closePawnAmount;
            }
            this.lblTotalAmount.Text = totalAmount.ToString();
            this.lblNewPawnAmount.Text = newPawnAmount.ToString();
            this.lblRedeemPawnAmount.Text = redeemPawnAmount.ToString();
            this.lblRenewPawnAmount.Text = renewPawnAmount.ToString();
            this.lblClosePawnAmount.Text = closePawnAmount.ToString();
            this.lblClearPawnAmount.Text = clearPawnAmount.ToString();
            this.lblMoneyRL.Text = moneyRL.ToString();
        }

        private void tbxOperationDate_Click(object sender, EventArgs e)
        {
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
                this.tbxOperationDate.Text = _date;
                //如果选中日期就自动隐藏MonthCalendar控件
                monthCalendar1.Hide();
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            OperationCount();
            OperationAmount();
        }

        private void brnPrint_Click(object sender, EventArgs e)
        {
            object path;
            path = Application.StartupPath + @"\Pram\OperationOfDay.dd";
            MSExcel.Application excelApp; //Excel应用程序变量
            MSExcel.Workbook excelDoc; //Excel文档变量
            excelApp = new MSExcel.ApplicationClass();  //初始化
            //由于使用的是COM库，因此有许多变量需要用Nothing代替
            Object Nothing = Missing.Value;
            excelDoc = excelApp.Workbooks._Open(Application.StartupPath + @"\Pram\OperationOfDay.dd", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

            //使用第一个工作表作为插入数据的工作表
            MSExcel.Worksheet ws = (MSExcel.Worksheet)excelDoc.Sheets[1];

            //声明一个MSExcel.Range 类型的变量r
            MSExcel.Range r;

            r = ws.get_Range(("C" + 2), ("C" + 2)); r.Value2 = this.tbxOperationDate.Text;
            r = ws.get_Range(("C" + 4), ("C" + 4)); r.Value2 = this.lblTotalAmount.Text;
            r = ws.get_Range(("C" + 6), ("C" + 6)); r.Value2 = this.lblNewPawnAmount.Text;
            r = ws.get_Range(("F" + 6), ("F" + 6)); r.Value2 = this.lblRenewPawnAmount.Text;
            r = ws.get_Range(("I" + 6), ("I" + 6)); r.Value2 = this.lblRedeemPawnAmount.Text;
            r = ws.get_Range(("C" + 7), ("C" + 7)); r.Value2 = this.lblClosePawnAmount.Text;
            r = ws.get_Range(("F" + 7), ("F" + 7)); r.Value2 = this.lblClearPawnAmount.Text;
            r = ws.get_Range(("I" + 7), ("I" + 7)); r.Value2 = this.lblMoneyRL.Text;

            object format = MSExcel.XlFileFormat.xlWorkbookNormal;

            //打印文档
            excelDoc.PrintOut(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing);


            //将excelDoc文档对象的内容保存为dd文档
            //excelDoc.Save();
            if (File.Exists(Application.StartupPath + @"\Pram\dump.dd"))
            {
                try
                {
                    File.Delete(Application.StartupPath + @"\Pram\dump.dd");
                }
                catch
                {
                    MessageBox.Show("记录文件正在被使用，请退出Excel\n" + e.ToString());
                }
            }
            excelDoc.SaveAs(Application.StartupPath + @"\Pram\dump.dd", format, Nothing, Nothing, Nothing, Nothing, MSExcel.XlSaveAsAccessMode.xlExclusive, Nothing, Nothing, Nothing, Nothing, Nothing);

            //关闭excelDoc文档对象 
            excelDoc.Close(Nothing, Nothing, Nothing);

            //关闭excelApp组件对象 
            excelApp.Quit();
            //MessageBox.Show("生成成功");
        }
    }
}