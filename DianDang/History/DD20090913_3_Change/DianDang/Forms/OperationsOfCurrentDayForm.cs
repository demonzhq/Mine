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
    public partial class OperationsOfCurrentDayForm : DockContent
    {
        public OperationsOfCurrentDayForm()
        {
            InitializeComponent();
            OperationCount();
            OperationAmount();
        }

        private void OperationCount()
        {
            try
            {
                string selectList = string.Format("{0},{1}", DDOperation.OperationNumberColumn.ColumnName,DDOperation.OperationTypeColumn.ColumnName);
                Query q = new Query(DDOperation.Schema).SetSelectList(selectList).DISTINCT().ORDER_BY(DDOperation.OperationNumberColumn.ColumnName);
                DateTime currentDate = DateTime.Now;
                string strDate = currentDate.Year.ToString() + "-" + currentDate.Month.ToString() + "-" + currentDate.Day.ToString();
                q.AddWhere("OperationDate", strDate);
                DataTable dt = q.ExecuteDataSet().Tables[0];
                if (dt.Rows.Count > 0)
                {
                    int operationType = 0, totalCount = 0, newPawn = 0, redeemPawn = 0, renewPawn = 0, closePawn = 0, deletePawn = 0, clearPawn = 0;
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

                    this.lblTotalCount.Text = totalCount.ToString();
                    this.lblNewPawnCount.Text = newPawn.ToString();
                    this.lblRedeemPawnCount.Text = redeemPawn.ToString();
                    this.lblRenewPawnCount.Text = renewPawn.ToString();
                    this.lblClosePawnCount.Text = closePawn.ToString();
                    this.lblClearPawnCount.Text = clearPawn.ToString();
                    this.lblDeletePawnCount.Text = deletePawn.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void OperationAmount()
        {
            DateTime dt = DateTime.Now;
            string strDate = dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString();
            Query query = new Query(DDOperation.Schema);
            query.AddWhere("OperationDate",strDate);
            DataTable dataTable = query.ExecuteDataSet().Tables[0];
            if (dataTable.Rows.Count > 0)
            {
                int operationType = 0;
                double amount = 0,totalAmount=0,newPawnAmount=0,redeemPawnAmount=0,renewPawnAmount=0,closePawnAmount=0,clearPawnAmount=0;
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    operationType = Convert.ToInt32(dataTable.Rows[i]["OperationType"]);
                    amount = Convert.ToDouble(dataTable.Rows[i]["Amount"]);
                    switch (operationType)
                    {
                        case 1:
                            newPawnAmount = newPawnAmount + amount;
                            break;
                        case 2:
                            redeemPawnAmount = redeemPawnAmount + amount;
                            break;
                        case 3:
                            renewPawnAmount=renewPawnAmount+amount;
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

                this.lblTotalAmount.Text = totalAmount.ToString();
                this.lblNewPawnAmount.Text = newPawnAmount.ToString();
                this.lblRedeemPawnAmount.Text = redeemPawnAmount.ToString();
                this.lblRenewPawnAmount.Text = renewPawnAmount.ToString();
                this.lblClosePawnAmount.Text = closePawnAmount.ToString();
                this.lblClearPawnAmount.Text = clearPawnAmount.ToString();
            }
        }
    }
}