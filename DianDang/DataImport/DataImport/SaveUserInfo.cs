using System;
using MSExcel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace DataImport
{
    public partial class Main
    {
        private void SaveUserInfo()
        {
            double TotalAmount = 0;
            DateTime StartDate = new DateTime();
            DateTime EndDate = new DateTime();
            #region 保存信息
            File.Copy(Application.StartupPath + @"\User.xls", Application.StartupPath + @"\UU.xls");
            File.Delete(Application.StartupPath + @"\User.xls");
            MSExcel.Application excelApp; //Excel应用程序变量
            MSExcel.Workbook excelDoc; //Excel文档变量
            excelApp = new MSExcel.ApplicationClass();  //初始化
            //由于使用的是COM库，因此有许多变量需要用Nothing代替
            Object Nothing = Missing.Value;
            excelDoc = excelApp.Workbooks._Open(Application.StartupPath + @"\UU.xls", Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
            MSExcel.Worksheet ws = (MSExcel.Worksheet)excelDoc.Sheets[1];
            MSExcel.Range r;

            int ExcelLine = 1;
            r = ws.get_Range(("A" + 1), ("A" + 1));
            while (r.Text.ToString() != "")
            {
                ExcelLine++;
                r = ws.get_Range(("A" + ExcelLine), ("A" + ExcelLine));
            }

            SqlResult = SqlConnection.Query("select CustomerName, PhoneNumber, Address, ContactPerson, CertTypeID, CertNumber from DDCustomerInfo");
            SqlData = SqlResult.GetResult();
            while (SqlData.Read())
            {
                TotalAmount = 0;
                r = ws.get_Range(("A" + ExcelLine), ("A" + ExcelLine)); r.Value2 = SqlData[0].ToString();
                r = ws.get_Range(("B" + ExcelLine), ("B" + ExcelLine)); r.Value2 = SqlData[1].ToString();
                r = ws.get_Range(("C" + ExcelLine), ("C" + ExcelLine)); r.Value2 = SqlData[2].ToString();
                r = ws.get_Range(("D" + ExcelLine), ("D" + ExcelLine)); r.Value2 = SqlData[3].ToString();
                r = ws.get_Range(("E" + ExcelLine), ("E" + ExcelLine)); r.Value2 = GetCertTypeNameByTypeID(Convert.ToInt32(SqlData[4].ToString()));
                r = ws.get_Range(("F" + ExcelLine), ("F" + ExcelLine)); r.Value2 = SqlData[5].ToString();

                DBFConnection.SetFile(this.DBFPath + @"CUST_RCD.DBF");
                DBFConnection.Connect();
                DBFResult = DBFConnection.Query("select D_JE, DATE, END_DATE from CUST_RCD.DBF where NAME='" + SqlData[0].ToString() + "'");
                DBFData = DBFResult.GetResult();
                while (DBFData.Read())
                {
                    TotalAmount = TotalAmount + Convert.ToDouble(DBFData[0].ToString());
                    StartDate = DateTime.Parse(DBFData[1].ToString());
                    EndDate = DateTime.Parse(DBFData[2].ToString());
                }
                DBFData.Close();
                DBFConnection.DisConnect();
                r = ws.get_Range(("G" + ExcelLine), ("G" + ExcelLine)); r.Value2 = TotalAmount;
                r = ws.get_Range(("H" + ExcelLine), ("H" + ExcelLine)); r.Value2 = StartDate.ToShortDateString();
                r = ws.get_Range(("I" + ExcelLine), ("I" + ExcelLine)); r.Value2 = EndDate.ToShortDateString();
                ExcelLine++;

            }
            SqlData.Close();

            object format = MSExcel.XlFileFormat.xlWorkbookNormal;

            excelDoc.SaveAs(Application.StartupPath + @"\User.xls", format, Nothing, Nothing, Nothing, Nothing, MSExcel.XlSaveAsAccessMode.xlExclusive, Nothing, Nothing, Nothing, Nothing, Nothing);

            excelDoc.Close(Nothing, Nothing, Nothing);

            excelApp.Quit();

            File.Delete(Application.StartupPath + @"\UU.xls");

            #endregion
        }
    }
}
