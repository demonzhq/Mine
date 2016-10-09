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
        private int m_OldTicketID;

        public RenewPawnOperationForm(int intTicketID)
        {
            InitializeComponent();
            Init();

            m_OldTicketID = intTicketID;
            LoadOldTicketInfo(intTicketID);
        }

        private void LoadOldTicketInfo(int intTicketID)
        {
            DDPawnTicket newTicket = new DDPawnTicket("TicketID", intTicketID);
            this.lblOldTicketNum.Text = newTicket.TicketNumber;
            this.tbxStartDate.Text = newTicket.StartDate;
            this.tbxPawnTerm.Text = "1";
            DateTime endDate = DateTime.Now.AddMonths(1);
            this.tbxEndDate.Text = endDate.Year.ToString() + "-" + endDate.Month.ToString() + "-" + endDate.Day.ToString();
                   
            Query query = new Query(DDTicketPawnage.Schema);
            query.AddWhere("TicketID", intTicketID);
            DataTable dt = query.ExecuteDataSet().Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DDPawnageInfo pawnageInfo = new DDPawnageInfo("PawnageID",dt.Rows[i]["PawnageID"]);
                this.dataGridView1.Rows.Add(1);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["ParentClassID"].Value = pawnageInfo.ParentID;
                DDPawnageClass parentClass = new DDPawnageClass("ClassID", pawnageInfo.ParentID);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["ParentClass"].Value = parentClass.ClassName;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["ChildClassID"].Value = pawnageInfo.ClassID;
                DDPawnageClass childClass = new DDPawnageClass("ClassID", pawnageInfo.ClassID);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["ChildClass"].Value = childClass.ClassName;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["FeeRate"].Value = childClass.MonthFeeRate;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["InterestRate"].Value = childClass.InterestRate;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Description"].Value = pawnageInfo.Description;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["CountNumber"].Value = pawnageInfo.CountNumber;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Weight"].Value = pawnageInfo.Weight;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["DiscountPercent"].Value = pawnageInfo.DiscountPercent;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Amount"].Value = pawnageInfo.Amount;
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Remark"].Value = pawnageInfo.Remark;
            }
            CaculateAmount();

        }

        private void Init()
        {
            InitParentClass();
        }

        private void InitParentClass()
        {
            Query query = new Query(DDPawnageClass.Schema);
            query.AddWhere("ParentID", 0);
            DataTable dt = query.ExecuteDataSet().Tables[0];

            if (dt.Rows.Count > 0)
            {
                this.cbxParentClass.DisplayMember = "ClassName";
                this.cbxParentClass.ValueMember = "ClassID";
                this.cbxParentClass.DataSource = dt;
            }
        }

        private void InitChildClass(int intParentID)
        {
            Query query = new Query(DDPawnageClass.Schema);
            query.AddWhere("ParentID", intParentID);
            DataTable dt = query.ExecuteDataSet().Tables[0];

            if (dt.Rows.Count > 0)
            {
                this.cbxChildClass.DisplayMember = "ClassName";
                this.cbxChildClass.ValueMember = "ClassID";
                this.cbxChildClass.DataSource = dt;
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow CurrentRow = this.dataGridView1.Rows[e.RowIndex];
            CurrentRow.HeaderCell.Value = Convert.ToString(e.RowIndex + 1);
        }

        private ToChineseValue newChinese = new ToChineseValue();
        private void CaculateAmount()
        {
            int count;
            try
            {
                count = Convert.ToInt32(this.tbxPawnTerm.Text);
            }
            catch
            {
                MessageBox.Show("典当期限输入不正确，典当金额统计错误！", "提示信息");
                return;
            }
            double amount = 0, totalAmount = 0, serviceFee = 0, totalServiceFee = 0, interestFee = 0, totalInterestFee = 0, paidFee = 0;
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

            paidFee = totalAmount - totalServiceFee - totalInterestFee;

            this.tbxTotalAmount.Text = totalAmount.ToString();
            this.tbxServiceFee.Text = totalServiceFee.ToString();
            this.tbxInterestFee.Text = totalInterestFee.ToString();
            this.tbxPaidFee.Text = paidFee.ToString();

            this.lblTotalAmount.Text = newChinese.toChineseChar(Convert.ToDecimal(totalAmount));
            this.lblServiceFee.Text = newChinese.toChineseChar(Convert.ToDecimal(totalServiceFee));
            this.lblInterestFee.Text = newChinese.toChineseChar(Convert.ToDecimal(totalInterestFee));
            this.lblPaidFee.Text = newChinese.toChineseChar(Convert.ToDecimal(paidFee));
        }


        private DialogResult CheckAllData()
        {            
            if (this.tbxPrice.Text == "0"||this.tbxPrice.Text.Trim().Length==0)
            {
                MessageBox.Show(this, "价格输入错误，请重新输入！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return DialogResult.No;
            }
            if (this.tbxCountNumber.Text == "0"||this.tbxCountNumber.Text.Trim().Length==0)
            {
                MessageBox.Show(this, "件数输入错误，请重新输入！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return DialogResult.No;
            }
            return DialogResult.OK;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DialogResult diaRes = CheckAllData();
            if (diaRes != DialogResult.OK)
            {
                return;
            }

            double price, percent, amount;

            try
            {
                price = Convert.ToDouble(this.tbxPrice.Text);
                percent = Convert.ToDouble(this.tbxDiscountPercent.Text);
            }
            catch
            {
                MessageBox.Show("数据格式不正确！", "输入数据");
                return;
            }

            amount = price * percent / 100;
            amount = Math.Round(amount, 2);

            this.dataGridView1.Rows.Add(1);
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["ParentClassID"].Value = this.cbxParentClass.SelectedValue;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["ParentClass"].Value = this.cbxParentClass.Text;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["ChildClassID"].Value = this.cbxChildClass.SelectedValue;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["ChildClass"].Value = this.cbxChildClass.Text;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["FeeRate"].Value = this.tbxFeeRate.Text;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["InterestRate"].Value = this.tbxInterestRate.Text;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Description"].Value = this.tbxDescription.Text;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["CountNumber"].Value = this.tbxCountNumber.Text;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Weight"].Value = this.tbxWeight.Text;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Price"].Value = this.tbxPrice.Text;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["DiscountPercent"].Value = this.tbxDiscountPercent.Text;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Amount"].Value = amount;
            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Remark"].Value = this.tbxRemark.Text;

            CaculateAmount();
        }

        private void GetRateByClass(int intClassID)
        {
            DDPawnageClass newClass = new DDPawnageClass("ClassID", intClassID);
            this.tbxFeeRate.Text = newClass.MonthFeeRate;
            this.tbxInterestRate.Text = newClass.InterestRate;
        }

        private void cbxParentClass_SelectedValueChanged(object sender, EventArgs e)
        {
            int intParentID = Convert.ToInt32(this.cbxParentClass.SelectedValue);
            InitChildClass(intParentID);
            GetRateByClass(intParentID);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (this.dataGridView1.Rows[i].Cells["Operation"].Value != null && this.dataGridView1.Rows[i].Cells["Operation"].Value.ToString() == "1")
                {
                    dataGridView1.Rows[i].Selected = true;
                }
                else
                {
                    dataGridView1.Rows[i].Selected = false;
                }
            }
            if (dataGridView1.SelectedRows.Count > 0)
            {
                for (int i = dataGridView1.SelectedRows.Count - 1; i > -1; i--)
                {
                    int rowIndex = dataGridView1.SelectedRows[i].Index;
                    DataGridViewRow dgr = dataGridView1.Rows[rowIndex];
                    dataGridView1.Rows.Remove(dgr);
                }
                CaculateAmount();
            }
            else
            {
                MessageBox.Show(this, "请选择需要删除的数据！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult diaRes = CheckAllData();
            if (diaRes != DialogResult.OK)
            {
                return;
            }
            double price, percent, amount;

            try
            {
                price = Convert.ToDouble(this.tbxPrice.Text);
                percent = Convert.ToDouble(this.tbxDiscountPercent.Text);
            }
            catch
            {
                MessageBox.Show("数据格式不正确！", "输入数据");
                return;
            }

            amount = price * percent / 100;
            amount = Math.Round(amount, 2);

            try
            {
                DataGridViewRow dgr = dataGridView1.CurrentRow;
                dgr.Cells["ParentClassID"].Value = this.cbxParentClass.SelectedValue;
                dgr.Cells["ParentClass"].Value = this.cbxParentClass.Text;
                dgr.Cells["ChildClassID"].Value = this.cbxChildClass.SelectedValue;
                dgr.Cells["ChildClass"].Value = this.cbxChildClass.Text;
                dgr.Cells["FeeRate"].Value = this.tbxFeeRate.Text;
                dgr.Cells["InterestRate"].Value = this.tbxInterestRate.Text;
                dgr.Cells["Description"].Value = this.tbxDescription.Text;
                dgr.Cells["CountNumber"].Value = this.tbxCountNumber.Text;
                dgr.Cells["Weight"].Value = this.tbxWeight.Text;
                dgr.Cells["Price"].Value = this.tbxPrice.Text;
                dgr.Cells["DiscountPercent"].Value = this.tbxDiscountPercent.Text;
                dgr.Cells["Amount"].Value = amount;
                dgr.Cells["Remark"].Value = this.tbxRemark.Text;

                CaculateAmount();

                MessageBox.Show(this, "数据修改成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show(this, "数据修改失败！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.dataGridView1.Rows.Count > 0)
            {
                DataGridViewRow dgr = dataGridView1.CurrentRow;
                this.cbxParentClass.Text = dgr.Cells["ParentClass"].Value.ToString();
                this.cbxChildClass.Text = dgr.Cells["ChildClass"].Value.ToString();
                this.tbxFeeRate.Text = dgr.Cells["Feerate"].Value.ToString();
                this.tbxInterestRate.Text = dgr.Cells["InterestRate"].Value.ToString();
                this.tbxDescription.Text = dgr.Cells["Description"].Value.ToString();
                this.tbxWeight.Text = dgr.Cells["CountNumber"].Value.ToString();
                this.tbxPrice.Text = dgr.Cells["Price"].Value.ToString();
                this.tbxDiscountPercent.Text = dgr.Cells["DiscountPercent"].Value.ToString();
                this.tbxRemark.Text = dgr.Cells["Remark"].Value.ToString();
            }
        }

        private void UpdatePawages(int intTicketID)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                double serviceFee = 0;
                double interestFee = 0;
                for (int i = dataGridView1.Rows.Count - 1; i > -1; i--)
                {
                    DataGridViewRow dgr = dataGridView1.Rows[i];

                    try
                    {
                        DDPawnageInfo newInfo = new DDPawnageInfo();
                        newInfo.ClassID = Convert.ToInt32(dgr.Cells["ChildClassID"].Value);
                        newInfo.ParentID = Convert.ToInt32(dgr.Cells["ParentClassID"].Value);
                        newInfo.StatusID = 3;
                        newInfo.CountNumber = dgr.Cells["CountNumber"].Value.ToString();
                        newInfo.Weight = dgr.Cells["Weight"].Value.ToString();
                        newInfo.DiscountPercent = dgr.Cells["DiscountPercent"].Value.ToString();
                        newInfo.Amount = dgr.Cells["Amount"].Value.ToString();
                        newInfo.ReckonAmount = "0";
                        serviceFee = Convert.ToDouble(dgr.Cells["Amount"].Value) * Convert.ToInt32(this.tbxPawnTerm.Text) * Convert.ToDouble(dgr.Cells["FeeRate"].Value) / 100;
                        newInfo.ServiceFee = serviceFee.ToString();
                        interestFee = Convert.ToDouble(dgr.Cells["Amount"].Value) * Convert.ToInt32(this.tbxPawnTerm.Text) * Convert.ToDouble(dgr.Cells["InterestRate"].Value) / 100;
                        newInfo.InterestFee = interestFee.ToString();
                        newInfo.ReturnFee = "0";
                        newInfo.OverdueFee = "0";
                        newInfo.Description = dgr.Cells["Description"].Value.ToString();
                        newInfo.IsReif = 0;
                        newInfo.StartDate = this.tbxStartDate.Text;
                        newInfo.EndDate = this.tbxEndDate.Text;
                        newInfo.OperationDate = this.tbxStartDate.Text;
                        newInfo.Remark = this.tbxRemark.Text;
                        newInfo.Save();

                        DDTicketPawnage newTicketPawnage = new DDTicketPawnage();
                        newTicketPawnage.TicketID = intTicketID;
                        newTicketPawnage.PawnageID = newInfo.PawnageID;
                        newTicketPawnage.Save();
                    }
                    catch
                    {
                        MessageBox.Show(this, "数据更新失败，请检查数据库是否连接正确！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
 
        }

        private void UpdatePawnTicket()
        {
            DDPawnTicket oldTicket = new DDPawnTicket("TicketID", m_OldTicketID);
            oldTicket.IsLast = 0;

            DDPawnTicket newTicket = new DDPawnTicket();
            newTicket.CustomerID = oldTicket.CustomerID;
            newTicket.StatusID = 3;
            newTicket.OldTicketID = oldTicket.TicketID;
            newTicket.TicketNumber = this.tbxTicketNumber.Text;
            newTicket.OldTicketNumber = this.lblOldTicketNum.Text;
            newTicket.TotalAmount = this.tbxTotalAmount.Text;
            newTicket.ServiceFee = this.tbxServiceFee.Text;
            newTicket.InterestFee = this.tbxInterestFee.Text;
            newTicket.OverdueFee = oldTicket.OverdueFee;
            newTicket.ReturnFee = oldTicket.ReturnFee;
            newTicket.StartDate = this.tbxStartDate.Text;
            newTicket.EndDate = this.tbxEndDate.Text;
            newTicket.OperateDate = this.tbxStartDate.Text;
            newTicket.OperaterName = MainForm.AccountName;
            newTicket.IsLast = 1;
            try
            {
                oldTicket.Save();
                newTicket.Save();
                UpdatePawages(newTicket.TicketID);
                MessageBox.Show(this, "续当成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show(this, "数据更新失败，请检查数据库是否连接正确！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void PrintPawnTicket()
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否同时将信息存入数据库？", "打印当票", MessageBoxButtons.YesNoCancel);
            if (result != DialogResult.Cancel)
            {
                if (result == DialogResult.Yes)
                {
                    UpdatePawnTicket();
                }
                PrintPawnTicket();
            }
        }

        private void tbxPawnTerm_TextChanged(object sender, EventArgs e)
        {
            int spanMonths = 0;
            try
            {
                spanMonths = Convert.ToInt32(this.tbxPawnTerm.Text);
            }
            catch
            {
                MessageBox.Show("典当期限输入不正确！", "提示信息");
                return;
            }

            DateTime startDate = Convert.ToDateTime(this.tbxStartDate.Text);
            DateTime endDate = startDate.AddMonths(spanMonths);
            this.tbxEndDate.Text = endDate.Year.ToString() + "-" + endDate.Month.ToString() + "-" + endDate.Day.ToString();
        }
   }
}