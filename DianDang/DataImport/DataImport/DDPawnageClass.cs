using System;
using System.Collections.Generic;
using System.Text;

namespace DataImport
{
    partial class Main
    {
        private void DDPawnageClass()
        {
            int SqlExecResult = 0;
            string SqlExecString = "";
            double MaxFeeRate = 0;
            double MinFeeRate = 0;
            double MonthFeeRate = 0;

            #region Get System MonthFeeRate & InterestRate
            double SysMonthFeeRate = 0;
            double SysInterestRate = 0;
            DBFConnection.SetFile(this.DBFPath + "CONFIG.DBF");
            DBFConnection.Connect();
            DBFResult = DBFConnection.Query("select SYS_FW, SYS_LX from CONFIG.DBF");
            DBFData = DBFResult.GetResult();
            while (DBFData.Read())
            {
                SysMonthFeeRate = Convert.ToDouble(CutSpace(DBFData[0].ToString()));
                SysInterestRate = Convert.ToDouble(CutSpace(DBFData[1].ToString()));
            }
            DBFData.Close();
            DBFConnection.DisConnect();
            #endregion

            #region Insert NoUpper
            int NoUpperID = 0;  
            SqlExecString = "Insert into DDPawnageClass (ClassName, ParentID, UnitID, MonthFeeRate, InterestRate, IsRoot, StatisticClassID) VALUES ('无上级分类', '1', '0','0','0','1','0')";
            SqlExecResult = SqlConnection.Exec(SqlExecString);
            SqlResult = SqlConnection.Query("select ClassID from DDPawnageClass where ClassName = '无上级分类'");
            SqlData = SqlResult.GetResult();
            SqlData.Read();
            NoUpperID = Convert.ToInt32(CutSpace(SqlData[0].ToString()));
            SqlData.Close();
            SqlExecResult = SqlConnection.Exec("update DDPawnageClass set ParentID = '" + NoUpperID + "' where ClassID='" + NoUpperID.ToString() + "'");
            #endregion

            #region Insert Root
            DBFConnection.SetFile(this.DBFPath + "DD_CLASS.DBF");
            DBFConnection.Connect();
            DBFResult = DBFConnection.Query("select CLASS_NAME, UNITTYPE, FW_RATE, LX_RATE, D1_CLASS from DD_CLASS.DBF");
            DBFData = DBFResult.GetResult();
            while (DBFData.Read())
            {
                MonthFeeRate = GetRate(CutSpace(DBFData[2].ToString()), SysMonthFeeRate.ToString());
                MaxFeeRate = MonthFeeRate * 1.1;
                MinFeeRate = MonthFeeRate * 0.9;
                SqlExecString = "Insert into DDPawnageClass (ClassName, ParentID, UnitID, MonthFeeRate, MaxFeeRate, MinFeeRate, InterestRate, IsRoot, StatisticClassID) VALUES ("
                                + "'" + CutSpace(DBFData[0].ToString()) + "', "
                                + "'0', "
                                + "'" + GetMesureUnitIDbByUNITTYPE(CutSpace(DBFData[1].ToString())) + "', "
                                + "'" + MonthFeeRate.ToString() +"', "
                                + "'" + MaxFeeRate.ToString() + "', "
                                + "'" + MinFeeRate.ToString() + "', "
                                + "'" + GetRate(CutSpace(DBFData[3].ToString()), SysInterestRate.ToString()) + "', "
                                + "'1', "
                                + "'" + GetStatisticClassIDByD1_CLASS(CutSpace(DBFData[4].ToString())) + "')";
                SqlExecResult = SqlConnection.Exec(SqlExecString);
            }
            DBFData.Close();
            DBFConnection.DisConnect();
            #endregion

            #region InsertRootOther
            SqlResult = SqlConnection.Query("select ClassID from DDPawnageClass where ClassName='其它'");
            SqlData = SqlResult.GetResult();
            if (!SqlData.Read())
            {
                SqlData.Close();
                SqlExecString = "Insert into DDPawnageClass (ClassName, ParentID, UnitID, MonthFeeRate, InterestRate, IsRoot, StatisticClassID) VALUES ("
                                + "'其它', "
                                + "'0', "
                                + "'" + GetMesureUnitIDbByUNITTYPE("0") + "', "
                                + "'" + SysMonthFeeRate + "', "
                                + "'" + SysInterestRate + "', "
                                + "'1', "
                                + "'" + GetStatisticClassIDByD1_CLASS("0") + "')";
                SqlExecResult = SqlConnection.Exec(SqlExecString);
            }
            SqlData.Close();
            

            int OtherID = 0;
            SqlResult = SqlConnection.Query("select ClassID from DDPawnageClass where ClassName='其它' and ParentID=0");
            SqlData = SqlResult.GetResult();
            while (SqlData.Read())
            {
                OtherID = Convert.ToInt32(SqlData[0].ToString());
            }
            SqlData.Close();

            SqlExecString = "Insert into DDPawnageClass (ClassName, ParentID, UnitID, MonthFeeRate, InterestRate, IsRoot, StatisticClassID) VALUES ("
                + "'其它', "
                + "'" + OtherID.ToString() + "', "
                + "'" + GetMesureUnitIDbByUNITTYPE("0") + "', "
                + "'" + SysMonthFeeRate + "', "
                + "'" + SysInterestRate + "', "
                + "'0', "
                + "'" + GetStatisticClassIDByD1_CLASS("0") + "')";
            SqlExecResult = SqlConnection.Exec(SqlExecString);
            #endregion

            #region Insert Detail
            int ParentID = 0;
            DBFConnection.SetFile(this.DBFPath + "DD_TYPE.DBF");
            DBFConnection.Connect();
            DBFResult = DBFConnection.Query("select DD_TYPE, DD_NAME from DD_TYPE.DBF");
            DBFData = DBFResult.GetResult();
            while (DBFData.Read())
            {
                ParentID = GetParentIDByDD_TYPE(CutSpace(DBFData[0].ToString()));
                SqlResultTemp = SqlTemp.Query("select UnitID, MonthFeeRate, InterestRate from DDPawnageClass where ClassID='" + ParentID + "'");
                SqlDataTemp = SqlResultTemp.GetResult();
                SqlDataTemp.Read();
                MaxFeeRate = Convert.ToDouble(SqlDataTemp[1].ToString()) * 1.1;
                MinFeeRate = Convert.ToDouble(SqlDataTemp[1].ToString()) * 0.9;
                SqlExecString = "insert into DDPawnageClass (ClassName, ParentID, UnitID, MonthFeeRate, MaxFeeRate, MinFeeRate, InterestRate, IsRoot, StatisticClassID) VALUES ("
                                + "'" + CutSpace(DBFData[1].ToString()) + "', "
                                + "'" + ParentID + "', "
                                + "'" + SqlDataTemp[0].ToString() + "', "
                                + "'" + SqlDataTemp[1].ToString() + "', "
                                + "'" + MaxFeeRate.ToString() + "', "
                                + "'" + MinFeeRate.ToString() + "', "
                                + "'" + SqlDataTemp[2].ToString() + "', "
                                + "'0', "
                                + "'0')";
                SqlDataTemp.Close();
                SqlExecResult = SqlConnection.Exec(SqlExecString);
            }
            DBFData.Close();
            DBFConnection.DisConnect();
            #endregion

            #region OtherDetail
            
            #endregion
        }

