using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using SubSonic;
using System.Transactions;

namespace DianDang
{
    public partial class RenewPawnOperationForm : DockContent
    {
        private string OldValue = "";

        private int m_TicketID;

        private int LoadingStatus = 0;

        public RenewPawnOperationForm(int intTicketID)
        {
            LoadingStatus = 1;
            InitializeComponent();
            LoadTicketInfo(intTicketID);
            LoadOperationNumber();
            this.cbxTermType.SelectedIndex = 0;
            LoadingStatus = 0;
            this.btnCaculate.Visible = false;
        }

        private string CaculateString(string strCode)
        {
            string strChar = string.Empty;
            string strRight, strMiddle, strLeft;
            strRight = string.Empty;
            strMiddle = string.Empty;
            strLeft = string.Empty;

            int j = 0;

            strChar = string.IsNullOrEmpty(strCode) ? "001" : strCode;

            if (strCode.Substring(strChar.Length - 1).Equals("9"))
            {
                for (int i = 0; i < strCode.Length; i++)
                {
                    if (strCode.Substring((strCode.Length - i - 1), 1).Equals("9"))
                        j++;
                    else
                        break;

                }
                strRight = strRight.PadRight(j, '0');   //有多少个9补多少个零
                strMiddle = Convert.ToString(int.Parse(strCode.Substring(strCode.Length - j - 1, 1)) + 1);   //加1后的值
                strLeft = strCode.Substring(0, strCode.Length - j - 1); //
                strChar = strLeft + strMiddle + strRight;

            }
            else
            {
                strRight = Convert.ToString(int.Parse(strCode.Substring(strCode.Length - 1)) + 1);
                strLeft = strCode.Substring(0, strCode.Length - 1);
                strChar = strLeft + strRight;
            }
            return strChar;
        }

        private string m_OperationNumber;
        private void LoadOperationNumber()
        {
            DDGeneralParemeter newParam = new DDGeneralParemeter("ParamName", "OperationNumber");
            m_OperationNumber = newParam.ParamValue.Trim();
        }
        private void UpdateOperationNumber()
        {
            DDGeneralParemeter newParam = new DDGeneralParemeter("ParamName", "OperationNumber");
            newParam.ParamValue = CaculateString(newParam.ParamValue.Trim());
            newParam.Save();
        }

        private string m_EndDate;
        private void LoadTicketInfo(int intTicketID)
        {
            m_TicketID = intTicketID;
            double TotalLastInterestFee = 0;
            double LastInterestFee = 0;
            DDPawnTicket newTicket = new DDPawnTicket("TicketID", intTicketID);
            this.lblOldTicketNum.Text = newTicket.TicketNumber;
            this.tbxStartDate.Text = newTicket.EndDate;
            this.tbxEndDate.Text = newTicket.EndDate;
            m_EndDate = newTicket.EndDate;
            DateTime operationDate = DateTime.Now;
            this.tbxOperationDate.Text = operationDate.Year.ToString() + "-" + operationDate.Month.ToString() + "-" + operationDate.Day.ToString();

            Query query = new Query(DDOperation.Schema);
            query.AddWhere("TicketID", intTicketID);
            query.AddWhere("NextOperationID", 0);
            query.AddWhere("OperationType",Comparison.NotEquals,6);
            DataTable dt = query.ExecuteDataSet().Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DDPawnageInfo pawnageInfo = new DDPawnageInfo("PawnageID",dt.Rows[i]["PawnageID"]);
                this.dataGridView1.Rows.Add(1);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["OperationID"].Value = dt.Rows[i]["OperationID"];
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["PawnageID"].Value = pawnageInfo.PawnageID;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["ParentClassID"].Value = pawnageInfo.ParentID;
                DDPawnageClass parentClass = new DDPawnageClass("ClassID", pawnageInfo.ParentID);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["ParentClass"].Value = parentClass.ClassName;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["ChildClassID"].Value = pawnageInfo.ClassID;
                DDPawnageClass childClass = new DDPawnageClass("ClassID", pawnageInfo.ClassID);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["ChildClass"].Value = childClass.ClassName;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["FeeRate"].Value = dt.Rows[i]["ServiceFeeRate"].ToString();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["InterestRate"].Value = dt.Rows[i]["InterestFeeRate"].ToString();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Description"].Value = pawnageInfo.Description;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["CountNumber"].Value = pawnageInfo.CountNumber;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Weight"].Value = pawnageInfo.Weight;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["DiscountPercent"].Value = pawnageInfo.DiscountPercent;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Amount"].Value = dt.Rows[i]["Amount"];
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Remark"].Value = pawnageInfo.Remark;

