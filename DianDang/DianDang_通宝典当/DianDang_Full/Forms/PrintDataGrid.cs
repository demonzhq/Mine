using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MSExcel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;

namespace DianDang
{
    public partial class PrintDataGrid : Form
    {
        string Title = "";
        DataGridView DataSource = new DataGridView();
        List <int> ColumnList = new List<int>();
        public PrintDataGrid(string iTitle, DataGridView iDataSource, List<int> iColumnList)
        {
            this.Title = iTitle;
            this.DataSource = iDataSource;
            this.ColumnList = iColumnList;
            InitializeComponent();
            LoadTemplate();
            this.Dispose();

        }

        private void LoadTemplate()
        {
            MSExcel.Application excelApp; //Excel应用程序变量
            MSExcel.Workbook excelDoc; //Excel文档变量
            excelApp = new MSExcel.ApplicationClass();  //初始化
            //由于使用的是COM库，因此有许多变量需要用Nothing代替
            Object Nothing = Missing.Value;
            excelDoc = excelApp.Workbooks._Open(Application.StartupPath + @"\Pram\DataTemplate.dd", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);

            //使用第一个工作表作为插入数据的工作表
            MSExcel.Worksheet ws = (MSExcel.Worksheet)excelDoc.Sheets[1];

            //声明一个MSExcel.Range 类型的变量r
            MSExcel.Range r;

            //打印标题
            r = ws.get_Range("A" + 1, "A" + 1); r.Value2 = Title;

            //打印栏目
            for (int i = 0; i < ColumnList.Count; i++)
            {
                r = ws.get_Range(GetExcelColumn(i) + 2, GetExcelColumn(i) + 2); r.Value2 = DataSource.Columns[ColumnList[i]].HeaderText.ToString();
            }

            

            //打印内容
            for (int i = 0; i < DataSource.Rows.Count; i++)
            {
                for (int j = 0; j < ColumnList.Count; j++)
                {
                    int Rows = 3 + i;

                    r = ws.get_Range(GetExcelColumn(j) + Rows, GetExcelColumn(j) + Rows); r.Value2 = DataSource.Rows[i].Cells[ColumnList[j]].FormattedValue.ToString();


                    
                }
            }
            



            object format = MSExcel.XlFileFormat.xlWorkbookNormal;

            excelDoc.PrintOut(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing);


            //将excelDoc文档对象的内容保存为dd文档
            //excelDoc.Save();
            if (File.Exists(Application.StartupPath + @"\Pram\dump.dd"))
            {
                try
                {
                    File.Delete(Application.StartupPath + @"\Pram\dump.dd");
                }
                catch (FieldAccessException e)
                {
                    MessageBox.Show("记录文件正在被使用，请退出Excel\n" + e.ToString());
                }
            }
            excelDoc.SaveAs(Application.StartupPath + @"\Pram\dump.dd", format, Nothing, Nothing, Nothing, Nothing, MSExcel.XlSaveAsAccessMode.xlExclusive, Nothing, Nothing, Nothing, Nothing, Nothing);




            //关闭excelDoc文档对象 
            excelDoc.Close(Nothing, Nothing, Nothing);

            //关闭excelApp组件对象 
            excelApp.Quit();
  

        }

        private string GetExcelColumn(int iColumn)
        {
            int Start = 65; // 'A'的ASCII
            string Result = "";

            if (iColumn < 25)
            {
                Result = Convert.ToChar(Start + iColumn).ToString();
            }

            return Result;
        }
    }
}