        private double GetRate(string theRate, string SysRate)
        {
            if (Convert.ToDouble(theRate) == -1)
            {
                return Convert.ToDouble(SysRate);
            }
            else return Convert.ToDouble(theRate);
        }

        private string GetStatisticClassIDByD1_CLASS(string D1_CLASS)
        {
            string FinalReturn = "";
            string ClassName = "";
            //Read ClassName
            DBFTemp.SetFile(this.DBFPath + "D1_CLASS.DBF");
            DBFTemp.Connect();
            DBFResultTemp = DBFTemp.Query("select D1_NAME from D1_CLASS.DBF where D1_CLASS = '" + D1_CLASS + "'");
            DBFDataTemp = DBFResultTemp.GetResult();
            while (DBFDataTemp.Read())
            {
                ClassName = CutSpace(DBFDataTemp[0].ToString());
            }
            DBFDataTemp.Close();
            DBFTemp.DisConnect();
            if (ClassName == "")
            {
                SqlResultTemp = SqlTemp.Query("select ClassID from DDStatisticClass where ClassName = '其它'");
                SqlDataTemp = SqlResultTemp.GetResult();
                SqlDataTemp.Read();
                FinalReturn = CutSpace(SqlDataTemp[0].ToString());
                SqlDataTemp.Close();
                return FinalReturn;
            }

            //GetStatisticClassID
            SqlResultTemp = SqlTemp.Query("select ClassID from DDStatisticClass where ClassName = '" + ClassName + "'");
            SqlDataTemp = SqlResultTemp.GetResult();
            SqlDataTemp.Read();
            FinalReturn = SqlDataTemp[0].ToString();
            SqlDataTemp.Close();
            return FinalReturn;
        }

