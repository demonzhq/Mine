using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace DianDang
{
    public class ClsDataGridViewPage
    {
        private int _RowsPerPage;   //每页记录数
        private int _TotalPage;     //总页数
        private int _curPage = 0;     //当前页数
        private DataGridView _DataGridView; //要分页的DataGridView
        private DataView _dv;       //与需要分页显示的的DataView
        public int RowsPerPage { get { return _RowsPerPage; } set { _RowsPerPage = value; } }      //获取与设置每页记录数
        public int TotalPage { get { return _TotalPage; } }                             //获取总页数
        public int curPage { get { return _curPage; } set { _curPage = value; } }                  //获取与设置当前页数
        public DataGridView GetDataGridView { set { _DataGridView = value; } }    //设置需要分页的GetDataGridView
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
        public void Paging()                //开始分页啦
        {   //首先判断DataView中的记录数是否足够形成多页，
            //如果不能，那么就只有一页，且DataGridView需要显示的记录等同于“最后一页”的记录
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
        //到第一页
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
        {//’防止不合法的当前页号
            _curPage -= 1;
            if (_curPage < 0)
            {
                _curPage = 0;
                return;
            }
            GoNoPage(_curPage);
        }
        //到最后一页
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
            {//防止不合法的页号
                return;
            }
            //防止页号溢出
            if (_curPage >= _TotalPage)
            {   //页号超出上限
                return;
            }
            if (_curPage == _TotalPage - 1)
            {
                //如果页号是最后一页，就显示最后一页
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
