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

            #region ҵ�����
            OutlookBarBand businessBand = new OutlookBarBand("ҵ�����");
            businessBand.SmallImageList = this.imageList;
            businessBand.LargeImageList = this.imageList;
            businessBand.Items.Add(new OutlookBarItem("��������", 0));
            businessBand.Items.Add(new OutlookBarItem("�굱����", 1));
            businessBand.Items.Add(new OutlookBarItem("��������", 2));
            businessBand.Items.Add(new OutlookBarItem("��������", 3));
            businessBand.Background = SystemColors.AppWorkspace;
            businessBand.TextColor = Color.White;
            outlookBar1.Bands.Add(businessBand);
            
            #endregion

            #region ͳ�Ʋ�ѯ
            OutlookBarBand searchBand = new OutlookBarBand("ͳ�Ʋ�ѯ");
            searchBand.SmallImageList = this.imageList;
            searchBand.LargeImageList = this.imageList;
            searchBand.Items.Add(new OutlookBarItem("��Ʊ������ѯ", 0));
            searchBand.Background = SystemColors.AppWorkspace;
            searchBand.TextColor = Color.White;
            outlookBar1.Bands.Add(searchBand); 
            #endregion

            #region �ͻ���Ϣ
            OutlookBarBand customerBand = new OutlookBarBand("�ͻ���Ϣ");
            customerBand.SmallImageList = this.imageList;
            customerBand.LargeImageList = this.imageList;
            customerBand.Items.Add(new OutlookBarItem("��ӿͻ�", 0));
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
                #region ҵ�����

                case "��������":
                    //CreatePawnForm frmCreatePawn = new CreatePawnForm();
                    //frmCreatePawn.Show(this.Parent.Controls["dockPanel1"]);
                    break;
                case "�굱����":
                    
                    break;
                case "��������":
                    //RenewPawnForm frmRenewPawn = new RenewPawnForm();
                    //frmRenewPawn.Show(this.Parent.Controls["dockPanel1"]);
                    break;
                case "��������":
                    
                    break;
                #endregion

                #region ͳ�Ʋ�ѯ
                case "��Ʊ������ѯ":
                  
                    break;
                #endregion

                default:
                    break;
            }
        }

    }
}