using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace DianDang
{
    public class ClsDataGridViewPage
    {
        private int _RowsPerPage;   //ÿҳ��¼��
        private int _TotalPage;     //��ҳ��
        private int _curPage = 0;     //��ǰҳ��
        private DataGridView _DataGridView; //Ҫ��ҳ��DataGridView
        private DataView _dv;       //����Ҫ��ҳ��ʾ�ĵ�DataView
        public int RowsPerPage { get { return _RowsPerPage; } set { _RowsPerPage = value; } }      //��ȡ������ÿҳ��¼��
        public int TotalPage { get { return _TotalPage; } }                             //��ȡ��ҳ��
        public int curPage { get { return _curPage; } set { _curPage = value; } }                  //��ȡ�����õ�ǰҳ��
        public DataGridView GetDataGridView { set { _DataGridView = value; } }    //������Ҫ��ҳ��GetDataGridView
        public DataView SetDataView { set { _dv = value; } }
        
        public ClsDataGridViewPage()
        {

        }
        public ClsDataGridViewPage(DataGridView datagridview, DataView dv, int RowsPerPage)
        {
            _DataGridView = datagridview;
            _dv = dv;
            _RowsPerPage = RowsPerPage;
        }
        public void Paging()                //��ʼ��ҳ��
        {   //�����ж�DataView�еļ�¼���Ƿ��㹻�γɶ�ҳ��
            //������ܣ���ô��ֻ��һҳ����DataGridView��Ҫ��ʾ�ļ�¼��ͬ�ڡ����һҳ���ļ�¼
            if (_dv.Count < 1)
            {
                _TotalPage = 0;
                return;
            }
            if (_dv.Count <= _RowsPerPage)
            {
                _TotalPage = 1;
                GoLastPage();
                return;
            }
            if (_dv.Count % _RowsPerPage == 0)
            {
                _TotalPage = (int)(_dv.Count / _RowsPerPage);
            }
            else
            {
                _TotalPage = (int)(_dv.Count / _RowsPerPage) + 1;
            }
            GoFirstPage();
        }
        //����һҳ
        public void GoFirstPage()
        {
            if (_TotalPage == 1)
            {
                GoLastPage();
                return;
            }
            _curPage = 0;
            GoNoPage(_curPage);
        }
        public void GoNextPage()
        {
            _curPage += 1;
            if (_curPage > _TotalPage - 1)
            {
                _curPage = _TotalPage - 1;
                return;
            }
            if (_curPage == _TotalPage - 1)
            {
                GoLastPage();
                return;
            }
            GoNoPage(_curPage);
        }
        public void GoPrevPage()
        {//����ֹ���Ϸ��ĵ�ǰҳ��
            _curPage -= 1;
            if (_curPage < 0)
            {
                _curPage = 0;
                return;
            }
            GoNoPage(_curPage);
        }
        //�����һҳ
        public void GoLastPage()
        {
            _curPage = _TotalPage - 1;
            int i;
            DataTable dt;
            dt = _dv.ToTable().Clone();
            for (i = (_TotalPage - 1) * _RowsPerPage; i <= _dv.Count - 1; i++)
            {
                DataRow dr = dt.NewRow();
                dr.ItemArray = _dv.ToTable().Rows[i].ItemArray;
                dt.Rows.Add(dr);
            }
            _DataGridView.DataSource = dt;
        }
        public void GoNoPage(int PageNo)
        {
            _curPage = PageNo;
            if (_curPage < 0)
            {//��ֹ���Ϸ���ҳ��
                return;
            }
            //��ֹҳ�����
            if (_curPage >= _TotalPage)
            {   //ҳ�ų�������
                return;
            }
            if (_curPage == _TotalPage - 1)
            {
                //���ҳ�������һҳ������ʾ���һҳ
                GoLastPage();
                return;
            }
            DataTable dt;
            dt = _dv.ToTable().Clone();
            int i;
            for (i = PageNo * _RowsPerPage; i <= (PageNo + 1) * _RowsPerPage - 1; i++)
            {
                DataRow dr = dt.NewRow();
                dr.ItemArray = _dv.ToTable().Rows[i].ItemArray;
                dt.Rows.Add(dr);
            }
            _DataGridView.DataSource = dt;
        }
    }
}
