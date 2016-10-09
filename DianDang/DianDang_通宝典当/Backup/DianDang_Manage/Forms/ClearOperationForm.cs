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
    public partial class ClearOperationForm : DockContent
    {
        public ClearOperationForm(int intTicketID)
        {
            InitializeComponent();
            LoadPawnageInfo(intTicketID);
            LoadOperationNumber();
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

        private int m_TicketID;

        private void LoadPawnageInfo(int intTicketID)
        {
            m_TicketID = intTicketID;
            DDPawnTicket newTicket=new DDPawnTicket("TicketID",intTicketID);

            Query query = new Query(DDOperation.Schema);
            query.AddWhere("TicketID", intTicketID);
            query.AddWhere("OperationType", 4);
            query.AddWhere("NextOperationID", 0);
            DataTable dt = query.ExecuteDataSet().Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {                
                this.dataGridView1.Rows.Add(1);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["PawnageID"].Value = dt.Rows[i]["PawnageID"];
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["OperationID"].Value = dt.Rows[i]["OperationID"];
                DDPawnageInfo pawnageInfo = new DDPawnageInfo("PawnageID", dt.Rows[i]["PawnageID"]);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["TicketNumber"].Value = newTicket.TicketNumber;
                DDPawnageClass newClass = new DDPawnageClass("ClassID", pawnageInfo.ClassID);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["ClassName"].Value = newClass.ClassName;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["CloseDate"].Value = dt.Rows[i]["OperationDate"];
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Amount"].Value = dt.Rows[i]["Amount"];
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["ReckonAmount"].Value = dt.Rows[i]["Amount"];



            }
        }

        private void UpdateOperation()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                DateTime operateDate = DateTime.Now;
                string strDate = operateDate.Year.ToString() + "-" + operateDate.Month.ToString() + "-" + operateDate.Day.ToString();
                    
                int iPawnageID = 0;
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
                        newOperation.OperationType = 7;  //7:清算
                        newOperation.OperationNumber = m_OperationNumber;
                        newOperation.ServiceFee = "0";
                        newOperation.InterestFee = "0";
                        newOperation.ReturnFee = "0";
                        newOperation.OverdueFee = "0";
                        newOperation.Amount = dgr.Cells["Amount"].Value.ToString();
                        newOperation.ReckonAmount = dgr.Cells["ReckonAmount"].Value.ToString();
                        newOperation.OperationDate = strDate;
                        newOperation.OperaterName = MainForm.AccountName;
                        newOperation.PreOperationID = preOperationID;
                        newOperation.NextOperationID = 0;
                        newOperation.Deleted = 0;
                        newOperation.Save();

                        DDOperation oldOperation = new DDOperation("OperationID", preOperationID);
                        oldOperation.NextOperationID = newOperation.OperationID;
                        oldOperation.Save();

                        DDPawnageInfo newInfo = new DDPawnageInfo("PawnageID", iPawnageID);
                        newInfo.StatusID = 7;
                        newInfo.Save();
                    }
                    catch
                    {
                        MessageBox.Show(this, "清算操作失败，请检查数据库是否连接正确！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                DDPawnTicket newTicket = new DDPawnTicket("TicketID", m_TicketID);
                newTicket.StatusID = 7;  //7:清算
                newTicket.Save();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                LoadOperationNumber();
                UpdateOperation();
                UpdateTicketStatus();
                UpdateOperationNumber();
                MessageBox.Show(this, "清算成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnClear.Enabled = false;
                LoadOperationNumber();
            }
            catch
            {
                MessageBox.Show(this, "清算操作失败，请检查数据库是否连接正确！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateTicketStatus()
        {
            DDPawnTicket newTicket = new DDPawnTicket("TicketID", m_TicketID);
            newTicket.StatusID = 7;
            newTicket.Save();
        }
    }
}