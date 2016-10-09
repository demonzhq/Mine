namespace LaptopBookingSystem
{
    partial class frMainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frMainForm));
            this.tcMainTabControl = new System.Windows.Forms.TabControl();
            this.tpStartPage = new System.Windows.Forms.TabPage();
            this.lblStartpgTitle = new System.Windows.Forms.Label();
            this.pbStartPgLogo = new System.Windows.Forms.PictureBox();
            this.tpInput = new System.Windows.Forms.TabPage();
            this.splitContainerInput = new System.Windows.Forms.SplitContainer();
            this.gbInputFunction = new System.Windows.Forms.GroupBox();
            this.btnLaptopInfo = new System.Windows.Forms.Button();
            this.btnLaptopTypeInfo = new System.Windows.Forms.Button();
            this.btnCompanyInfo = new System.Windows.Forms.Button();
            this.btnProjectSuperviseInfo = new System.Windows.Forms.Button();
            this.btnParameterInfo = new System.Windows.Forms.Button();
            this.btnProjectMantance = new System.Windows.Forms.Button();
            this.gbLaptopInfo = new System.Windows.Forms.GroupBox();
            this.btnLaptopInfoFilter = new System.Windows.Forms.Button();
            this.btnLaptopInfoDelete = new System.Windows.Forms.Button();
            this.btnLaptopInfoAdd = new System.Windows.Forms.Button();
            this.btnLaptopInfoModelFilterShowAll = new System.Windows.Forms.Button();
            this.cbxLaptopInfoModelFilter = new System.Windows.Forms.ComboBox();
            this.lblLaptopInfoModelFilter = new System.Windows.Forms.Label();
            this.tbxLaptopInfoAssetFilter = new System.Windows.Forms.TextBox();
            this.lblLaptopInfoAssetsFilter = new System.Windows.Forms.Label();
            this.dgvLaptopInfo = new System.Windows.Forms.DataGridView();
            this.dgvLaptopInfoSid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLaptopInfoOperation = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvLaptopInfoLaptopTypeSid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLaptopInfoNilsenAssetsNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLaptopInfoBrand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLaptopInfoModel = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvLaptopInfoLaptopSerial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLaptopInfoisComplete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvLaptopInfoRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLaptopInfoPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLaptopInfoPurchaseCompanySid = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvLaptopInfoPurchaseDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbProjectInfo = new System.Windows.Forms.GroupBox();
            this.btnDeleteProjectInfo = new System.Windows.Forms.Button();
            this.btnAddProjectInfo = new System.Windows.Forms.Button();
            this.btnFilterProjectInfo = new System.Windows.Forms.Button();
            this.tbxProjectInfoNameFilter = new System.Windows.Forms.TextBox();
            this.lblProjectNameFilter = new System.Windows.Forms.Label();
            this.tbxProjectInfoNumberFilter = new System.Windows.Forms.TextBox();
            this.lblProjectNumberFilter = new System.Windows.Forms.Label();
            this.dgvProjectInfo = new System.Windows.Forms.DataGridView();
            this.dgvProjectInfoSid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvProjectInfoOperation = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvProjectInfoNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvProjectInfoName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvProjectInfoProjectSuperviserSid = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvProjectInfoProjectTypeSid = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvProjectInfoLaunchDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvProjectInfoCloseDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbInputStartPage = new System.Windows.Forms.GroupBox();
            this.pbInputStartPageLogo = new System.Windows.Forms.PictureBox();
            this.gbProjectSuperviserInfo = new System.Windows.Forms.GroupBox();
            this.btnProjectSuperviserInfoAdd = new System.Windows.Forms.Button();
            this.btnProjectSuperviserInfoDelete = new System.Windows.Forms.Button();
            this.btnProjectSuperviserInfoSearch = new System.Windows.Forms.Button();
            this.tbxProjectSuperviserInfoName = new System.Windows.Forms.TextBox();
            this.lblProjectSuperviseInfoName = new System.Windows.Forms.Label();
            this.dgvProjectSuperviserInfo = new System.Windows.Forms.DataGridView();
            this.dgvProjectSuperviserInfoSid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvProjectSuperviserInfoOperation = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvProjectSuperviserInfoName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvProjectSuperviserInfoPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvProjectSuperviserInfoMobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvProjectSuperviserInfoMailAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbParameterInfo = new System.Windows.Forms.GroupBox();
            this.gbProjecyTypeInfo = new System.Windows.Forms.GroupBox();
            this.btnProjectTypeDelete = new System.Windows.Forms.Button();
            this.dgvParameterProjectTypeInfo = new System.Windows.Forms.DataGridView();
            this.dgvParameterProjectTypeInfoSid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvParameterProjectTypeInfoOperation = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvParameterProjectTypeInfoProjectType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnProjectTypeInfoAdd = new System.Windows.Forms.Button();
            this.gbCityInfo = new System.Windows.Forms.GroupBox();
            this.dgvParameterCityInfo = new System.Windows.Forms.DataGridView();
            this.dgvParameterCityInfoSid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvParameterCityInfoOperation = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvParameterCityInfoCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnParameterCityInfoDelete = new System.Windows.Forms.Button();
            this.btnParameterCityInfoAdd = new System.Windows.Forms.Button();
            this.gbLaptopType = new System.Windows.Forms.GroupBox();
            this.btnLaptopTypeInfoFilter = new System.Windows.Forms.Button();
            this.btnLaptopTypeInfoDelete = new System.Windows.Forms.Button();
            this.btnLaptopTypeInfoAdd = new System.Windows.Forms.Button();
            this.dgvLaptopTypeInfo = new System.Windows.Forms.DataGridView();
            this.dgvLaptopTypeInfoSid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLaptopTypeInfoOperation = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvLaptopTypeInfoImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvLaptopTypeInfoBrand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLaptopTypeInfoModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLaptopTypeInfoBatteryCapacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLaptopTypeInfoisTouchScreen = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.gbCompanyInfo = new System.Windows.Forms.GroupBox();
            this.btnCompanyInfoFilter = new System.Windows.Forms.Button();
            this.btnCompanyInfoDelete = new System.Windows.Forms.Button();
            this.btnCompanyInfoAdd = new System.Windows.Forms.Button();
            this.tbxCompanyInfoCodeFilter = new System.Windows.Forms.TextBox();
            this.lblCompanyInfoCodeFilter = new System.Windows.Forms.Label();
            this.tbxCompanyInfoNameFilter = new System.Windows.Forms.TextBox();
            this.lblCompanyInfoNameFilter = new System.Windows.Forms.Label();
            this.btnCompanyInfoCityFilterShowAll = new System.Windows.Forms.Button();
            this.lblCompanyInfoCityFilter = new System.Windows.Forms.Label();
            this.cbxCompanyInfoCityFilter = new System.Windows.Forms.ComboBox();
            this.dgvCompanyInfo = new System.Windows.Forms.DataGridView();
            this.dgvCompanyInfoSid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCompanyInfoOperation = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvCompanyInfoName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCompanyInfoCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCompanyInfoParameterCitySid = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvCompanyInfoisVender = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tpOperation = new System.Windows.Forms.TabPage();
            this.splitContainerOperation = new System.Windows.Forms.SplitContainer();
            this.gbOperationFunction = new System.Windows.Forms.GroupBox();
            this.btnAssignJob = new System.Windows.Forms.Button();
            this.btnBuyLaptop = new System.Windows.Forms.Button();
            this.gbAssignJob = new System.Windows.Forms.GroupBox();
            this.splitContainerAssignJob1 = new System.Windows.Forms.SplitContainer();
            this.splitContainerAssignJob2 = new System.Windows.Forms.SplitContainer();
            this.gbAssignJobProject = new System.Windows.Forms.GroupBox();
            this.btnAssignJobProjectNext = new System.Windows.Forms.Button();
            this.btnAssignJobProjectFilter = new System.Windows.Forms.Button();
            this.lblAssignJobProCodejectFilter = new System.Windows.Forms.Label();
            this.tbxAssignJobProjectCodeFilter = new System.Windows.Forms.TextBox();
            this.dgvAssignJobProject = new System.Windows.Forms.DataGridView();
            this.gbAssignJobCompany = new System.Windows.Forms.GroupBox();
            this.btnAssignJobCompanyPre = new System.Windows.Forms.Button();
            this.dgvAssignjobCompany = new System.Windows.Forms.DataGridView();
            this.dgvAssignJobCompanyOperation = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvAssignJobCompanyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAssignJobCompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAssignJobCompanyFilter = new System.Windows.Forms.Button();
            this.btnAssignJobCompanyCityFilterAll = new System.Windows.Forms.Button();
            this.cbxAssignJobCompanyCityFilter = new System.Windows.Forms.ComboBox();
            this.lblAssignJobLocationFilter = new System.Windows.Forms.Label();
            this.tbxAssignJobCompanyCodeFilter = new System.Windows.Forms.TextBox();
            this.lblAssignJobCompanyCodeFilter = new System.Windows.Forms.Label();
            this.gbAssignJobLaptop = new System.Windows.Forms.GroupBox();
            this.pnAssignJobBottom = new System.Windows.Forms.Panel();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblAssignJobDate = new System.Windows.Forms.Label();
            this.btnAssignJobAssign = new System.Windows.Forms.Button();
            this.gbBuyLaotop = new System.Windows.Forms.GroupBox();
            this.nbxBuyLaptopQuatity = new System.Windows.Forms.NumericUpDown();
            this.lblBuyLaptopQuatity = new System.Windows.Forms.Label();
            this.dtBuyLaptopPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.lblBuyLaptopPurchaseDate = new System.Windows.Forms.Label();
            this.btnBuyLaptopBuy = new System.Windows.Forms.Button();
            this.gbBuyLaptopAssets = new System.Windows.Forms.GroupBox();
            this.nbxBuyLaptopAssetsFrom = new System.Windows.Forms.NumericUpDown();
            this.tbxBuyLaptopAssetsFix = new System.Windows.Forms.TextBox();
            this.lblBuyLaptopAssetsFix = new System.Windows.Forms.Label();
            this.lblBuyLaptopAssetsFrom = new System.Windows.Forms.Label();
            this.tbxBuyLpatopRemark = new System.Windows.Forms.TextBox();
            this.lblBuyLpatopRemark = new System.Windows.Forms.Label();
            this.tbxBuyLaptopPrice = new System.Windows.Forms.TextBox();
            this.lblBuyLaptopPrice = new System.Windows.Forms.Label();
            this.cbxBuyLaptopPurchaseCompany = new System.Windows.Forms.ComboBox();
            this.lblBuyLaptopPurchaseCompany = new System.Windows.Forms.Label();
            this.cbxBuyLaptopModel = new System.Windows.Forms.ComboBox();
            this.lblBuyLaptopLaptopModel = new System.Windows.Forms.Label();
            this.gbOperationStartPage = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PhotoPicker = new System.Windows.Forms.OpenFileDialog();
            this.dgvAssignJobProjectSid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAssignJobProjectCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAssignJobProjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcMainTabControl.SuspendLayout();
            this.tpStartPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStartPgLogo)).BeginInit();
            this.tpInput.SuspendLayout();
            this.splitContainerInput.Panel1.SuspendLayout();
            this.splitContainerInput.Panel2.SuspendLayout();
            this.splitContainerInput.SuspendLayout();
            this.gbInputFunction.SuspendLayout();
            this.gbLaptopInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaptopInfo)).BeginInit();
            this.gbProjectInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjectInfo)).BeginInit();
            this.gbInputStartPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInputStartPageLogo)).BeginInit();
            this.gbProjectSuperviserInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjectSuperviserInfo)).BeginInit();
            this.gbParameterInfo.SuspendLayout();
            this.gbProjecyTypeInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameterProjectTypeInfo)).BeginInit();
            this.gbCityInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameterCityInfo)).BeginInit();
            this.gbLaptopType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaptopTypeInfo)).BeginInit();
            this.gbCompanyInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompanyInfo)).BeginInit();
            this.tpOperation.SuspendLayout();
            this.splitContainerOperation.Panel1.SuspendLayout();
            this.splitContainerOperation.Panel2.SuspendLayout();
            this.splitContainerOperation.SuspendLayout();
            this.gbOperationFunction.SuspendLayout();
            this.gbAssignJob.SuspendLayout();
            this.splitContainerAssignJob1.Panel1.SuspendLayout();
            this.splitContainerAssignJob1.Panel2.SuspendLayout();
            this.splitContainerAssignJob1.SuspendLayout();
            this.splitContainerAssignJob2.Panel1.SuspendLayout();
            this.splitContainerAssignJob2.Panel2.SuspendLayout();
            this.splitContainerAssignJob2.SuspendLayout();
            this.gbAssignJobProject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignJobProject)).BeginInit();
            this.gbAssignJobCompany.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignjobCompany)).BeginInit();
            this.pnAssignJobBottom.SuspendLayout();
            this.gbBuyLaotop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbxBuyLaptopQuatity)).BeginInit();
            this.gbBuyLaptopAssets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbxBuyLaptopAssetsFrom)).BeginInit();
            this.gbOperationStartPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tcMainTabControl
            // 
            this.tcMainTabControl.Controls.Add(this.tpStartPage);
            this.tcMainTabControl.Controls.Add(this.tpInput);
            this.tcMainTabControl.Controls.Add(this.tpOperation);
            this.tcMainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMainTabControl.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcMainTabControl.Location = new System.Drawing.Point(0, 0);
            this.tcMainTabControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tcMainTabControl.Name = "tcMainTabControl";
            this.tcMainTabControl.SelectedIndex = 0;
            this.tcMainTabControl.Size = new System.Drawing.Size(990, 562);
            this.tcMainTabControl.TabIndex = 0;
            // 
            // tpStartPage
            // 
            this.tpStartPage.Controls.Add(this.lblStartpgTitle);
            this.tpStartPage.Controls.Add(this.pbStartPgLogo);
            this.tpStartPage.Location = new System.Drawing.Point(4, 23);
            this.tpStartPage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tpStartPage.Name = "tpStartPage";
            this.tpStartPage.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tpStartPage.Size = new System.Drawing.Size(982, 535);
            this.tpStartPage.TabIndex = 0;
            this.tpStartPage.Text = "StartPage";
            this.tpStartPage.UseVisualStyleBackColor = true;
            // 
            // lblStartpgTitle
            // 
            this.lblStartpgTitle.AutoSize = true;
            this.lblStartpgTitle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 30F);
            this.lblStartpgTitle.Location = new System.Drawing.Point(252, 395);
            this.lblStartpgTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStartpgTitle.Name = "lblStartpgTitle";
            this.lblStartpgTitle.Size = new System.Drawing.Size(480, 46);
            this.lblStartpgTitle.TabIndex = 1;
            this.lblStartpgTitle.Text = "Laptop Booking System";
            // 
            // pbStartPgLogo
            // 
            this.pbStartPgLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbStartPgLogo.Image")));
            this.pbStartPgLogo.InitialImage = null;
            this.pbStartPgLogo.Location = new System.Drawing.Point(241, 90);
            this.pbStartPgLogo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbStartPgLogo.Name = "pbStartPgLogo";
            this.pbStartPgLogo.Size = new System.Drawing.Size(502, 208);
            this.pbStartPgLogo.TabIndex = 0;
            this.pbStartPgLogo.TabStop = false;
            // 
            // tpInput
            // 
            this.tpInput.Controls.Add(this.splitContainerInput);
            this.tpInput.Location = new System.Drawing.Point(4, 23);
            this.tpInput.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tpInput.Name = "tpInput";
            this.tpInput.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tpInput.Size = new System.Drawing.Size(982, 535);
            this.tpInput.TabIndex = 1;
            this.tpInput.Text = "Input";
            this.tpInput.UseVisualStyleBackColor = true;
            // 
            // splitContainerInput
            // 
            this.splitContainerInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerInput.Location = new System.Drawing.Point(4, 3);
            this.splitContainerInput.Name = "splitContainerInput";
            // 
            // splitContainerInput.Panel1
            // 
            this.splitContainerInput.Panel1.Controls.Add(this.gbInputFunction);
            // 
            // splitContainerInput.Panel2
            // 
            this.splitContainerInput.Panel2.Controls.Add(this.gbLaptopInfo);
            this.splitContainerInput.Panel2.Controls.Add(this.gbProjectInfo);
            this.splitContainerInput.Panel2.Controls.Add(this.gbInputStartPage);
            this.splitContainerInput.Panel2.Controls.Add(this.gbProjectSuperviserInfo);
            this.splitContainerInput.Panel2.Controls.Add(this.gbParameterInfo);
            this.splitContainerInput.Panel2.Controls.Add(this.gbLaptopType);
            this.splitContainerInput.Panel2.Controls.Add(this.gbCompanyInfo);
            this.splitContainerInput.Size = new System.Drawing.Size(974, 529);
            this.splitContainerInput.SplitterDistance = 135;
            this.splitContainerInput.TabIndex = 0;
            // 
            // gbInputFunction
            // 
            this.gbInputFunction.Controls.Add(this.btnLaptopInfo);
            this.gbInputFunction.Controls.Add(this.btnLaptopTypeInfo);
            this.gbInputFunction.Controls.Add(this.btnCompanyInfo);
            this.gbInputFunction.Controls.Add(this.btnProjectSuperviseInfo);
            this.gbInputFunction.Controls.Add(this.btnParameterInfo);
            this.gbInputFunction.Controls.Add(this.btnProjectMantance);
            this.gbInputFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbInputFunction.Location = new System.Drawing.Point(0, 0);
            this.gbInputFunction.Name = "gbInputFunction";
            this.gbInputFunction.Size = new System.Drawing.Size(135, 529);
            this.gbInputFunction.TabIndex = 0;
            this.gbInputFunction.TabStop = false;
            this.gbInputFunction.Text = "Function";
            // 
            // btnLaptopInfo
            // 
            this.btnLaptopInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLaptopInfo.Location = new System.Drawing.Point(6, 179);
            this.btnLaptopInfo.Name = "btnLaptopInfo";
            this.btnLaptopInfo.Size = new System.Drawing.Size(123, 23);
            this.btnLaptopInfo.TabIndex = 5;
            this.btnLaptopInfo.Text = "Laptop Info";
            this.btnLaptopInfo.UseVisualStyleBackColor = true;
            this.btnLaptopInfo.Click += new System.EventHandler(this.btnLaptopInfo_Click);
            // 
            // btnLaptopTypeInfo
            // 
            this.btnLaptopTypeInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLaptopTypeInfo.Location = new System.Drawing.Point(6, 150);
            this.btnLaptopTypeInfo.Name = "btnLaptopTypeInfo";
            this.btnLaptopTypeInfo.Size = new System.Drawing.Size(123, 23);
            this.btnLaptopTypeInfo.TabIndex = 4;
            this.btnLaptopTypeInfo.Text = "Laptop Type";
            this.btnLaptopTypeInfo.UseVisualStyleBackColor = true;
            this.btnLaptopTypeInfo.Click += new System.EventHandler(this.btnLaptopTypeInfo_Click);
            // 
            // btnCompanyInfo
            // 
            this.btnCompanyInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompanyInfo.Location = new System.Drawing.Point(6, 121);
            this.btnCompanyInfo.Name = "btnCompanyInfo";
            this.btnCompanyInfo.Size = new System.Drawing.Size(123, 23);
            this.btnCompanyInfo.TabIndex = 3;
            this.btnCompanyInfo.Text = "Company Info";
            this.btnCompanyInfo.UseVisualStyleBackColor = true;
            this.btnCompanyInfo.Click += new System.EventHandler(this.btnCompanyInfo_Click);
            // 
            // btnProjectSuperviseInfo
            // 
            this.btnProjectSuperviseInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProjectSuperviseInfo.Location = new System.Drawing.Point(6, 92);
            this.btnProjectSuperviseInfo.Name = "btnProjectSuperviseInfo";
            this.btnProjectSuperviseInfo.Size = new System.Drawing.Size(123, 23);
            this.btnProjectSuperviseInfo.TabIndex = 2;
            this.btnProjectSuperviseInfo.Text = "Project Superviser";
            this.btnProjectSuperviseInfo.UseVisualStyleBackColor = true;
            this.btnProjectSuperviseInfo.Click += new System.EventHandler(this.btnProjectSuperviseInfo_Click);
            // 
            // btnParameterInfo
            // 
            this.btnParameterInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnParameterInfo.Location = new System.Drawing.Point(6, 63);
            this.btnParameterInfo.Name = "btnParameterInfo";
            this.btnParameterInfo.Size = new System.Drawing.Size(123, 23);
            this.btnParameterInfo.TabIndex = 1;
            this.btnParameterInfo.Text = "Parameter Info";
            this.btnParameterInfo.UseVisualStyleBackColor = true;
            this.btnParameterInfo.Click += new System.EventHandler(this.btnParameterInfo_Click);
            // 
            // btnProjectMantance
            // 
            this.btnProjectMantance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProjectMantance.Location = new System.Drawing.Point(6, 34);
            this.btnProjectMantance.Name = "btnProjectMantance";
            this.btnProjectMantance.Size = new System.Drawing.Size(123, 23);
            this.btnProjectMantance.TabIndex = 0;
            this.btnProjectMantance.Text = "Project Info";
            this.btnProjectMantance.UseVisualStyleBackColor = true;
            this.btnProjectMantance.Click += new System.EventHandler(this.btnProjectInfoMantance_Click);
            // 
            // gbLaptopInfo
            // 
            this.gbLaptopInfo.Controls.Add(this.btnLaptopInfoFilter);
            this.gbLaptopInfo.Controls.Add(this.btnLaptopInfoDelete);
            this.gbLaptopInfo.Controls.Add(this.btnLaptopInfoAdd);
            this.gbLaptopInfo.Controls.Add(this.btnLaptopInfoModelFilterShowAll);
            this.gbLaptopInfo.Controls.Add(this.cbxLaptopInfoModelFilter);
            this.gbLaptopInfo.Controls.Add(this.lblLaptopInfoModelFilter);
            this.gbLaptopInfo.Controls.Add(this.tbxLaptopInfoAssetFilter);
            this.gbLaptopInfo.Controls.Add(this.lblLaptopInfoAssetsFilter);
            this.gbLaptopInfo.Controls.Add(this.dgvLaptopInfo);
            this.gbLaptopInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbLaptopInfo.Location = new System.Drawing.Point(0, 0);
            this.gbLaptopInfo.Name = "gbLaptopInfo";
            this.gbLaptopInfo.Size = new System.Drawing.Size(835, 529);
            this.gbLaptopInfo.TabIndex = 10;
            this.gbLaptopInfo.TabStop = false;
            this.gbLaptopInfo.Text = "Laptop Infomation";
            this.gbLaptopInfo.Visible = false;
            // 
            // btnLaptopInfoFilter
            // 
            this.btnLaptopInfoFilter.Location = new System.Drawing.Point(592, 25);
            this.btnLaptopInfoFilter.Name = "btnLaptopInfoFilter";
            this.btnLaptopInfoFilter.Size = new System.Drawing.Size(75, 23);
            this.btnLaptopInfoFilter.TabIndex = 11;
            this.btnLaptopInfoFilter.Text = "Filter";
            this.btnLaptopInfoFilter.UseVisualStyleBackColor = true;
            this.btnLaptopInfoFilter.Click += new System.EventHandler(this.btnLaptopInfoFilter_Click);
            // 
            // btnLaptopInfoDelete
            // 
            this.btnLaptopInfoDelete.Location = new System.Drawing.Point(673, 26);
            this.btnLaptopInfoDelete.Name = "btnLaptopInfoDelete";
            this.btnLaptopInfoDelete.Size = new System.Drawing.Size(75, 23);
            this.btnLaptopInfoDelete.TabIndex = 10;
            this.btnLaptopInfoDelete.Text = "Delete";
            this.btnLaptopInfoDelete.UseVisualStyleBackColor = true;
            this.btnLaptopInfoDelete.Click += new System.EventHandler(this.btnLaptopInfoDelete_Click);
            // 
            // btnLaptopInfoAdd
            // 
            this.btnLaptopInfoAdd.Location = new System.Drawing.Point(754, 26);
            this.btnLaptopInfoAdd.Name = "btnLaptopInfoAdd";
            this.btnLaptopInfoAdd.Size = new System.Drawing.Size(75, 23);
            this.btnLaptopInfoAdd.TabIndex = 9;
            this.btnLaptopInfoAdd.Text = "Add";
            this.btnLaptopInfoAdd.UseVisualStyleBackColor = true;
            this.btnLaptopInfoAdd.Click += new System.EventHandler(this.btnLaptopInfoAdd_Click);
            // 
            // btnLaptopInfoModelFilterShowAll
            // 
            this.btnLaptopInfoModelFilterShowAll.Location = new System.Drawing.Point(339, 27);
            this.btnLaptopInfoModelFilterShowAll.Name = "btnLaptopInfoModelFilterShowAll";
            this.btnLaptopInfoModelFilterShowAll.Size = new System.Drawing.Size(31, 23);
            this.btnLaptopInfoModelFilterShowAll.TabIndex = 8;
            this.btnLaptopInfoModelFilterShowAll.Text = "All";
            this.btnLaptopInfoModelFilterShowAll.UseVisualStyleBackColor = true;
            this.btnLaptopInfoModelFilterShowAll.Click += new System.EventHandler(this.btnLaptopInfoModelFilterShowAll_Click);
            // 
            // cbxLaptopInfoModelFilter
            // 
            this.cbxLaptopInfoModelFilter.FormattingEnabled = true;
            this.cbxLaptopInfoModelFilter.Location = new System.Drawing.Point(214, 27);
            this.cbxLaptopInfoModelFilter.Name = "cbxLaptopInfoModelFilter";
            this.cbxLaptopInfoModelFilter.Size = new System.Drawing.Size(121, 22);
            this.cbxLaptopInfoModelFilter.TabIndex = 7;
            // 
            // lblLaptopInfoModelFilter
            // 
            this.lblLaptopInfoModelFilter.AutoSize = true;
            this.lblLaptopInfoModelFilter.Location = new System.Drawing.Point(166, 31);
            this.lblLaptopInfoModelFilter.Name = "lblLaptopInfoModelFilter";
            this.lblLaptopInfoModelFilter.Size = new System.Drawing.Size(42, 14);
            this.lblLaptopInfoModelFilter.TabIndex = 6;
            this.lblLaptopInfoModelFilter.Text = "Model";
            // 
            // tbxLaptopInfoAssetFilter
            // 
            this.tbxLaptopInfoAssetFilter.Location = new System.Drawing.Point(59, 28);
            this.tbxLaptopInfoAssetFilter.Name = "tbxLaptopInfoAssetFilter";
            this.tbxLaptopInfoAssetFilter.Size = new System.Drawing.Size(100, 21);
            this.tbxLaptopInfoAssetFilter.TabIndex = 5;
            // 
            // lblLaptopInfoAssetsFilter
            // 
            this.lblLaptopInfoAssetsFilter.AutoSize = true;
            this.lblLaptopInfoAssetsFilter.Location = new System.Drawing.Point(12, 31);
            this.lblLaptopInfoAssetsFilter.Name = "lblLaptopInfoAssetsFilter";
            this.lblLaptopInfoAssetsFilter.Size = new System.Drawing.Size(41, 14);
            this.lblLaptopInfoAssetsFilter.TabIndex = 4;
            this.lblLaptopInfoAssetsFilter.Text = "Asset";
            // 
            // dgvLaptopInfo
            // 
            this.dgvLaptopInfo.AllowUserToAddRows = false;
            this.dgvLaptopInfo.AllowUserToDeleteRows = false;
            this.dgvLaptopInfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvLaptopInfo.ColumnHeadersHeight = 40;
            this.dgvLaptopInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvLaptopInfoSid,
            this.dgvLaptopInfoOperation,
            this.dgvLaptopInfoLaptopTypeSid,
            this.dgvLaptopInfoNilsenAssetsNumber,
            this.dgvLaptopInfoBrand,
            this.dgvLaptopInfoModel,
            this.dgvLaptopInfoLaptopSerial,
            this.dgvLaptopInfoisComplete,
            this.dgvLaptopInfoRemark,
            this.dgvLaptopInfoPrice,
            this.dgvLaptopInfoPurchaseCompanySid,
            this.dgvLaptopInfoPurchaseDate});
            this.dgvLaptopInfo.Location = new System.Drawing.Point(9, 59);
            this.dgvLaptopInfo.Name = "dgvLaptopInfo";
            this.dgvLaptopInfo.RowTemplate.Height = 23;
            this.dgvLaptopInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLaptopInfo.Size = new System.Drawing.Size(820, 464);
            this.dgvLaptopInfo.TabIndex = 3;
            this.dgvLaptopInfo.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLaptopInfo_CellValueChanged);
            // 
            // dgvLaptopInfoSid
            // 
            this.dgvLaptopInfoSid.DataPropertyName = "Sid";
            this.dgvLaptopInfoSid.HeaderText = "Sid";
            this.dgvLaptopInfoSid.Name = "dgvLaptopInfoSid";
            this.dgvLaptopInfoSid.Visible = false;
            this.dgvLaptopInfoSid.Width = 51;
            // 
            // dgvLaptopInfoOperation
            // 
            this.dgvLaptopInfoOperation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgvLaptopInfoOperation.DataPropertyName = "Operation";
            this.dgvLaptopInfoOperation.HeaderText = "OP";
            this.dgvLaptopInfoOperation.Name = "dgvLaptopInfoOperation";
            this.dgvLaptopInfoOperation.Width = 31;
            // 
            // dgvLaptopInfoLaptopTypeSid
            // 
            this.dgvLaptopInfoLaptopTypeSid.HeaderText = "LaptopTypeSid";
            this.dgvLaptopInfoLaptopTypeSid.Name = "dgvLaptopInfoLaptopTypeSid";
            this.dgvLaptopInfoLaptopTypeSid.Visible = false;
            // 
            // dgvLaptopInfoNilsenAssetsNumber
            // 
            this.dgvLaptopInfoNilsenAssetsNumber.HeaderText = "Assets Number";
            this.dgvLaptopInfoNilsenAssetsNumber.Name = "dgvLaptopInfoNilsenAssetsNumber";
            // 
            // dgvLaptopInfoBrand
            // 
            this.dgvLaptopInfoBrand.HeaderText = "Brand";
            this.dgvLaptopInfoBrand.Name = "dgvLaptopInfoBrand";
            this.dgvLaptopInfoBrand.ReadOnly = true;
            this.dgvLaptopInfoBrand.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dgvLaptopInfoModel
            // 
            this.dgvLaptopInfoModel.HeaderText = "Model";
            this.dgvLaptopInfoModel.Name = "dgvLaptopInfoModel";
            this.dgvLaptopInfoModel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLaptopInfoModel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dgvLaptopInfoLaptopSerial
            // 
            this.dgvLaptopInfoLaptopSerial.HeaderText = "Laptop Serial";
            this.dgvLaptopInfoLaptopSerial.Name = "dgvLaptopInfoLaptopSerial";
            // 
            // dgvLaptopInfoisComplete
            // 
            this.dgvLaptopInfoisComplete.HeaderText = "isComplete";
            this.dgvLaptopInfoisComplete.Name = "dgvLaptopInfoisComplete";
            // 
            // dgvLaptopInfoRemark
            // 
            this.dgvLaptopInfoRemark.HeaderText = "Remark";
            this.dgvLaptopInfoRemark.Name = "dgvLaptopInfoRemark";
            // 
            // dgvLaptopInfoPrice
            // 
            this.dgvLaptopInfoPrice.HeaderText = "Price";
            this.dgvLaptopInfoPrice.Name = "dgvLaptopInfoPrice";
            this.dgvLaptopInfoPrice.Width = 75;
            // 
            // dgvLaptopInfoPurchaseCompanySid
            // 
            this.dgvLaptopInfoPurchaseCompanySid.HeaderText = "Purchase Company";
            this.dgvLaptopInfoPurchaseCompanySid.Name = "dgvLaptopInfoPurchaseCompanySid";
            // 
            // dgvLaptopInfoPurchaseDate
            // 
            this.dgvLaptopInfoPurchaseDate.HeaderText = "Purchase Date";
            this.dgvLaptopInfoPurchaseDate.Name = "dgvLaptopInfoPurchaseDate";
            // 
            // gbProjectInfo
            // 
            this.gbProjectInfo.Controls.Add(this.btnDeleteProjectInfo);
            this.gbProjectInfo.Controls.Add(this.btnAddProjectInfo);
            this.gbProjectInfo.Controls.Add(this.btnFilterProjectInfo);
            this.gbProjectInfo.Controls.Add(this.tbxProjectInfoNameFilter);
            this.gbProjectInfo.Controls.Add(this.lblProjectNameFilter);
            this.gbProjectInfo.Controls.Add(this.tbxProjectInfoNumberFilter);
            this.gbProjectInfo.Controls.Add(this.lblProjectNumberFilter);
            this.gbProjectInfo.Controls.Add(this.dgvProjectInfo);
            this.gbProjectInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbProjectInfo.Location = new System.Drawing.Point(0, 0);
            this.gbProjectInfo.Name = "gbProjectInfo";
            this.gbProjectInfo.Size = new System.Drawing.Size(835, 529);
            this.gbProjectInfo.TabIndex = 0;
            this.gbProjectInfo.TabStop = false;
            this.gbProjectInfo.Text = "Project Info";
            this.gbProjectInfo.Visible = false;
            // 
            // btnDeleteProjectInfo
            // 
            this.btnDeleteProjectInfo.Location = new System.Drawing.Point(673, 39);
            this.btnDeleteProjectInfo.Name = "btnDeleteProjectInfo";
            this.btnDeleteProjectInfo.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteProjectInfo.TabIndex = 9;
            this.btnDeleteProjectInfo.Text = "Delete";
            this.btnDeleteProjectInfo.UseVisualStyleBackColor = true;
            this.btnDeleteProjectInfo.Click += new System.EventHandler(this.btnDeleteSelect_Click);
            // 
            // btnAddProjectInfo
            // 
            this.btnAddProjectInfo.Location = new System.Drawing.Point(754, 39);
            this.btnAddProjectInfo.Name = "btnAddProjectInfo";
            this.btnAddProjectInfo.Size = new System.Drawing.Size(75, 23);
            this.btnAddProjectInfo.TabIndex = 8;
            this.btnAddProjectInfo.Text = "Add";
            this.btnAddProjectInfo.UseVisualStyleBackColor = true;
            this.btnAddProjectInfo.Click += new System.EventHandler(this.btnAddProject_Click);
            // 
            // btnFilterProjectInfo
            // 
            this.btnFilterProjectInfo.Location = new System.Drawing.Point(592, 39);
            this.btnFilterProjectInfo.Name = "btnFilterProjectInfo";
            this.btnFilterProjectInfo.Size = new System.Drawing.Size(75, 23);
            this.btnFilterProjectInfo.TabIndex = 7;
            this.btnFilterProjectInfo.Text = "Filter";
            this.btnFilterProjectInfo.UseVisualStyleBackColor = true;
            this.btnFilterProjectInfo.Click += new System.EventHandler(this.btnProjectInfoFilter_Click);
            // 
            // tbxProjectInfoNameFilter
            // 
            this.tbxProjectInfoNameFilter.Location = new System.Drawing.Point(248, 40);
            this.tbxProjectInfoNameFilter.Name = "tbxProjectInfoNameFilter";
            this.tbxProjectInfoNameFilter.Size = new System.Drawing.Size(100, 21);
            this.tbxProjectInfoNameFilter.TabIndex = 4;
            // 
            // lblProjectNameFilter
            // 
            this.lblProjectNameFilter.AutoSize = true;
            this.lblProjectNameFilter.Location = new System.Drawing.Point(197, 43);
            this.lblProjectNameFilter.Name = "lblProjectNameFilter";
            this.lblProjectNameFilter.Size = new System.Drawing.Size(45, 14);
            this.lblProjectNameFilter.TabIndex = 3;
            this.lblProjectNameFilter.Text = "Name:";
            // 
            // tbxProjectInfoNumberFilter
            // 
            this.tbxProjectInfoNumberFilter.Location = new System.Drawing.Point(81, 40);
            this.tbxProjectInfoNumberFilter.Name = "tbxProjectInfoNumberFilter";
            this.tbxProjectInfoNumberFilter.Size = new System.Drawing.Size(100, 21);
            this.tbxProjectInfoNumberFilter.TabIndex = 2;
            // 
            // lblProjectNumberFilter
            // 
            this.lblProjectNumberFilter.AutoSize = true;
            this.lblProjectNumberFilter.Location = new System.Drawing.Point(17, 43);
            this.lblProjectNumberFilter.Name = "lblProjectNumberFilter";
            this.lblProjectNumberFilter.Size = new System.Drawing.Size(58, 14);
            this.lblProjectNumberFilter.TabIndex = 1;
            this.lblProjectNumberFilter.Text = "Number:";
            // 
            // dgvProjectInfo
            // 
            this.dgvProjectInfo.AllowUserToAddRows = false;
            this.dgvProjectInfo.AllowUserToDeleteRows = false;
            this.dgvProjectInfo.AllowUserToResizeRows = false;
            this.dgvProjectInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProjectInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvProjectInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProjectInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvProjectInfoSid,
            this.dgvProjectInfoOperation,
            this.dgvProjectInfoNumber,
            this.dgvProjectInfoName,
            this.dgvProjectInfoProjectSuperviserSid,
            this.dgvProjectInfoProjectTypeSid,
            this.dgvProjectInfoLaunchDate,
            this.dgvProjectInfoCloseDate});
            this.dgvProjectInfo.Location = new System.Drawing.Point(9, 69);
            this.dgvProjectInfo.Name = "dgvProjectInfo";
            this.dgvProjectInfo.RowTemplate.Height = 23;
            this.dgvProjectInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProjectInfo.Size = new System.Drawing.Size(823, 454);
            this.dgvProjectInfo.TabIndex = 0;
            this.dgvProjectInfo.TabStop = false;
            this.dgvProjectInfo.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProjectInfo_CellValueChanged);
            // 
            // dgvProjectInfoSid
            // 
            this.dgvProjectInfoSid.DataPropertyName = "Sid";
            this.dgvProjectInfoSid.HeaderText = "ProjectSid";
            this.dgvProjectInfoSid.Name = "dgvProjectInfoSid";
            this.dgvProjectInfoSid.Visible = false;
            this.dgvProjectInfoSid.Width = 92;
            // 
            // dgvProjectInfoOperation
            // 
            this.dgvProjectInfoOperation.DataPropertyName = "ProjectOperation";
            this.dgvProjectInfoOperation.HeaderText = "OP";
            this.dgvProjectInfoOperation.Name = "dgvProjectInfoOperation";
            this.dgvProjectInfoOperation.Width = 31;
            // 
            // dgvProjectInfoNumber
            // 
            this.dgvProjectInfoNumber.DataPropertyName = "Number";
            this.dgvProjectInfoNumber.HeaderText = "Number";
            this.dgvProjectInfoNumber.Name = "dgvProjectInfoNumber";
            this.dgvProjectInfoNumber.Width = 79;
            // 
            // dgvProjectInfoName
            // 
            this.dgvProjectInfoName.DataPropertyName = "Name";
            this.dgvProjectInfoName.HeaderText = "Name";
            this.dgvProjectInfoName.Name = "dgvProjectInfoName";
            this.dgvProjectInfoName.Width = 66;
            // 
            // dgvProjectInfoProjectSuperviserSid
            // 
            this.dgvProjectInfoProjectSuperviserSid.DataPropertyName = "Superviser";
            this.dgvProjectInfoProjectSuperviserSid.HeaderText = "Superviser";
            this.dgvProjectInfoProjectSuperviserSid.Name = "dgvProjectInfoProjectSuperviserSid";
            this.dgvProjectInfoProjectSuperviserSid.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProjectInfoProjectSuperviserSid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvProjectInfoProjectSuperviserSid.Width = 96;
            // 
            // dgvProjectInfoProjectTypeSid
            // 
            this.dgvProjectInfoProjectTypeSid.HeaderText = "Type";
            this.dgvProjectInfoProjectTypeSid.Name = "dgvProjectInfoProjectTypeSid";
            this.dgvProjectInfoProjectTypeSid.Width = 43;
            // 
            // dgvProjectInfoLaunchDate
            // 
            this.dgvProjectInfoLaunchDate.DataPropertyName = "LaunchDate";
            this.dgvProjectInfoLaunchDate.HeaderText = "Launch Date";
            this.dgvProjectInfoLaunchDate.Name = "dgvProjectInfoLaunchDate";
            this.dgvProjectInfoLaunchDate.Width = 104;
            // 
            // dgvProjectInfoCloseDate
            // 
            this.dgvProjectInfoCloseDate.DataPropertyName = "CloseDate";
            this.dgvProjectInfoCloseDate.HeaderText = "Close Date";
            this.dgvProjectInfoCloseDate.Name = "dgvProjectInfoCloseDate";
            this.dgvProjectInfoCloseDate.Width = 95;
            // 
            // gbInputStartPage
            // 
            this.gbInputStartPage.Controls.Add(this.pbInputStartPageLogo);
            this.gbInputStartPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbInputStartPage.Location = new System.Drawing.Point(0, 0);
            this.gbInputStartPage.Name = "gbInputStartPage";
            this.gbInputStartPage.Size = new System.Drawing.Size(835, 529);
            this.gbInputStartPage.TabIndex = 10;
            this.gbInputStartPage.TabStop = false;
            this.gbInputStartPage.Text = "Start Page";
            // 
            // pbInputStartPageLogo
            // 
            this.pbInputStartPageLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbInputStartPageLogo.Image")));
            this.pbInputStartPageLogo.InitialImage = null;
            this.pbInputStartPageLogo.Location = new System.Drawing.Point(153, 109);
            this.pbInputStartPageLogo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbInputStartPageLogo.Name = "pbInputStartPageLogo";
            this.pbInputStartPageLogo.Size = new System.Drawing.Size(502, 208);
            this.pbInputStartPageLogo.TabIndex = 1;
            this.pbInputStartPageLogo.TabStop = false;
            // 
            // gbProjectSuperviserInfo
            // 
            this.gbProjectSuperviserInfo.Controls.Add(this.btnProjectSuperviserInfoAdd);
            this.gbProjectSuperviserInfo.Controls.Add(this.btnProjectSuperviserInfoDelete);
            this.gbProjectSuperviserInfo.Controls.Add(this.btnProjectSuperviserInfoSearch);
            this.gbProjectSuperviserInfo.Controls.Add(this.tbxProjectSuperviserInfoName);
            this.gbProjectSuperviserInfo.Controls.Add(this.lblProjectSuperviseInfoName);
            this.gbProjectSuperviserInfo.Controls.Add(this.dgvProjectSuperviserInfo);
            this.gbProjectSuperviserInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbProjectSuperviserInfo.Location = new System.Drawing.Point(0, 0);
            this.gbProjectSuperviserInfo.Name = "gbProjectSuperviserInfo";
            this.gbProjectSuperviserInfo.Size = new System.Drawing.Size(835, 529);
            this.gbProjectSuperviserInfo.TabIndex = 3;
            this.gbProjectSuperviserInfo.TabStop = false;
            this.gbProjectSuperviserInfo.Text = "Project Superviser";
            this.gbProjectSuperviserInfo.Visible = false;
            // 
            // btnProjectSuperviserInfoAdd
            // 
            this.btnProjectSuperviserInfoAdd.Location = new System.Drawing.Point(754, 33);
            this.btnProjectSuperviserInfoAdd.Name = "btnProjectSuperviserInfoAdd";
            this.btnProjectSuperviserInfoAdd.Size = new System.Drawing.Size(75, 23);
            this.btnProjectSuperviserInfoAdd.TabIndex = 8;
            this.btnProjectSuperviserInfoAdd.Text = "Add";
            this.btnProjectSuperviserInfoAdd.UseVisualStyleBackColor = true;
            this.btnProjectSuperviserInfoAdd.Click += new System.EventHandler(this.btnProjectSuperviserInfoAdd_Click);
            // 
            // btnProjectSuperviserInfoDelete
            // 
            this.btnProjectSuperviserInfoDelete.Location = new System.Drawing.Point(673, 34);
            this.btnProjectSuperviserInfoDelete.Name = "btnProjectSuperviserInfoDelete";
            this.btnProjectSuperviserInfoDelete.Size = new System.Drawing.Size(75, 23);
            this.btnProjectSuperviserInfoDelete.TabIndex = 7;
            this.btnProjectSuperviserInfoDelete.Text = "Delete";
            this.btnProjectSuperviserInfoDelete.UseVisualStyleBackColor = true;
            this.btnProjectSuperviserInfoDelete.Click += new System.EventHandler(this.btnProjectSuperviserInfoDelete_Click);
            // 
            // btnProjectSuperviserInfoSearch
            // 
            this.btnProjectSuperviserInfoSearch.Location = new System.Drawing.Point(592, 33);
            this.btnProjectSuperviserInfoSearch.Name = "btnProjectSuperviserInfoSearch";
            this.btnProjectSuperviserInfoSearch.Size = new System.Drawing.Size(75, 23);
            this.btnProjectSuperviserInfoSearch.TabIndex = 6;
            this.btnProjectSuperviserInfoSearch.Text = "Search";
            this.btnProjectSuperviserInfoSearch.UseVisualStyleBackColor = true;
            this.btnProjectSuperviserInfoSearch.Click += new System.EventHandler(this.btnProjectSuperviserInfoSearch_Click);
            // 
            // tbxProjectSuperviserInfoName
            // 
            this.tbxProjectSuperviserInfoName.Location = new System.Drawing.Point(81, 34);
            this.tbxProjectSuperviserInfoName.Name = "tbxProjectSuperviserInfoName";
            this.tbxProjectSuperviserInfoName.Size = new System.Drawing.Size(100, 21);
            this.tbxProjectSuperviserInfoName.TabIndex = 5;
            // 
            // lblProjectSuperviseInfoName
            // 
            this.lblProjectSuperviseInfoName.AutoSize = true;
            this.lblProjectSuperviseInfoName.Location = new System.Drawing.Point(26, 37);
            this.lblProjectSuperviseInfoName.Name = "lblProjectSuperviseInfoName";
            this.lblProjectSuperviseInfoName.Size = new System.Drawing.Size(45, 14);
            this.lblProjectSuperviseInfoName.TabIndex = 4;
            this.lblProjectSuperviseInfoName.Text = "Name:";
            // 
            // dgvProjectSuperviserInfo
            // 
            this.dgvProjectSuperviserInfo.AllowUserToAddRows = false;
            this.dgvProjectSuperviserInfo.AllowUserToDeleteRows = false;
            this.dgvProjectSuperviserInfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvProjectSuperviserInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvProjectSuperviserInfoSid,
            this.dgvProjectSuperviserInfoOperation,
            this.dgvProjectSuperviserInfoName,
            this.dgvProjectSuperviserInfoPhone,
            this.dgvProjectSuperviserInfoMobile,
            this.dgvProjectSuperviserInfoMailAddress});
            this.dgvProjectSuperviserInfo.Location = new System.Drawing.Point(9, 69);
            this.dgvProjectSuperviserInfo.Name = "dgvProjectSuperviserInfo";
            this.dgvProjectSuperviserInfo.RowTemplate.Height = 23;
            this.dgvProjectSuperviserInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProjectSuperviserInfo.Size = new System.Drawing.Size(820, 454);
            this.dgvProjectSuperviserInfo.TabIndex = 3;
            this.dgvProjectSuperviserInfo.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProjectSuperviserInfo_CellValueChanged);
            // 
            // dgvProjectSuperviserInfoSid
            // 
            this.dgvProjectSuperviserInfoSid.DataPropertyName = "Sid";
            this.dgvProjectSuperviserInfoSid.HeaderText = "Sid";
            this.dgvProjectSuperviserInfoSid.Name = "dgvProjectSuperviserInfoSid";
            this.dgvProjectSuperviserInfoSid.Visible = false;
            this.dgvProjectSuperviserInfoSid.Width = 51;
            // 
            // dgvProjectSuperviserInfoOperation
            // 
            this.dgvProjectSuperviserInfoOperation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgvProjectSuperviserInfoOperation.DataPropertyName = "Operation";
            this.dgvProjectSuperviserInfoOperation.HeaderText = "OP";
            this.dgvProjectSuperviserInfoOperation.Name = "dgvProjectSuperviserInfoOperation";
            this.dgvProjectSuperviserInfoOperation.Width = 31;
            // 
            // dgvProjectSuperviserInfoName
            // 
            this.dgvProjectSuperviserInfoName.HeaderText = "Name";
            this.dgvProjectSuperviserInfoName.Name = "dgvProjectSuperviserInfoName";
            this.dgvProjectSuperviserInfoName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dgvProjectSuperviserInfoPhone
            // 
            this.dgvProjectSuperviserInfoPhone.HeaderText = "Phone";
            this.dgvProjectSuperviserInfoPhone.Name = "dgvProjectSuperviserInfoPhone";
            // 
            // dgvProjectSuperviserInfoMobile
            // 
            this.dgvProjectSuperviserInfoMobile.HeaderText = "Mobile";
            this.dgvProjectSuperviserInfoMobile.Name = "dgvProjectSuperviserInfoMobile";
            // 
            // dgvProjectSuperviserInfoMailAddress
            // 
            this.dgvProjectSuperviserInfoMailAddress.HeaderText = "MailAddress";
            this.dgvProjectSuperviserInfoMailAddress.Name = "dgvProjectSuperviserInfoMailAddress";
            this.dgvProjectSuperviserInfoMailAddress.Width = 200;
            // 
            // gbParameterInfo
            // 
            this.gbParameterInfo.Controls.Add(this.gbProjecyTypeInfo);
            this.gbParameterInfo.Controls.Add(this.gbCityInfo);
            this.gbParameterInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbParameterInfo.Location = new System.Drawing.Point(0, 0);
            this.gbParameterInfo.Name = "gbParameterInfo";
            this.gbParameterInfo.Size = new System.Drawing.Size(835, 529);
            this.gbParameterInfo.TabIndex = 10;
            this.gbParameterInfo.TabStop = false;
            this.gbParameterInfo.Text = "Parameter Info";
            this.gbParameterInfo.Visible = false;
            // 
            // gbProjecyTypeInfo
            // 
            this.gbProjecyTypeInfo.Controls.Add(this.btnProjectTypeDelete);
            this.gbProjecyTypeInfo.Controls.Add(this.dgvParameterProjectTypeInfo);
            this.gbProjecyTypeInfo.Controls.Add(this.btnProjectTypeInfoAdd);
            this.gbProjecyTypeInfo.Location = new System.Drawing.Point(339, 20);
            this.gbProjecyTypeInfo.Name = "gbProjecyTypeInfo";
            this.gbProjecyTypeInfo.Size = new System.Drawing.Size(307, 503);
            this.gbProjecyTypeInfo.TabIndex = 1;
            this.gbProjecyTypeInfo.TabStop = false;
            this.gbProjecyTypeInfo.Text = "ProjectType";
            // 
            // btnProjectTypeDelete
            // 
            this.btnProjectTypeDelete.Location = new System.Drawing.Point(151, 23);
            this.btnProjectTypeDelete.Name = "btnProjectTypeDelete";
            this.btnProjectTypeDelete.Size = new System.Drawing.Size(75, 23);
            this.btnProjectTypeDelete.TabIndex = 5;
            this.btnProjectTypeDelete.Text = "Delete";
            this.btnProjectTypeDelete.UseVisualStyleBackColor = true;
            this.btnProjectTypeDelete.Click += new System.EventHandler(this.btnProjectTypeDelete_Click);
            // 
            // dgvParameterProjectTypeInfo
            // 
            this.dgvParameterProjectTypeInfo.AllowUserToAddRows = false;
            this.dgvParameterProjectTypeInfo.AllowUserToDeleteRows = false;
            this.dgvParameterProjectTypeInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvParameterProjectTypeInfoSid,
            this.dgvParameterProjectTypeInfoOperation,
            this.dgvParameterProjectTypeInfoProjectType});
            this.dgvParameterProjectTypeInfo.Location = new System.Drawing.Point(6, 52);
            this.dgvParameterProjectTypeInfo.Name = "dgvParameterProjectTypeInfo";
            this.dgvParameterProjectTypeInfo.RowTemplate.Height = 23;
            this.dgvParameterProjectTypeInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvParameterProjectTypeInfo.Size = new System.Drawing.Size(310, 445);
            this.dgvParameterProjectTypeInfo.TabIndex = 3;
            this.dgvParameterProjectTypeInfo.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParameterProjectTypeInfo_CellValueChanged);
            // 
            // dgvParameterProjectTypeInfoSid
            // 
            this.dgvParameterProjectTypeInfoSid.DataPropertyName = "Sid";
            this.dgvParameterProjectTypeInfoSid.HeaderText = "Sid";
            this.dgvParameterProjectTypeInfoSid.Name = "dgvParameterProjectTypeInfoSid";
            this.dgvParameterProjectTypeInfoSid.Visible = false;
            this.dgvParameterProjectTypeInfoSid.Width = 51;
            // 
            // dgvParameterProjectTypeInfoOperation
            // 
            this.dgvParameterProjectTypeInfoOperation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgvParameterProjectTypeInfoOperation.DataPropertyName = "Operation";
            this.dgvParameterProjectTypeInfoOperation.HeaderText = "OP";
            this.dgvParameterProjectTypeInfoOperation.Name = "dgvParameterProjectTypeInfoOperation";
            this.dgvParameterProjectTypeInfoOperation.Width = 31;
            // 
            // dgvParameterProjectTypeInfoProjectType
            // 
            this.dgvParameterProjectTypeInfoProjectType.HeaderText = "Type";
            this.dgvParameterProjectTypeInfoProjectType.Name = "dgvParameterProjectTypeInfoProjectType";
            this.dgvParameterProjectTypeInfoProjectType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvParameterProjectTypeInfoProjectType.Width = 150;
            // 
            // btnProjectTypeInfoAdd
            // 
            this.btnProjectTypeInfoAdd.Location = new System.Drawing.Point(232, 23);
            this.btnProjectTypeInfoAdd.Name = "btnProjectTypeInfoAdd";
            this.btnProjectTypeInfoAdd.Size = new System.Drawing.Size(75, 23);
            this.btnProjectTypeInfoAdd.TabIndex = 4;
            this.btnProjectTypeInfoAdd.Text = "Add";
            this.btnProjectTypeInfoAdd.UseVisualStyleBackColor = true;
            this.btnProjectTypeInfoAdd.Click += new System.EventHandler(this.btnProjectTypeInfoAdd_Click);
            // 
            // gbCityInfo
            // 
            this.gbCityInfo.Controls.Add(this.dgvParameterCityInfo);
            this.gbCityInfo.Controls.Add(this.btnParameterCityInfoDelete);
            this.gbCityInfo.Controls.Add(this.btnParameterCityInfoAdd);
            this.gbCityInfo.Location = new System.Drawing.Point(20, 20);
            this.gbCityInfo.Name = "gbCityInfo";
            this.gbCityInfo.Size = new System.Drawing.Size(313, 503);
            this.gbCityInfo.TabIndex = 0;
            this.gbCityInfo.TabStop = false;
            this.gbCityInfo.Text = "City";
            // 
            // dgvParameterCityInfo
            // 
            this.dgvParameterCityInfo.AllowUserToAddRows = false;
            this.dgvParameterCityInfo.AllowUserToDeleteRows = false;
            this.dgvParameterCityInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvParameterCityInfoSid,
            this.dgvParameterCityInfoOperation,
            this.dgvParameterCityInfoCity});
            this.dgvParameterCityInfo.Location = new System.Drawing.Point(6, 52);
            this.dgvParameterCityInfo.Name = "dgvParameterCityInfo";
            this.dgvParameterCityInfo.RowTemplate.Height = 23;
            this.dgvParameterCityInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvParameterCityInfo.Size = new System.Drawing.Size(301, 445);
            this.dgvParameterCityInfo.TabIndex = 0;
            this.dgvParameterCityInfo.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParameterCityInfo_CellValueChanged);
            // 
            // dgvParameterCityInfoSid
            // 
            this.dgvParameterCityInfoSid.DataPropertyName = "Sid";
            this.dgvParameterCityInfoSid.HeaderText = "Sid";
            this.dgvParameterCityInfoSid.Name = "dgvParameterCityInfoSid";
            this.dgvParameterCityInfoSid.Visible = false;
            this.dgvParameterCityInfoSid.Width = 51;
            // 
            // dgvParameterCityInfoOperation
            // 
            this.dgvParameterCityInfoOperation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgvParameterCityInfoOperation.DataPropertyName = "Operation";
            this.dgvParameterCityInfoOperation.HeaderText = "OP";
            this.dgvParameterCityInfoOperation.Name = "dgvParameterCityInfoOperation";
            this.dgvParameterCityInfoOperation.Width = 31;
            // 
            // dgvParameterCityInfoCity
            // 
            this.dgvParameterCityInfoCity.HeaderText = "City";
            this.dgvParameterCityInfoCity.Name = "dgvParameterCityInfoCity";
            this.dgvParameterCityInfoCity.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvParameterCityInfoCity.Width = 150;
            // 
            // btnParameterCityInfoDelete
            // 
            this.btnParameterCityInfoDelete.Location = new System.Drawing.Point(151, 24);
            this.btnParameterCityInfoDelete.Name = "btnParameterCityInfoDelete";
            this.btnParameterCityInfoDelete.Size = new System.Drawing.Size(75, 23);
            this.btnParameterCityInfoDelete.TabIndex = 2;
            this.btnParameterCityInfoDelete.Text = "Delete";
            this.btnParameterCityInfoDelete.UseVisualStyleBackColor = true;
            this.btnParameterCityInfoDelete.Click += new System.EventHandler(this.btnParameterCityInfoDelete_Click);
            // 
            // btnParameterCityInfoAdd
            // 
            this.btnParameterCityInfoAdd.Location = new System.Drawing.Point(232, 23);
            this.btnParameterCityInfoAdd.Name = "btnParameterCityInfoAdd";
            this.btnParameterCityInfoAdd.Size = new System.Drawing.Size(75, 23);
            this.btnParameterCityInfoAdd.TabIndex = 1;
            this.btnParameterCityInfoAdd.Text = "Add";
            this.btnParameterCityInfoAdd.UseVisualStyleBackColor = true;
            this.btnParameterCityInfoAdd.Click += new System.EventHandler(this.btnParameterCityInfoAdd_Click);
            // 
            // gbLaptopType
            // 
            this.gbLaptopType.Controls.Add(this.btnLaptopTypeInfoFilter);
            this.gbLaptopType.Controls.Add(this.btnLaptopTypeInfoDelete);
            this.gbLaptopType.Controls.Add(this.btnLaptopTypeInfoAdd);
            this.gbLaptopType.Controls.Add(this.dgvLaptopTypeInfo);
            this.gbLaptopType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbLaptopType.Location = new System.Drawing.Point(0, 0);
            this.gbLaptopType.Name = "gbLaptopType";
            this.gbLaptopType.Size = new System.Drawing.Size(835, 529);
            this.gbLaptopType.TabIndex = 12;
            this.gbLaptopType.TabStop = false;
            this.gbLaptopType.Text = "Laptop Type";
            this.gbLaptopType.Visible = false;
            // 
            // btnLaptopTypeInfoFilter
            // 
            this.btnLaptopTypeInfoFilter.Location = new System.Drawing.Point(592, 39);
            this.btnLaptopTypeInfoFilter.Name = "btnLaptopTypeInfoFilter";
            this.btnLaptopTypeInfoFilter.Size = new System.Drawing.Size(75, 23);
            this.btnLaptopTypeInfoFilter.TabIndex = 5;
            this.btnLaptopTypeInfoFilter.Text = "Filter";
            this.btnLaptopTypeInfoFilter.UseVisualStyleBackColor = true;
            this.btnLaptopTypeInfoFilter.Click += new System.EventHandler(this.btnLaptopTypeInfoFilter_Click);
            // 
            // btnLaptopTypeInfoDelete
            // 
            this.btnLaptopTypeInfoDelete.Location = new System.Drawing.Point(673, 39);
            this.btnLaptopTypeInfoDelete.Name = "btnLaptopTypeInfoDelete";
            this.btnLaptopTypeInfoDelete.Size = new System.Drawing.Size(75, 23);
            this.btnLaptopTypeInfoDelete.TabIndex = 4;
            this.btnLaptopTypeInfoDelete.Text = "Delete";
            this.btnLaptopTypeInfoDelete.UseVisualStyleBackColor = true;
            this.btnLaptopTypeInfoDelete.Click += new System.EventHandler(this.btnLaptopTypeInfoDelete_Click);
            // 
            // btnLaptopTypeInfoAdd
            // 
            this.btnLaptopTypeInfoAdd.Location = new System.Drawing.Point(754, 39);
            this.btnLaptopTypeInfoAdd.Name = "btnLaptopTypeInfoAdd";
            this.btnLaptopTypeInfoAdd.Size = new System.Drawing.Size(75, 23);
            this.btnLaptopTypeInfoAdd.TabIndex = 3;
            this.btnLaptopTypeInfoAdd.Text = "Add";
            this.btnLaptopTypeInfoAdd.UseVisualStyleBackColor = true;
            this.btnLaptopTypeInfoAdd.Click += new System.EventHandler(this.btnLaptopTypeInfoAdd_Click);
            // 
            // dgvLaptopTypeInfo
            // 
            this.dgvLaptopTypeInfo.AllowUserToAddRows = false;
            this.dgvLaptopTypeInfo.AllowUserToDeleteRows = false;
            this.dgvLaptopTypeInfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvLaptopTypeInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvLaptopTypeInfoSid,
            this.dgvLaptopTypeInfoOperation,
            this.dgvLaptopTypeInfoImage,
            this.dgvLaptopTypeInfoBrand,
            this.dgvLaptopTypeInfoModel,
            this.dgvLaptopTypeInfoBatteryCapacity,
            this.dgvLaptopTypeInfoisTouchScreen});
            this.dgvLaptopTypeInfo.Location = new System.Drawing.Point(15, 72);
            this.dgvLaptopTypeInfo.Name = "dgvLaptopTypeInfo";
            this.dgvLaptopTypeInfo.RowTemplate.Height = 23;
            this.dgvLaptopTypeInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLaptopTypeInfo.Size = new System.Drawing.Size(814, 445);
            this.dgvLaptopTypeInfo.TabIndex = 2;
            this.dgvLaptopTypeInfo.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLaptopTypeInfo_CellContentDoubleClick);
            this.dgvLaptopTypeInfo.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLaptopTypeInfo_CellValueChanged);
            // 
            // dgvLaptopTypeInfoSid
            // 
            this.dgvLaptopTypeInfoSid.DataPropertyName = "Sid";
            this.dgvLaptopTypeInfoSid.HeaderText = "Sid";
            this.dgvLaptopTypeInfoSid.Name = "dgvLaptopTypeInfoSid";
            this.dgvLaptopTypeInfoSid.Visible = false;
            this.dgvLaptopTypeInfoSid.Width = 51;
            // 
            // dgvLaptopTypeInfoOperation
            // 
            this.dgvLaptopTypeInfoOperation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgvLaptopTypeInfoOperation.DataPropertyName = "Operation";
            this.dgvLaptopTypeInfoOperation.HeaderText = "OP";
            this.dgvLaptopTypeInfoOperation.Name = "dgvLaptopTypeInfoOperation";
            this.dgvLaptopTypeInfoOperation.Width = 31;
            // 
            // dgvLaptopTypeInfoImage
            // 
            this.dgvLaptopTypeInfoImage.HeaderText = "Image";
            this.dgvLaptopTypeInfoImage.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dgvLaptopTypeInfoImage.Name = "dgvLaptopTypeInfoImage";
            // 
            // dgvLaptopTypeInfoBrand
            // 
            this.dgvLaptopTypeInfoBrand.HeaderText = "Brand";
            this.dgvLaptopTypeInfoBrand.Name = "dgvLaptopTypeInfoBrand";
            this.dgvLaptopTypeInfoBrand.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dgvLaptopTypeInfoModel
            // 
            this.dgvLaptopTypeInfoModel.HeaderText = "Model";
            this.dgvLaptopTypeInfoModel.Name = "dgvLaptopTypeInfoModel";
            // 
            // dgvLaptopTypeInfoBatteryCapacity
            // 
            this.dgvLaptopTypeInfoBatteryCapacity.HeaderText = "Battery Capacity";
            this.dgvLaptopTypeInfoBatteryCapacity.Name = "dgvLaptopTypeInfoBatteryCapacity";
            // 
            // dgvLaptopTypeInfoisTouchScreen
            // 
            this.dgvLaptopTypeInfoisTouchScreen.HeaderText = "isTouchScreen";
            this.dgvLaptopTypeInfoisTouchScreen.Name = "dgvLaptopTypeInfoisTouchScreen";
            // 
            // gbCompanyInfo
            // 
            this.gbCompanyInfo.Controls.Add(this.btnCompanyInfoFilter);
            this.gbCompanyInfo.Controls.Add(this.btnCompanyInfoDelete);
            this.gbCompanyInfo.Controls.Add(this.btnCompanyInfoAdd);
            this.gbCompanyInfo.Controls.Add(this.tbxCompanyInfoCodeFilter);
            this.gbCompanyInfo.Controls.Add(this.lblCompanyInfoCodeFilter);
            this.gbCompanyInfo.Controls.Add(this.tbxCompanyInfoNameFilter);
            this.gbCompanyInfo.Controls.Add(this.lblCompanyInfoNameFilter);
            this.gbCompanyInfo.Controls.Add(this.btnCompanyInfoCityFilterShowAll);
            this.gbCompanyInfo.Controls.Add(this.lblCompanyInfoCityFilter);
            this.gbCompanyInfo.Controls.Add(this.cbxCompanyInfoCityFilter);
            this.gbCompanyInfo.Controls.Add(this.dgvCompanyInfo);
            this.gbCompanyInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCompanyInfo.Location = new System.Drawing.Point(0, 0);
            this.gbCompanyInfo.Name = "gbCompanyInfo";
            this.gbCompanyInfo.Size = new System.Drawing.Size(835, 529);
            this.gbCompanyInfo.TabIndex = 10;
            this.gbCompanyInfo.TabStop = false;
            this.gbCompanyInfo.Text = "Company Infomation";
            this.gbCompanyInfo.Visible = false;
            // 
            // btnCompanyInfoFilter
            // 
            this.btnCompanyInfoFilter.Location = new System.Drawing.Point(592, 33);
            this.btnCompanyInfoFilter.Name = "btnCompanyInfoFilter";
            this.btnCompanyInfoFilter.Size = new System.Drawing.Size(75, 23);
            this.btnCompanyInfoFilter.TabIndex = 11;
            this.btnCompanyInfoFilter.Text = "Filter";
            this.btnCompanyInfoFilter.UseVisualStyleBackColor = true;
            this.btnCompanyInfoFilter.Click += new System.EventHandler(this.btnCompanyInfoFilter_Click);
            // 
            // btnCompanyInfoDelete
            // 
            this.btnCompanyInfoDelete.Location = new System.Drawing.Point(673, 34);
            this.btnCompanyInfoDelete.Name = "btnCompanyInfoDelete";
            this.btnCompanyInfoDelete.Size = new System.Drawing.Size(75, 23);
            this.btnCompanyInfoDelete.TabIndex = 10;
            this.btnCompanyInfoDelete.Text = "Delete";
            this.btnCompanyInfoDelete.UseVisualStyleBackColor = true;
            this.btnCompanyInfoDelete.Click += new System.EventHandler(this.btnCompanyInfoDelete_Click);
            // 
            // btnCompanyInfoAdd
            // 
            this.btnCompanyInfoAdd.Location = new System.Drawing.Point(754, 34);
            this.btnCompanyInfoAdd.Name = "btnCompanyInfoAdd";
            this.btnCompanyInfoAdd.Size = new System.Drawing.Size(75, 23);
            this.btnCompanyInfoAdd.TabIndex = 9;
            this.btnCompanyInfoAdd.Text = "Add";
            this.btnCompanyInfoAdd.UseVisualStyleBackColor = true;
            this.btnCompanyInfoAdd.Click += new System.EventHandler(this.btnCompanyInfoAdd_Click);
            // 
            // tbxCompanyInfoCodeFilter
            // 
            this.tbxCompanyInfoCodeFilter.Location = new System.Drawing.Point(165, 33);
            this.tbxCompanyInfoCodeFilter.Name = "tbxCompanyInfoCodeFilter";
            this.tbxCompanyInfoCodeFilter.Size = new System.Drawing.Size(58, 21);
            this.tbxCompanyInfoCodeFilter.TabIndex = 8;
            // 
            // lblCompanyInfoCodeFilter
            // 
            this.lblCompanyInfoCodeFilter.AutoSize = true;
            this.lblCompanyInfoCodeFilter.Location = new System.Drawing.Point(128, 36);
            this.lblCompanyInfoCodeFilter.Name = "lblCompanyInfoCodeFilter";
            this.lblCompanyInfoCodeFilter.Size = new System.Drawing.Size(38, 14);
            this.lblCompanyInfoCodeFilter.TabIndex = 7;
            this.lblCompanyInfoCodeFilter.Text = "Code";
            // 
            // tbxCompanyInfoNameFilter
            // 
            this.tbxCompanyInfoNameFilter.Location = new System.Drawing.Point(64, 32);
            this.tbxCompanyInfoNameFilter.Name = "tbxCompanyInfoNameFilter";
            this.tbxCompanyInfoNameFilter.Size = new System.Drawing.Size(58, 21);
            this.tbxCompanyInfoNameFilter.TabIndex = 6;
            // 
            // lblCompanyInfoNameFilter
            // 
            this.lblCompanyInfoNameFilter.AutoSize = true;
            this.lblCompanyInfoNameFilter.Location = new System.Drawing.Point(17, 36);
            this.lblCompanyInfoNameFilter.Name = "lblCompanyInfoNameFilter";
            this.lblCompanyInfoNameFilter.Size = new System.Drawing.Size(41, 14);
            this.lblCompanyInfoNameFilter.TabIndex = 5;
            this.lblCompanyInfoNameFilter.Text = "Name";
            // 
            // btnCompanyInfoCityFilterShowAll
            // 
            this.btnCompanyInfoCityFilterShowAll.Location = new System.Drawing.Point(339, 31);
            this.btnCompanyInfoCityFilterShowAll.Name = "btnCompanyInfoCityFilterShowAll";
            this.btnCompanyInfoCityFilterShowAll.Size = new System.Drawing.Size(31, 23);
            this.btnCompanyInfoCityFilterShowAll.TabIndex = 4;
            this.btnCompanyInfoCityFilterShowAll.Text = "All";
            this.btnCompanyInfoCityFilterShowAll.UseVisualStyleBackColor = true;
            this.btnCompanyInfoCityFilterShowAll.Click += new System.EventHandler(this.btnCompanyInfoCityFilterShowAll_Click);
            // 
            // lblCompanyInfoCityFilter
            // 
            this.lblCompanyInfoCityFilter.AutoSize = true;
            this.lblCompanyInfoCityFilter.Location = new System.Drawing.Point(229, 37);
            this.lblCompanyInfoCityFilter.Name = "lblCompanyInfoCityFilter";
            this.lblCompanyInfoCityFilter.Size = new System.Drawing.Size(30, 14);
            this.lblCompanyInfoCityFilter.TabIndex = 3;
            this.lblCompanyInfoCityFilter.Text = "City";
            // 
            // cbxCompanyInfoCityFilter
            // 
            this.cbxCompanyInfoCityFilter.FormattingEnabled = true;
            this.cbxCompanyInfoCityFilter.Location = new System.Drawing.Point(265, 32);
            this.cbxCompanyInfoCityFilter.Name = "cbxCompanyInfoCityFilter";
            this.cbxCompanyInfoCityFilter.Size = new System.Drawing.Size(68, 22);
            this.cbxCompanyInfoCityFilter.TabIndex = 2;
            // 
            // dgvCompanyInfo
            // 
            this.dgvCompanyInfo.AllowUserToAddRows = false;
            this.dgvCompanyInfo.AllowUserToDeleteRows = false;
            this.dgvCompanyInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvCompanyInfoSid,
            this.dgvCompanyInfoOperation,
            this.dgvCompanyInfoName,
            this.dgvCompanyInfoCode,
            this.dgvCompanyInfoParameterCitySid,
            this.dgvCompanyInfoisVender});
            this.dgvCompanyInfo.Location = new System.Drawing.Point(9, 72);
            this.dgvCompanyInfo.Name = "dgvCompanyInfo";
            this.dgvCompanyInfo.RowTemplate.Height = 23;
            this.dgvCompanyInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCompanyInfo.Size = new System.Drawing.Size(820, 445);
            this.dgvCompanyInfo.TabIndex = 1;
            this.dgvCompanyInfo.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCompanyInfo_CellValueChanged);
            // 
            // dgvCompanyInfoSid
            // 
            this.dgvCompanyInfoSid.DataPropertyName = "Sid";
            this.dgvCompanyInfoSid.HeaderText = "Sid";
            this.dgvCompanyInfoSid.Name = "dgvCompanyInfoSid";
            this.dgvCompanyInfoSid.Visible = false;
            this.dgvCompanyInfoSid.Width = 51;
            // 
            // dgvCompanyInfoOperation
            // 
            this.dgvCompanyInfoOperation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgvCompanyInfoOperation.DataPropertyName = "Operation";
            this.dgvCompanyInfoOperation.HeaderText = "OP";
            this.dgvCompanyInfoOperation.Name = "dgvCompanyInfoOperation";
            this.dgvCompanyInfoOperation.Width = 31;
            // 
            // dgvCompanyInfoName
            // 
            this.dgvCompanyInfoName.HeaderText = "Name";
            this.dgvCompanyInfoName.Name = "dgvCompanyInfoName";
            this.dgvCompanyInfoName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCompanyInfoName.Width = 150;
            // 
            // dgvCompanyInfoCode
            // 
            this.dgvCompanyInfoCode.HeaderText = "Code";
            this.dgvCompanyInfoCode.Name = "dgvCompanyInfoCode";
            // 
            // dgvCompanyInfoParameterCitySid
            // 
            this.dgvCompanyInfoParameterCitySid.HeaderText = "City";
            this.dgvCompanyInfoParameterCitySid.Name = "dgvCompanyInfoParameterCitySid";
            this.dgvCompanyInfoParameterCitySid.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCompanyInfoParameterCitySid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dgvCompanyInfoisVender
            // 
            this.dgvCompanyInfoisVender.HeaderText = "isVender?";
            this.dgvCompanyInfoisVender.Name = "dgvCompanyInfoisVender";
            this.dgvCompanyInfoisVender.Width = 75;
            // 
            // tpOperation
            // 
            this.tpOperation.Controls.Add(this.splitContainerOperation);
            this.tpOperation.Location = new System.Drawing.Point(4, 23);
            this.tpOperation.Name = "tpOperation";
            this.tpOperation.Padding = new System.Windows.Forms.Padding(3);
            this.tpOperation.Size = new System.Drawing.Size(982, 535);
            this.tpOperation.TabIndex = 2;
            this.tpOperation.Text = "Operation";
            this.tpOperation.UseVisualStyleBackColor = true;
            // 
            // splitContainerOperation
            // 
            this.splitContainerOperation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerOperation.Location = new System.Drawing.Point(3, 3);
            this.splitContainerOperation.Name = "splitContainerOperation";
            // 
            // splitContainerOperation.Panel1
            // 
            this.splitContainerOperation.Panel1.Controls.Add(this.gbOperationFunction);
            // 
            // splitContainerOperation.Panel2
            // 
            this.splitContainerOperation.Panel2.Controls.Add(this.gbAssignJob);
            this.splitContainerOperation.Panel2.Controls.Add(this.gbBuyLaotop);
            this.splitContainerOperation.Panel2.Controls.Add(this.gbOperationStartPage);
            this.splitContainerOperation.Size = new System.Drawing.Size(976, 529);
            this.splitContainerOperation.SplitterDistance = 114;
            this.splitContainerOperation.TabIndex = 0;
            // 
            // gbOperationFunction
            // 
            this.gbOperationFunction.Controls.Add(this.btnAssignJob);
            this.gbOperationFunction.Controls.Add(this.btnBuyLaptop);
            this.gbOperationFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbOperationFunction.Location = new System.Drawing.Point(0, 0);
            this.gbOperationFunction.Name = "gbOperationFunction";
            this.gbOperationFunction.Size = new System.Drawing.Size(114, 529);
            this.gbOperationFunction.TabIndex = 0;
            this.gbOperationFunction.TabStop = false;
            this.gbOperationFunction.Text = "Function";
            // 
            // btnAssignJob
            // 
            this.btnAssignJob.Location = new System.Drawing.Point(6, 51);
            this.btnAssignJob.Name = "btnAssignJob";
            this.btnAssignJob.Size = new System.Drawing.Size(102, 23);
            this.btnAssignJob.TabIndex = 1;
            this.btnAssignJob.Text = "Assign Job";
            this.btnAssignJob.UseVisualStyleBackColor = true;
            this.btnAssignJob.Click += new System.EventHandler(this.btnAssignJob_Click);
            // 
            // btnBuyLaptop
            // 
            this.btnBuyLaptop.Location = new System.Drawing.Point(6, 20);
            this.btnBuyLaptop.Name = "btnBuyLaptop";
            this.btnBuyLaptop.Size = new System.Drawing.Size(103, 23);
            this.btnBuyLaptop.TabIndex = 0;
            this.btnBuyLaptop.Text = "Buy Laptop";
            this.btnBuyLaptop.UseVisualStyleBackColor = true;
            this.btnBuyLaptop.Click += new System.EventHandler(this.btnBuyLaptop_Click);
            // 
            // gbAssignJob
            // 
            this.gbAssignJob.Controls.Add(this.splitContainerAssignJob1);
            this.gbAssignJob.Controls.Add(this.pnAssignJobBottom);
            this.gbAssignJob.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAssignJob.Location = new System.Drawing.Point(0, 0);
            this.gbAssignJob.Name = "gbAssignJob";
            this.gbAssignJob.Size = new System.Drawing.Size(858, 529);
            this.gbAssignJob.TabIndex = 15;
            this.gbAssignJob.TabStop = false;
            this.gbAssignJob.Text = "Job Assignment";
            this.gbAssignJob.Visible = false;
            // 
            // splitContainerAssignJob1
            // 
            this.splitContainerAssignJob1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerAssignJob1.Location = new System.Drawing.Point(3, 17);
            this.splitContainerAssignJob1.Name = "splitContainerAssignJob1";
            // 
            // splitContainerAssignJob1.Panel1
            // 
            this.splitContainerAssignJob1.Panel1.Controls.Add(this.splitContainerAssignJob2);
            // 
            // splitContainerAssignJob1.Panel2
            // 
            this.splitContainerAssignJob1.Panel2.Controls.Add(this.gbAssignJobLaptop);
            this.splitContainerAssignJob1.Size = new System.Drawing.Size(852, 499);
            this.splitContainerAssignJob1.SplitterDistance = 360;
            this.splitContainerAssignJob1.TabIndex = 1;
            // 
            // splitContainerAssignJob2
            // 
            this.splitContainerAssignJob2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerAssignJob2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerAssignJob2.Name = "splitContainerAssignJob2";
            // 
            // splitContainerAssignJob2.Panel1
            // 
            this.splitContainerAssignJob2.Panel1.Controls.Add(this.gbAssignJobProject);
            // 
            // splitContainerAssignJob2.Panel2
            // 
            this.splitContainerAssignJob2.Panel2.Controls.Add(this.gbAssignJobCompany);
            this.splitContainerAssignJob2.Size = new System.Drawing.Size(360, 499);
            this.splitContainerAssignJob2.SplitterDistance = 159;
            this.splitContainerAssignJob2.TabIndex = 0;
            // 
            // gbAssignJobProject
            // 
            this.gbAssignJobProject.Controls.Add(this.btnAssignJobProjectNext);
            this.gbAssignJobProject.Controls.Add(this.btnAssignJobProjectFilter);
            this.gbAssignJobProject.Controls.Add(this.lblAssignJobProCodejectFilter);
            this.gbAssignJobProject.Controls.Add(this.tbxAssignJobProjectCodeFilter);
            this.gbAssignJobProject.Controls.Add(this.dgvAssignJobProject);
            this.gbAssignJobProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAssignJobProject.Location = new System.Drawing.Point(0, 0);
            this.gbAssignJobProject.Name = "gbAssignJobProject";
            this.gbAssignJobProject.Size = new System.Drawing.Size(159, 499);
            this.gbAssignJobProject.TabIndex = 0;
            this.gbAssignJobProject.TabStop = false;
            this.gbAssignJobProject.Text = "Project";
            // 
            // btnAssignJobProjectNext
            // 
            this.btnAssignJobProjectNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssignJobProjectNext.Location = new System.Drawing.Point(78, 470);
            this.btnAssignJobProjectNext.Name = "btnAssignJobProjectNext";
            this.btnAssignJobProjectNext.Size = new System.Drawing.Size(75, 23);
            this.btnAssignJobProjectNext.TabIndex = 4;
            this.btnAssignJobProjectNext.Text = "Next";
            this.btnAssignJobProjectNext.UseVisualStyleBackColor = true;
            this.btnAssignJobProjectNext.Click += new System.EventHandler(this.btnAssignJobProjectNext_Click);
            // 
            // btnAssignJobProjectFilter
            // 
            this.btnAssignJobProjectFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssignJobProjectFilter.Location = new System.Drawing.Point(80, 48);
            this.btnAssignJobProjectFilter.Name = "btnAssignJobProjectFilter";
            this.btnAssignJobProjectFilter.Size = new System.Drawing.Size(75, 23);
            this.btnAssignJobProjectFilter.TabIndex = 3;
            this.btnAssignJobProjectFilter.Text = "Filter";
            this.btnAssignJobProjectFilter.UseVisualStyleBackColor = true;
            this.btnAssignJobProjectFilter.Click += new System.EventHandler(this.btnAssignJobProjectFilter_Click);
            // 
            // lblAssignJobProCodejectFilter
            // 
            this.lblAssignJobProCodejectFilter.AutoSize = true;
            this.lblAssignJobProCodejectFilter.Location = new System.Drawing.Point(7, 24);
            this.lblAssignJobProCodejectFilter.Name = "lblAssignJobProCodejectFilter";
            this.lblAssignJobProCodejectFilter.Size = new System.Drawing.Size(34, 14);
            this.lblAssignJobProCodejectFilter.TabIndex = 2;
            this.lblAssignJobProCodejectFilter.Text = "Num";
            // 
            // tbxAssignJobProjectCodeFilter
            // 
            this.tbxAssignJobProjectCodeFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxAssignJobProjectCodeFilter.Location = new System.Drawing.Point(51, 21);
            this.tbxAssignJobProjectCodeFilter.Name = "tbxAssignJobProjectCodeFilter";
            this.tbxAssignJobProjectCodeFilter.Size = new System.Drawing.Size(102, 21);
            this.tbxAssignJobProjectCodeFilter.TabIndex = 1;
            // 
            // dgvAssignJobProject
            // 
            this.dgvAssignJobProject.AllowUserToAddRows = false;
            this.dgvAssignJobProject.AllowUserToDeleteRows = false;
            this.dgvAssignJobProject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAssignJobProject.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAssignJobProject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssignJobProject.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvAssignJobProjectSid,
            this.dgvAssignJobProjectCode,
            this.dgvAssignJobProjectName});
            this.dgvAssignJobProject.Location = new System.Drawing.Point(6, 75);
            this.dgvAssignJobProject.MultiSelect = false;
            this.dgvAssignJobProject.Name = "dgvAssignJobProject";
            this.dgvAssignJobProject.ReadOnly = true;
            this.dgvAssignJobProject.RowHeadersVisible = false;
            this.dgvAssignJobProject.RowTemplate.Height = 23;
            this.dgvAssignJobProject.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAssignJobProject.Size = new System.Drawing.Size(149, 389);
            this.dgvAssignJobProject.TabIndex = 0;
            // 
            // gbAssignJobCompany
            // 
            this.gbAssignJobCompany.Controls.Add(this.btnAssignJobCompanyPre);
            this.gbAssignJobCompany.Controls.Add(this.dgvAssignjobCompany);
            this.gbAssignJobCompany.Controls.Add(this.btnAssignJobCompanyFilter);
            this.gbAssignJobCompany.Controls.Add(this.btnAssignJobCompanyCityFilterAll);
            this.gbAssignJobCompany.Controls.Add(this.cbxAssignJobCompanyCityFilter);
            this.gbAssignJobCompany.Controls.Add(this.lblAssignJobLocationFilter);
            this.gbAssignJobCompany.Controls.Add(this.tbxAssignJobCompanyCodeFilter);
            this.gbAssignJobCompany.Controls.Add(this.lblAssignJobCompanyCodeFilter);
            this.gbAssignJobCompany.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAssignJobCompany.Location = new System.Drawing.Point(0, 0);
            this.gbAssignJobCompany.Name = "gbAssignJobCompany";
            this.gbAssignJobCompany.Size = new System.Drawing.Size(197, 499);
            this.gbAssignJobCompany.TabIndex = 1;
            this.gbAssignJobCompany.TabStop = false;
            this.gbAssignJobCompany.Text = "Company";
            // 
            // btnAssignJobCompanyPre
            // 
            this.btnAssignJobCompanyPre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssignJobCompanyPre.Location = new System.Drawing.Point(9, 470);
            this.btnAssignJobCompanyPre.Name = "btnAssignJobCompanyPre";
            this.btnAssignJobCompanyPre.Size = new System.Drawing.Size(75, 23);
            this.btnAssignJobCompanyPre.TabIndex = 10;
            this.btnAssignJobCompanyPre.Text = "Pre";
            this.btnAssignJobCompanyPre.UseVisualStyleBackColor = true;
            // 
            // dgvAssignjobCompany
            // 
            this.dgvAssignjobCompany.AllowUserToAddRows = false;
            this.dgvAssignjobCompany.AllowUserToDeleteRows = false;
            this.dgvAssignjobCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAssignjobCompany.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvAssignjobCompany.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAssignjobCompany.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvAssignJobCompanyOperation,
            this.dgvAssignJobCompanyCode,
            this.dgvAssignJobCompanyName});
            this.dgvAssignjobCompany.Location = new System.Drawing.Point(6, 104);
            this.dgvAssignjobCompany.MultiSelect = false;
            this.dgvAssignjobCompany.Name = "dgvAssignjobCompany";
            this.dgvAssignjobCompany.ReadOnly = true;
            this.dgvAssignjobCompany.RowHeadersVisible = false;
            this.dgvAssignjobCompany.RowTemplate.Height = 23;
            this.dgvAssignjobCompany.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAssignjobCompany.Size = new System.Drawing.Size(185, 360);
            this.dgvAssignjobCompany.TabIndex = 9;
            // 
            // dgvAssignJobCompanyOperation
            // 
            this.dgvAssignJobCompanyOperation.HeaderText = "OP";
            this.dgvAssignJobCompanyOperation.Name = "dgvAssignJobCompanyOperation";
            this.dgvAssignJobCompanyOperation.ReadOnly = true;
            this.dgvAssignJobCompanyOperation.Width = 31;
            // 
            // dgvAssignJobCompanyCode
            // 
            this.dgvAssignJobCompanyCode.FillWeight = 20F;
            this.dgvAssignJobCompanyCode.HeaderText = "Code";
            this.dgvAssignJobCompanyCode.Name = "dgvAssignJobCompanyCode";
            this.dgvAssignJobCompanyCode.ReadOnly = true;
            this.dgvAssignJobCompanyCode.Width = 63;
            // 
            // dgvAssignJobCompanyName
            // 
            this.dgvAssignJobCompanyName.HeaderText = "Name";
            this.dgvAssignJobCompanyName.Name = "dgvAssignJobCompanyName";
            this.dgvAssignJobCompanyName.ReadOnly = true;
            this.dgvAssignJobCompanyName.Width = 66;
            // 
            // btnAssignJobCompanyFilter
            // 
            this.btnAssignJobCompanyFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssignJobCompanyFilter.Location = new System.Drawing.Point(116, 75);
            this.btnAssignJobCompanyFilter.Name = "btnAssignJobCompanyFilter";
            this.btnAssignJobCompanyFilter.Size = new System.Drawing.Size(75, 23);
            this.btnAssignJobCompanyFilter.TabIndex = 8;
            this.btnAssignJobCompanyFilter.Text = "Filter";
            this.btnAssignJobCompanyFilter.UseVisualStyleBackColor = true;
            this.btnAssignJobCompanyFilter.Click += new System.EventHandler(this.btnAssignJobCompanyFilter_Click);
            // 
            // btnAssignJobCompanyCityFilterAll
            // 
            this.btnAssignJobCompanyCityFilterAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssignJobCompanyCityFilterAll.Location = new System.Drawing.Point(160, 47);
            this.btnAssignJobCompanyCityFilterAll.Name = "btnAssignJobCompanyCityFilterAll";
            this.btnAssignJobCompanyCityFilterAll.Size = new System.Drawing.Size(31, 23);
            this.btnAssignJobCompanyCityFilterAll.TabIndex = 7;
            this.btnAssignJobCompanyCityFilterAll.Text = "All";
            this.btnAssignJobCompanyCityFilterAll.UseVisualStyleBackColor = true;
            this.btnAssignJobCompanyCityFilterAll.Click += new System.EventHandler(this.btnAssignJobCompanyCityFilterAll_Click);
            // 
            // cbxAssignJobCompanyCityFilter
            // 
            this.cbxAssignJobCompanyCityFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbxAssignJobCompanyCityFilter.FormattingEnabled = true;
            this.cbxAssignJobCompanyCityFilter.Location = new System.Drawing.Point(50, 47);
            this.cbxAssignJobCompanyCityFilter.Name = "cbxAssignJobCompanyCityFilter";
            this.cbxAssignJobCompanyCityFilter.Size = new System.Drawing.Size(104, 22);
            this.cbxAssignJobCompanyCityFilter.TabIndex = 6;
            // 
            // lblAssignJobLocationFilter
            // 
            this.lblAssignJobLocationFilter.AutoSize = true;
            this.lblAssignJobLocationFilter.Location = new System.Drawing.Point(14, 50);
            this.lblAssignJobLocationFilter.Name = "lblAssignJobLocationFilter";
            this.lblAssignJobLocationFilter.Size = new System.Drawing.Size(30, 14);
            this.lblAssignJobLocationFilter.TabIndex = 5;
            this.lblAssignJobLocationFilter.Text = "City";
            // 
            // tbxAssignJobCompanyCodeFilter
            // 
            this.tbxAssignJobCompanyCodeFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxAssignJobCompanyCodeFilter.Location = new System.Drawing.Point(50, 20);
            this.tbxAssignJobCompanyCodeFilter.Name = "tbxAssignJobCompanyCodeFilter";
            this.tbxAssignJobCompanyCodeFilter.Size = new System.Drawing.Size(104, 21);
            this.tbxAssignJobCompanyCodeFilter.TabIndex = 4;
            // 
            // lblAssignJobCompanyCodeFilter
            // 
            this.lblAssignJobCompanyCodeFilter.AutoSize = true;
            this.lblAssignJobCompanyCodeFilter.Location = new System.Drawing.Point(6, 24);
            this.lblAssignJobCompanyCodeFilter.Name = "lblAssignJobCompanyCodeFilter";
            this.lblAssignJobCompanyCodeFilter.Size = new System.Drawing.Size(38, 14);
            this.lblAssignJobCompanyCodeFilter.TabIndex = 0;
            this.lblAssignJobCompanyCodeFilter.Text = "Code";
            // 
            // gbAssignJobLaptop
            // 
            this.gbAssignJobLaptop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAssignJobLaptop.Location = new System.Drawing.Point(0, 0);
            this.gbAssignJobLaptop.Name = "gbAssignJobLaptop";
            this.gbAssignJobLaptop.Size = new System.Drawing.Size(488, 499);
            this.gbAssignJobLaptop.TabIndex = 2;
            this.gbAssignJobLaptop.TabStop = false;
            this.gbAssignJobLaptop.Text = "Laptop";
            // 
            // pnAssignJobBottom
            // 
            this.pnAssignJobBottom.Controls.Add(this.dateTimePicker1);
            this.pnAssignJobBottom.Controls.Add(this.lblAssignJobDate);
            this.pnAssignJobBottom.Controls.Add(this.btnAssignJobAssign);
            this.pnAssignJobBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnAssignJobBottom.Location = new System.Drawing.Point(3, 516);
            this.pnAssignJobBottom.Name = "pnAssignJobBottom";
            this.pnAssignJobBottom.Size = new System.Drawing.Size(852, 10);
            this.pnAssignJobBottom.TabIndex = 0;
            this.pnAssignJobBottom.Visible = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(91, 8);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(116, 21);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // lblAssignJobDate
            // 
            this.lblAssignJobDate.AutoSize = true;
            this.lblAssignJobDate.Location = new System.Drawing.Point(7, 13);
            this.lblAssignJobDate.Name = "lblAssignJobDate";
            this.lblAssignJobDate.Size = new System.Drawing.Size(78, 14);
            this.lblAssignJobDate.TabIndex = 1;
            this.lblAssignJobDate.Text = "Assign Date";
            // 
            // btnAssignJobAssign
            // 
            this.btnAssignJobAssign.Location = new System.Drawing.Point(677, 9);
            this.btnAssignJobAssign.Name = "btnAssignJobAssign";
            this.btnAssignJobAssign.Size = new System.Drawing.Size(75, 23);
            this.btnAssignJobAssign.TabIndex = 0;
            this.btnAssignJobAssign.Text = "Assign";
            this.btnAssignJobAssign.UseVisualStyleBackColor = true;
            this.btnAssignJobAssign.Click += new System.EventHandler(this.btnAssignJobAssign_Click);
            // 
            // gbBuyLaotop
            // 
            this.gbBuyLaotop.Controls.Add(this.nbxBuyLaptopQuatity);
            this.gbBuyLaotop.Controls.Add(this.lblBuyLaptopQuatity);
            this.gbBuyLaotop.Controls.Add(this.dtBuyLaptopPurchaseDate);
            this.gbBuyLaotop.Controls.Add(this.lblBuyLaptopPurchaseDate);
            this.gbBuyLaotop.Controls.Add(this.btnBuyLaptopBuy);
            this.gbBuyLaotop.Controls.Add(this.gbBuyLaptopAssets);
            this.gbBuyLaotop.Controls.Add(this.tbxBuyLpatopRemark);
            this.gbBuyLaotop.Controls.Add(this.lblBuyLpatopRemark);
            this.gbBuyLaotop.Controls.Add(this.tbxBuyLaptopPrice);
            this.gbBuyLaotop.Controls.Add(this.lblBuyLaptopPrice);
            this.gbBuyLaotop.Controls.Add(this.cbxBuyLaptopPurchaseCompany);
            this.gbBuyLaotop.Controls.Add(this.lblBuyLaptopPurchaseCompany);
            this.gbBuyLaotop.Controls.Add(this.cbxBuyLaptopModel);
            this.gbBuyLaotop.Controls.Add(this.lblBuyLaptopLaptopModel);
            this.gbBuyLaotop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbBuyLaotop.Location = new System.Drawing.Point(0, 0);
            this.gbBuyLaotop.Name = "gbBuyLaotop";
            this.gbBuyLaotop.Size = new System.Drawing.Size(858, 529);
            this.gbBuyLaotop.TabIndex = 0;
            this.gbBuyLaotop.TabStop = false;
            this.gbBuyLaotop.Text = "Buy Laptop";
            this.gbBuyLaotop.Visible = false;
            // 
            // nbxBuyLaptopQuatity
            // 
            this.nbxBuyLaptopQuatity.Location = new System.Drawing.Point(65, 280);
            this.nbxBuyLaptopQuatity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nbxBuyLaptopQuatity.Name = "nbxBuyLaptopQuatity";
            this.nbxBuyLaptopQuatity.Size = new System.Drawing.Size(158, 21);
            this.nbxBuyLaptopQuatity.TabIndex = 13;
            this.nbxBuyLaptopQuatity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblBuyLaptopQuatity
            // 
            this.lblBuyLaptopQuatity.AutoSize = true;
            this.lblBuyLaptopQuatity.Location = new System.Drawing.Point(10, 282);
            this.lblBuyLaptopQuatity.Name = "lblBuyLaptopQuatity";
            this.lblBuyLaptopQuatity.Size = new System.Drawing.Size(49, 14);
            this.lblBuyLaptopQuatity.TabIndex = 14;
            this.lblBuyLaptopQuatity.Text = "Quatity";
            // 
            // dtBuyLaptopPurchaseDate
            // 
            this.dtBuyLaptopPurchaseDate.Location = new System.Drawing.Point(350, 48);
            this.dtBuyLaptopPurchaseDate.Name = "dtBuyLaptopPurchaseDate";
            this.dtBuyLaptopPurchaseDate.Size = new System.Drawing.Size(158, 21);
            this.dtBuyLaptopPurchaseDate.TabIndex = 12;
            // 
            // lblBuyLaptopPurchaseDate
            // 
            this.lblBuyLaptopPurchaseDate.AutoSize = true;
            this.lblBuyLaptopPurchaseDate.Location = new System.Drawing.Point(223, 51);
            this.lblBuyLaptopPurchaseDate.Name = "lblBuyLaptopPurchaseDate";
            this.lblBuyLaptopPurchaseDate.Size = new System.Drawing.Size(92, 14);
            this.lblBuyLaptopPurchaseDate.TabIndex = 11;
            this.lblBuyLaptopPurchaseDate.Text = "Purchase Date";
            // 
            // btnBuyLaptopBuy
            // 
            this.btnBuyLaptopBuy.Location = new System.Drawing.Point(65, 307);
            this.btnBuyLaptopBuy.Name = "btnBuyLaptopBuy";
            this.btnBuyLaptopBuy.Size = new System.Drawing.Size(75, 23);
            this.btnBuyLaptopBuy.TabIndex = 10;
            this.btnBuyLaptopBuy.Text = "Buy";
            this.btnBuyLaptopBuy.UseVisualStyleBackColor = true;
            this.btnBuyLaptopBuy.Click += new System.EventHandler(this.btnBuyLaptopBuy_Click);
            // 
            // gbBuyLaptopAssets
            // 
            this.gbBuyLaptopAssets.Controls.Add(this.nbxBuyLaptopAssetsFrom);
            this.gbBuyLaptopAssets.Controls.Add(this.tbxBuyLaptopAssetsFix);
            this.gbBuyLaptopAssets.Controls.Add(this.lblBuyLaptopAssetsFix);
            this.gbBuyLaptopAssets.Controls.Add(this.lblBuyLaptopAssetsFrom);
            this.gbBuyLaptopAssets.Location = new System.Drawing.Point(65, 75);
            this.gbBuyLaptopAssets.Name = "gbBuyLaptopAssets";
            this.gbBuyLaptopAssets.Size = new System.Drawing.Size(246, 78);
            this.gbBuyLaptopAssets.TabIndex = 8;
            this.gbBuyLaptopAssets.TabStop = false;
            this.gbBuyLaptopAssets.Text = "Assets";
            // 
            // nbxBuyLaptopAssetsFrom
            // 
            this.nbxBuyLaptopAssetsFrom.Location = new System.Drawing.Point(65, 49);
            this.nbxBuyLaptopAssetsFrom.Name = "nbxBuyLaptopAssetsFrom";
            this.nbxBuyLaptopAssetsFrom.Size = new System.Drawing.Size(120, 21);
            this.nbxBuyLaptopAssetsFrom.TabIndex = 3;
            // 
            // tbxBuyLaptopAssetsFix
            // 
            this.tbxBuyLaptopAssetsFix.Location = new System.Drawing.Point(65, 22);
            this.tbxBuyLaptopAssetsFix.Name = "tbxBuyLaptopAssetsFix";
            this.tbxBuyLaptopAssetsFix.Size = new System.Drawing.Size(120, 21);
            this.tbxBuyLaptopAssetsFix.TabIndex = 2;
            // 
            // lblBuyLaptopAssetsFix
            // 
            this.lblBuyLaptopAssetsFix.AutoSize = true;
            this.lblBuyLaptopAssetsFix.Location = new System.Drawing.Point(18, 25);
            this.lblBuyLaptopAssetsFix.Name = "lblBuyLaptopAssetsFix";
            this.lblBuyLaptopAssetsFix.Size = new System.Drawing.Size(27, 14);
            this.lblBuyLaptopAssetsFix.TabIndex = 1;
            this.lblBuyLaptopAssetsFix.Text = "Fix:";
            // 
            // lblBuyLaptopAssetsFrom
            // 
            this.lblBuyLaptopAssetsFrom.AutoSize = true;
            this.lblBuyLaptopAssetsFrom.Location = new System.Drawing.Point(18, 51);
            this.lblBuyLaptopAssetsFrom.Name = "lblBuyLaptopAssetsFrom";
            this.lblBuyLaptopAssetsFrom.Size = new System.Drawing.Size(41, 14);
            this.lblBuyLaptopAssetsFrom.TabIndex = 0;
            this.lblBuyLaptopAssetsFrom.Text = "From:";
            // 
            // tbxBuyLpatopRemark
            // 
            this.tbxBuyLpatopRemark.Location = new System.Drawing.Point(65, 172);
            this.tbxBuyLpatopRemark.Multiline = true;
            this.tbxBuyLpatopRemark.Name = "tbxBuyLpatopRemark";
            this.tbxBuyLpatopRemark.Size = new System.Drawing.Size(559, 89);
            this.tbxBuyLpatopRemark.TabIndex = 7;
            // 
            // lblBuyLpatopRemark
            // 
            this.lblBuyLpatopRemark.AutoSize = true;
            this.lblBuyLpatopRemark.Location = new System.Drawing.Point(6, 175);
            this.lblBuyLpatopRemark.Name = "lblBuyLpatopRemark";
            this.lblBuyLpatopRemark.Size = new System.Drawing.Size(53, 14);
            this.lblBuyLpatopRemark.TabIndex = 6;
            this.lblBuyLpatopRemark.Text = "Remark";
            // 
            // tbxBuyLaptopPrice
            // 
            this.tbxBuyLaptopPrice.Location = new System.Drawing.Point(65, 48);
            this.tbxBuyLaptopPrice.Name = "tbxBuyLaptopPrice";
            this.tbxBuyLaptopPrice.Size = new System.Drawing.Size(121, 21);
            this.tbxBuyLaptopPrice.TabIndex = 5;
            this.tbxBuyLaptopPrice.Text = "5000";
            // 
            // lblBuyLaptopPrice
            // 
            this.lblBuyLaptopPrice.AutoSize = true;
            this.lblBuyLaptopPrice.Location = new System.Drawing.Point(17, 51);
            this.lblBuyLaptopPrice.Name = "lblBuyLaptopPrice";
            this.lblBuyLaptopPrice.Size = new System.Drawing.Size(37, 14);
            this.lblBuyLaptopPrice.TabIndex = 4;
            this.lblBuyLaptopPrice.Text = "Price";
            // 
            // cbxBuyLaptopPurchaseCompany
            // 
            this.cbxBuyLaptopPurchaseCompany.FormattingEnabled = true;
            this.cbxBuyLaptopPurchaseCompany.Location = new System.Drawing.Point(350, 20);
            this.cbxBuyLaptopPurchaseCompany.Name = "cbxBuyLaptopPurchaseCompany";
            this.cbxBuyLaptopPurchaseCompany.Size = new System.Drawing.Size(158, 22);
            this.cbxBuyLaptopPurchaseCompany.TabIndex = 3;
            // 
            // lblBuyLaptopPurchaseCompany
            // 
            this.lblBuyLaptopPurchaseCompany.AutoSize = true;
            this.lblBuyLaptopPurchaseCompany.Location = new System.Drawing.Point(223, 23);
            this.lblBuyLaptopPurchaseCompany.Name = "lblBuyLaptopPurchaseCompany";
            this.lblBuyLaptopPurchaseCompany.Size = new System.Drawing.Size(121, 14);
            this.lblBuyLaptopPurchaseCompany.TabIndex = 2;
            this.lblBuyLaptopPurchaseCompany.Text = "Purchase Company";
            // 
            // cbxBuyLaptopModel
            // 
            this.cbxBuyLaptopModel.FormattingEnabled = true;
            this.cbxBuyLaptopModel.Location = new System.Drawing.Point(65, 20);
            this.cbxBuyLaptopModel.Name = "cbxBuyLaptopModel";
            this.cbxBuyLaptopModel.Size = new System.Drawing.Size(121, 22);
            this.cbxBuyLaptopModel.TabIndex = 1;
            // 
            // lblBuyLaptopLaptopModel
            // 
            this.lblBuyLaptopLaptopModel.AutoSize = true;
            this.lblBuyLaptopLaptopModel.Location = new System.Drawing.Point(17, 23);
            this.lblBuyLaptopLaptopModel.Name = "lblBuyLaptopLaptopModel";
            this.lblBuyLaptopLaptopModel.Size = new System.Drawing.Size(42, 14);
            this.lblBuyLaptopLaptopModel.TabIndex = 0;
            this.lblBuyLaptopLaptopModel.Text = "Model";
            // 
            // gbOperationStartPage
            // 
            this.gbOperationStartPage.Controls.Add(this.pictureBox1);
            this.gbOperationStartPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbOperationStartPage.Location = new System.Drawing.Point(0, 0);
            this.gbOperationStartPage.Name = "gbOperationStartPage";
            this.gbOperationStartPage.Size = new System.Drawing.Size(858, 529);
            this.gbOperationStartPage.TabIndex = 8;
            this.gbOperationStartPage.TabStop = false;
            this.gbOperationStartPage.Text = "Start Page";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(165, 159);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(502, 208);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // PhotoPicker
            // 
            this.PhotoPicker.Filter = "Photo|*.jpg;*.bmp;*.png;*.gif|All File|*.*";
            this.PhotoPicker.FileOk += new System.ComponentModel.CancelEventHandler(this.PhotoPicker_FileOk);
            // 
            // dgvAssignJobProjectSid
            // 
            this.dgvAssignJobProjectSid.HeaderText = "Sid";
            this.dgvAssignJobProjectSid.Name = "dgvAssignJobProjectSid";
            this.dgvAssignJobProjectSid.ReadOnly = true;
            this.dgvAssignJobProjectSid.Visible = false;
            this.dgvAssignJobProjectSid.Width = 32;
            // 
            // dgvAssignJobProjectCode
            // 
            this.dgvAssignJobProjectCode.FillWeight = 20F;
            this.dgvAssignJobProjectCode.HeaderText = "Code";
            this.dgvAssignJobProjectCode.Name = "dgvAssignJobProjectCode";
            this.dgvAssignJobProjectCode.ReadOnly = true;
            this.dgvAssignJobProjectCode.Width = 63;
            // 
            // dgvAssignJobProjectName
            // 
            this.dgvAssignJobProjectName.HeaderText = "Name";
            this.dgvAssignJobProjectName.Name = "dgvAssignJobProjectName";
            this.dgvAssignJobProjectName.ReadOnly = true;
            this.dgvAssignJobProjectName.Width = 66;
            // 
            // frMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 562);
            this.Controls.Add(this.tcMainTabControl);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frMainForm";
            this.Text = "LaptopBookingSystem";
            this.tcMainTabControl.ResumeLayout(false);
            this.tpStartPage.ResumeLayout(false);
            this.tpStartPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStartPgLogo)).EndInit();
            this.tpInput.ResumeLayout(false);
            this.splitContainerInput.Panel1.ResumeLayout(false);
            this.splitContainerInput.Panel2.ResumeLayout(false);
            this.splitContainerInput.ResumeLayout(false);
            this.gbInputFunction.ResumeLayout(false);
            this.gbLaptopInfo.ResumeLayout(false);
            this.gbLaptopInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaptopInfo)).EndInit();
            this.gbProjectInfo.ResumeLayout(false);
            this.gbProjectInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjectInfo)).EndInit();
            this.gbInputStartPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbInputStartPageLogo)).EndInit();
            this.gbProjectSuperviserInfo.ResumeLayout(false);
            this.gbProjectSuperviserInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProjectSuperviserInfo)).EndInit();
            this.gbParameterInfo.ResumeLayout(false);
            this.gbProjecyTypeInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameterProjectTypeInfo)).EndInit();
            this.gbCityInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParameterCityInfo)).EndInit();
            this.gbLaptopType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaptopTypeInfo)).EndInit();
            this.gbCompanyInfo.ResumeLayout(false);
            this.gbCompanyInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompanyInfo)).EndInit();
            this.tpOperation.ResumeLayout(false);
            this.splitContainerOperation.Panel1.ResumeLayout(false);
            this.splitContainerOperation.Panel2.ResumeLayout(false);
            this.splitContainerOperation.ResumeLayout(false);
            this.gbOperationFunction.ResumeLayout(false);
            this.gbAssignJob.ResumeLayout(false);
            this.splitContainerAssignJob1.Panel1.ResumeLayout(false);
            this.splitContainerAssignJob1.Panel2.ResumeLayout(false);
            this.splitContainerAssignJob1.ResumeLayout(false);
            this.splitContainerAssignJob2.Panel1.ResumeLayout(false);
            this.splitContainerAssignJob2.Panel2.ResumeLayout(false);
            this.splitContainerAssignJob2.ResumeLayout(false);
            this.gbAssignJobProject.ResumeLayout(false);
            this.gbAssignJobProject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignJobProject)).EndInit();
            this.gbAssignJobCompany.ResumeLayout(false);
            this.gbAssignJobCompany.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAssignjobCompany)).EndInit();
            this.pnAssignJobBottom.ResumeLayout(false);
            this.pnAssignJobBottom.PerformLayout();
            this.gbBuyLaotop.ResumeLayout(false);
            this.gbBuyLaotop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbxBuyLaptopQuatity)).EndInit();
            this.gbBuyLaptopAssets.ResumeLayout(false);
            this.gbBuyLaptopAssets.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nbxBuyLaptopAssetsFrom)).EndInit();
            this.gbOperationStartPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.TabControl tcMainTabControl;
        private System.Windows.Forms.TabPage tpStartPage;
        private System.Windows.Forms.TabPage tpInput;
        private System.Windows.Forms.PictureBox pbStartPgLogo;
        private System.Windows.Forms.Label lblStartpgTitle;
        private System.Windows.Forms.SplitContainer splitContainerInput;
        private System.Windows.Forms.GroupBox gbInputFunction;
        private System.Windows.Forms.Button btnProjectMantance;
        private System.Windows.Forms.GroupBox gbProjectInfo;
        private System.Windows.Forms.DataGridView dgvProjectInfo;
        private System.Windows.Forms.Label lblProjectNameFilter;
        private System.Windows.Forms.TextBox tbxProjectInfoNumberFilter;
        private System.Windows.Forms.Label lblProjectNumberFilter;
        private System.Windows.Forms.TextBox tbxProjectInfoNameFilter;
        private System.Windows.Forms.Button btnFilterProjectInfo;
        private System.Windows.Forms.Button btnAddProjectInfo;
        private System.Windows.Forms.Button btnDeleteProjectInfo;
        private System.Windows.Forms.GroupBox gbInputStartPage;
        private System.Windows.Forms.PictureBox pbInputStartPageLogo;
        private System.Windows.Forms.Button btnParameterInfo;
        private System.Windows.Forms.GroupBox gbParameterInfo;
        private System.Windows.Forms.GroupBox gbProjecyTypeInfo;
        private System.Windows.Forms.GroupBox gbCityInfo;
        private System.Windows.Forms.DataGridView dgvParameterCityInfo;
        private System.Windows.Forms.Button btnParameterCityInfoDelete;
        private System.Windows.Forms.Button btnParameterCityInfoAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvParameterCityInfoSid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvParameterCityInfoOperation;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvParameterCityInfoCity;
        private System.Windows.Forms.Button btnProjectTypeDelete;
        private System.Windows.Forms.DataGridView dgvParameterProjectTypeInfo;
        private System.Windows.Forms.Button btnProjectTypeInfoAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvParameterProjectTypeInfoSid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvParameterProjectTypeInfoOperation;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvParameterProjectTypeInfoProjectType;
        private System.Windows.Forms.Button btnProjectSuperviseInfo;
        private System.Windows.Forms.GroupBox gbProjectSuperviserInfo;
        private System.Windows.Forms.DataGridView dgvProjectSuperviserInfo;
        private System.Windows.Forms.Button btnProjectSuperviserInfoSearch;
        private System.Windows.Forms.TextBox tbxProjectSuperviserInfoName;
        private System.Windows.Forms.Label lblProjectSuperviseInfoName;
        private System.Windows.Forms.Button btnProjectSuperviserInfoAdd;
        private System.Windows.Forms.Button btnProjectSuperviserInfoDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvProjectSuperviserInfoSid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvProjectSuperviserInfoOperation;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvProjectSuperviserInfoName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvProjectSuperviserInfoPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvProjectSuperviserInfoMobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvProjectSuperviserInfoMailAddress;
        private System.Windows.Forms.Button btnCompanyInfo;
        private System.Windows.Forms.GroupBox gbCompanyInfo;
        private System.Windows.Forms.DataGridView dgvCompanyInfo;
        private System.Windows.Forms.ComboBox cbxCompanyInfoCityFilter;
        private System.Windows.Forms.Button btnCompanyInfoCityFilterShowAll;
        private System.Windows.Forms.Label lblCompanyInfoCityFilter;
        private System.Windows.Forms.TextBox tbxCompanyInfoCodeFilter;
        private System.Windows.Forms.Label lblCompanyInfoCodeFilter;
        private System.Windows.Forms.TextBox tbxCompanyInfoNameFilter;
        private System.Windows.Forms.Label lblCompanyInfoNameFilter;
        private System.Windows.Forms.Button btnCompanyInfoFilter;
        private System.Windows.Forms.Button btnCompanyInfoDelete;
        private System.Windows.Forms.Button btnCompanyInfoAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCompanyInfoSid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvCompanyInfoOperation;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCompanyInfoName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCompanyInfoCode;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvCompanyInfoParameterCitySid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvCompanyInfoisVender;
        private System.Windows.Forms.Button btnLaptopTypeInfo;
        private System.Windows.Forms.GroupBox gbLaptopType;
        private System.Windows.Forms.DataGridView dgvLaptopTypeInfo;
        private System.Windows.Forms.OpenFileDialog PhotoPicker;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLaptopTypeInfoSid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvLaptopTypeInfoOperation;
        private System.Windows.Forms.DataGridViewImageColumn dgvLaptopTypeInfoImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLaptopTypeInfoBrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLaptopTypeInfoModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLaptopTypeInfoBatteryCapacity;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvLaptopTypeInfoisTouchScreen;
        private System.Windows.Forms.Button btnLaptopTypeInfoFilter;
        private System.Windows.Forms.Button btnLaptopTypeInfoDelete;
        private System.Windows.Forms.Button btnLaptopTypeInfoAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvProjectInfoSid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvProjectInfoOperation;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvProjectInfoNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvProjectInfoName;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvProjectInfoProjectSuperviserSid;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvProjectInfoProjectTypeSid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvProjectInfoLaunchDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvProjectInfoCloseDate;
        private System.Windows.Forms.Button btnLaptopInfo;
        private System.Windows.Forms.GroupBox gbLaptopInfo;
        private System.Windows.Forms.DataGridView dgvLaptopInfo;
        private System.Windows.Forms.Button btnLaptopInfoModelFilterShowAll;
        private System.Windows.Forms.ComboBox cbxLaptopInfoModelFilter;
        private System.Windows.Forms.Label lblLaptopInfoModelFilter;
        private System.Windows.Forms.TextBox tbxLaptopInfoAssetFilter;
        private System.Windows.Forms.Label lblLaptopInfoAssetsFilter;
        private System.Windows.Forms.Button btnLaptopInfoFilter;
        private System.Windows.Forms.Button btnLaptopInfoDelete;
        private System.Windows.Forms.Button btnLaptopInfoAdd;
        private System.Windows.Forms.TabPage tpOperation;
        private System.Windows.Forms.SplitContainer splitContainerOperation;
        private System.Windows.Forms.GroupBox gbOperationFunction;
        private System.Windows.Forms.Button btnBuyLaptop;
        private System.Windows.Forms.GroupBox gbBuyLaotop;
        private System.Windows.Forms.ComboBox cbxBuyLaptopModel;
        private System.Windows.Forms.Label lblBuyLaptopLaptopModel;
        private System.Windows.Forms.ComboBox cbxBuyLaptopPurchaseCompany;
        private System.Windows.Forms.Label lblBuyLaptopPurchaseCompany;
        private System.Windows.Forms.Label lblBuyLpatopRemark;
        private System.Windows.Forms.TextBox tbxBuyLaptopPrice;
        private System.Windows.Forms.Label lblBuyLaptopPrice;
        private System.Windows.Forms.TextBox tbxBuyLpatopRemark;
        private System.Windows.Forms.GroupBox gbOperationStartPage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox gbBuyLaptopAssets;
        private System.Windows.Forms.TextBox tbxBuyLaptopAssetsFix;
        private System.Windows.Forms.Label lblBuyLaptopAssetsFix;
        private System.Windows.Forms.Label lblBuyLaptopAssetsFrom;
        private System.Windows.Forms.NumericUpDown nbxBuyLaptopAssetsFrom;
        private System.Windows.Forms.Button btnBuyLaptopBuy;
        private System.Windows.Forms.NumericUpDown nbxBuyLaptopQuatity;
        private System.Windows.Forms.Label lblBuyLaptopQuatity;
        private System.Windows.Forms.DateTimePicker dtBuyLaptopPurchaseDate;
        private System.Windows.Forms.Label lblBuyLaptopPurchaseDate;
        private System.Windows.Forms.Button btnAssignJob;
        private System.Windows.Forms.GroupBox gbAssignJob;
        private System.Windows.Forms.SplitContainer splitContainerAssignJob1;
        private System.Windows.Forms.SplitContainer splitContainerAssignJob2;
        private System.Windows.Forms.GroupBox gbAssignJobProject;
        private System.Windows.Forms.GroupBox gbAssignJobCompany;
        private System.Windows.Forms.GroupBox gbAssignJobLaptop;
        private System.Windows.Forms.Panel pnAssignJobBottom;
        private System.Windows.Forms.TextBox tbxAssignJobProjectCodeFilter;
        private System.Windows.Forms.DataGridView dgvAssignJobProject;
        private System.Windows.Forms.Button btnAssignJobAssign;
        private System.Windows.Forms.Label lblAssignJobProCodejectFilter;
        private System.Windows.Forms.Button btnAssignJobProjectFilter;
        private System.Windows.Forms.Label lblAssignJobCompanyCodeFilter;
        private System.Windows.Forms.Button btnAssignJobProjectNext;
        private System.Windows.Forms.TextBox tbxAssignJobCompanyCodeFilter;
        private System.Windows.Forms.Button btnAssignJobCompanyCityFilterAll;
        private System.Windows.Forms.ComboBox cbxAssignJobCompanyCityFilter;
        private System.Windows.Forms.Label lblAssignJobLocationFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLaptopInfoSid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvLaptopInfoOperation;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLaptopInfoLaptopTypeSid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLaptopInfoNilsenAssetsNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLaptopInfoBrand;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvLaptopInfoModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLaptopInfoLaptopSerial;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvLaptopInfoisComplete;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLaptopInfoRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLaptopInfoPrice;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvLaptopInfoPurchaseCompanySid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLaptopInfoPurchaseDate;
        private System.Windows.Forms.Button btnAssignJobCompanyPre;
        private System.Windows.Forms.DataGridView dgvAssignjobCompany;
        private System.Windows.Forms.Button btnAssignJobCompanyFilter;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblAssignJobDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvAssignJobCompanyOperation;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvAssignJobCompanyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvAssignJobCompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvAssignJobProjectSid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvAssignJobProjectCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvAssignJobProjectName;
    }
}

