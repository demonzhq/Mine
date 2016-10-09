using System;
using MSExcel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Reflection;
using System.IO;


namespace DataImport
{
    public partial class Main
    {
        private void DDCustomerInfo()
        {
            int SqlExecResult = 0;
            string SqlExecString = "";

            #region 从CUST_RCD当票信息中插入客户
            DBFConnection.SetFile(this.DBFPath + @"CUST_RCD.DBF");
            DBFConnection.Connect();
            DBFResult = DBFConnection.Query("select NAME, MARK, ADDRESS, S_NO, SFZ_ID, DATE from CUST_RCD.DBF order by DATE");
            DBFData = DBFResult.GetResult();
            while (DBFData.Read())
            {
                if (isExistCustomerInSQL(CutSpace(DBFData[0].ToString()), CutSpace(DBFData[4].ToString())) == false)
                {
                    SqlExecString = "insert into DDCustomerInfo (CustomerName, PhoneNumber, Address, CertTypeID, CertNumber, CreatDate) "
                                    + "VALUES ( "
                                    + "'" + CutSpace(DBFData[0].ToString()) + "', "
                                    + "'" + CutSpace(DBFData[1].ToString()) + "', "
                                    + "'" + CutSpace(DBFData[2].ToString()) + "', "
                                    + GetSqlCertIDbyDBFCertID(CutSpace(DBFData[3].ToString())) + ", "
                                    + "'" + CutSpace(DBFData[4].ToString()) + "', "
                                    + "'" + ChangeDateFormat(DateTime.Parse(DBFData[5].ToString()).ToShortDateString()) + "')";
                    SqlExecResult = SqlConnection.Exec(SqlExecString);
                }
            }
            DBFData.Close();
            DBFConnection.DisConnect();
            #endregion

            #region 从CUST_CNT中插入身份证客户
            DBFConnection.SetFile(this.DBFPath + @"CUST_CNT.DBF");
            DBFConnection.Connect();
            DBFResult = DBFConnection.Query("select distinct NAME, MARK, ADDRESS, SFZ_ID, ST_DATE from CUST_CNT.DBF order by ST_DATE");
            DBFData = DBFResult.GetResult();
            while (DBFData.Read())
            {
                if (isExistCustomerInSQL(CutSpace(DBFData[0].ToString()), CutSpace(DBFData[3].ToString())) == false)
                {
                    int CertID = GetCertIDByName("身份证");
                    SqlExecString = "insert into DDCustomerInfo (CustomerName, PhoneNumber, Address, CertTypeID, CertNumber) "
                                    + "VALUES ( "
                                    + "'" + CutSpace(DBFData[0].ToString()) + "', "
                                    + "'" + CutSpace(DBFData[1].ToString()) + "', "
                                    + "'" + CutSpace(DBFData[2].ToString()) + "', "
                                    + CertID.ToString() + ", "
                                    + "'" + CutSpace(DBFData[3].ToString()) + "', "
                                    + "'" + ChangeDateFormat(DateTime.Parse(DBFData[4].ToString()).ToShortDateString()) + "')";

                    SqlExecResult = SqlConnection.Exec(SqlExecString);
                }

            }
            DBFData.Close();
            DBFConnection.DisConnect();
            #endregion

            #region 插入公司信息
            DBFConnection.SetFile(this.DBFPath + "UNITINFO.DBF");
            DBFConnection.Connect();
            DBFResult = DBFConnection.Query("select distinct NAME, PHONE, ADDRESS, UNIT_ID, B_NO from UNITINFO.DBF");
            DBFData = DBFResult.GetResult();
            while (DBFData.Read())
            {
                if (isExistCustomerInSQL(CutSpace(DBFData[0].ToString()), CutSpace(DBFData[3].ToString())) == false)
                {
                    SqlExecString = "insert into DDCustomerInfo (CustomerName, PhoneNumber, Address, ContactPerson, CertTypeID, CertNumber) "
                                    + "VALUES ( "
                                    + "'" + CutSpace(DBFData[0].ToString()) + "', "
                                    + "'" + CutSpace(DBFData[1].ToString()) + "', "
                                    + "'" + CutSpace(DBFData[2].ToString()) + "', "
                                    + "'" + GetContactNamebyB_NO(CutSpace(DBFData[4].ToString())) + "', "
                                    + "'" + GetCertIDByName("营业执照") + "', "
                                    + "'" + CutSpace(DBFData[3].ToString()) + "')";
                    SqlExecResult = SqlConnection.Exec(SqlExecString);
                }
            }
            DBFData.Close();
            DBFConnection.DisConnect();
            #endregion            
        }

