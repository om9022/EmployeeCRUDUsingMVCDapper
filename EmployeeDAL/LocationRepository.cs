

using Dapper;
using EmployeeDAL;
using Employeemodel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationDAL
{
    public class LocationRepository
    {
       public List<LocModel> GetLocationList()
        {
            LocationModelViewModel ls = new LocationModelViewModel();
            string sql = "[GetLocationList]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {


                }, commandType: CommandType.StoredProcedure);
                ls.LocationList = multi.Read<LocModel>().ToList();
            }
            return ls.LocationList;
        }

        public LocModel ViewLocations(int Id)
        {
            LocModel md = new LocModel();
            string sql = "[ViewLocation]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {

                    Id = Id

                }, commandType: CommandType.StoredProcedure);
                md = multi.Read<LocModel>().SingleOrDefault();
            }
            return md;
        }

        public ResponseStatusModel AddLocation(LocModel model)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            ///string sql = "[AddLocation]";
            // using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            // {
            //     var multi = conn.QueryMultiple(sql, new
            //     {
            //         Location = model.Location
            //     }, commandType: CommandType.StoredProcedure);
            //     response = multi.Read<ResponseStatusModel>().SingleOrDefault();
            // }
            // return response;


             int addEmp;
            SqlConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString);
            SqlCommand cmd = new SqlCommand("insert into Tbl_Location(Location, Active)Values('" + model.Location +  "','" + 1 + "')", conn);
            conn.Open();
            addEmp = cmd.ExecuteNonQuery();
            if (addEmp == 0)
            {
                response.n = 0;
                response.Msg = "Failed to Add Employee";
                response.Status = "Failed";
            }
            else
            {
                response.n = 1;
                response.Msg = "Employee Added Successfully";
                response.Status = "Success";
            }
            return response;
        }

        public ResponseStatusModel UpdateLocation(LocModel md)
        {
            ResponseStatusModel res = new ResponseStatusModel();
            string sql = "[UpdateLocation]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    Id = md.Id,
                    Location = md.Location
                }, commandType: CommandType.StoredProcedure) ; 
                res = multi.Read<ResponseStatusModel>().SingleOrDefault();
            }
            return res;
        }

        public ResponseStatusModel RemoveLocation(int Id)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            string sql = "[RemoveLocation]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {

                    Id = Id
                }, commandType: CommandType.StoredProcedure);
                response = multi.Read<ResponseStatusModel>().FirstOrDefault();
            }
            return response;
        }

        public List<LocModel> GetLocationNameDropdownList()
        {
            LocationModelViewModel tpmvm = new LocationModelViewModel();
            string sql = "[LocationDropdown]";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {

                }, commandType: CommandType.StoredProcedure);
                tpmvm.LocationList = multi.Read<LocModel>().ToList();
            }
            return tpmvm.LocationList;
        }
    }
}
