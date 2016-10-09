using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using LaptopBookingSystem;
using System.ComponentModel;
using System.Drawing;
using System.IO;

namespace LaptopBookingSystem
{
    public partial class frMainForm
    {
        private void HideAllOperationGroupBox()
        {
            gbOperationStartPage.Hide();
            gbBuyLaotop.Hide();
            gbAssignJob.Hide();
        }

        #region BuyLaptop
        private void btnBuyLaptop_Click(object sender, EventArgs e)
        {
            tcMainTabControl.SelectedTab = tpOperation;
            HideAllOperationGroupBox();
            gbBuyLaotop.Show();
            var queryCompanyInfo = from p in NCompanyInfo.All()
                                   where p.isDeleted == false
                                   select p;
            cbxBuyLaptopPurchaseCompany.DataSource = new BindingSource(queryCompanyInfo, null);
            cbxBuyLaptopPurchaseCompany.DisplayMember = NCompanyInfoTable.NameColumn;
            cbxBuyLaptopPurchaseCompany.ValueMember = NCompanyInfoTable.SidColumn;
            var queryLaptopTypeInfo = from p in NLaptopType.All()
                                       where p.isDeleted == false
                                       select p;
            cbxBuyLaptopModel.DataSource = new BindingSource(queryLaptopTypeInfo, null);
            cbxBuyLaptopModel.DisplayMember = NLaptopTypeTable.ModelColumn;
            cbxBuyLaptopModel.ValueMember = NLaptopTypeTable.SidColumn;                                  
        }
        private void btnBuyLaptopBuy_Click(object sender, EventArgs e)
        {
            string AddString = "";
            for (int i = 0; i < nbxBuyLaptopQuatity.Value.ToString().Length; i++)
                AddString += "0";
            try
            {
                for (int i = 0; i < nbxBuyLaptopQuatity.Value; i++)
                {
                    NLaptopInfo newLaptopInfo = new NLaptopInfo();
                    if (cbxBuyLaptopModel.SelectedValue != null)
                        newLaptopInfo.LaptopTypeSid = (int)cbxBuyLaptopModel.SelectedValue;
                    newLaptopInfo.NielsenAssetsNumber = tbxBuyLaptopAssetsFix.Text + (nbxBuyLaptopAssetsFrom.Value + i).ToString(AddString);
                    newLaptopInfo.LaptopSerial = "";
                    try
                    {
                        newLaptopInfo.Price = Convert.ToInt32(tbxBuyLaptopPrice.Text);
                    }
                    catch
                    {
                        newLaptopInfo.Price = 0;
                    }
                    newLaptopInfo.isComplete = true;
                    newLaptopInfo.PurchaseDate = dtBuyLaptopPurchaseDate.Value;
                    newLaptopInfo.Remark = tbxBuyLpatopRemark.Text;
                    if (cbxBuyLaptopPurchaseCompany.SelectedValue != null)
                        newLaptopInfo.PurchaseCompanySid = (int)cbxBuyLaptopPurchaseCompany.SelectedValue;
                    newLaptopInfo.isDeleted = false;
                    newLaptopInfo.Save();
                }
                MessageBox.Show("Purchase Sucess");
            }
            catch
            {
                MessageBox.Show("Purchase Error");
            }
        }
        #endregion

        #region AssignJob
        private void btnAssignJob_Click(object sender, EventArgs e)
        {
            tcMainTabControl.SelectedTab = tpOperation;
            HideAllOperationGroupBox();
            gbAssignJob.Show();
            gbAssignJobProject.Enabled = true;
            gbAssignJobCompany.Enabled = false;
            gbAssignJobLaptop.Enabled = false;
            var queryCityInfo = from p in NParameterCity.All()
                                where p.isDeleted == false
                                select p;
            cbxAssignJobCompanyCityFilter.DataSource = new BindingSource(queryCityInfo, null);
            cbxAssignJobCompanyCityFilter.DisplayMember = NParameterCityTable.CityColumn;
            cbxAssignJobCompanyCityFilter.ValueMember = NParameterCityTable.SidColumn;
        }

        #region Project
        private void btnAssignJobProjectNext_Click(object sender, EventArgs e)
        {
            if (dgvAssignJobProject.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a project");
            }
            else
            {
                gbAssignJobProject.Enabled = false;
                gbAssignJobCompany.Enabled = true;
                gbAssignJobLaptop.Enabled = true;
                var queryConpany = from p in NCompanyInfo.All()
                                   where p.isDeleted == false
                                   select p;
                var queryProjectAssignment = from p in NProjectAssignment.All()
                                             where p.isDeleted == false
                                             select p;

            }

            

        }
        private void btnAssignJobProjectFilter_Click(object sender, EventArgs e)
        {
            dgvAssignJobProject.Rows.Clear();
            var queryProjectInfo = from p in NProjectInfo.All()
                                   where p.isDeleted == false
                                   && p.ProjectNumber.Contains(tbxAssignJobProjectCodeFilter.Text)
                                   select p;
            foreach (var t in queryProjectInfo)
            {
                dgvAssignJobProject.Rows.Add();
                dgvAssignJobProject.Rows[dgvAssignJobProject.Rows.Count - 1].Cells[dgvAssignJobProjectCode.Name].Value = t.ProjectNumber;
                dgvAssignJobProject.Rows[dgvAssignJobProject.Rows.Count - 1].Cells[dgvAssignJobProjectName.Name].Value = t.Name;
            }
        }
        #endregion

        #region Operation
        private void btnAssignJobCompanyCityFilterAll_Click(object sender, EventArgs e)
        {
            cbxAssignJobCompanyCityFilter.SelectedValue = -1;
        }
        private void btnAssignJobCompanyFilter_Click(object sender, EventArgs e)
        {
            dgvAssignjobCompany.Rows.Clear();
            IQueryable<NCompanyInfo> queryCompanyInfo;
            if (cbxAssignJobCompanyCityFilter.SelectedValue == null)
            {
                queryCompanyInfo = from p in NCompanyInfo.All()
                                   where p.isDeleted == false
                                   && p.Code.Contains(tbxAssignJobCompanyCodeFilter.Text)
                                   select p;
            }
            else
            {
                queryCompanyInfo = from p in NCompanyInfo.All()
                                   where p.isDeleted == false
                                   && p.Code.Contains(tbxAssignJobCompanyCodeFilter.Text)
                                   && p.ParameterCitySid == (int)cbxAssignJobCompanyCityFilter.SelectedValue
                                   select p;
            }
            foreach (var t in queryCompanyInfo)
            {
                dgvAssignjobCompany.Rows.Add();
                dgvAssignjobCompany.Rows[dgvAssignjobCompany.Rows.Count - 1].Cells[dgvAssignJobCompanyCode.Name].Value = t.Code;
                dgvAssignjobCompany.Rows[dgvAssignjobCompany.Rows.Count - 1].Cells[dgvAssignJobCompanyName.Name].Value = t.Name;
            }
        }
        #endregion


        private void btnAssignJobAssign_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
