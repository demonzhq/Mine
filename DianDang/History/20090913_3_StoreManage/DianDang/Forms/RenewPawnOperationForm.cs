using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using SubSonic;

namespace DianDang
{
    public partial class RenewPawnOperationForm : DockContent
    {
        private int m_TicketID;

        public RenewPawnOperationForm(int intTicketID)
        {
            InitializeComponent();
            LoadTicketInfo(intTicketID);
            LoadOperationNumber();
            this.cbxTermType.SelectedIndex = 0;
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
            DDPawnTicket newTicket = new DDPawnTicket("TicketID", intTicketID);
            this.lblOldTicketNum.Text = newTicket.TicketNumber;
            this.tbxStartDate.Text = newTicket.StartDate;
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
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["FeeRate"].Value = pawnageInfo.FeeRate;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["InterestRate"].Value = pawnageInfo.InterestRate;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Description"].Value = pawnageInfo.Description;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["CountNumber"].Value = pawnageInfo.CountNumber;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Weight"].Value = pawnageInfo.Weight;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["DiscountPercent"].Value = pawnageInfo.DiscountPercent;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Amount"].Value = dt.Rows[i]["Amount"];
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Remark"].Value = pawnageInfo.Remark;
            }
            CaculateAmount();

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow CurrentRow = this.dataGridView1.Rows[e.RowIndex];
            CurrentRow.HeaderCell.Value = Convert.ToString(e.RowIndex + 1);
        }

        private ToChineseValue newChinese = new ToChineseValue();

        private void CaculateAmount()
        {
            double count;
            try
            {
                count = Convert.ToDouble(this.tbxPawnTerm.Text);
            }
            catch
            {
                MessageBox.Show("典当期限输入不正确，典当金额统计错误！", "提示信息");
                return;
            }
            if (this.cbxTermType.SelectedIndex != 0)
            {
                count = count / 30;
            }
            double amount = 0, totalAmount = 0, serviceFee = 0, totalServiceFee = 0, interestFee = 0, totalInterestFee = 0;
            for (int i = dataGridView1.Rows.Count - 1; i > -1; i--)
            {
                amount = Convert.ToDouble(dataGridView1.Rows[i].Cells["Amount"].Value);
                serviceFee = count * amount * Convert.ToDouble(dataGridView1.Rows[i].Cells["FeeRate"].Value) / 100;
                interestFee = count * amount * Convert.ToDouble(dataGridView1.Rows[i].Cells["InterestRate"].Value) / 100;
                serviceFee = Math.Round(serviceFee, 2);
                interestFee = Math.Round(interestFee, 2);

                totalAmount += amount;
                totalServiceFee += serviceFee;
                totalInterestFee += interestFee;
            }


            this.tbxTotalAmount.Text = totalAmount.ToString();
            this.tbxServiceFee.Text = totalServiceFee.ToString();
            this.tbxInterestFee.Text = totalInterestFee.ToString();

            this.lblTotalAmount.Text = newChinese.toChineseChar(Convert.ToDecimal(totalAmount));
            this.lblServiceFee.Text = newChinese.toChineseChar(Convert.ToDecimal(totalServiceFee));
            this.lblInterestFee.Text = newChinese.toChineseChar(Convert.ToDecimal(totalInterestFee));
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
            if (dataGridView1.Rows.Count > 0)
            {
                DDPawnTicket newTicket = new DDPawnTicket("TicketID", m_TicketID);
                newTicket.StatusID = 3;  //3:续当
                newTicket.EndDate = this.tbxEndDate.Text;
                newTicket.Save();

                int iPawnageID = 0;
                double serviceFee = 0;
                double interestFee = 0;
                int preOperationID = 0;
                for (int i = dataGridView1.Rows.Count - 1; i > -1; i--)
                {
                    DataGridViewRow dgr = dataGridView1.Rows[i];
                    try
                    {
                        iPawnageID = Convert.ToInt32(dgr.Cells["PawnageID"].Value);
                        preOperationID = Convert.ToInt32(dgr.Cells["OperationID"].Value);
                        DDOperation newOperation = new DDOperation();
                        newOperation.TicketID = m_TicketID;
                        newOperation.PawnageID = iPawnageID;
                        newOperation.OperationType = 3;   //3 ：续当
                        newOperation.OperationNumber =m_OperationNumber ;
                        //计算服务费
                        serviceFee = Convert.ToDouble(dgr.Cells["Amount"].Value) * Convert.ToInt32(this.tbxPawnTerm.Text) * Convert.ToDouble(dgr.Cells["FeeRate"].Value) / 100;
                        serviceFee = Math.Round(serviceFee, 2);
                        newOperation.ServiceFee = serviceFee.ToString();
                        //计算典当利息
                        interestFee = Convert.ToDouble(dgr.Cells["Amount"].Value) * Convert.ToInt32(this.tbxPawnTerm.Text) * Convert.ToDouble(dgr.Cells["InterestRate"].Value) / 100;
                        interestFee = Math.Round(interestFee, 2);
                        newOperation.InterestFee = interestFee.ToString();
                        newOperation.ReturnFee = "0";
                        newOperation.OverdueFee = "0";
                        newOperation.Amount = dgr.Cells["Amount"].Value.ToString();
                        newOperation.ReckonAmount = "0";
                        newOperation.OperationDate = this.tbxOperationDate.Text;
                        newOperation.StartDate = this.tbxStartDate.Text;
                        newOperation.EndDate = this.tbxEndDate.Text;
                        newOperation.OperaterName = MainForm.AccountName;
                        newOperation.PreOperationID = preOperationID;
                        newOperation.NextOperationID = 0;
                        newOperation.Save();

                        DDOperation oldOperation = new DDOperation("OperationID", preOperationID);
                        oldOperation.NextOperationID = newOperation.OperationID;
                        oldOperation.Save();

                        DDPawnageInfo newInfo = new DDPawnageInfo("PawnageID",iPawnageID);
                        newInfo.EndDate = this.tbxEndDate.Text;
                        newInfo.Save();
                    }
                    catch
                    {
                        MessageBox.Show(this, "续当操作失败，请检查数据库是否连接正确！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

        }
        private void PrintPawnTicket()
        {
            RenewPawnPrintPreviewForm frmRenewPawnPrintView = new RenewPawnPrintPreviewForm(this,m_TicketID);
            //frmRenewPawnPrintView.Show();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否同时将信息存入数据库？", "打印当票", MessageBoxButtons.YesNoCancel);
            if (result != DialogResult.Cancel)
            {
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        DialogResult res = CheckAllData();
                        if (res != DialogResult.OK)
                        {
                            return;
                        }
                        UpdateOperation();
                        UpdateOperationNumber();                        
                        //MessageBox.Show(this, "续当成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show(this, "续当操作失败，请检查数据库是否连接正确！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }                
            }
            PrintPawnTicket();
        }

        private void tbxPawnTerm_TextChanged(object sender, EventArgs e)
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

            DDPawnTicket newTicket = new DDPawnTicket("TicketID",m_TicketID);

            DateTime endDate = Convert.ToDateTime(newTicket.EndDate);
            if (this.cbxTermType.SelectedIndex == 0)
            {
                endDate = endDate.AddMonths(spanTime);
            }
            else
            {
                endDate = endDate.AddDays(spanTime);
            }
            this.tbxEndDate.Text = endDate.Year.ToString() + "-" + endDate.Month.ToString() + "-" + endDate.Day.ToString();
            CaculateAmount();
        }

        private void cbxTermType_SelectedIndexChanged(object sender, EventArgs e)
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

            DDPawnTicket newTicket = new DDPawnTicket("TicketID", m_TicketID);

            DateTime endDate = Convert.ToDateTime(newTicket.EndDate);
            if (this.cbxTermType.SelectedIndex == 0)
            {
                endDate = endDate.AddMonths(spanTime);
            }
            else
            {
                endDate = endDate.AddDays(spanTime);
            }
            this.tbxEndDate.Text = endDate.Year.ToString() + "-" + endDate.Month.ToString() + "-" + endDate.Day.ToString();
            CaculateAmount();
        }
   }
}