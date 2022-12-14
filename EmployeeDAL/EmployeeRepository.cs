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

    public class EmployeeRepository
    {

        public List<EmpModel> GetEmployeeList()
        {
            EmployeeViewModelView emp = new EmployeeViewModelView();
            string sql = "Select * from emp_Table where Active=1";
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {

                }, commandType: CommandType.Text);
                emp.EmplModelList = multi.Read<EmpModel>().ToList();
            }
            return emp.EmplModelList;
        }

        public EmpModel ViewemployeeName(int id)
        {
            EmpModel em = new EmpModel();

            //SqlConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString);
            //SqlCommand cmd = new SqlCommand("Select * from Emp_Table where Id=" + id, conn);
            //conn.Open();
            //SqlDataReader dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    em.Name = dr["Name"].ToString();
            //    em.Contact = dr["Contact"].ToString();
            //    em.Location = dr["Location"].ToString();
                
            //}
            //return em;


            string sql = "Select * from Emp_Table where Id=" + id;
            using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            {
                var multi = conn.QueryMultiple(sql, new
                {
                    Id = id
                }, commandType: CommandType.Text);
                em = multi.Read<EmpModel>().SingleOrDefault();
            }
            return em;
        }

        public ResponseStatusModel AddEmployee(EmpModel user)
        {
            ResponseStatusModel res = new ResponseStatusModel();

            int addEmp;
            SqlConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString);
            SqlCommand cmd = new SqlCommand("insert into Emp_Table(Name, Contact, Location, Active, Status)Values('" + user.Name + "','" + user.Contact + "','" + user.Location + "','"+ 1 + "','"+ user.Status +"')", conn );
            conn.Open();
            addEmp = cmd.ExecuteNonQuery();
            if (addEmp == 0)
            {
                res.n = 0;
                res.Msg = "Failed to Add Employee";
                res.Status = "Failed";
            }
            else
            {
                res.n = 1;
                res.Msg = "Employee Added Successfully";
                res.Status = "Success";
            }
            return res;
            //string sql = "[AddEmployee]";
            //using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            //{
            //    var multi = conn.QueryMultiple(sql, new
            //    {
            //        Name = user.Name,
            //        Contact = user.Contact,
            //        Location = user.Location,
                    
            //    }, commandType: CommandType.StoredProcedure);
            //    res = multi.Read<ResponseStatusModel>().SingleOrDefault();
            //}
            //return res;
        }

        public ResponseStatusModel UpdateEmployee(EmpModel user)
        {
            ResponseStatusModel res = new ResponseStatusModel();
            SqlConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString);
            //SqlCommand cmd = new SqlCommand("Update Emp_Table Set Name='" + user.Name + "',Contact'" + user.Contact + "',Location'" + user.Location + "',Active'" + 1 + "',Status'" + user.Status + "' where Id= " +user.Id + )", conn);
            SqlCommand cmd = new SqlCommand("Update Emp_Table Set Name='" + user.Name + "',Contact='" + user.Contact + "',Location='" + user.Location + "' Where Id=" + user.Id, conn);
            conn.Open();
            int updateEmp = cmd.ExecuteNonQuery();

            if (updateEmp == 0)
            {
                res.n = 0;
                res.Msg = "Failed to Update Employee";
                res.Status = "Failed";
            }
            else
            {
                res.n = 1;
                res.Msg = "Employee Update Successfully";
                res.Status = "Success";
            }
            return res;



            //string sql = "[UpdateEmployee]";
            //using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            //{
            //    var multi = conn.QueryMultiple(sql, new
            //    {
            //        Id = user.Id,
            //        Name = user.Name,
            //        Contact = user.Contact,
            //        Location = user.Location
            //    }, commandType: CommandType.StoredProcedure);
            //    res = multi.Read<ResponseStatusModel>().SingleOrDefault();
            //}
            //return res;
        }
        public ResponseStatusModel RemoveEmployee(int Id)
        {
            ResponseStatusModel res = new ResponseStatusModel();

            SqlConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString);
            SqlCommand cmd = new SqlCommand("Delete from Emp_Table where Id=" + Id, conn);
            conn.Open();
            int dltEmp = cmd.ExecuteNonQuery();
            if (dltEmp == 0)
            {
                res.n = 0;
                res.Msg = "Failed to Delete Employee";
                res.Status = "Failed";
            }
            else
            {
                res.n = 1;
                res.Msg = "Employee Deleted Successfully";
                res.Status = "Success";
            }
            return res;


            //string sql = "[RemoveEmployee]";
            //using (IDbConnection conn = new SqlConnection(Connection.GetConnection().ConnectionString))
            //{
            //    var multi = conn.QueryMultiple(sql, new
            //    {
            //        Id = Id
            //    }, commandType: CommandType.StoredProcedure);
            //    res = multi.Read<ResponseStatusModel>().SingleOrDefault();

            //}
            //return res;
        }
    }
}




