using System;
using System.Collections.Generic;
using System.Text;

namespace DataImport
{
    partial class Main
    {
        private void DDCarInfo()
        {
            int SqlExecResult = 0;
            string SqlExecString = "";
            int theTicketID = 0;
            int thePawnageID = 0;
            int i = 0;
            string DateNone = "1899/12/300:00:00";
            string theInsuranceDate = "";
            string theRoadtollDate = "";
            string theCheckDate = "";


            DBFConnection.SetFile(this.DBFPath + @"\1008.DBF");
            DBFConnection.Connect();
            DBFResult = DBFConnection.Query("select D1008_01, D1008_02, D1008_03, D1008_04, D1008_05, D1008_06, D1008_07, B_NO, NO from 1008.DBF");
            DBFData = DBFResult.GetResult();
            while (DBFData.Read())
            {
                theTicketID = GetTicketIDbyTicketNumber(CutSpace(DBFData[7].ToString()));
                if (theTicketID != 0)
                {
                    SqlResult = SqlConnection.Query("select distinct PawnageID from DDOperation where TicketID='" + theTicketID + "'");
                    SqlData = SqlResult.GetResult();
                    i = 0;
                    while (i < Convert.ToInt32(CutSpace(DBFData[8].ToString())))
                    {
                        SqlData.Read();
                        i++;
                    }
                    thePawnageID = Convert.ToInt32(CutSpace(SqlData[0].ToString()));
                    SqlData.Close();

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
                        theRoadtollDate = ChangeDateFormat(DateTime.Parse(DBFData[5].ToString()).ToShortDateString());
                    }
                    else
                    {
                        theRoadtollDate = "";
                    }
                    if (CutSpace(DBFData[6].ToString()) != DateNone)
                    {
                        theCheckDate = ChangeDateFormat(DateTime.Parse(DBFData[6].ToString()).ToShortDateString());
                    }
                    else
                    {
                        theCheckDate = "";
                    }


                    SqlExecString = "insert into DDCarInfo (LicenseNumber, CarType, EngineNumber, CarCaseNumber, InsuranceDate, RoadtollDate, CheckDate, PawnageID) "
                                    + "VALUES ("
                                    + "'" + CutSpace(DBFData[0].ToString()) + "', "
                                    + "'" + CutSpace(DBFData[1].ToString()) + "', "
                                    + "'" + CutSpace(DBFData[2].ToString()) + "', "
                                    + "'" + CutSpace(DBFData[3].ToString()) + "', "
                                    + "'" + theInsuranceDate + "', "
                                    + "'" + theRoadtollDate + "', "
                                    + "'" + theCheckDate + "', "
                                    + "'" + thePawnageID.ToString() + "')";
                    SqlExecResult = SqlConnection.Exec(SqlExecString);


                    theTicketID = 0;
                    thePawnageID = 0;
                    theInsuranceDate = "";
                    theRoadtollDate = "";
                    theCheckDate = "";
                }
            }
            DBFData.Close();
            DBFConnection.DisConnect();
        }
    }
}
