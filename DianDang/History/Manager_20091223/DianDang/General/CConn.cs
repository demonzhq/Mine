using System;
using System.Collections.Generic;
using System.Text;

/*数据库连接类*/

namespace DianDang
{
    class CConn
    {
        private string strDBAddress;
        private string strDBName;
        private string strSqlUser;
        private string strSqlPwd;

        public string DBAddress
        {
            get
            {
                return strDBAddress;
            }
            set
            {
                strDBAddress = value;
            }
        }

        public string DBName
        {
            get
            {
                return strDBName;
            }
            set
            {
                strDBName = value;
            }
        }

        public string SqlUser
        {
            get
            {
                return strSqlUser;
            }
            set
            {
                strSqlUser = value;
            }
        }

        public string SqlPwd
        {
            get
            {
                return strSqlPwd;
            }
            set
            {
                strSqlPwd = value;
            }
        }
    }
}
