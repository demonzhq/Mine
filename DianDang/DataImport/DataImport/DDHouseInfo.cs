using System;
using System.Collections.Generic;
using System.Text;

namespace DataImport
{
    partial class Main
    {
        void DDHouseInfo()
        {
            int SqlExecResult = 0;
            string SqlExecString = "";
            int theTicketID = 0;
            int thePawnageID = 0;
            int i = 0;
            string DateNone = "1899/12/300:00:00";
            string theRegisterDate = "";
            string theInsuranceDate = "";
            string theNotarizationDate = "";


            DBFConnection.SetFile(this.DBFPath + @"\1009.DBF");
            DBFConnection.Connect();
            DBFResult = DBFConnection.Query("select D1009_03, D1009_02, D1009_04, D1009_05, D1009_06, D1009_07, B_NO, NO from 1009.DBF");
            DBFData = DBFResult.GetResult();
            while (DBFData.Read())
            {
                theTicketID = GetTicketIDbyTicketNumber(CutSpace(DBFData[6].ToString()));
                if (theTicketID != 0)
                {
                    SqlResult = SqlConnection.Query("select distinct PawnageID from DDOperation where TicketID='" + theTicketID + "'");
                    SqlData = SqlResult.GetResult();
                    i = 0;
                    while (i < Convert.ToInt32(CutSpace(DBFData[7].ToString())))
                    {
                        SqlData.Read();
                        i++;
                    }
                    thePawnageID = Convert.ToInt32(CutSpace(SqlData[0].ToString()));
                    SqlData.Close();

                    if (CutSpace(DBFData[3].ToString()) != DateNone)
                    {
                        theRegisterDate = ChangeDateFormat(DateTime.Parse(DBFData[3].ToString()).ToShortDateString());
                    }
                    else
                    {
                        theRegisterDate = "";
                    }
                    if (CutSpace(DBFData[4].ToString()) != DateNone)
                    {
                        theInsuranceDate = ChangeDateFormat(DateTime.Parse(DBFData[4].ToString()).ToShortDateString());
                    }
                    else
                    {
                        theInsuranceDate = "";
                    }
                    if (CutSpace(DBFData[5].ToString()) != DateNone)
                    {
                        theNotarizationDate = ChangeDateFormat(DateTime.Parse(DBFData[5].ToString()).ToShortDateString());
                    }
                    else
                    {
                        theNotarizationDate = "";
                    }

                    SqlExecString = "insert into DDHouseInfo (Address, CompactNumber, Area, RegisterDate, InsuranceDate, NotarizationDate, PawnageID) "
                                    + "VALUES ("
                                    + "'" + CutSpace(DBFData[0].ToString()) + "', "
                                    + "'" + CutSpace(DBFData[1].ToString()) + "', "
                                    + "'" + CutSpace(DBFData[2].ToString()) + "', "
                                    + "'" + theRegisterDate + "', "
                                    + "'" + theInsuranceDate + "', "
                                    + "'" + theNotarizationDate + "', "
                                    + "'" + thePawnageID.ToString() + "')";
                    SqlExecResult = SqlConnection.Exec(SqlExecString);


                    theTicketID = 0;
                    thePawnageID = 0;
                    theRegisterDate = "";
                    theInsuranceDate = "";
                    theNotarizationDate = "";
                }
            }
            DBFData.Close();
            DBFConnection.DisConnect();
        }
    }
}
