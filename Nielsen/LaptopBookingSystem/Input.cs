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
        private void HideAllInputGroupBox()
        {
            gbInputStartPage.Hide();
            gbProjectInfo.Hide();
            gbParameterInfo.Hide();
            gbProjectSuperviserInfo.Hide();
            gbCompanyInfo.Hide();
            gbLaptopType.Hide();
            gbLaptopInfo.Hide();
        }

        #region ProjectInfo
        private void btnProjectInfoMantance_Click(object sender, EventArgs e)
        {
            tcMainTabControl.SelectedTab = tpInput;
            HideAllInputGroupBox();
            gbProjectInfo.Show();
            var queryProjectSuperviser = NProjectSuperviserInfo.Find(x => x.isDeleted == false);
            dgvProjectInfoProjectSuperviserSid.DataSource = new BindingSource(queryProjectSuperviser, null);
            dgvProjectInfoProjectSuperviserSid.DisplayMember = NProjectSuperviserInfoTable.NameColumn;
            dgvProjectInfoProjectSuperviserSid.ValueMember = NProjectSuperviserInfoTable.SidColumn;
            var queryProjectType = NParameterProjectType.Find(x => x.isDeleted == false);
            dgvProjectInfoProjectTypeSid.DataSource = new BindingSource(queryProjectType,null);
            dgvProjectInfoProjectTypeSid.DisplayMember = NParameterProjectTypeTable.ProjectTypeColumn;
            dgvProjectInfoProjectTypeSid.ValueMember = NParameterProjectTypeTable.SidColumn;
            btnProjectInfoFilter_Click(sender, e);
        }

        private void btnProjectInfoFilter_Click(object sender, EventArgs e)
        {
            dgvProjectInfo.Rows.Clear();
            var query = from p in NProjectInfo.All()
                        where p.ProjectNumber.Contains(tbxProjectInfoNumberFilter.Text)
                        && p.Name.Contains(tbxProjectInfoNameFilter.Text)
                        && p.isDeleted == false
                        select p;
            isLoading = true;
            foreach (var t in query)
            {
                dgvProjectInfo.Rows.Add();
                dgvProjectInfo.Rows[dgvProjectInfo.Rows.Count - 1].Cells[dgvProjectInfoSid.Name].Value = t.Sid;
                dgvProjectInfo.Rows[dgvProjectInfo.Rows.Count - 1].Cells[dgvProjectInfoNumber.Name].Value = t.ProjectNumber.TrimEnd();
                dgvProjectInfo.Rows[dgvProjectInfo.Rows.Count - 1].Cells[dgvProjectInfoName.Name].Value = t.Name.TrimEnd();
                dgvProjectInfo.Rows[dgvProjectInfo.Rows.Count - 1].Cells[dgvProjectInfoProjectSuperviserSid.Name].Value = t.ProjectSuperviserInfoSid;
                dgvProjectInfo.Rows[dgvProjectInfo.Rows.Count - 1].Cells[dgvProjectInfoProjectTypeSid.Name].Value = t.ProjectTypeSid;
                dgvProjectInfo.Rows[dgvProjectInfo.Rows.Count - 1].Cells[dgvProjectInfoLaunchDate.Name].Value = t.LaunchDate.Value.ToString("yyyy-MM-dd");
                dgvProjectInfo.Rows[dgvProjectInfo.Rows.Count - 1].Cells[dgvProjectInfoCloseDate.Name].Value = t.CloseDate.Value.ToString("yyyy-MM-dd");
            }
            
            isLoading = false;
        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            dgvProjectInfo.Rows.Add();
            isLoading = true;
            dgvProjectInfo.Rows[dgvProjectInfo.Rows.Count - 1].Cells[dgvProjectInfoLaunchDate.Name].Value = DateTime.Now.ToString("yyyy-MM-dd");
            dgvProjectInfo.Rows[dgvProjectInfo.Rows.Count - 1].Cells[dgvProjectInfoCloseDate.Name].Value = DateTime.Now.ToString("yyyy-MM-dd");
            NProjectInfo newProjectInfo = new NProjectInfo();
            newProjectInfo.Name = "";
            newProjectInfo.ProjectNumber = "";
            newProjectInfo.LaunchDate = DateTime.Now;
            newProjectInfo.CloseDate = DateTime.Now;
            newProjectInfo.isDeleted = false;
            newProjectInfo.Save();
            dgvProjectInfo.Rows[dgvProjectInfo.Rows.Count - 1].Cells[dgvProjectInfoSid.Name].Value = newProjectInfo.Sid;
            isLoading = false;
        }

        private void dgvProjectInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (isLoading == false && e.RowIndex != -1 && dgvProjectInfo.Columns[e.ColumnIndex].Name != dgvProjectInfoOperation.Name)
            {
                int ProjectSid = 0;
                ProjectSid = (int)dgvProjectInfo.Rows[e.RowIndex].Cells[dgvProjectInfoSid.Name].Value;

                DateTime newLaunchDate = new DateTime();
                DateTime newCloseDate = new DateTime();
                try
                {
                    newLaunchDate = DateTime.Parse(dgvProjectInfo.Rows[e.RowIndex].Cells[dgvProjectInfoLaunchDate.Name].Value.ToString().TrimEnd());
                    newCloseDate = DateTime.Parse(dgvProjectInfo.Rows[e.RowIndex].Cells[dgvProjectInfoCloseDate.Name].Value.ToString().TrimEnd());
                }
                catch
                {
                    MessageBox.Show("Date Error");
                    return;
                }


                NProjectInfo theProjectInfo = NProjectInfo.SingleOrDefault(x => x.Sid == ProjectSid);
                if (dgvProjectInfo.Rows[e.RowIndex].Cells[dgvProjectInfoNumber.Name].Value != null)
                    theProjectInfo.ProjectNumber = (string)dgvProjectInfo.Rows[e.RowIndex].Cells[dgvProjectInfoNumber.Name].Value;
                if (dgvProjectInfo.Rows[e.RowIndex].Cells[dgvProjectInfoName.Name].Value != null)
                    theProjectInfo.Name = (string)dgvProjectInfo.Rows[e.RowIndex].Cells[dgvProjectInfoName.Name].Value;
                if (dgvProjectInfo.Rows[e.RowIndex].Cells[dgvProjectInfoProjectSuperviserSid.Name].Value != null)
                    theProjectInfo.ProjectSuperviserInfoSid = (int)dgvProjectInfo.Rows[e.RowIndex].Cells[dgvProjectInfoProjectSuperviserSid.Name].Value;
                if (dgvProjectInfo.Rows[e.RowIndex].Cells[dgvProjectInfoProjectTypeSid.Name].Value != null)
                    theProjectInfo.ProjectTypeSid = (int)dgvProjectInfo.Rows[e.RowIndex].Cells[dgvProjectInfoProjectTypeSid.Name].Value;
                theProjectInfo.LaunchDate = newLaunchDate;
                theProjectInfo.CloseDate = newCloseDate;
                theProjectInfo.Save();
            }
        }

        private void btnDeleteSelect_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvProjectInfo.Rows.Count;i++)
            {
                if (dgvProjectInfo.Rows[i].Cells[dgvProjectInfoOperation.Name].Value != null && (bool)dgvProjectInfo.Rows[i].Cells[dgvProjectInfoOperation.Name].Value == true)
                {
                    var theProjectInfos = NProjectInfo.SingleOrDefault(x => x.Sid == (int)dgvProjectInfo.Rows[i].Cells[dgvProjectInfoSid.Name].Value);
                    theProjectInfos.isDeleted = true;
                    theProjectInfos.Save();
                }
            }
            btnProjectInfoFilter_Click(sender, e);
        }
        #endregion

        #region ParameterInfo
        private void btnParameterInfo_Click(object sender, EventArgs e)
        {
            tcMainTabControl.SelectedTab = tpInput;
            RefreshParameterPage();
            HideAllInputGroupBox();
            gbParameterInfo.Show();
        }

        private void RefreshParameterPage()
        {
            isLoading = true;
            dgvParameterCityInfo.Rows.Clear();
            dgvParameterProjectTypeInfo.Rows.Clear();
            var queryCity = from p in NParameterCity.All()
                        where p.isDeleted == false
                        select p;
            foreach (var t in queryCity)
            {
                dgvParameterCityInfo.Rows.Add();
                dgvParameterCityInfo.Rows[dgvParameterCityInfo.Rows.Count - 1].Cells[dgvParameterCityInfoSid.Name].Value = t.Sid;
                dgvParameterCityInfo.Rows[dgvParameterCityInfo.Rows.Count - 1].Cells[dgvParameterCityInfoCity.Name].Value = t.City.TrimEnd();
            }
            var queryProjectType = from p in NParameterProjectType.All()
                                   where p.isDeleted == false
                                   select p;
            foreach (var t in queryProjectType)
            {
                dgvParameterProjectTypeInfo.Rows.Add();
                dgvParameterProjectTypeInfo.Rows[dgvParameterProjectTypeInfo.Rows.Count - 1].Cells[dgvParameterProjectTypeInfoSid.Name].Value = t.Sid;
                dgvParameterProjectTypeInfo.Rows[dgvParameterProjectTypeInfo.Rows.Count - 1].Cells[dgvParameterProjectTypeInfoProjectType.Name].Value = t.ProjectType.TrimEnd();
            }
            isLoading = false;
        }

        private void btnParameterCityInfoAdd_Click(object sender, EventArgs e)
        {
            isLoading = true;
            dgvParameterCityInfo.Rows.Add();
            NParameterCity newCity = new NParameterCity();
            newCity.City = "";
            newCity.isDeleted = false;
            newCity.Save();
            dgvParameterCityInfo.Rows[dgvParameterCityInfo.Rows.Count - 1].Cells[dgvParameterCityInfoSid.Name].Value = newCity.Sid;
            isLoading = false;
        }

        private void dgvParameterCityInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (isLoading == false && e.RowIndex != -1 && dgvParameterCityInfo.Columns[e.ColumnIndex].Name != dgvParameterCityInfoOperation.Name)
            {
                int ParameterInfoSid = (int)dgvParameterCityInfo.Rows[e.RowIndex].Cells[dgvParameterCityInfoSid.Name].Value;
                NParameterCity theCity = NParameterCity.SingleOrDefault(x => x.Sid == ParameterInfoSid);
                theCity.City = (string)dgvParameterCityInfo.Rows[e.RowIndex].Cells[dgvParameterCityInfoCity.Name].Value;
                theCity.Save();
            }
        }

        private void btnParameterCityInfoDelete_Click(object sender, EventArgs e)
        {
            isLoading = true;
            for (int i = 0; i < dgvParameterCityInfo.Rows.Count; i++)
            {
                if (dgvParameterCityInfo.Rows[i].Cells[dgvParameterCityInfoOperation.Name].Value != null && (bool)dgvParameterCityInfo.Rows[i].Cells[dgvParameterCityInfoOperation.Name].Value == true)
                {
                    NParameterCity theCity = NParameterCity.SingleOrDefault(x => x.Sid == (int)dgvParameterCityInfo.Rows[i].Cells[dgvParameterCityInfoSid.Name].Value);
                    theCity.isDeleted = true;
                    theCity.Save();
                }
            }
            RefreshParameterPage();
            isLoading = false;
        }

        private void btnProjectTypeInfoAdd_Click(object sender, EventArgs e)
        {
            isLoading = true;
            dgvParameterProjectTypeInfo.Rows.Add();
            NParameterProjectType newProjectType = new NParameterProjectType();
            newProjectType.ProjectType = "";
            newProjectType.isDeleted = false;
            newProjectType.Save();
            dgvParameterProjectTypeInfo.Rows[dgvParameterProjectTypeInfo.Rows.Count - 1].Cells[dgvParameterProjectTypeInfoSid.Name].Value = newProjectType.Sid;
            isLoading = false;
        }

        private void dgvParameterProjectTypeInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (isLoading == false && e.RowIndex != -1 && dgvParameterProjectTypeInfo.Columns[e.ColumnIndex].Name != dgvParameterProjectTypeInfoOperation.Name)
            {
                int ParameterInfoSid = (int)dgvParameterProjectTypeInfo.Rows[e.RowIndex].Cells[dgvParameterProjectTypeInfoSid.Name].Value;
                NParameterProjectType theProjectType = NParameterProjectType.SingleOrDefault(x => x.Sid == ParameterInfoSid);
                theProjectType.ProjectType = (string)dgvParameterProjectTypeInfo.Rows[e.RowIndex].Cells[dgvParameterProjectTypeInfoProjectType.Name].Value;
                theProjectType.Save();
            }
        }

        private void btnProjectTypeDelete_Click(object sender, EventArgs e)
        {
            isLoading = true;
            for (int i = 0; i < dgvParameterProjectTypeInfo.Rows.Count; i++)
            {
                if (dgvParameterProjectTypeInfo.Rows[i].Cells[dgvParameterProjectTypeInfoOperation.Name].Value != null && (bool)dgvParameterProjectTypeInfo.Rows[i].Cells[dgvParameterProjectTypeInfoOperation.Name].Value == true)
                {
                    NParameterProjectType theProjectType = NParameterProjectType.SingleOrDefault(x => x.Sid == (int)dgvParameterProjectTypeInfo.Rows[i].Cells[dgvParameterProjectTypeInfoSid.Name].Value);
                    theProjectType.isDeleted = true;
                    theProjectType.Save();
                }
            }
            RefreshParameterPage();
            isLoading = false;
        }
        #endregion

        #region ProjectSuperviser

        private void btnProjectSuperviseInfo_Click(object sender, EventArgs e)
        {
            tcMainTabControl.SelectedTab = tpInput;
            RefreshParameterPage();
            HideAllInputGroupBox();
            btnProjectSuperviserInfoSearch_Click(sender, e);
            gbProjectSuperviserInfo.Show();
        }

        private void btnProjectSuperviserInfoSearch_Click(object sender, EventArgs e)
        {
            isLoading = true;
            dgvProjectSuperviserInfo.Rows.Clear();
            var query = from p in NProjectSuperviserInfo.All()
                        where p.isDeleted == false
                        && p.Name.Contains(tbxProjectSuperviserInfoName.Text)
                        select p;
            foreach (var t in query)
            {
                dgvProjectSuperviserInfo.Rows.Add();
                dgvProjectSuperviserInfo.Rows[dgvProjectSuperviserInfo.Rows.Count - 1].Cells[dgvProjectSuperviserInfoSid.Name].Value = t.Sid;
                dgvProjectSuperviserInfo.Rows[dgvProjectSuperviserInfo.Rows.Count - 1].Cells[dgvProjectSuperviserInfoName.Name].Value = t.Name.TrimEnd();
                dgvProjectSuperviserInfo.Rows[dgvProjectSuperviserInfo.Rows.Count - 1].Cells[dgvProjectSuperviserInfoPhone.Name].Value = t.Phone.TrimEnd();
                dgvProjectSuperviserInfo.Rows[dgvProjectSuperviserInfo.Rows.Count - 1].Cells[dgvProjectSuperviserInfoMobile.Name].Value = t.Mobile.TrimEnd();
                dgvProjectSuperviserInfo.Rows[dgvProjectSuperviserInfo.Rows.Count - 1].Cells[dgvProjectSuperviserInfoMailAddress.Name].Value = t.MailAddress.TrimEnd();
            }
            isLoading = false;
        }

        private void dgvProjectSuperviserInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (isLoading == false && e.RowIndex != -1 && dgvProjectSuperviserInfo.Columns[e.ColumnIndex].Name != dgvProjectSuperviserInfoOperation.Name)
            {
                int theSid = (int)dgvProjectSuperviserInfo.Rows[e.RowIndex].Cells[dgvProjectSuperviserInfoSid.Name].Value;
                NProjectSuperviserInfo theSuperviserInfo = NProjectSuperviserInfo.SingleOrDefault(x => x.Sid == theSid);
                if (dgvProjectSuperviserInfo.Rows[e.RowIndex].Cells[dgvProjectSuperviserInfoName.Name].Value != null)
                    theSuperviserInfo.Name = (string)dgvProjectSuperviserInfo.Rows[e.RowIndex].Cells[dgvProjectSuperviserInfoName.Name].Value;
                if (dgvProjectSuperviserInfo.Rows[e.RowIndex].Cells[dgvProjectSuperviserInfoPhone.Name].Value != null)
                    theSuperviserInfo.Phone = (string)dgvProjectSuperviserInfo.Rows[e.RowIndex].Cells[dgvProjectSuperviserInfoPhone.Name].Value;
                if (dgvProjectSuperviserInfo.Rows[e.RowIndex].Cells[dgvProjectSuperviserInfoMobile.Name].Value != null)
                    theSuperviserInfo.Mobile = (string)dgvProjectSuperviserInfo.Rows[e.RowIndex].Cells[dgvProjectSuperviserInfoMobile.Name].Value;
                if (dgvProjectSuperviserInfo.Rows[e.RowIndex].Cells[dgvProjectSuperviserInfoMailAddress.Name].Value != null)
                    theSuperviserInfo.MailAddress = (string)dgvProjectSuperviserInfo.Rows[e.RowIndex].Cells[dgvProjectSuperviserInfoMailAddress.Name].Value;
                theSuperviserInfo.Save();
            }
        }

        private void btnProjectSuperviserInfoAdd_Click(object sender, EventArgs e)
        {
            isLoading = true;
            dgvProjectSuperviserInfo.Rows.Add();
            NProjectSuperviserInfo newProjectSuperviserInfo = new NProjectSuperviserInfo();
            newProjectSuperviserInfo.Name = "";
            newProjectSuperviserInfo.Phone = "";
            newProjectSuperviserInfo.Mobile = "";
            newProjectSuperviserInfo.MailAddress = "";
            newProjectSuperviserInfo.isDeleted = false;
            newProjectSuperviserInfo.Save();
            dgvProjectSuperviserInfo.Rows[dgvProjectSuperviserInfo.Rows.Count - 1].Cells[dgvProjectSuperviserInfoSid.Name].Value = newProjectSuperviserInfo.Sid;
            isLoading = false;
        }

        private void btnProjectSuperviserInfoDelete_Click(object sender, EventArgs e)
        {
            isLoading = true;
            for (int i = 0; i < dgvProjectSuperviserInfo.Rows.Count; i++)
            {
                if (dgvProjectSuperviserInfo.Rows[i].Cells[dgvProjectSuperviserInfoOperation.Name].Value != null && (bool)dgvProjectSuperviserInfo.Rows[i].Cells[dgvProjectSuperviserInfoOperation.Name].Value == true)
                {
                    NProjectSuperviserInfo theSuperviserInfo = NProjectSuperviserInfo.SingleOrDefault(x => x.Sid == (int)dgvProjectSuperviserInfo.Rows[i].Cells[dgvProjectSuperviserInfoSid.Name].Value);
                    theSuperviserInfo.isDeleted = true;
                    theSuperviserInfo.Save();
                }
            }
            btnProjectSuperviserInfoSearch_Click(sender, e);
            isLoading = false;
        }
        #endregion

        #region CompanyInfo
        private void btnCompanyInfo_Click(object sender, EventArgs e)
        {
            isLoading = true;
            tcMainTabControl.SelectedTab = tpInput;
            RefreshParameterPage();
            HideAllInputGroupBox();
            gbCompanyInfo.Show();
            var queryCity = from p in NParameterCity.All()
                            where p.isDeleted == false
                            select p;
            cbxCompanyInfoCityFilter.DataSource = new BindingSource(queryCity, null);
            cbxCompanyInfoCityFilter.DisplayMember = NParameterCityTable.CityColumn;
            cbxCompanyInfoCityFilter.ValueMember = NParameterCityTable.SidColumn;
            cbxCompanyInfoCityFilter.SelectedValue = -1;
            dgvCompanyInfoParameterCitySid.DataSource = new BindingSource(queryCity, null);
            dgvCompanyInfoParameterCitySid.DisplayMember = NParameterCityTable.CityColumn;
            dgvCompanyInfoParameterCitySid.ValueMember = NParameterCityTable.SidColumn;
            btnCompanyInfoFilter_Click(sender, e);
            isLoading = false;
        }
        private void btnCompanyInfoCityFilterShowAll_Click(object sender, EventArgs e)
        {
            cbxCompanyInfoCityFilter.SelectedValue = -1;
        }
        private void btnCompanyInfoFilter_Click(object sender, EventArgs e)
        {
            isLoading = true;
            dgvCompanyInfo.Rows.Clear();

            IQueryable<NCompanyInfo> query;
            if (cbxCompanyInfoCityFilter.SelectedValue == null)
            {
                query = from p in NCompanyInfo.All()
                        where p.Code.Contains(tbxCompanyInfoCodeFilter.Text)
                        && p.Name.Contains(tbxCompanyInfoNameFilter.Text)
                        && p.isDeleted == false
                        select p;
            }
            else
            {
                query = from p in NCompanyInfo.All()
                        where p.Code.Contains(tbxCompanyInfoCodeFilter.Text)
                        && p.Name.Contains(tbxCompanyInfoNameFilter.Text)
                        && p.ParameterCitySid == (int)cbxCompanyInfoCityFilter.SelectedValue
                        && p.isDeleted == false
                        select p;
            }
            foreach (var t in query)
            {
                dgvCompanyInfo.Rows.Add();
                dgvCompanyInfo.Rows[dgvCompanyInfo.Rows.Count - 1].Cells[dgvCompanyInfoSid.Name].Value = t.Sid;
                dgvCompanyInfo.Rows[dgvCompanyInfo.Rows.Count - 1].Cells[dgvCompanyInfoName.Name].Value = t.Name;
                dgvCompanyInfo.Rows[dgvCompanyInfo.Rows.Count - 1].Cells[dgvCompanyInfoCode.Name].Value = t.Code;
                dgvCompanyInfo.Rows[dgvCompanyInfo.Rows.Count - 1].Cells[dgvCompanyInfoParameterCitySid.Name].Value = t.ParameterCitySid;
                dgvCompanyInfo.Rows[dgvCompanyInfo.Rows.Count - 1].Cells[dgvCompanyInfoisVender.Name].Value = t.isVender;
            }
            isLoading = false;
        }
        private void btnCompanyInfoAdd_Click(object sender, EventArgs e)
        {
            isLoading = true;
            dgvCompanyInfo.Rows.Add();
            NCompanyInfo newCompanInfo = new NCompanyInfo();
            newCompanInfo.Name = "";
            newCompanInfo.Code = "";
            newCompanInfo.isVender = false;
            newCompanInfo.isDeleted = false;
            newCompanInfo.Save();
            dgvCompanyInfo.Rows[dgvCompanyInfo.Rows.Count - 1].Cells[dgvCompanyInfoSid.Name].Value = newCompanInfo.Sid;
            isLoading = false;
        }
        private void dgvCompanyInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && isLoading == false && dgvCompanyInfo.Columns[e.ColumnIndex].Name != dgvCompanyInfoOperation.Name)
            {
                int Sid = (int)dgvCompanyInfo.Rows[e.RowIndex].Cells[dgvCompanyInfoSid.Name].Value;
                NCompanyInfo theCity = NCompanyInfo.SingleOrDefault(x => x.Sid == Sid);
                if (dgvCompanyInfo.Rows[e.RowIndex].Cells[dgvCompanyInfoName.Name].Value != null)
                    theCity.Name = (string)dgvCompanyInfo.Rows[e.RowIndex].Cells[dgvCompanyInfoName.Name].Value;
                if (dgvCompanyInfo.Rows[e.RowIndex].Cells[dgvCompanyInfoCode.Name].Value != null)
                    theCity.Code = (string)dgvCompanyInfo.Rows[e.RowIndex].Cells[dgvCompanyInfoCode.Name].Value;
                if (dgvCompanyInfo.Rows[e.RowIndex].Cells[dgvCompanyInfoParameterCitySid.Name].Value != null)
                    theCity.ParameterCitySid = (int)dgvCompanyInfo.Rows[e.RowIndex].Cells[dgvCompanyInfoParameterCitySid.Name].Value;
                if (dgvCompanyInfo.Rows[e.RowIndex].Cells[dgvCompanyInfoisVender.Name].Value != null)
                    theCity.isVender = (bool)dgvCompanyInfo.Rows[e.RowIndex].Cells[dgvCompanyInfoisVender.Name].Value;
                theCity.Save();
            }
        }
        private void btnCompanyInfoDelete_Click(object sender, EventArgs e)
        {
            isLoading = true;
            for (int i = 0; i < dgvCompanyInfo.Rows.Count; i++)
            {
                if (dgvCompanyInfo.Rows[i].Cells[dgvCompanyInfoOperation.Name].Value != null && (bool)dgvCompanyInfo.Rows[i].Cells[dgvCompanyInfoOperation.Name].Value == true)
                {
                    NCompanyInfo theCompanyInfo = NCompanyInfo.SingleOrDefault(x => x.Sid == (int)dgvCompanyInfo.Rows[i].Cells[dgvCompanyInfoSid.Name].Value);
                    theCompanyInfo.isDeleted = true;
                    theCompanyInfo.Save();
                }
            }
            btnCompanyInfoFilter_Click(sender, e);
            isLoading = false;
        }
        #endregion

        #region LaptopType
        int dgvLapTopTypeInfoPhotoPickUpRowIndex = 0;
        private void btnLaptopTypeInfo_Click(object sender, EventArgs e)
        {
            tcMainTabControl.SelectedTab = tpInput;
            RefreshParameterPage();
            HideAllInputGroupBox();
            gbLaptopType.Show();
            btnLaptopTypeInfoFilter_Click(sender, e);
        }
        private void dgvLaptopTypeInfo_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvLapTopTypeInfoPhotoPickUpRowIndex = e.RowIndex;
            if (dgvLaptopTypeInfo.Columns[e.ColumnIndex].Name == dgvLaptopTypeInfoImage.Name)
            {
                PhotoPicker.ShowDialog();
            }
        }
        private void PhotoPicker_FileOk(object sender, CancelEventArgs e)
        {
            dgvLaptopTypeInfo.Rows[dgvLapTopTypeInfoPhotoPickUpRowIndex].Cells[dgvLaptopTypeInfoImage.Name].Value = Image.FromFile(PhotoPicker.FileNames[0]);
        }
        private void btnLaptopTypeInfoFilter_Click(object sender, EventArgs e)
        {
            isLoading = true;
            dgvLaptopTypeInfo.Rows.Clear();
            var query = from p in NLaptopType.All()
                        where p.isDeleted == false
                        select p;
            foreach (var t in query)
            {
                dgvLaptopTypeInfo.Rows.Add();
                dgvLaptopTypeInfo.Rows[dgvLaptopTypeInfo.Rows.Count - 1].Cells[dgvLaptopTypeInfoSid.Name].Value = t.Sid;
                if (t.Image != null)
                {
                    MemoryStream buf = new MemoryStream(t.Image);
                    dgvLaptopTypeInfo.Rows[dgvLaptopTypeInfo.Rows.Count - 1].Cells[dgvLaptopTypeInfoImage.Name].Value = Image.FromStream(buf);
                }
                dgvLaptopTypeInfo.Rows[dgvLaptopTypeInfo.Rows.Count - 1].Cells[dgvLaptopTypeInfoBrand.Name].Value = t.Brand;
                dgvLaptopTypeInfo.Rows[dgvLaptopTypeInfo.Rows.Count - 1].Cells[dgvLaptopTypeInfoModel.Name].Value = t.Model;
                dgvLaptopTypeInfo.Rows[dgvLaptopTypeInfo.Rows.Count - 1].Cells[dgvLaptopTypeInfoisTouchScreen.Name].Value = t.isTouchScreen;
                dgvLaptopTypeInfo.Rows[dgvLaptopTypeInfo.Rows.Count - 1].Cells[dgvLaptopTypeInfoBatteryCapacity.Name].Value = t.BatteryCapacity;
            }
            isLoading = false;
        }
        private void btnLaptopTypeInfoAdd_Click(object sender, EventArgs e)
        {
            isLoading = true;
            dgvLaptopTypeInfo.Rows.Add();
            NLaptopType newLaptopType = new NLaptopType();
            newLaptopType.Brand = "";
            newLaptopType.Model = "";
            newLaptopType.isTouchScreen = false;
            newLaptopType.BatteryCapacity = 0;
            newLaptopType.isDeleted = false;
            newLaptopType.Save();
            dgvLaptopTypeInfo.Rows[dgvLaptopTypeInfo.Rows.Count - 1].Cells[dgvLaptopTypeInfoSid.Name].Value = newLaptopType.Sid;
            isLoading = false;
        }
        private void dgvLaptopTypeInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && isLoading == false && dgvLaptopTypeInfo.Columns[e.ColumnIndex].Name != dgvLaptopTypeInfoOperation.Name)
            {
                int theSid = (int)dgvLaptopTypeInfo.Rows[e.RowIndex].Cells[dgvLaptopTypeInfoSid.Name].Value;
                NLaptopType theLaptopTypeInfo = NLaptopType.SingleOrDefault(x => x.Sid == theSid);
                if (dgvLaptopTypeInfo.Rows[e.RowIndex].Cells[dgvLaptopTypeInfoImage.Name].Value != null)
                {
                    Image theImage = (Image)dgvLaptopTypeInfo.Rows[e.RowIndex].Cells[dgvLaptopTypeInfoImage.Name].Value;
                    MemoryStream ms = new MemoryStream();
                    theImage.Save(ms,System.Drawing.Imaging.ImageFormat.Jpeg);
                    /*
                    System.IO.FileStream fs = new System.IO.FileStream(PhotoPicker.FileNames[0], System.IO.FileMode.Open, System.IO.FileAccess.Read);
                    byte[] buffByte = new byte[fs.Length];
                    fs.Read(buffByte, 0, (int)fs.Length);
                    fs.Close();
                    */
                    theLaptopTypeInfo.Image = ms.ToArray();
                }
                if (dgvLaptopTypeInfo.Rows[e.RowIndex].Cells[dgvLaptopTypeInfoBrand.Name].Value != null)
                    theLaptopTypeInfo.Brand = (string)dgvLaptopTypeInfo.Rows[e.RowIndex].Cells[dgvLaptopTypeInfoBrand.Name].Value;
                if (dgvLaptopTypeInfo.Rows[e.RowIndex].Cells[dgvLaptopTypeInfoModel.Name].Value != null)
                    theLaptopTypeInfo.Model = (string)dgvLaptopTypeInfo.Rows[e.RowIndex].Cells[dgvLaptopTypeInfoModel.Name].Value;
                if (dgvLaptopTypeInfo.Rows[e.RowIndex].Cells[dgvLaptopTypeInfoisTouchScreen.Name].Value != null)
                    theLaptopTypeInfo.isTouchScreen = (bool)dgvLaptopTypeInfo.Rows[e.RowIndex].Cells[dgvLaptopTypeInfoisTouchScreen.Name].Value;
                if (dgvLaptopTypeInfo.Rows[e.RowIndex].Cells[dgvLaptopTypeInfoBatteryCapacity.Name].Value != null)
                    try
                    {
                        theLaptopTypeInfo.BatteryCapacity = Convert.ToInt32(dgvLaptopTypeInfo.Rows[e.RowIndex].Cells[dgvLaptopTypeInfoBatteryCapacity.Name].Value);
                    }
                    catch
                    {
                        MessageBox.Show("Battery Capacity Error");
                    }
                theLaptopTypeInfo.Save();

            }
        }
        private void btnLaptopTypeInfoDelete_Click(object sender, EventArgs e)
        {
            isLoading = true;
            for (int i = 0; i < dgvLaptopTypeInfo.Rows.Count; i++)
            {
                if (dgvLaptopTypeInfo.Rows[i].Cells[dgvLaptopTypeInfoOperation.Name].Value != null && (bool)dgvLaptopTypeInfo.Rows[i].Cells[dgvLaptopTypeInfoOperation.Name].Value == true)
                {
                    NLaptopType theLaptopType = NLaptopType.SingleOrDefault(x => x.Sid == (int)dgvLaptopTypeInfo.Rows[i].Cells[dgvLaptopTypeInfoSid.Name].Value);
                    theLaptopType.isDeleted = true;
                    theLaptopType.Save();
                }
            }
            btnLaptopTypeInfoFilter_Click(sender, e);
            isLoading = false;
        }
        #endregion

        #region LaptopInfo
        private void btnLaptopInfo_Click(object sender, EventArgs e)
        {
            tcMainTabControl.SelectedTab = tpInput;
            RefreshParameterPage();
            HideAllInputGroupBox();
            gbLaptopInfo.Show();
            var queryLaptopType = from p in NLaptopType.All()
                                  where p.isDeleted == false
                                  select p;
            cbxLaptopInfoModelFilter.DataSource = new BindingSource(queryLaptopType, null);
            cbxLaptopInfoModelFilter.DisplayMember = NLaptopTypeTable.ModelColumn;
            cbxLaptopInfoModelFilter.ValueMember = NLaptopTypeTable.SidColumn;
            cbxLaptopInfoModelFilter.SelectedValue = -1;
            /*
            var queryBrand = from p in NLaptopType.All()
                             where p.isDeleted == false
                             group p by new { p.Brand } into q
                             select q.FirstOrDefault();
            dgvLaptopInfoBrand.DataSource = new BindingSource(queryBrand, null);
            dgvLaptopInfoBrand.DisplayMember = NLaptopTypeTable.BrandColumn;
            dgvLaptopInfoBrand.ValueMember = NLaptopTypeTable.SidColumn;
             * */
            dgvLaptopInfoModel.DataSource = new BindingSource(queryLaptopType, null);
            dgvLaptopInfoModel.DisplayMember = NLaptopTypeTable.ModelColumn;
            dgvLaptopInfoModel.ValueMember = NLaptopTypeTable.SidColumn;
            var queryCompanyInfo = from p in NCompanyInfo.All()
                                   where p.isDeleted == false
                                   select p;
            dgvLaptopInfoPurchaseCompanySid.DataSource = new BindingSource(queryCompanyInfo, null);
            dgvLaptopInfoPurchaseCompanySid.DisplayMember = NCompanyInfoTable.NameColumn;
            dgvLaptopInfoPurchaseCompanySid.ValueMember = NCompanyInfoTable.SidColumn;
            btnLaptopInfoFilter_Click(sender, e);
        }
        private void btnLaptopInfoModelFilterShowAll_Click(object sender, EventArgs e)
        {
            cbxLaptopInfoModelFilter.SelectedValue = -1;
        }
        private void btnLaptopInfoFilter_Click(object sender, EventArgs e)
        {
            isLoading = true;
            dgvLaptopInfo.Rows.Clear();
            IQueryable<NLaptopInfo> query;
            if (cbxLaptopInfoModelFilter.SelectedValue == null)
            {
                query = from p in NLaptopInfo.All()
                        where p.NielsenAssetsNumber.Contains(tbxLaptopInfoAssetFilter.Text)
                        && p.isDeleted == false
                        select p;
            }
            else
            {
                query = from p in NLaptopInfo.All()
                        where p.NielsenAssetsNumber.Contains(tbxLaptopInfoAssetFilter.Text)
                        && p.LaptopTypeSid == (int)cbxLaptopInfoModelFilter.SelectedValue
                        && p.isDeleted == false
                        select p;
            }
            foreach (var t in query)
            {
                dgvLaptopInfo.Rows.Add();
                dgvLaptopInfo.Rows[dgvLaptopInfo.Rows.Count - 1].Cells[dgvLaptopInfoSid.Name].Value = t.Sid;
                dgvLaptopInfo.Rows[dgvLaptopInfo.Rows.Count - 1].Cells[dgvLaptopInfoLaptopTypeSid.Name].Value = t.LaptopTypeSid;
                if (t.LaptopTypeSid != null)
                {
                    NLaptopType theLaptopType = NLaptopType.SingleOrDefault(x => x.Sid == t.LaptopTypeSid);
                    dgvLaptopInfo.Rows[dgvLaptopInfo.Rows.Count - 1].Cells[dgvLaptopInfoBrand.Name].Value = theLaptopType.Brand;
                }
                dgvLaptopInfo.Rows[dgvLaptopInfo.Rows.Count - 1].Cells[dgvLaptopInfoModel.Name].Value = t.LaptopTypeSid;
                dgvLaptopInfo.Rows[dgvLaptopInfo.Rows.Count - 1].Cells[dgvLaptopInfoNilsenAssetsNumber.Name].Value = t.NielsenAssetsNumber;
                dgvLaptopInfo.Rows[dgvLaptopInfo.Rows.Count - 1].Cells[dgvLaptopInfoLaptopSerial.Name].Value = t.LaptopSerial;
                dgvLaptopInfo.Rows[dgvLaptopInfo.Rows.Count - 1].Cells[dgvLaptopInfoisComplete.Name].Value = t.isComplete;
                dgvLaptopInfo.Rows[dgvLaptopInfo.Rows.Count - 1].Cells[dgvLaptopInfoRemark.Name].Value = t.Remark;
                dgvLaptopInfo.Rows[dgvLaptopInfo.Rows.Count - 1].Cells[dgvLaptopInfoPrice.Name].Value = t.Price;
                dgvLaptopInfo.Rows[dgvLaptopInfo.Rows.Count - 1].Cells[dgvLaptopInfoPurchaseCompanySid.Name].Value = t.PurchaseCompanySid;
                dgvLaptopInfo.Rows[dgvLaptopInfo.Rows.Count - 1].Cells[dgvLaptopInfoPurchaseDate.Name].Value = t.PurchaseDate.Value.ToString("yyyy-MM-dd");
            }
            isLoading = false;
        }
        private void btnLaptopInfoAdd_Click(object sender, EventArgs e)
        {
            isLoading = true;
            dgvLaptopInfo.Rows.Add();
            NLaptopInfo newLaptopInfo = new NLaptopInfo();
            newLaptopInfo.NielsenAssetsNumber = "";
            newLaptopInfo.LaptopSerial = "";
            newLaptopInfo.isComplete = true;
            newLaptopInfo.Remark = "";
            newLaptopInfo.Price = 0;
            newLaptopInfo.PurchaseDate = DateTime.Now;
            newLaptopInfo.isDeleted = false;
            newLaptopInfo.Save();
            dgvLaptopInfo.Rows[dgvLaptopInfo.Rows.Count - 1].Cells[dgvLaptopInfoPurchaseDate.Name].Value = DateTime.Now.ToString("yyyy-MM-dd");
            dgvLaptopInfo.Rows[dgvLaptopInfo.Rows.Count - 1].Cells[dgvLaptopInfoSid.Name].Value = newLaptopInfo.Sid;
            isLoading = false;
        }
        private void dgvLaptopInfo_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (isLoading == false && e.RowIndex != -1 && dgvLaptopInfo.Columns[e.ColumnIndex].Name != dgvLaptopInfoOperation.Name)
            {
                int Sid = (int)dgvLaptopInfo.Rows[e.RowIndex].Cells[dgvLaptopInfoSid.Name].Value;
                if (dgvLaptopInfo.Columns[e.ColumnIndex].Name == dgvLaptopInfoModel.Name)
                {
                    if (dgvLaptopInfo.Rows[e.RowIndex].Cells[dgvLaptopInfoModel.Name].Value != null)
                    {
                        NLaptopType theLaptopType = NLaptopType.SingleOrDefault(x => x.Sid == (int)dgvLaptopInfo.Rows[e.RowIndex].Cells[dgvLaptopInfoModel.Name].Value);
                        dgvLaptopInfo.Rows[e.RowIndex].Cells[dgvLaptopInfoLaptopTypeSid.Name].Value = dgvLaptopInfo.Rows[e.RowIndex].Cells[dgvLaptopInfoModel.Name].Value;
                        dgvLaptopInfo.Rows[e.RowIndex].Cells[dgvLaptopInfoBrand.Name].Value = theLaptopType.Brand;
                    }
                }
                NLaptopInfo theLaptopInfo = NLaptopInfo.SingleOrDefault(x => x.Sid == Sid);
                if (dgvLaptopInfo.Rows[e.RowIndex].Cells[dgvLaptopInfoLaptopTypeSid.Name].Value != null)
                    theLaptopInfo.LaptopTypeSid = (int)dgvLaptopInfo.Rows[e.RowIndex].Cells[dgvLaptopInfoLaptopTypeSid.Name].Value;
                if (dgvLaptopInfo.Rows[e.RowIndex].Cells[dgvLaptopInfoNilsenAssetsNumber.Name].Value != null)
                    theLaptopInfo.NielsenAssetsNumber = (string)dgvLaptopInfo.Rows[e.RowIndex].Cells[dgvLaptopInfoNilsenAssetsNumber.Name].Value;
                if (dgvLaptopInfo.Rows[e.RowIndex].Cells[dgvLaptopInfoLaptopSerial.Name].Value != null)
                    theLaptopInfo.LaptopSerial = (string)dgvLaptopInfo.Rows[e.RowIndex].Cells[dgvLaptopInfoLaptopSerial.Name].Value;
                if (dgvLaptopInfo.Rows[e.RowIndex].Cells[dgvLaptopInfoPurchaseDate.Name].Value != null)
                {
                    try
                    {
                        DateTime newPurchaseDate = DateTime.Parse((string)dgvLaptopInfo.Rows[e.RowIndex].Cells[dgvLaptopInfoPurchaseDate.Name].Value);
                        theLaptopInfo.PurchaseDate = newPurchaseDate;
                    }
                    catch
                    {
                        MessageBox.Show("Date Input Error");
                    }
                }
                if (dgvLaptopInfo.Rows[e.RowIndex].Cells[dgvLaptopInfoPrice.Name].Value != null)
                {
                    try
                    {
                        int Price = Convert.ToInt32(dgvLaptopInfo.Rows[e.RowIndex].Cells[dgvLaptopInfoPrice.Name].Value);
                        theLaptopInfo.Price = Price;
                    }
                    catch
                    {
                        MessageBox.Show("Price Error");
                    }
                }
                if (dgvLaptopInfo.Rows[e.RowIndex].Cells[dgvLaptopInfoisComplete.Name].Value != null)
                    theLaptopInfo.isComplete = (bool)dgvLaptopInfo.Rows[e.RowIndex].Cells[dgvLaptopInfoisComplete.Name].Value;
                if (dgvLaptopInfo.Rows[e.RowIndex].Cells[dgvLaptopInfoRemark.Name].Value != null)
                    theLaptopInfo.Remark = (string)dgvLaptopInfo.Rows[e.RowIndex].Cells[dgvLaptopInfoRemark.Name].Value;
                if (dgvLaptopInfo.Rows[e.RowIndex].Cells[dgvLaptopInfoPurchaseCompanySid.Name].Value != null)
                    theLaptopInfo.PurchaseCompanySid = (int)dgvLaptopInfo.Rows[e.RowIndex].Cells[dgvLaptopInfoPurchaseCompanySid.Name].Value;
                theLaptopInfo.Save();
            }
        }
        private void btnLaptopInfoDelete_Click(object sender, EventArgs e)
        {
            isLoading = true;
            for (int i = 0; i < dgvLaptopInfo.Rows.Count; i++)
            {
                if (dgvLaptopInfo.Rows[i].Cells[dgvLaptopInfoOperation.Name].Value != null && (bool)dgvLaptopInfo.Rows[i].Cells[dgvLaptopInfoOperation.Name].Value == true)
                {
                    int Sid = (int)dgvLaptopInfo.Rows[i].Cells[dgvLaptopInfoSid.Name].Value;
                    NLaptopInfo newLaptopInfo = NLaptopInfo.SingleOrDefault(x => x.Sid == Sid);
                    newLaptopInfo.isDeleted = true;
                    newLaptopInfo.Save();
                }
            }
            btnLaptopInfoFilter_Click(sender, e);
            isLoading = false;
        }
        #endregion
    }
}
