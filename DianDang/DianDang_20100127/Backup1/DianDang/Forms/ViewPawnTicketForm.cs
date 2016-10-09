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
    public partial class ViewPawnTicketForm : DockContent
    {
        private int m_TicketID;

        public ViewPawnTicketForm(int intTicketID)
        {
            InitializeComponent();
            InitCbxCertType();
            LoadTicketInfo(intTicketID);
        }

        private void InitCbxCertType()
        {
            Query query = new Query(DDCertType.Schema);
            DataSet comboCertTypeDataset = query.ExecuteDataSet();
            this.cbxCertType.DataSource = comboCertTypeDataset.Tables[0];
            this.cbxCertType.DisplayMember = "TypeName";
            this.cbxCertType.ValueMember = "TypeID";
        }

        private void LoadCustomerInfo(int intCustomerID)
        {
            DDCustomerInfo newCustomer = new DDCustomerInfo("CustomerID",intCustomerID);
            tbxCustomerName.Text = newCustomer.CustomerName;
            tbxContactPerson.Text = newCustomer.ContactPerson;
            tbxCustomerAdd.Text = newCustomer.Address;
            tbxCertNum.Text = newCustomer.CertNumber;
            tbxCustomerPhone.Text = newCustomer.PhoneNumber;
            cbxCertType.SelectedValue = newCustomer.CertTypeID;
        }

        private ToChineseValue newChinese = new ToChineseValue();

        private void LoadTicketInfo(int intTicketID)
        {           
            m_TicketID = intTicketID;
            DDPawnTicket newTicket = new DDPawnTicket("TicketID", intTicketID);
            this.tbxTicketNumber.Text = newTicket.TicketNumber;
            this.tbxStartDate.Text = newTicket.StartDate;
            this.tbxEndDate.Text = newTicket.EndDate;
            DateTime operationDate = DateTime.Now;

            LoadCustomerInfo(Convert.ToInt32(newTicket.CustomerID));
            Query query = new Query(DDOperation.Schema);
            query.AddWhere("TicketID", intTicketID);
            query.AddWhere("OperationType", 1);
            DataTable dt = query.ExecuteDataSet().Tables[0];

            double totalServiceFee = 0;
            double totalAmount = 0;
            double totalInterestFee = 0;
            double paidFee = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DDPawnageInfo pawnageInfo = new DDPawnageInfo("PawnageID", dt.Rows[i]["PawnageID"]);
                this.dataGridView1.Rows.Add(1);                
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
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["PawnageID"].Value = dt.Rows[i]["PawnageID"].ToString();
                totalAmount+=Convert.ToDouble(dt.Rows[i]["Amount"]);
                totalServiceFee +=Convert.ToDouble( dt.Rows[i]["ServiceFee"]);
                totalInterestFee +=Convert.ToDouble( dt.Rows[i]["InterestFee"]);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Remark"].Value = pawnageInfo.Remark;
                
            }
            this.tbxTotalAmount.Text = totalAmount.ToString();
            this.lblTotalAmount.Text = newChinese.toChineseChar(Convert.ToDecimal(totalAmount));
            this.tbxServiceFee.Text = totalServiceFee.ToString();
            this.lblServiceFee.Text = newChinese.toChineseChar(Convert.ToDecimal(totalServiceFee)); ;
            this.tbxInterestFee.Text = totalInterestFee.ToString();
            this.lblInterestFee.Text = newChinese.toChineseChar(Convert.ToDecimal(totalInterestFee));
            paidFee = totalAmount - totalServiceFee;
            this.tbxPaidFee.Text = paidFee.ToString();
            this.lblPaidFee.Text = newChinese.toChineseChar(Convert.ToDecimal(paidFee));

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow CurrentRow = this.dataGridView1.Rows[e.RowIndex];
            CurrentRow.HeaderCell.Value = Convert.ToString(e.RowIndex + 1);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PawnTicketPrintPreviewForm frmPawnTicketPrint = new PawnTicketPrintPreviewForm(this, m_TicketID);
        }
   }
}