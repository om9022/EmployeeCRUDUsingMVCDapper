using EmployeeDAL;
using Employeemodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EmployeeBAL
{
    public class EmployeeService
    {
        EmployeeRepository repo = new EmployeeRepository();

        public List<EmpModel> GetEmployeeList()
        {
            return repo.GetEmployeeList();
        }

        public EmpModel ViewemployeeName(int id)
        {
            return repo.ViewemployeeName(id);
        }

        public ResponseStatusModel AddEmployee(EmpModel user)
        {
            return repo.AddEmployee(user);
        }
        
        public ResponseStatusModel UpdateEmployee(EmpModel user)
        {
            return repo.UpdateEmployee(user);
        }

        public ResponseStatusModel RemoveEmployee(int id)
        {
           

            return repo.RemoveEmployee(id);
        }
      
    }
}
