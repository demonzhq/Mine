using System.IO;
using System;

namespace DataImport
{
    public partial class Main
    {
        string CompanyInfo_StartTicketNumber = "000000001";
        DateTime CompanyInfo_SetupDate = DateTime.Now;
        
        private void DDCompanyInfo()
        {
            string SetupDate = CompanyInfo_SetupDate.ToShortDateString();
            SetupDate = SetupDate.Replace('/', '-');
            int SqlExecResult = 0;
            string SqlExecString = "";

            DBFConnection.SetFile(this.DBFPath + "CONFIG.DBF");
            DBFConnection.Connect();

            DBFResult = DBFConnection.Query("select CO_NAME, PHONE, XKZ_ID, ADDRESS, M_STATION, M_NAME, FIX, CONTENTS from CONFIG.DBF");
            DBFData = DBFResult.GetResult();
            DBFData.Read();
            SqlExecString = "insert into DDCompanyInfo (CompanyName, AmountAccuracy, PhoneNumber, LicenseCode, Address, SubCompanyNumber, SubCompanyName, Postalcode, ShopHours, StartTicketNumber, SetupDate, CountDayMode)"
                            + "VALUES ("
                            + "'" + CutSpace(DBFData[0].ToString()) + "', "
                            + "'" + this.numericUpDown1.Value.ToString() +"', "
                            + "'" + CutSpace(DBFData[1].ToString()) + "', "
                            + "'" + CutSpace(DBFData[2].ToString()) + "', "
                            + "'" + CutSpace(DBFData[3].ToString()) + "', "
                            + "'" + CutSpace(DBFData[4].ToString()) + "', "
                            + "'" + CutSpace(DBFData[5].ToString()) + "', "
                            + "'" + CutSpace(DBFData[6].ToString()) + "', "
                            + "'" + CutSpace(DBFData[7].ToString()) + "', "
                            + "'" + CompanyInfo_StartTicketNumber + "', "
                            + "'" + SetupDate + "', "
                            + "'" + "0" + "')";
            SqlExecResult = SqlConnection.Exec(SqlExecString);
            DBFData.Close();


            DBFConnection.DisConnect();
        }
    }
}