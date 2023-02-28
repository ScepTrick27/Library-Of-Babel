using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLogic.DBs
{
    public class DBMediator
    {
        protected SqlConnection conn;
        public DBMediator()
        {
            const string connStr = "Server=mssqlstud.fhict.local;Database=dbi489945;User Id=dbi489945;Password=booMPentakill27;Encrypt=false;";
            this.conn = new SqlConnection(connStr);
        }

    }
}
