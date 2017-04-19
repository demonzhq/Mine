//*******************************************************************************
//Copyright (C) 2005 Cognex Corporation
//
//Subject to Cognex Corporation's terms and conditions and license agreement,
//you are authorized to use and modify this sample source code in any way you find
//useful, provided the Software and/or the modified Software is used solely in
//conjunction with a Cognex Machine Vision System.  Furthermore you acknowledge
//and agree that Cognex has no warranty, obligations or liability for your use
//of the Software.
//*******************************************************************************
//NOTE: YOUR AND YOUR COMPANY'S USE OF THE IN-SIGHT SAMPLE SOURCE CODE CONTAINED
//IN THIS FILE IS SUBJECT TO THE TERMS AND CONDITIONS OF SALE AS FURTHER
//MODIFIED BY THE LIMITED USE LICENSE AGREEMENT GOVERNING THE USE AND
// DISTRIBUTION OF IN-SIGHT SAMPLE SOURCE CODE.
//
//PLEASE READ THE TERMS OF USE BELOW:
//LIMITED USE LICENSE AGREEMENT (LULA)
//
//YOUR AND YOUR COMPANY'S ("YOUR") USE OF THE SOURCE CODE IS
//EXPRESSLY CONDITIONED UPON YOUR ACCEPTANCE OF THE FOLLOWING TERMS:
//1.  IN-SIGHT SAMPLE SOURCE CODE MAY BE USED EXCLUSIVELY WITH COGNEX HARDWARE
//    AND SOFTWARE PRODUCTS.
//2.  IN-SIGHT SAMPLE SOURCE CODE MAY NOT BE DISTRIBUTED OR SUB-LICENSED WITHOUT
//    A SEPARATE WRITTEN AGREEMENT SIGNED BY BOTH YOUR COMPANY AND COGNEX CORPORATION.
//3.  ANY VIOLATION OF THIS LULA, THE TERMS AND CONDITIONS OF SALE, AND/OR
//    THE ACCOMPANYING SOFTWARE LICENSE WILL ENTITLE COGNEX CORPORATION TO REVOKE
//    YOUR SOFTWARE LICENSE.
//*******************************************************************************


