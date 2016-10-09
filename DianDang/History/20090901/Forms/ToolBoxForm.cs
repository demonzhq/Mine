using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using UtilityLibrary.WinControls;

namespace DianDang
{
    public partial class ToolBoxForm : DockContent
    {
        private  OutlookBar outlookBar1 = null;

        public ToolBoxForm()
        {
            InitializeComponent();
            InitializeOutlookbar();
        }

        private void InitializeOutlookbar()
        {
            outlookBar1 = new OutlookBar();

            #region 业务管理
            OutlookBarBand businessBand = new OutlookBarBand("业务管理");
            businessBand.SmallImageList = this.imageList;
            businessBand.LargeImageList = this.imageList;
            businessBand.Items.Add(new OutlookBarItem("建当处理", 0));
            businessBand.Items.Add(new OutlookBarItem("赎当处理", 1));
            businessBand.Items.Add(new OutlookBarItem("续当处理", 2));
            businessBand.Items.Add(new OutlookBarItem("绝当处理", 3));
            businessBand.Background = SystemColors.AppWorkspace;
            businessBand.TextColor = Color.White;
            outlookBar1.Bands.Add(businessBand);
            
            #endregion

            #region 统计查询
            OutlookBarBand searchBand = new OutlookBarBand("统计查询");
            searchBand.SmallImageList = this.imageList;
            searchBand.LargeImageList = this.imageList;
            searchBand.Items.Add(new OutlookBarItem("当票检索查询", 0));
            searchBand.Background = SystemColors.AppWorkspace;
            searchBand.TextColor = Color.White;
            outlookBar1.Bands.Add(searchBand); 
            #endregion

            #region 客户信息
            OutlookBarBand customerBand = new OutlookBarBand("客户信息");
            customerBand.SmallImageList = this.imageList;
            customerBand.LargeImageList = this.imageList;
            customerBand.Items.Add(new OutlookBarItem("添加客户", 0));
            customerBand.Background = SystemColors.AppWorkspace;
            customerBand.TextColor = Color.White;
            outlookBar1.Bands.Add(customerBand);
            #endregion

            outlookBar1.Dock = DockStyle.Fill;
            outlookBar1.SetCurrentBand(0);
            outlookBar1.ItemClicked += new OutlookBarItemClickedHandler(OnOutlookBarItemClicked);

            outlookBar1.FlatArrowButtons = true;
            this.panelToolBox.Controls.AddRange(new Control[] { outlookBar1 });
        }

        private void OnOutlookBarItemClicked(OutlookBarBand band, OutlookBarItem item)
        {
            switch (item.Text)
            {
                #region 业务管理

                case "建当处理":
                    //CreatePawnForm frmCreatePawn = new CreatePawnForm();
                    //frmCreatePawn.Show(this.Parent.Controls["dockPanel1"]);
                    break;
                case "赎当处理":
                    
                    break;
                case "续当处理":
                    //RenewPawnForm frmRenewPawn = new RenewPawnForm();
                    //frmRenewPawn.Show(this.Parent.Controls["dockPanel1"]);
                    break;
                case "绝当处理":
                    
                    break;
                #endregion

                #region 统计查询
                case "当票检索查询":
                  
                    break;
                #endregion

                default:
                    break;
            }
        }

    }
}