                //计算上期利息
                DateTime StartDate = DateTime.Parse(dt.Rows[i]["StartDate"].ToString());
                DateTime EndDate = DateTime.Parse(dt.Rows[i]["EndDate"].ToString());
                PawnSpan LastInterestSpan = DianDangFunction.GetPawnSpan(StartDate, EndDate , FeeType.InterestFee, PeridType.Within);

                LastInterestFee = (LastInterestSpan.Months + LastInterestSpan.CountDays / 30) * Convert.ToDouble(dt.Rows[i]["InterestFeeRate"].ToString()) * Convert.ToDouble(dt.Rows[i]["Amount"].ToString()) / 100;
                LastInterestFee = DianDangFunction.myRound(LastInterestFee, MainForm.AmountAccuracy);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["InterestFee"].Value = LastInterestFee;
                TotalLastInterestFee += LastInterestFee;               
            }
            CaculateAmount();

            this.tbxLastInterestFee.Text = TotalLastInterestFee.ToString();
            this.lblLastInterestFee.Text = newChinese.toChineseChar(Convert.ToDecimal(TotalLastInterestFee));
            

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow CurrentRow = this.dataGridView1.Rows[e.RowIndex];
            CurrentRow.HeaderCell.Value = Convert.ToString(e.RowIndex + 1);
        }

        private ToChineseValue newChinese = new ToChineseValue();

        private void CaculateAmount()
        {
            LoadingStatus = 1;
            PawnSpan ServiceSpan = DianDangFunction.GetPawnSpan(DateTime.Parse(tbxStartDate.Text), DateTime.Parse(tbxEndDate.Text), FeeType.ServiceFee, PeridType.Within);
            PawnSpan InterestSpan = DianDangFunction.GetPawnSpan(DateTime.Parse(tbxStartDate.Text), DateTime.Parse(tbxEndDate.Text), FeeType.InterestFee, PeridType.Within);

            double amount = 0, totalAmount = 0, serviceFee = 0, totalServiceFee = 0, interestFee = 0, totalInterestFee = 0, CustomerPaid = 0;
            for (int i = dataGridView1.Rows.Count - 1; i > -1; i--)
            {
                amount = Convert.ToDouble(dataGridView1.Rows[i].Cells["Amount"].Value);
                serviceFee = (ServiceSpan.Months + ServiceSpan.CountDays / 30) * amount * Convert.ToDouble(dataGridView1.Rows[i].Cells["FeeRate"].Value) / 100;
                interestFee = (InterestSpan.Months + InterestSpan.CountDays / 30) * amount * Convert.ToDouble(dataGridView1.Rows[i].Cells["InterestRate"].Value) / 100;
                serviceFee = DianDangFunction.myRound(serviceFee, MainForm.AmountAccuracy);
                interestFee = DianDangFunction.myRound(interestFee, MainForm.AmountAccuracy);
                dataGridView1.Rows[i].Cells["ServiceFee"].Value = serviceFee;
                

                totalAmount += amount;
                totalServiceFee += serviceFee;
                totalInterestFee += interestFee;
            }
            CustomerPaid = totalServiceFee + Convert.ToDouble(this.tbxLastInterestFee.Text);
            CustomerPaid = DianDangFunction.myRound(CustomerPaid, MainForm.AmountAccuracy);

            this.tbxTotalAmount.Text = totalAmount.ToString();
            this.tbxServiceFee.Text = totalServiceFee.ToString();
            this.tbxInterestFee.Text = totalInterestFee.ToString();
            this.tbxCustomerPaid.Text = CustomerPaid.ToString();

            this.lblTotalAmount.Text = newChinese.toChineseChar(Convert.ToDecimal(totalAmount));
            this.lblServiceFee.Text = newChinese.toChineseChar(Convert.ToDecimal(totalServiceFee));
            this.lblInterestFee.Text = newChinese.toChineseChar(Convert.ToDecimal(totalInterestFee));
            this.lblCustomerPaid.Text = newChinese.toChineseChar(Convert.ToDecimal(CustomerPaid));
            LoadingStatus = 0;
        }

        private void CaculateDataGridAmount()
        {
            LoadingStatus = 1;
            double totalServiceFee = 0;
            double totalLastInterestFee = 0;
            double totalInterestFee = 0;
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    PawnSpan InterestSpan = DianDangFunction.GetPawnSpan(DateTime.Parse(tbxStartDate.Text), DateTime.Parse(tbxEndDate.Text), FeeType.InterestFee, PeridType.Within);
                    double amount = Convert.ToDouble(dataGridView1.Rows[i].Cells["Amount"].Value.ToString());
                    double interestFeeRate = Convert.ToDouble(dataGridView1.Rows[i].Cells["InterestRate"].Value.ToString());

                    double interestFee = (InterestSpan.Months + InterestSpan.CountDays / 30) * amount * interestFeeRate / 100;
                    interestFee = DianDangFunction.myRound(interestFee, MainForm.AmountAccuracy);
                    totalInterestFee += interestFee;

                    totalServiceFee += Convert.ToDouble(dataGridView1.Rows[i].Cells["ServiceFee"].Value);
                    totalLastInterestFee += Convert.ToDouble(dataGridView1.Rows[i].Cells["InterestFee"].Value);
                    
                }
            }
            tbxServiceFee.Text = DianDangFunction.myRound(totalServiceFee, MainForm.AmountAccuracy).ToString();
            lblServiceFee.Text = newChinese.toChineseChar(Convert.ToDecimal(totalServiceFee));

            tbxLastInterestFee.Text = DianDangFunction.myRound(totalLastInterestFee, MainForm.AmountAccuracy).ToString();
            lblLastInterestFee.Text = newChinese.toChineseChar(Convert.ToDecimal(totalLastInterestFee));

            tbxInterestFee.Text = DianDangFunction.myRound(totalInterestFee, MainForm.AmountAccuracy).ToString();
            lblInterestFee.Text = newChinese.toChineseChar(Convert.ToDecimal(totalInterestFee));

            tbxCustomerPaid.Text = DianDangFunction.myRound((totalServiceFee + totalLastInterestFee), MainForm.AmountAccuracy).ToString();
            lblCustomerPaid.Text = newChinese.toChineseChar(Convert.ToDecimal(tbxCustomerPaid.Text));
            LoadingStatus = 0;
        }

        private DialogResult CheckAllData()
        {
            try
            {
                int pawnTerm = Convert.ToInt32(this.tbxPawnTerm.Text);
                if (pawnTerm != 0)
                {
                    return DialogResult.OK;
                }
                else
                {
                    MessageBox.Show(this, "续当期限不能为0！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return DialogResult.No;
                }
            }
            catch
            {
                return DialogResult.No;
            }
 
        }

        private void UpdateOperation()
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {

                    DDPawnTicket newTicket = new DDPawnTicket("TicketID", m_TicketID);

                    newTicket.StatusID = 3;  //3:续当
                    newTicket.EndDate = this.tbxEndDate.Text;
                    newTicket.Save();

                    int iPawnageID = 0;
                    int preOperationID = 0;

                    for (int i = dataGridView1.Rows.Count - 1; i > -1; i--)
                    {
                        DataGridViewRow dgr = dataGridView1.Rows[i];
                        iPawnageID = Convert.ToInt32(dgr.Cells["PawnageID"].Value);
                        DDPawnageInfo newInfo = new DDPawnageInfo("PawnageID", iPawnageID);


                        preOperationID = Convert.ToInt32(dgr.Cells["OperationID"].Value);
                        DDOperation newOperation = new DDOperation();
                        newOperation.TicketID = m_TicketID;
                        newOperation.PawnageID = iPawnageID;
                        newOperation.OperationType = 3;   //3 ：续当
                        newOperation.OperationNumber = m_OperationNumber;
                        newOperation.ServiceFee = dataGridView1.Rows[i].Cells["ServiceFee"].Value.ToString();
                        newOperation.InterestFee = dataGridView1.Rows[i].Cells["InterestFee"].Value.ToString();
                        newOperation.ReturnFee = "0";
                        newOperation.OverdueFee = "0";
                        newOperation.Amount = dgr.Cells["Amount"].Value.ToString();
                        newOperation.ReckonAmount = "0";
                        newOperation.OperationDate = this.tbxOperationDate.Text;
                        newOperation.StartDate = this.tbxStartDate.Text;
                        newOperation.EndDate = this.tbxEndDate.Text;
                        DDUser newOperater = new DDUser("AccountName", MainForm.AccountName);
                        newOperation.OperaterName = newOperater.UserName;
                        newOperation.PreOperationID = preOperationID;
                        newOperation.ServiceFeeRate = dgr.Cells["FeeRate"].Value.ToString();
                        newOperation.InterestFeeRate = dgr.Cells["InterestRate"].Value.ToString();
                        newOperation.NextOperationID = 0;
                        newOperation.Deleted = 0;
                        newOperation.Save();

                        DDOperation oldOperation = new DDOperation("OperationID", preOperationID);
                        oldOperation.NextOperationID = newOperation.OperationID;
                        oldOperation.Save();

                        newInfo.FeeRate = dgr.Cells["FeeRate"].Value.ToString();
                        newInfo.InterestRate = dgr.Cells["InterestRate"].Value.ToString();
                        newInfo.EndDate = this.tbxEndDate.Text;
                        newInfo.StatusID = 3; //续当
                        newInfo.Save();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void PrintPawnTicket()
        {
            RenewPawnPrintPreviewForm frmRenewPawnPrintView = new RenewPawnPrintPreviewForm(m_TicketID,m_OperationNumber);
            //frmRenewPawnPrintView.Show();
        }

        private void PrintReceipt()
        {
            ReceiptPrintViewForm frmReceiptPrintView = new ReceiptPrintViewForm(m_TicketID, m_OperationNumber);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DialogResult res = CheckAllData();
            if (res != DialogResult.OK)
            {
                return;
            }

            using (TransactionScope Scope = new TransactionScope())
            {
                try
                {
                    LoadOperationNumber();
                    UpdateOperation();
                    UpdateOperationNumber();
                    this.btnPrint.Enabled = false;

                    DDPrintParam newParam = new DDPrintParam("PrintOption", 3);
                    if (newParam.OptionValue == 1)
                    {
                        PrintPawnTicket();
                    }

                    newParam = new DDPrintParam("PrintOption", 4);
                    if (newParam.OptionValue == 1)
                    {
                        PrintReceipt();
                    }
                    LoadOperationNumber();
                    this.btnPrint.Enabled = false;

                    Scope.Complete();
                    MessageBox.Show(this, "续当成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    Scope.Dispose();
                    MessageBox.Show(this, "续当操作失败，请检查数据库是否连接正确！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }
        }

        private void tbxPawnTerm_TextChanged(object sender, EventArgs e)
        {
            this.monthCalendar1.Hide();
            if (this.cbxTermType.SelectedIndex != -1)
            {
                int spanTime = 0;
                try
                {
                    spanTime = Convert.ToInt32(this.tbxPawnTerm.Text);
                }
                catch
                {
                    MessageBox.Show("典当期限输入不正确！", "提示信息");
                    return;
                }

                DateTime startDate = Convert.ToDateTime(this.tbxStartDate.Text);
                DateTime endDate;
                if (this.cbxTermType.SelectedIndex == 0)
                {
                    endDate = startDate.AddMonths(spanTime);
                    //二月份特殊处理
                    if (DateTime.IsLeapYear(startDate.Year) == true && startDate.Month == 2 && startDate.Day == 29 ||
                        DateTime.IsLeapYear(startDate.Year) == false && startDate.Month == 2 && startDate.Day == 28)
                    {
                        endDate = new DateTime(endDate.Year, endDate.Month, DateTime.DaysInMonth(endDate.Year, endDate.Month));
                    }

                }
                else
                {
                    endDate = startDate.AddDays(spanTime);
                    this.lblPawnTerm.Text = spanTime.ToString();
                }

                this.tbxEndDate.Text = endDate.Year.ToString() + "-" + endDate.Month.ToString() + "-" + endDate.Day.ToString();
                CaculateAmount();
            }
        }

        private void cbxTermType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadingStatus = 1;
            int spanTime = 0;
            int count = 0;
            try
            {
                spanTime = Convert.ToInt32(this.tbxPawnTerm.Text);
            }
            catch
            {
                MessageBox.Show("典当期限输入不正确！", "提示信息");
                return;
            }

            DateTime startDate = Convert.ToDateTime(this.tbxStartDate.Text);
            DateTime endDate;
            if (this.cbxTermType.SelectedIndex == 0)
            {
                endDate = startDate.AddMonths(spanTime);
            }
            else
            {
                if (spanTime > 0)
                {
                    count = spanTime / 30;
                    spanTime = spanTime - 30 * count;
                    if (0 < spanTime && spanTime < 6)
                    {
                        spanTime = 5;
                    }
                    else if (5 < spanTime && spanTime < 16)
                    {
                        spanTime = 15;
                    }
                    else if (15 < spanTime && spanTime < 30)
                    {
                        spanTime = 30;
                    }
                    spanTime = 30 * count + spanTime;
                }
                endDate = startDate.AddDays(spanTime);
                this.tbxPawnTerm.Text = spanTime.ToString();
            }
            this.tbxEndDate.Text = endDate.Year.ToString() + "-" + endDate.Month.ToString() + "-" + endDate.Day.ToString();
            CaculateAmount();
            LoadingStatus = 0;
        }

        private void btnCaculate_Click(object sender, EventArgs e)
        {
            CaculateAmount();
        }

        private void tbxPawnTerm_Leave(object sender, EventArgs e)
        {

        }


        void tbxOperationDate_Click(object sender, System.EventArgs e)
        {
            monthCalendar1.Show();
        }

        void monthCalendar1_LostFocus(object sender, System.EventArgs e)
        {
            monthCalendar1.Hide();
        }

        void monthCalendar1_DateSelected(object sender, System.Windows.Forms.DateRangeEventArgs e)
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
                monthCalendar1.Hide();
            }
        }

        void dataGridView1_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                try
                {
                    OldValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
                catch
                {
                }
            }
        }

        void dataGridView1_CellValueChanged(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (LoadingStatus == 0 && e.ColumnIndex != -1)
            {
                if (e.ColumnIndex == dataGridView1.Columns["FeeRate"].Index)
                {
                    try
                    {
                        PawnSpan ServiceSpan = DianDangFunction.GetPawnSpan(DateTime.Parse(tbxStartDate.Text), DateTime.Parse(tbxEndDate.Text), FeeType.ServiceFee, PeridType.Within);
                        double amount = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["Amount"].Value.ToString());
                        double serviceFeeRate = Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["FeeRate"].Value.ToString());
                        dataGridView1.Rows[e.RowIndex].Cells["ServiceFee"].Value = (ServiceSpan.Months + ServiceSpan.CountDays / 30) * amount * serviceFeeRate / 100;
                        CaculateDataGridAmount();
                    }
                    catch
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = OldValue;
                        MessageBox.Show("请输入正确的费率", "提示信息");
                    }
                }
                else
                {
                    try
                    {
                        Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        CaculateDataGridAmount();
                    }
                    catch
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = OldValue;
                        MessageBox.Show("请输入正确的金额", "提示信息");
                    }
                }
            }

            //throw new System.NotImplementedException();
        }
   }
}