using System;
using System.Collections.Generic;
using System.Text;

namespace DataImport
{
    partial class Main
    {
        private void DDPermissions()
        {
            int SqlExecResult;
            string SqlExecString;

            SqlExecString = "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '1')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '2')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '3')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '4')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '5')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '6')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '7')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '8')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '9')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '10')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '11')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '12')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '13')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '14')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '15')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '16')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '17')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '18')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '19')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '20')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '21')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '22')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '23')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '24')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '25')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '26')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '27')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '28')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '29')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '30')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '31')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '32')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '33')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '34')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '35')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '36')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '37')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '38')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '39')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '40')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '41')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '42')"
                            + "insert into DDPermissions (RoleID, ModuleID) VALUES ('1', '43')";
            SqlExecResult = SqlConnection.Exec(SqlExecString);

        }
    }
}