        private int GetCertIDByName(string theName)
        {
            SqlResultTemp = SqlTemp.Query("select TypeID from DDCertTypes where TypeName='" + theName + "'");
            SqlDataTemp = SqlResultTemp.GetResult();
            if (SqlDataTemp.Read())
            {
                int ID = Convert.ToInt32(SqlDataTemp[0]);
                SqlDataTemp.Close();
                return ID;
            }
            else
            {
                SqlDataTemp.Close();
                return -1;
            }
        }

        private int GetSqlCertIDbyDBFCertID(string DBFID)
        {
            DBFTemp.SetFile(this.DBFPath + "S_TYPE.DBF");
            DBFTemp.Connect();
            DBFResultTemp = DBFTemp.Query("select S_TYPE from S_TYPE.DBF where S_NO='" + DBFID + "'");
            DBFDataTemp = DBFResultTemp.GetResult();
            if (DBFDataTemp.Read())
            {
                string DBFName = CutSpace(DBFDataTemp[0].ToString());
                DBFDataTemp.Close();
                DBFTemp.DisConnect();
                SqlResultTemp = SqlTemp.Query("select TypeID from DDCertTypes where TypeName='" + DBFName + "'");
                SqlDataTemp = SqlResultTemp.GetResult();
                if (SqlDataTemp.Read())
                {
                    int SqlID = Convert.ToInt32(CutSpace(SqlDataTemp[0].ToString()));
                    SqlDataTemp.Close();
                    DBFDataTemp.Close();
                    DBFTemp.DisConnect();
                    return SqlID;
                }
                else
                {
                    DBFDataTemp.Close();
                    DBFTemp.DisConnect();
                    SqlDataTemp.Close();
                    return -1;
                }
            }
            else
            {
                DBFDataTemp.Close();
                DBFTemp.DisConnect();
                return -1;
            }

        }

        private int GetSqlCustomerIDbyNameCertNumber(string theName, string theCertNumber)
        {
            int CustomerID = 0;
            SqlResultTemp = SqlTemp.Query("select CustomerID from DDCustomerInfo where CustomerName='" + theName + "' and CertNumber='" + theCertNumber + "'");
            SqlDataTemp = SqlResultTemp.GetResult();
            if (SqlDataTemp.Read())
            {
                CustomerID = Convert.ToInt32(SqlDataTemp[0].ToString());
            }
            SqlDataTemp.Close();
            return CustomerID;
        }

        private bool isExistCustomerInSQL(string Name, string CertNumber)
        {
            SqlResultTemp = SqlTemp.Query("select * from DDCustomerInfo where CustomerName='" + Name + "' and CertNumber='" + CertNumber + "'");
            SqlDataTemp = SqlResultTemp.GetResult();
            if (SqlDataTemp.Read())
            {
                SqlDataTemp.Close();
                return true;
            }
            else
            {
                SqlDataTemp.Close();
                return false;
            }
        }

        private string GetContactNamebyB_NO(string B_NO)
        {
            DBFTemp.SetFile(this.DBFPath + "CUST_RCD.DBF");
            DBFTemp.Connect();
            DBFResultTemp = DBFTemp.Query("select NAME from CUST_RCD.DBF where B_NO='" + B_NO + "'");
            DBFDataTemp = DBFResultTemp.GetResult();
            if (DBFDataTemp.Read())
            {
                string ContactName = CutSpace(DBFDataTemp[0].ToString());
                DBFDataTemp.Close();
                DBFTemp.DisConnect();
                return ContactName;
            }
            else
            {
                DBFDataTemp.Close();
                DBFTemp.DisConnect();
                return "";
            }

        }
    }
}