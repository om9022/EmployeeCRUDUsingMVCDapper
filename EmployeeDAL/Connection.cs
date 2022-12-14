using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDAL
{
    public class Connection
    {
        public static IDbConnection GetConnection()
        {
            IDbConnection connection = new SqlConnection(ConfigurationManager.AppSettings["CS"].ToString());
            return connection;
        }
    }
}
