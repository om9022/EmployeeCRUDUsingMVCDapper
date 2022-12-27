using Dapper;
using Employeemodel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDAL
{
    public class LoginRepository
    {
        public LoginResponseModel LoginDetails(string Name, string Password)
        {
            LoginResponseModel response = new LoginResponseModel();
            string sql = "[LoginUser]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multy = conn.QueryMultiple(sql, new
                {
                    Name = Name,
                    Password = Password
                }, commandType: CommandType.StoredProcedure);
                response.RegistrationMaster = multy.Read<RegistrationModel>().SingleOrDefault();
                response.response = multy.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return response;
        }
    }
}
