using System;
using System.Collections.Generic;
using System.Text;

namespace DataImport
{
    partial class Main
    {
        private void DDTicketStatus()
        {
            int SqlExecResult = 0;
            string SqlExecString = "";

            SqlExecString = "insert into DDTicketStatus (Description, Visible, IsOperation) VALUES('新当', '1', '1')\n"
                           + "insert into DDTicketStatus (Description, Visible, IsOperation) VALUES('赎当', '1', '1')\n"
                           + "insert into DDTicketStatus (Description, Visible, IsOperation) VALUES('续当', '1', '1')\n"
                           + "insert into DDTicketStatus (Description, Visible, IsOperation) VALUES('绝当', '1', '1')\n"
                           + "insert into DDTicketStatus (Description, Visible, IsOperation) VALUES('冻结', '1', '1')\n"
                           + "insert into DDTicketStatus (Description, Visible, IsOperation) VALUES('删除', '0', '1')\n"
                           + "insert into DDTicketStatus (Description, Visible, IsOperation) VALUES('清算', '1', '1')\n"
                           + "insert into DDTicketStatus (Description, Visible, IsOperation) VALUES('过期', '1', '0')\n"
                           + "insert into DDTicketStatus (Description, Visible, IsOperation) VALUES('在库', '1', '0')\n"
                           + "insert into DDTicketStatus (Description, Visible, IsOperation) VALUES('全部', '1', '1')\n";
            SqlExecResult = SqlConnection.Exec(SqlExecString);
        }

        private int GetStatusIDbyName(string theName)
        {
            SqlResultTemp = SqlTemp.Query("select StatusID from DDTicketStatus where Description='" + theName + "'");
            SqlDataTemp = SqlResultTemp.GetResult();
            if (SqlDataTemp.Read())
            {
                int StatusID = 0;
                StatusID = Convert.ToInt32(SqlDataTemp[0].ToString());
                SqlDataTemp.Close();
                return StatusID;
            }
            SqlDataTemp.Close();
            return 0;
        }
    }
}
