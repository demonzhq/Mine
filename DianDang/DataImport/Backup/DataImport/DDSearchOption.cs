using System;
using System.Collections.Generic;
using System.Text;

namespace DataImport
{
    partial class Main
    {
        private void DDSearchOption()
        {
            int SqlExecResult = 0;
            string SqlExecString = "";

            SqlExecString = "insert into DDSearchOption (OptionName, FieldName, SearchTypeID) VALUES ('客户姓名', 'CustomerName', '1')\n"
                            + "insert into DDSearchOption (OptionName, FieldName, SearchTypeID) VALUES ('证件号码', 'CertNumber', '1')\n"
                            + "insert into DDSearchOption (OptionName, FieldName, SearchTypeID) VALUES ('电话号码', 'PhoneNumber', '1')\n"
                            + "insert into DDSearchOption (OptionName, FieldName, SearchTypeID) VALUES ('地址', 'Address', '1')\n"
                            + "insert into DDSearchOption (OptionName, FieldName, SearchTypeID) VALUES ('当票号', 'TicketNumber', '2')\n"
                            + "insert into DDSearchOption (OptionName, FieldName, SearchTypeID) VALUES ('证件号码', 'CertNumber', '2')\n"
                            + "insert into DDSearchOption (OptionName, FieldName, SearchTypeID) VALUES ('姓名', 'CustomerName', '2')\n"
                            + "insert into DDSearchOption (OptionName, FieldName, SearchTypeID) VALUES ('操作人', 'AccountName', '3')\n"
                            + "insert into DDSearchOption (OptionName, FieldName, SearchTypeID) VALUES ('姓名', 'UserName', '3')\n"
                            + "insert into DDSearchOption (OptionName, FieldName, SearchTypeID) VALUES ('证件号码', 'CertNumber', '3')\n"
                            + "insert into DDSearchOption (OptionName, FieldName, SearchTypeID) VALUES ('在库全部', '', '4')\n"
                            + "insert into DDSearchOption (OptionName, FieldName, SearchTypeID) VALUES ('在库正常', '', '4')\n"
                            + "insert into DDSearchOption (OptionName, FieldName, SearchTypeID) VALUES ('在库过期', '', '4')\n"
                            + "insert into DDSearchOption (OptionName, FieldName, SearchTypeID) VALUES ('冻结当品', '', '4')\n"
                            + "insert into DDSearchOption (OptionName, FieldName, SearchTypeID) VALUES ('已绝当', '', '4')\n"
                            + "insert into DDSearchOption (OptionName, FieldName, SearchTypeID) VALUES ('已赎回', '', '4')\n"
                            + "insert into DDSearchOption (OptionName, FieldName, SearchTypeID) VALUES ('已清算', '', '4')\n"
                            + "insert into DDSearchOption (OptionName, FieldName, SearchTypeID) VALUES ('全部', '', '4')\n"
                            + "insert into DDSearchOption (OptionName, FieldName, SearchTypeID) VALUES ('当票号', 'PawnageID', '5')\n"
                            + "insert into DDSearchOption (OptionName, FieldName, SearchTypeID) VALUES ('客户姓名', 'CustomerName', '5')\n"
                            + "insert into DDSearchOption (OptionName, FieldName, SearchTypeID) VALUES ('当品描述', 'Description', '5')\n"
                            + "insert into DDSearchOption (OptionName, FieldName, SearchTypeID) VALUES ('当品备注', 'Remark', '5')\n"
                            + "insert into DDSearchOption (OptionName, FieldName, SearchTypeID) VALUES ('当值大于', 'Price', '5')\n"
                            + "insert into DDSearchOption (OptionName, FieldName, SearchTypeID) VALUES ('当值小于', 'Price', '5')\n"
                            + "insert into DDSearchOption (OptionName, FieldName, SearchTypeID) VALUES ('一级分类', 'ClassName', '5')\n"
                            + "insert into DDSearchOption (OptionName, FieldName, SearchTypeID) VALUES ('二级分类', 'ClassName', '5')\n";
            SqlExecResult = SqlConnection.Exec(SqlExecString);
        }
    }
}