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
    public partial class CreatePawnForm : DockContent
    {
        public CreatePawnForm()
        {
            InitializeComponent();
            Init();
        }
              
        private void Init()
        {
            LoadTicketNumber();
            LoadOperationNumber();
            InitCbxCertType();
            InitParentClass();

            DateTime dt = DateTime.Now;
            this.tbxStartDate.Text = dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString();
            this.tbxPawnTerm.Text = "1";
            dt = dt.AddMonths(1);
            this.tbxEndDate.Text = dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString();
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
        private void LoadTicketNumber()
        {
            DDGeneralParemeter newParam = new DDGeneralParemeter("ParamName", "CurrentTicketNumber");
            this.tbxTicketNumber.Text = newParam.ParamValue.Trim();
        }
        private void UpdateTicketNumber()
        {
            DDGeneralParemeter newParam = new DDGeneralParemeter("ParamName", "CurrentTicketNumber");
            newParam.ParamValue = CaculateString(newParam.ParamValue.Trim());
            newParam.Save();
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

        private void InitCbxCertType()
        {
            Query query = new Query(DDCertType.Schema);
            DataSet comboCertTypeDataset = query.ExecuteDataSet();
            this.cbxCertType.DataSource = comboCertTypeDataset.Tables[0];
            this.cbxCertType.DisplayMember = "TypeName";
            this.cbxCertType.ValueMember = "TypeID";
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
                serviceFee = count*amount * Convert.ToDouble(dataGridView1.Rows[i].Cells["FeeRate"].Value) / 100;
                interestFee = count*amount * Convert.ToDouble(dataGridView1.Rows[i].Cells["InterestRate"].Value) / 100;
                serviceFee = Math.Round(serviceFee, 2);
                interestFee = Math.Round(interestFee, 2);

                totalAmount += amount;
                totalServiceFee += serviceFee;
                totalInterestFee += interestFee;
            }

            paidFee = totalAmount - totalServiceFee;

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
        private DialogResult CheckTicketNumber()
        {
            string strTicketNumber = this.tbxTicketNumber.Text.Trim();
            if (strTicketNumber.Length == 0)
            {
                MessageBox.Show(this, "当票号不能为空！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbxTicketNumber.Focus();
                return DialogResult.No;
            }
            Query query = new Query(DDPawnTicket.Schema);
            query.AddWhere("TicketNumber",strTicketNumber);
            DataTable dt = query.ExecuteDataSet().Tables[0];
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show(this, "该当票号已经存在，请重新输入！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbxTicketNumber.Focus();
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
            if (intParentID == 194)
            {
                this.panelHouseInfo.Visible = true;
                this.panelCarInfo.Visible = false;
            }
            else if (intParentID == 186)
            {
                this.panelHouseInfo.Visible = false;
                this.panelCarInfo.Visible = true;
            }
            else
            {
                this.panelCarInfo.Visible = false;
                this.panelHouseInfo.Visible = false;
            }
        }

        private void tbxStartDate_Click(object sender, EventArgs e)
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
                this.tbxStartDate.Text = _date;
                //如果选中日期就自动隐藏MonthCalendar控件
                monthCalendar1.Hide();
            }

            DateTime dt = Convert.ToDateTime(this.tbxStartDate.Text); ;
            int spanMonths ;
            try
            {
                spanMonths = Convert.ToInt32(this.tbxPawnTerm.Text);
            }
            catch
            {
                MessageBox.Show("典当期限输入不正确！", "提示信息");
                return;
            }                
            dt = dt.AddMonths(spanMonths);
            this.tbxEndDate.Text = dt.Year.ToString() + "-" + dt.Month.ToString() + "-" + dt.Day.ToString();
        }

        private void btnGetCustomerInfo_Click(object sender, EventArgs e)
        {
            Int32 result;
            Int32 port = 1001;    //USB接口
            UInt32 flag = 0;

            result = CardRecognise.OpenCardReader(port, flag);

            if (result != 0)    
            {
                MessageBox.Show(this, "设备初始化失败，请检查设备是否已连接？", "提示信息",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                CardRecognise.PERSONINFOW newInfo = new CardRecognise.PERSONINFOW();
                result = CardRecognise.GetPersonMsgW(ref newInfo, "");
                if (result != 0)
                {
                    MessageBox.Show(this, "读卡错误，请重新操作！","提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    tbxCustomerName.Text = newInfo.name;
                    tbxContactPerson.Text = newInfo.name;
                    tbxCustomerAdd.Text = newInfo.address;
                    tbxCertNum.Text = newInfo.cardId;
                }
            }
            CardRecognise.CloseCardReader();
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
                this.tbxWeight.Text = dgr.Cells["Weight"].Value.ToString();
                this.tbxPrice.Text = dgr.Cells["Amount"].Value.ToString();
                this.tbxDiscountPercent.Text = dgr.Cells["DiscountPercent"].Value.ToString();
                this.tbxRemark.Text = dgr.Cells["Remark"].Value.ToString();
            }
        }

        private int UpdateCustomerInfo()
        {
            Query query = new Query(DDCustomerInfo.Schema);
            query.AddWhere("CertNUmber", this.tbxCertNum.Text);
            DataTable dt = query.ExecuteDataSet().Tables[0];
            if (dt.Rows.Count == 0)
            {
                DDCustomerInfo newCustomer = new DDCustomerInfo();
                newCustomer.CustomerName = this.tbxCustomerName.Text;
                newCustomer.PhoneNumber = this.tbxCustomerPhone.Text;
                newCustomer.Address = this.tbxCustomerAdd.Text;
                newCustomer.ContactPerson = this.tbxContactPerson.Text;
                newCustomer.CertTypeID = Convert.ToInt32(this.cbxCertType.SelectedValue);
                newCustomer.CertNumber = this.tbxCertNum.Text;
                newCustomer.Save();
                return newCustomer.CustomerID;
            }
            else
            {
                return Convert.ToInt32(dt.Rows[0]["CustomerID"]);
            }
        }

        private int UpdatePawages(int i)
        {

            DataGridViewRow dgr = dataGridView1.Rows[i];

            try
            {
                DDPawnageInfo newInfo = new DDPawnageInfo();
                newInfo.ClassID = Convert.ToInt32(dgr.Cells["ChildClassID"].Value);
                newInfo.ParentID = Convert.ToInt32(dgr.Cells["ParentClassID"].Value);
                newInfo.CountNumber = dgr.Cells["CountNumber"].Value.ToString();
                newInfo.Weight = dgr.Cells["Weight"].Value.ToString();
                newInfo.FeeRate = dgr.Cells["FeeRate"].Value.ToString();
                newInfo.InterestRate = dgr.Cells["InterestRate"].Value.ToString();
                newInfo.DiscountPercent = dgr.Cells["DiscountPercent"].Value.ToString();
                newInfo.Description = dgr.Cells["Description"].Value.ToString();  
                newInfo.StartDate = this.tbxStartDate.Text;
                newInfo.EndDate = this.tbxEndDate.Text;
                newInfo.Remark = dgr.Cells["Remark"].Value.ToString();                        
                newInfo.Save();
                return newInfo.PawnageID;
            }
            catch
            {
                MessageBox.Show(this, "当品信息更新失败，请检查数据库是否连接正确！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            } 
        }

        private int m_TicketID;

        private int UpdatePawnTicket()
        {
            try
            {
                int intCustomerID = UpdateCustomerInfo();
                DDPawnTicket newTicket = new DDPawnTicket();
                newTicket.CustomerID = intCustomerID;
                newTicket.TicketNumber = this.tbxTicketNumber.Text;
                newTicket.StartDate = this.tbxStartDate.Text;
                newTicket.EndDate = this.tbxEndDate.Text;
                newTicket.StatusID = 1;
                newTicket.Save();
                UpdateTicketNumber();
                m_TicketID = newTicket.TicketID;
                return newTicket.TicketID;
            }
            catch
            {
                MessageBox.Show(this, "当票信息更新失败，请检查数据库是否连接正确！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return 0;
            }
        }

        private void UpdateOperation()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                int iTicketID = UpdatePawnTicket();
                int iPawnageID = 0;
                double serviceFee = 0;
                double interestFee = 0;
                for (int i = dataGridView1.Rows.Count - 1; i > -1; i--)
                {
                    DataGridViewRow dgr = dataGridView1.Rows[i];
                    try
                    {
                        iPawnageID = UpdatePawages(i);
                        DDOperation newOperation = new DDOperation();
                        newOperation.TicketID = iTicketID;
                        newOperation.PawnageID = iPawnageID;
                        newOperation.OperationType = 1;   //1 ：新当
                        newOperation.OperationNumber = m_OperationNumber;
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
                        newOperation.OperationDate = this.tbxStartDate.Text;
                        newOperation.StartDate = this.tbxStartDate.Text;
                        newOperation.EndDate = this.tbxEndDate.Text;
                        newOperation.OperaterName = MainForm.AccountName;
                        newOperation.PreOperationID = 0;
                        newOperation.NextOperationID = 0;
                        newOperation.Save();                       
                    }
                    catch
                    {
                        MessageBox.Show(this, "建当操作失败，请检查数据库是否连接正确！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

        }

        private void PrintPawnTicket()
        {
            PawnTicketPrintPreviewForm frmPawnTicketPrint = new PawnTicketPrintPreviewForm(this, m_TicketID); //
            frmPawnTicketPrint.Show();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DialogResult dataCheckDlg = CheckTicketNumber();
            if (dataCheckDlg != DialogResult.OK)
            {
                return;
            }
            DialogResult result = MessageBox.Show("是否同时将信息存入数据库？", "打印当票", MessageBoxButtons.YesNoCancel);
            if (result != DialogResult.Cancel)
            {
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        UpdateOperation();
                        UpdateOperationNumber();
                        MessageBox.Show(this, "建当成功！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show(this, "建当操作失败，请检查数据库是否连接正确！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                PrintPawnTicket();
            }
        }

        private void tbxPawnTerm_TextChanged(object sender, EventArgs e)
        {
            int spanMonths=0;
            try
            {
                spanMonths = Convert.ToInt32(this.tbxPawnTerm.Text);
            }
            catch
            {
                MessageBox.Show("典当期限输入不正确！","提示信息");
                return;
            }

            DateTime startDate = Convert.ToDateTime(this.tbxStartDate.Text);
            DateTime endDate = startDate.AddMonths(spanMonths);
            this.tbxEndDate.Text = endDate.Year.ToString() + "-" + endDate.Month.ToString() + "-" + endDate.Day.ToString();
            CaculateAmount();
        }
   }
}