using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace DisplayControl
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.Label lblGridOpacityValue;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.CheckBox chkLive;
		internal System.Windows.Forms.CheckBox chkOnline;
		internal System.Windows.Forms.CheckBox chkImage;
		internal System.Windows.Forms.CheckBox chkGraphics;
		internal System.Windows.Forms.CheckBox chkGrid;
		internal System.Windows.Forms.TextBox txtPassword;
		internal System.Windows.Forms.TextBox txtUserName;
		internal System.Windows.Forms.TextBox txtAddress;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.RadioButton optFill;
		internal System.Windows.Forms.RadioButton optFit;
		internal System.Windows.Forms.RadioButton optNone;
		internal System.Windows.Forms.GroupBox GroupBox2;
		internal System.Windows.Forms.StatusBar StatusBar1;
		internal System.Windows.Forms.StatusBarPanel lblState;
		internal System.Windows.Forms.StatusBarPanel lblStatus;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		//Cognex ISDK True/False type that will be binded to the chkOnline control.
		private Cognex.InSight.Controls.Display.CvsInSightDisplay CvsInSightDisplay2;
		internal System.Windows.Forms.GroupBox grpImageZoom;
		internal System.Windows.Forms.GroupBox grpControls;
        internal System.Windows.Forms.Button btnConnect;
        internal Label lblATestMode;
		private System.Windows.Forms.HScrollBar hScrollOpacity;

		public frmMain()
		{
            //
            //Initialize the Cognex SDK before using the In-Sight Display control
            //
            Cognex.InSight.CvsInSightSoftwareDevelopmentKit.Initialize();

            //
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			// We want a range of 0 to 100 giving us 101 total values.
			// Adjust the maximum by the large increment - 1, since we are
			// starting at 0, not 1.
			this.hScrollOpacity.Maximum += this.hScrollOpacity.LargeChange - 1;

      // Load the same theme used by In-Sight Explorer. This should be done before
      // the app is shown, and does not rely on a connection. It only needs to be
      // done once.
      CvsInSightDisplay2.LoadStandardTheme();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.grpControls = new System.Windows.Forms.GroupBox();
            this.lblATestMode = new System.Windows.Forms.Label();
            this.lblGridOpacityValue = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.hScrollOpacity = new System.Windows.Forms.HScrollBar();
            this.chkLive = new System.Windows.Forms.CheckBox();
            this.chkOnline = new System.Windows.Forms.CheckBox();
            this.chkImage = new System.Windows.Forms.CheckBox();
            this.chkGraphics = new System.Windows.Forms.CheckBox();
            this.chkGrid = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.grpImageZoom = new System.Windows.Forms.GroupBox();
            this.optFill = new System.Windows.Forms.RadioButton();
            this.optFit = new System.Windows.Forms.RadioButton();
            this.optNone = new System.Windows.Forms.RadioButton();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.CvsInSightDisplay2 = new Cognex.InSight.Controls.Display.CvsInSightDisplay();
            this.StatusBar1 = new System.Windows.Forms.StatusBar();
            this.lblState = new System.Windows.Forms.StatusBarPanel();
            this.lblStatus = new System.Windows.Forms.StatusBarPanel();
            this.grpControls.SuspendLayout();
            this.grpImageZoom.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).BeginInit();
            this.SuspendLayout();
            //
            // grpControls
            //
            this.grpControls.Controls.Add(this.lblATestMode);
            this.grpControls.Controls.Add(this.lblGridOpacityValue);
            this.grpControls.Controls.Add(this.Label4);
            this.grpControls.Controls.Add(this.hScrollOpacity);
            this.grpControls.Controls.Add(this.chkLive);
            this.grpControls.Controls.Add(this.chkOnline);
            this.grpControls.Controls.Add(this.chkImage);
            this.grpControls.Controls.Add(this.chkGraphics);
            this.grpControls.Controls.Add(this.chkGrid);
            this.grpControls.Controls.Add(this.txtPassword);
            this.grpControls.Controls.Add(this.txtUserName);
            this.grpControls.Controls.Add(this.txtAddress);
            this.grpControls.Controls.Add(this.btnConnect);
            this.grpControls.Controls.Add(this.Label3);
            this.grpControls.Controls.Add(this.Label2);
            this.grpControls.Controls.Add(this.Label1);
            this.grpControls.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpControls.Location = new System.Drawing.Point(8, 8);
            this.grpControls.Name = "grpControls";
            this.grpControls.Size = new System.Drawing.Size(760, 104);
            this.grpControls.TabIndex = 18;
            this.grpControls.TabStop = false;
            this.grpControls.Text = "Controls";
            //
            // lblATestMode
            //
            this.lblATestMode.Location = new System.Drawing.Point(253, 24);
            this.lblATestMode.Name = "lblATestMode";
            this.lblATestMode.Size = new System.Drawing.Size(75, 16);
            this.lblATestMode.TabIndex = 31;
            this.lblATestMode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblATestMode.Click += new System.EventHandler(this.lblATestMode_Click);
            //
            // lblGridOpacityValue
            //
            this.lblGridOpacityValue.Location = new System.Drawing.Point(680, 24);
            this.lblGridOpacityValue.Name = "lblGridOpacityValue";
            this.lblGridOpacityValue.Size = new System.Drawing.Size(40, 16);
            this.lblGridOpacityValue.TabIndex = 30;
            this.lblGridOpacityValue.Text = "75%";
            this.lblGridOpacityValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // Label4
            //
            this.Label4.Location = new System.Drawing.Point(602, 24);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(75, 16);
            this.Label4.TabIndex = 29;
            this.Label4.Text = "Grid Opacity:";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // hScrollOpacity
            //
            this.hScrollOpacity.Location = new System.Drawing.Point(584, 48);
            this.hScrollOpacity.Name = "hScrollOpacity";
            this.hScrollOpacity.Size = new System.Drawing.Size(152, 16);
            this.hScrollOpacity.TabIndex = 28;
            this.hScrollOpacity.Value = 75;
            this.hScrollOpacity.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollOpacity_ValueChanged);
            //
            // chkLive
            //
            this.chkLive.Location = new System.Drawing.Point(472, 48);
            this.chkLive.Name = "chkLive";
            this.chkLive.Size = new System.Drawing.Size(80, 16);
            this.chkLive.TabIndex = 27;
            this.chkLive.Text = "Live";
            this.chkLive.CheckedChanged += new System.EventHandler(this.chkLive_CheckedChanged);
            //
            // chkOnline
            //
            this.chkOnline.Location = new System.Drawing.Point(472, 24);
            this.chkOnline.Name = "chkOnline";
            this.chkOnline.Size = new System.Drawing.Size(112, 16);
            this.chkOnline.TabIndex = 26;
            this.chkOnline.Text = "Online";
            this.chkOnline.CheckedChanged += new System.EventHandler(this.chkOnline_CheckedChanged);
            //
            // chkImage
            //
            this.chkImage.Location = new System.Drawing.Point(352, 72);
            this.chkImage.Name = "chkImage";
            this.chkImage.Size = new System.Drawing.Size(112, 16);
            this.chkImage.TabIndex = 25;
            this.chkImage.Text = "Show Image";
            this.chkImage.CheckedChanged += new System.EventHandler(this.chkImage_CheckedChanged);
            //
            // chkGraphics
            //
            this.chkGraphics.Location = new System.Drawing.Point(352, 48);
            this.chkGraphics.Name = "chkGraphics";
            this.chkGraphics.Size = new System.Drawing.Size(112, 16);
            this.chkGraphics.TabIndex = 24;
            this.chkGraphics.Text = "Show Graphics";
            this.chkGraphics.CheckedChanged += new System.EventHandler(this.chkGraphics_CheckedChanged);
            //
            // chkGrid
            //
            this.chkGrid.Location = new System.Drawing.Point(352, 24);
            this.chkGrid.Name = "chkGrid";
            this.chkGrid.Size = new System.Drawing.Size(112, 16);
            this.chkGrid.TabIndex = 23;
            this.chkGrid.Text = "Show Grid";
            this.chkGrid.CheckedChanged += new System.EventHandler(this.chkGrid_CheckedChanged);
            //
            // txtPassword
            //
            this.txtPassword.Location = new System.Drawing.Point(96, 72);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(144, 21);
            this.txtPassword.TabIndex = 2;
            //
            // txtUserName
            //
            this.txtUserName.Location = new System.Drawing.Point(96, 48);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(144, 21);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.Text = "admin";
            //
            // txtAddress
            //
            this.txtAddress.Location = new System.Drawing.Point(96, 24);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(144, 21);
            this.txtAddress.TabIndex = 0;
            this.txtAddress.Text = "127.0.0.1";
            //
            // btnConnect
            //
            this.btnConnect.Location = new System.Drawing.Point(248, 48);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(80, 24);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "&Connect";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            //
            // Label3
            //
            this.Label3.Location = new System.Drawing.Point(16, 72);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(75, 16);
            this.Label3.TabIndex = 18;
            this.Label3.Text = "Password:";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // Label2
            //
            this.Label2.Location = new System.Drawing.Point(16, 48);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(75, 16);
            this.Label2.TabIndex = 17;
            this.Label2.Text = "User Name:";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // Label1
            //
            this.Label1.Location = new System.Drawing.Point(16, 24);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(75, 16);
            this.Label1.TabIndex = 16;
            this.Label1.Text = "Address:";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // grpImageZoom
            //
            this.grpImageZoom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpImageZoom.Controls.Add(this.optFill);
            this.grpImageZoom.Controls.Add(this.optFit);
            this.grpImageZoom.Controls.Add(this.optNone);
            this.grpImageZoom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpImageZoom.Location = new System.Drawing.Point(776, 8);
            this.grpImageZoom.Name = "grpImageZoom";
            this.grpImageZoom.Size = new System.Drawing.Size(96, 104);
            this.grpImageZoom.TabIndex = 19;
            this.grpImageZoom.TabStop = false;
            this.grpImageZoom.Text = "Image Zoom";
            //
            // optFill
            //
            this.optFill.Location = new System.Drawing.Point(16, 72);
            this.optFill.Name = "optFill";
            this.optFill.Size = new System.Drawing.Size(40, 16);
            this.optFill.TabIndex = 2;
            this.optFill.Text = "Fill";
            this.optFill.CheckedChanged += new System.EventHandler(this.optFill_CheckedChanged);
            //
            // optFit
            //
            this.optFit.Location = new System.Drawing.Point(16, 48);
            this.optFit.Name = "optFit";
            this.optFit.Size = new System.Drawing.Size(40, 16);
            this.optFit.TabIndex = 1;
            this.optFit.Text = "Fit";
            this.optFit.CheckedChanged += new System.EventHandler(this.optFit_CheckedChanged);
            //
            // optNone
            //
            this.optNone.Location = new System.Drawing.Point(16, 24);
            this.optNone.Name = "optNone";
            this.optNone.Size = new System.Drawing.Size(48, 16);
            this.optNone.TabIndex = 0;
            this.optNone.Text = "None";
            this.optNone.CheckedChanged += new System.EventHandler(this.optNone_CheckedChanged);
            //
            // GroupBox2
            //
            this.GroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox2.Controls.Add(this.CvsInSightDisplay2);
            this.GroupBox2.Location = new System.Drawing.Point(8, 112);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(864, 536);
            this.GroupBox2.TabIndex = 20;
            this.GroupBox2.TabStop = false;
            //
            // CvsInSightDisplay2
            //
            this.CvsInSightDisplay2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CvsInSightDisplay2.DefaultTextScaleMode = Cognex.InSight.Controls.Display.CvsInSightDisplay.TextScaleModeType.Proportional;
            this.CvsInSightDisplay2.Location = new System.Drawing.Point(8, 18);
            this.CvsInSightDisplay2.Name = "CvsInSightDisplay2";
            this.CvsInSightDisplay2.Size = new System.Drawing.Size(848, 511);
            this.CvsInSightDisplay2.TabIndex = 0;
            this.CvsInSightDisplay2.StatusInformationChanged += new System.EventHandler(this.CvsInSightDisplay2_StatusInformationChanged);
            this.CvsInSightDisplay2.ConnectedChanged += new System.EventHandler(this.CvsInSightDisplay2_ConnectedChanged);
            this.CvsInSightDisplay2.StateChanged += new Cognex.InSight.Controls.Display.CvsDisplayStateChangedEventHandler(this.CvsInSightDisplay2_StateChanged);
            this.CvsInSightDisplay2.ConnectCompleted += new Cognex.InSight.CvsConnectCompletedEventHandler(this.CvsInSightDisplay2_ConnectCompleted);
            //
            // StatusBar1
            //
            this.StatusBar1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusBar1.Location = new System.Drawing.Point(0, 654);
            this.StatusBar1.Name = "StatusBar1";
            this.StatusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.lblState,
            this.lblStatus});
            this.StatusBar1.ShowPanels = true;
            this.StatusBar1.Size = new System.Drawing.Size(880, 16);
            this.StatusBar1.TabIndex = 21;
            //
            // lblState
            //
            this.lblState.Name = "lblState";
            this.lblState.Width = 200;
            //
            // lblStatus
            //
            this.lblStatus.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Width = 663;
            //
            // frmMain
            //
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(880, 670);
            this.Controls.Add(this.StatusBar1);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.grpImageZoom);
            this.Controls.Add(this.grpControls);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmMain";
            this.Text = "Display Control Sample";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.grpControls.ResumeLayout(false);
            this.grpControls.PerformLayout();
            this.grpImageZoom.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).EndInit();
            this.ResumeLayout(false);

    }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.Run(new frmMain());
		}

		#region General Functions

		//Sets all checkboxes to be unchecked
		private void ClearCheckboxes()
		{
			chkOnline.Checked = false;
			chkGraphics.Checked = false;
			chkGrid.Checked = false;
			chkImage.Checked = false;
			chkLive.Checked = false;
		}

		//Updates the text of the status bar based on the changed state of the display control
		private void UpdateStateMsg()
		{
			switch(CvsInSightDisplay2.State)
			{
				case Cognex.InSight.Controls.Display.CvsDisplayState.Connecting:
					StatusBar1.Panels[0].Text = "Connecting...";
					break;
				case Cognex.InSight.Controls.Display.CvsDisplayState.Dialog:
					StatusBar1.Panels[0].Text = "Dialog";
					break;
				case Cognex.InSight.Controls.Display.CvsDisplayState.DialogEditingReferenceRanges:
					StatusBar1.Panels[0].Text = "Dialog Reference";
					break;
				case Cognex.InSight.Controls.Display.CvsDisplayState.EditingCellExpression:
					StatusBar1.Panels[0].Text = "Editing Expression";
					break;
				case Cognex.InSight.Controls.Display.CvsDisplayState.EditingCellValue:
					StatusBar1.Panels[0].Text = "Editing Value";
					break;
				case Cognex.InSight.Controls.Display.CvsDisplayState.EditingGraphics:
					StatusBar1.Panels[0].Text = "Editing Graphics";
					break;
				case Cognex.InSight.Controls.Display.CvsDisplayState.EditingReferenceRanges:
					StatusBar1.Panels[0].Text = "Editing Reference";
					break;
				case Cognex.InSight.Controls.Display.CvsDisplayState.Normal:
					StatusBar1.Panels[0].Text = "Normal";
					break;
				case Cognex.InSight.Controls.Display.CvsDisplayState.Waiting:
					StatusBar1.Panels[0].Text = "Waiting...";
					break;
				case Cognex.InSight.Controls.Display.CvsDisplayState.Wizard:
					StatusBar1.Panels[0].Text = "Wizard";
					break;
				default:
					StatusBar1.Panels[0].Text = "Unknown";
					break;
			}
		}

		#endregion

		#region CvsInSightDisplay2 Events

		//The connected state changed within the display control.  Event raised.
		private void CvsInSightDisplay2_ConnectedChanged(object sender, System.EventArgs e)
		{
      if (CvsInSightDisplay2.Connected)
      {
        btnConnect.Text = "Dis&connect";

      }
      else
        btnConnect.Text = "&Connect";
		}

		//The state changed within the display control.  Event raised.
		private void CvsInSightDisplay2_StateChanged(object sender, System.EventArgs e)
		{
			UpdateStateMsg();
		}

		//The display control is now connected.  Event raised.
		private void CvsInSightDisplay2_ConnectCompleted(object sender, Cognex.InSight.CvsConnectCompletedEventArgs e)
		{
			chkImage.Checked = CvsInSightDisplay2.ShowImage;

			if (CvsInSightDisplay2.ImageZoomMode == Cognex.InSight.Controls.Display.CvsDisplayZoom.None)
				optNone.Checked = true;
			else if (CvsInSightDisplay2.ImageZoomMode == Cognex.InSight.Controls.Display.CvsDisplayZoom.Fit)
				optFit.Checked = true;
			else if (CvsInSightDisplay2.ImageZoomMode == Cognex.InSight.Controls.Display.CvsDisplayZoom.Fill)
				optFill.Checked = true;
      btnConnect.Enabled = true;
		}

		//The status changed within the display control.  Event raised.
		private void CvsInSightDisplay2_StatusInformationChanged(object sender, System.EventArgs e)
		{
			StatusBar1.Panels[1].Text = CvsInSightDisplay2.StatusInformation;
		}
		#endregion

		#region Buttons

		//Connect button is clicked.
		//The display control will connect to the IP/Sensor name found in
		//  txtAddress, using the username/password supplied from txtUserName/txtPassword accordingly.
		private void btnConnect_Click(object sender, System.EventArgs e)
		{
			if (!(CvsInSightDisplay2.Connected))
			{
				CvsInSightDisplay2.Connect(txtAddress.Text, txtUserName.Text, txtPassword.Text, false);
                btnConnect.Enabled = false;

			}
			else
			{
				CvsInSightDisplay2.Disconnect();
			}
			Refresh();
		}


		#endregion

		#region Radio Image Zoom Button Events
		private void optFill_CheckedChanged(object sender, System.EventArgs e)
		{
			if (optFill.Checked)
			{
				CvsInSightDisplay2.ImageZoomMode = Cognex.InSight.Controls.Display.CvsDisplayZoom.Fill;
                TestZoomMode();  //Interal Test
			}
		}

		private void optFit_CheckedChanged(object sender, System.EventArgs e)
		{
			if (optFit.Checked)
			{
				CvsInSightDisplay2.ImageZoomMode = Cognex.InSight.Controls.Display.CvsDisplayZoom.Fit;
                TestZoomMode();  //Interal Test
			}
		}

		private void optNone_CheckedChanged(object sender, System.EventArgs e)
		{
			if (optNone.Checked)
			{
				CvsInSightDisplay2.ImageZoomMode = Cognex.InSight.Controls.Display.CvsDisplayZoom.None;
                TestZoomMode();  //Interal Test
			}
		}
		#endregion

		#region Form
		//Main initializations done here...
		private void frmMain_Load(object sender, System.EventArgs e)
		{
			hScrollOpacity.Value = System.Convert.ToInt32(CvsInSightDisplay2.GridOpacity * 100.0);

			//Bind the display's editing actions to controls
			CvsInSightDisplay2.Edit.SoftOnline.Bind(chkOnline); // online mode
			CvsInSightDisplay2.Edit.LiveAcquire.Bind(chkLive);  // live mode
      CvsInSightDisplay2.Edit.ShowGraphics.Bind(chkGraphics);
      CvsInSightDisplay2.Edit.ShowGrid.Bind(chkGrid);

		}
		#endregion

		#region Opacity ScrollBar Handler
		//The opacity scrollbar is changed
		private void hScrollOpacity_ValueChanged(object sender, System.Windows.Forms.ScrollEventArgs e)
		{
			CvsInSightDisplay2.GridOpacity = (double)e.NewValue / 100;
			lblGridOpacityValue.Text = System.Convert.ToString(CvsInSightDisplay2.GridOpacity*100) + '%';
		}
		#endregion

		#region Controls GroupBox Checkbox Handlers

        /*
		//The "Show Graphics" checkbox is clicked
		//Toggles whether or not the graphics are shown in the grid or over the image
		private void chkGraphics_CheckedChanged(object sender, System.EventArgs e)
		{
			CvsInSightDisplay2.ShowGraphics = chkGraphics.Checked;
		}
        */

        /*
		//The "Show Grid" checkbox is clicked
		//Toggles whether or not the grid is shown over the image
		private void chkGrid_CheckedChanged(object sender, System.EventArgs e)
		{
			CvsInSightDisplay2.ShowGrid = chkGrid.Checked;
		}
        */

		#endregion

        //internal test code
        #region AutomatedTestHelper

        private bool ATEST_MODE = false;

        private void lblATestMode_Click(object sender, EventArgs e)
        {
            if (!ATEST_MODE)
            {
                ATEST_MODE = true;
                lblATestMode.BackColor = Color.Green;
            }
            else
            {
                Application.Exit();
            }
        }

        private void UpdateTestStatus(string message)
        {
            StatusBar1.Panels[0].Text = message;
        }

        private void chkGrid_CheckedChanged(object sender, EventArgs e)
        {
            if(ATEST_MODE)
                UpdateTestStatus("Show Grid = " + CvsInSightDisplay2.ShowGrid);
        }

        private void chkGraphics_CheckedChanged(object sender, EventArgs e)
        {
            if(ATEST_MODE)
                UpdateTestStatus("Show Graphics = " + CvsInSightDisplay2.ShowGraphics);
        }

        private void chkOnline_CheckedChanged(object sender, EventArgs e)
        {
            if(ATEST_MODE)
                UpdateTestStatus("Online = " + CvsInSightDisplay2.SoftOnline);
        }
        //The "Show Image" checkbox is clicked
        //Toggles whether or not the background image is shown behind the grid
        private void chkImage_CheckedChanged(object sender, System.EventArgs e)
        {
            CvsInSightDisplay2.ShowImage = chkImage.Checked;
            if(ATEST_MODE)
                UpdateTestStatus("Show Image = " + CvsInSightDisplay2.ShowImage);
        }

        private void TestZoomMode()
        {
            if (ATEST_MODE)
                UpdateTestStatus("Zoom Mode = " + CvsInSightDisplay2.ImageZoomMode);
        }

        private void chkLive_CheckedChanged(object sender, EventArgs e)
        {
            if (ATEST_MODE)
                UpdateTestStatus("Live Mode = " + !CvsInSightDisplay2.Edit.LiveAcquire.Activated);
        }

        #endregion





    }
}
