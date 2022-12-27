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
    public class RegistrationRepository
    {
        public List<RegistrationModel> GetUserList()
        {
            RegistrationViewModel view = new RegistrationViewModel();
            string sql = "[GetUser]";
            using(IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {

                }, commandType: CommandType.StoredProcedure);
                view.RegistrationModelList = multi.Read<RegistrationModel>().ToList();
            }

            return view.RegistrationModelList;
        }

        //public RegistrationModel ViewUserList(int Id)
        //{
        //    RegistrationModel master = new RegistrationModel();
        //    string sql = "[ViewUser]";

        //    using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
        //    {
        //        var multi = conn.QueryMultiple(sql, new
        //        {

        //        }, commandType: CommandType.StoredProcedure);
        //        master = multi.Read<RegistrationModel>().SingleOrDefault();
        //    }
        //    return master;
        //}

        public ResponseStatusModel AddUser(RegistrationModel user)
        {
            ResponseStatusModel res = new ResponseStatusModel();
            string sql = "[AddUser]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    Name = user.Name,
                    EmailId = user.EmailId,
                    Password = user.Password
                }, commandType: CommandType.StoredProcedure);
                res = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return res;
        }


        //public ResponseStatusModel updateUser(RegistrationModel user)
        //{
        //    ResponseStatusModel res = new ResponseStatusModel();
        //    string sql = "[UpdateUser]";
        //    using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
        //    {
        //        var multi = conn.QueryMultiple(sql, new
        //        {

        //        }, commandType: CommandType.StoredProcedure);
        //        res = multi.Read<ResponseStatusModel>().SingleOrDefault();
        //    }
        //    return res;
        //}

        //public ResponseStatusModel RemoveUser(int Id)
        //{
        //    ResponseStatusModel res = new ResponseStatusModel();
        //    string sql = "[RemoveUser]";
        //    using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
        //    {
        //        var multi = conn.QueryMultiple(sql, new
        //        {

        //        }, commandType: CommandType.StoredProcedure);
        //        res = multi.Read<ResponseStatusModel>().SingleOrDefault();
        //    }
        //    return res;
        //}
    }
}
