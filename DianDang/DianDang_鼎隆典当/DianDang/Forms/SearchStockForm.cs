using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using WeifenLuo.WinFormsUI.Docking;
using SubSonic;

namespace DianDang
{
    public partial class SearchStockForm : DockContent
    {
        Comm_Func func = new Comm_Func();

        public SearchStockForm()
        {
            InitializeComponent();
        }

        Color GetColor(string strNow, string strSource)
        {
            float _fNow = float.Parse(strNow);
            float _fSource = float.Parse(strSource);
            if (_fNow > _fSource)
                return func.PubColorDown;
            else if (_fNow == _fSource)
                return func.PubColorNormal;
            else
                return func.PubColorUp;
        }

        // ��ȡ����һ������λС����ֵ
        string GetWan(string strSource)
        {
            if (strSource == "") return "";
            float _fResult = float.Parse(strSource);
            _fResult = _fResult / 10000;
            return _fResult.ToString(".##");
        }

        //�����Ʊ����
        void GetInfo(string strCode)
        {
            string[] _ArrInfo = func.getStockInfoByCode(strCode); //��ȡ��Ϣ����
            Color _Color;

            pic.Load(func.getStockImageByteByCode(strCode));

            if (_ArrInfo[3] != "")
            {
                _Color = GetColor(_ArrInfo[4], _ArrInfo[3]);

                gbInfo.Text = _ArrInfo[1] + "(" + _ArrInfo[0] + ") ";
                labNewPrice.Text = _ArrInfo[3];
                labUpDown.Text = _ArrInfo[6] + "(" + _ArrInfo[9] + ")";
                labNewPrice.ForeColor = labUpDown.ForeColor = _Color;

                labPreDay.Text = _ArrInfo[4];
                labTodayOpen.Text = _ArrInfo[5];
                //��ͼ�
                labMinPrice.Text = _ArrInfo[7];
                _Color = GetColor(_ArrInfo[4], _ArrInfo[7]);
                labMinPrice.ForeColor = _Color;
                //��߼�
                labMaxPrice.Text = _ArrInfo[8];
                _Color = GetColor(_ArrInfo[4], _ArrInfo[8]);
                labMaxPrice.ForeColor = _Color;
                //�ɽ�����
                labBecome.Text = GetWan(_ArrInfo[10]) + "����";
                labBecomePrice.Text = GetWan(_ArrInfo[11]) + "��Ԫ";
            }
        }

        private void SearchStockForm_Load(object sender, EventArgs e)
        {
            func.initalService();
        }

        private void ThreadFuntion()
        {
            GetInfo(tbxStockCode.Text);
            this.progressBar.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {           
            tbxStockCode.Text = tbxStockCode.Text.Trim();
            if (tbxStockCode.Text.Length == 6||tbxStockCode.Text.Length==8)
            {
                this.progressBar.Visible = true;
                Control.CheckForIllegalCrossThreadCalls = false;
                Thread thread = new Thread(new ThreadStart(ThreadFuntion));
                thread.IsBackground = true;
                thread.Start();
            }
            else
            {
                MessageBox.Show("��Ʊ�����������!","��ʾ��Ϣ");
            }
        }
    }
}