        private string GetMesureUnitIDbByUNITTYPE(string UNITTYPE)
        {
            string FinalReturn = "";
            string MesureUnitName = "";
            //Read MesureUnitName
            DBFTemp.SetFile(this.DBFPath + "UNITTYPE.DBF");
            DBFTemp.Connect();
            DBFResultTemp = DBFTemp.Query("select UNITNAME from UNITTYPE.DBF where UNITTYPE = '" + UNITTYPE + "'");
            DBFDataTemp = DBFResultTemp.GetResult();
            while (DBFDataTemp.Read())
            {
                MesureUnitName = CutSpace(DBFDataTemp[0].ToString());
            }
            DBFDataTemp.Close();
            DBFTemp.DisConnect();
            if (MesureUnitName == "")
            {
                SqlResultTemp = SqlTemp.Query("select UnitID from DDMesureUnit where UnitName = '其它'");
                SqlDataTemp = SqlResultTemp.GetResult();
                SqlDataTemp.Read();
                FinalReturn = CutSpace(SqlDataTemp[0].ToString());
                SqlDataTemp.Close();
                return FinalReturn;
            }
            //Get MasureUnitID
            SqlResultTemp = SqlTemp.Query("select UnitID from DDMesureUnit where UnitName = '" + MesureUnitName + "'");
            SqlDataTemp = SqlResultTemp.GetResult();
            SqlDataTemp.Read();
            FinalReturn = SqlDataTemp[0].ToString();
            SqlDataTemp.Close();
            return FinalReturn;
        }

        private int GetParentIDByDD_TYPE(string DD_TYPE)
        {
            string DD_CLASS = "";
            string ClassName = "";
            string FinalReturn = "";
            //GetClassName
            DD_CLASS = DD_TYPE.Substring(0, 4);
            DBFTemp.SetFile(this.DBFPath + "DD_CLASS.DBF");
            DBFTemp.Connect();
            DBFResultTemp = DBFTemp.Query("select CLASS_NAME from DD_CLASS.DBF where DD_CLASS='" + DD_CLASS + "'");
            DBFDataTemp = DBFResultTemp.GetResult();
            while (DBFDataTemp.Read())
            {
                ClassName = CutSpace(DBFDataTemp[0].ToString());
            }
            DBFDataTemp.Close();
            DBFTemp.DisConnect();

            //GetClassId
            SqlResultTemp = SqlTemp.Query("select ClassID from DDPawnageClass where ClassName='" + ClassName + "' order by ClassID DESC");
            SqlDataTemp = SqlResultTemp.GetResult();
            while (SqlDataTemp.Read())
            {
                FinalReturn = SqlDataTemp[0].ToString();
            }
            SqlDataTemp.Close();
           
            //if not success
            if (FinalReturn == "")
            {
                SqlResultTemp = SqlTemp.Query("select ClassID from DDPawnageClass where ClassName='其它'");
                SqlDataTemp = SqlResultTemp.GetResult();
                SqlDataTemp.Read();
                FinalReturn = SqlDataTemp[0].ToString();
                SqlDataTemp.Close();
                return Convert.ToInt32(FinalReturn);
            }
            else return Convert.ToInt32(FinalReturn);
        }

        private int GetClassIDByDD_TYPE(string DD_TYPE)
        {
            int ClassID = 0;
            string ClassName = "";

            //Get Class Name from DBF
            DBFTemp.SetFile(this.DBFPath + "DD_CLASS.DBF");
            DBFTemp.Connect();
            DBFResultTemp = DBFTemp.Query("select DD_NAME from DD_TYPE.DBF where DD_TYPE='" + DD_TYPE + "'");
            DBFDataTemp = DBFResultTemp.GetResult();
            while (DBFDataTemp.Read())
            {
                ClassName = CutSpace(DBFDataTemp[0].ToString());
            }
            DBFDataTemp.Close();
            DBFTemp.DisConnect();

            //Get ClassID from SQL
            SqlResultTemp = SqlTemp.Query("select ClassID from DDPawnageClass where ClassName='" + ClassName + "'");
            SqlDataTemp = SqlResultTemp.GetResult();
            while (SqlDataTemp.Read())
            {
                ClassID = Convert.ToInt32(SqlDataTemp[0].ToString());
            }
            SqlDataTemp.Close();
            return ClassID;
        }

    }
}
