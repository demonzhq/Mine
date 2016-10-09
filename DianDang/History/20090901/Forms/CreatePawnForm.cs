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
        private void LoadCompanyInfo()
        {
            DDCompanyInfo company = new DDCompanyInfo("CompanyID",1);
            this.tbxCompanyName.Text = company.CompanyName;
            this.tbxCompanyPhone.Text = company.PhoneNumber;
            this.tbxCompanyAdd.Text = company.Address;
            this.tbxLicenseCode.Text = company.LicenseCode;
            this.tbxRemark.Text = company.Remark;
        }

        public CreatePawnForm(int TicketID)
        {
 
        }

        public CreatePawnForm()
        {
            InitializeComponent();
            LoadCompanyInfo();
            InitComboboxCertType();
            InitComboboxClass();
            InitFeeRate();
        }

        private void InitComboboxCertType()
        {
            Query query = new Query(DDCertType.Schema);
            DataSet comboCertTypeDataset = query.ExecuteDataSet();
            this.cbxCertType.DataSource = comboCertTypeDataset.Tables[0];
            this.cbxCertType.DisplayMember = "TypeName";
            this.cbxCertType.ValueMember = "TypeID";
        }
        private void InitComboboxClass()
        {
            Query query = new Query(DDPawnageClass.Schema);
            query.AddWhere("ParentID", 0);
            DataTable dt = query.ExecuteDataSet().Tables[0];
            
            this.cbxParentClass1.DisplayMember = "ClassName";
            this.cbxParentClass1.ValueMember = "ClassID";
            this.cbxParentClass1.DataSource = dt;
           
            this.cbxParentClass2.DisplayMember = "ClassName";
            this.cbxParentClass2.ValueMember = "ClassID";
            this.cbxParentClass2.DataSource = dt.Copy();
            
            this.cbxParentClass3.DisplayMember = "ClassName";
            this.cbxParentClass3.ValueMember = "ClassID";
            this.cbxParentClass3.DataSource = dt.Copy();

            Query query2 = new Query(DDPawnageClass.Schema);
            query2.AddWhere("ParentID", Convert.ToInt32(cbxParentClass1.SelectedValue));
            DataTable dt2 = query2.ExecuteDataSet().Tables[0];

            this.cbxChildClass1.DataSource = dt2;
            this.cbxChildClass1.DisplayMember = "ClassName";
            this.cbxChildClass1.ValueMember = "ClassID";

            this.cbxChildClass2.DataSource = dt2.Copy();
            this.cbxChildClass2.DisplayMember = "ClassName";
            this.cbxChildClass2.ValueMember = "ClassID";

            this.cbxChildClass3.DataSource = dt2.Copy();
            this.cbxChildClass3.DisplayMember = "ClassName";
            this.cbxChildClass3.ValueMember = "ClassID";
        }

        private void InitFeeRate()
        {
            DDFeeRate newFeeRate = new DDFeeRate("RateType", 1);
            this.tbxFeeRate.Text = newFeeRate.Rate.ToString();
            DDFeeRate newInterestRate = new DDFeeRate("RateType", 2);
            this.tbxInterestRate.Text = newInterestRate.Rate.ToString();
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

        private void UpdatePawages(int ticketID)
        {
            if (tbxCount1.Text != "0")
            {
                try
                {
                    DDPawnageInfo newInfo = new DDPawnageInfo();
                    newInfo.ClassID = Convert.ToInt32(this.cbxChildClass1.SelectedValue);
                    newInfo.CountNumber = this.tbxCount1.Text;
                    newInfo.Price = this.tbxPrice1.Text;
                    newInfo.Amount = this.tbxPawnageAmount1.Text;
                    newInfo.Description = this.tbxDescr1.Text;
                    newInfo.TicketID = ticketID;
                    newInfo.IsReif = 0;
                    newInfo.Save();
                }
                catch
                {
                    MessageBox.Show("当品添加失败，请检查数据库连接状态！");
                }
            }
            if (tbxCount2.Text != "0")
            {
                try
                {
                    DDPawnageInfo newInfo = new DDPawnageInfo();
                    newInfo.ClassID = Convert.ToInt32(this.cbxChildClass2.SelectedValue);
                    newInfo.CountNumber = this.tbxCount2.Text;
                    newInfo.Price = this.tbxPrice2.Text;
                    newInfo.Amount = this.tbxPawnageAmount2.Text;
                    newInfo.Description = this.tbxDescr2.Text;
                    newInfo.TicketID = ticketID;
                    newInfo.IsReif = 0;
                    newInfo.Save();
                }
                catch
                {
                    MessageBox.Show("当品添加失败，请检查数据库连接状态！");
                }
            }
            if (tbxCount3.Text != "0")
            {
                try
                {
                    DDPawnageInfo newInfo = new DDPawnageInfo();
                    newInfo.ClassID = Convert.ToInt32(this.cbxChildClass3.SelectedValue);
                    newInfo.CountNumber = this.tbxCount3.Text;
                    newInfo.Price = this.tbxPrice3.Text;
                    newInfo.Amount = this.tbxPawnageAmount3.Text;
                    newInfo.Description = this.tbxDescr3.Text;
                    newInfo.TicketID = ticketID;
                    newInfo.IsReif = 0;
                    newInfo.Save();
                }
                catch
                {
                    MessageBox.Show("当品添加失败，请检查数据库连接状态！");
                }
            }
        }

        private void UpdatePawnTicket()
        {
            int intCustomerID = UpdateCustomerInfo();

            DDPawnTicket newTicket = new DDPawnTicket();
            newTicket.CompanyID = 1;
            newTicket.CustomerID = intCustomerID;
            newTicket.StatusID = 1;
            newTicket.TicketNumber = this.tbxTicketNumber.Text;
            newTicket.StartDate = this.tbxStartDate.Text;
            newTicket.EndDate = this.tbxEndDate.Text;
            newTicket.OperateDate = this.tbxOperateDate.Text;
            newTicket.Remark = this.tbxRemark.Text;
            //newTicket.OperatorID = 1111;
            try
            {
                newTicket.Save();
                UpdatePawages(newTicket.TicketID);
            }
            catch
            {
                MessageBox.Show("当票信息更新失败，请检查数据库连接状态！");
            }
        }

        private void UpdateAllData()
        {
            UpdateCustomerInfo();            
            UpdatePawnTicket();
            MessageBox.Show("数据更新成功！","数据更新");
        }

        private void PrintPawnTicket()
        {
            
        }

        private void CheckAllData()                       //用户输入验证
        {
 
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DialogResult result=MessageBox.Show("是否同时将信息存入数据库？", "打印当票", MessageBoxButtons.YesNoCancel);
            if (result != DialogResult.Cancel)
            {
                CheckAllData();
                if (result == DialogResult.Yes)
                {
                    UpdateAllData();
                }
                PrintPawnTicket();
            }
        }

        private void cbxParentClass1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Query query = new Query(DDPawnageClass.Schema);
            query.AddWhere("ParentID",Convert.ToInt32(cbxParentClass1.SelectedValue));
            DataTable dt = query.ExecuteDataSet().Tables[0];
            this.cbxChildClass1.DataSource = dt;
        }

        private void cbxParentClass2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Query query = new Query(DDPawnageClass.Schema);
            query.AddWhere("ParentID", Convert.ToInt32(cbxParentClass2.SelectedValue));
            DataTable dt = query.ExecuteDataSet().Tables[0];
            this.cbxChildClass2.DataSource = dt;
        }

        private void cbxParentClass3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Query query = new Query(DDPawnageClass.Schema);
            query.AddWhere("ParentID", Convert.ToInt32(cbxParentClass3.SelectedValue));
            DataTable dt = query.ExecuteDataSet().Tables[0];
            this.cbxChildClass3.DataSource = dt;
        }

        private ToChineseValue newChinese = new ToChineseValue();
        private double totalAmount = 0;
        private void tbxTotalAmount_Enter(object sender, EventArgs e)
        {
            double tempFee = totalAmount * Convert.ToDouble(tbxFeeRate.Text) / 100;
            tbxFee.Text = tempFee.ToString();
            double tempInterestFee = totalAmount * Convert.ToDouble(tbxInterestRate.Text) / 100;
            double tempPaidFee = totalAmount - tempFee - tempInterestFee;
            tbxPaidFee.Text = tempPaidFee.ToString();

            tbxTotalAmount.Text = newChinese.toChineseChar(Convert.ToDecimal(totalAmount));
            tbxFeeChinese.Text = newChinese.toChineseChar(Convert.ToDecimal(tempFee));
            tbxPaidFeeChinese.Text = newChinese.toChineseChar(Convert.ToDecimal(tempPaidFee));
        }

        private void CaculateAmount(int number)
        {
            int count1, count2, count3;
            double price1,price2,price3;
            double percent1, percent2,percent3;
            double amount1 = Convert.ToDouble(this.tbxPawnageAmount1.Text);
            double amount2 = Convert.ToDouble(this.tbxPawnageAmount2.Text);
            double amount3 = Convert.ToDouble(this.tbxPawnageAmount3.Text);
            switch(number)
            {
                case 1:
                    try
                    {
                        count1 = Convert.ToInt32(this.tbxCount1.Text);
                        price1 = Convert.ToInt32(this.tbxPrice1.Text);
                        percent1 = Convert.ToInt32(this.tbxPercent1.Text);
                        amount1 = count1 * price1 * percent1 / 100;
                        this.tbxPawnageAmount1.Text = amount1.ToString();
                        this.tbxPawnageAmountChinese1.Text = newChinese.toChineseChar(Convert.ToDecimal(amount1));                        
                    }
                    catch
                    {
                        MessageBox.Show("请输入正确的字符！");
                    }
                    break;

                case 2:
                    try
                    {
                        count2 = Convert.ToInt32(this.tbxCount2.Text);
                        price2 = Convert.ToInt32(this.tbxPrice2.Text);
                        percent2 = Convert.ToInt32(this.tbxPercent2.Text);
                        amount2 = count2 * price2 * percent2 / 100;
                        this.tbxPawnageAmount2.Text = amount2.ToString();
                        this.tbxPawnageAmountChinese2.Text = newChinese.toChineseChar(Convert.ToDecimal(amount2));
                    }
                    catch
                    {
                        MessageBox.Show("请输入正确的字符！");
                    }
                    break;
                case 3:
                    try
                    {
                        count3 = Convert.ToInt32(this.tbxCount3.Text);
                        price3 = Convert.ToInt32(this.tbxPrice3.Text);
                        percent3 = Convert.ToInt32(this.tbxPercent3.Text);
                        amount3 = count3 * price3 * percent3 / 100;
                        this.tbxPawnageAmount3.Text = amount3.ToString();
                        this.tbxPawnageAmountChinese3.Text = newChinese.toChineseChar(Convert.ToDecimal(amount3));
                    }
                    catch
                    {
                        MessageBox.Show("请输入正确的字符！");
                    }
                    break;
                default:
                    break;
            }
            totalAmount = amount1 + amount2 + amount3;
            this.tbxPawnageAmountTotal.Text = totalAmount.ToString();
            this.tbxPawnageAmountTotalChinese.Text = newChinese.toChineseChar(Convert.ToDecimal(totalAmount));
        }

        private void tbxCount1_TextChanged(object sender, EventArgs e)
        {
            CaculateAmount(1);
        }

        private void tbxPrice1_TextChanged(object sender, EventArgs e)
        {
            CaculateAmount(1);
        }

        private void tbxPercent1_TextChanged(object sender, EventArgs e)
        {
            CaculateAmount(1);
        }

        private void tbxCount2_TextChanged(object sender, EventArgs e)
        {
            CaculateAmount(2);
        }

        private void tbxPrice2_TextChanged(object sender, EventArgs e)
        {
            CaculateAmount(2);
        }

        private void tbxPercent2_TextChanged(object sender, EventArgs e)
        {
            CaculateAmount(2);
        }

        private void tbxCount3_TextChanged(object sender, EventArgs e)
        {
            CaculateAmount(3);
        }

        private void tbxPrice3_TextChanged(object sender, EventArgs e)
        {
            CaculateAmount(3);
        }

        private void tbxPercent3_TextChanged(object sender, EventArgs e)
        {
            CaculateAmount(3);
        }

        int textBoxNumber;
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

        private void tbxOperateDate_Click(object sender, EventArgs e)
        {
            textBoxNumber = 3;
            this.monthCalendar1.Visible = true;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
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
                    case 3:
                        this.tbxOperateDate.Text = _date;
                        break;
                    default:
                        break;
                }
                //如果选中日期就自动隐藏MonthCalendar控件
                monthCalendar1.Hide();
            }
        }

        private void tbxCertNum_Click(object sender, EventArgs e)
        {
            Int32 result;
            Int32 port = 1001;    //USB接口
            UInt32 flag = 0;

            result = CardRecognise.OpenCardReader(port, flag);

            if (result != 0)    //
            {
                MessageBox.Show("设备初始化失败，请检查设备是否已连接？");
            }
            else
            {
                CardRecognise.PERSONINFOW newInfo = new CardRecognise.PERSONINFOW();
                result = CardRecognise.GetPersonMsgW(ref newInfo, "");
                if (result != 0)
                {
                    MessageBox.Show("读卡失败！");
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
    }
}