using EmployeeDAL;
using Employeemodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBAL
{
    public class RegistrationService
    {
        RegistrationRepository repo = new RegistrationRepository();

        public List<RegistrationModel> GetUserList()
        {
            return repo.GetUserList();
        }

        //public RegistrationModel ViewUserList(int Id)
        //{
        //    return repo.ViewUserList(Id);
        //}

        public ResponseStatusModel AddUser(RegistrationModel user)
        {
            return repo.AddUser(user);
        }

        //public ResponseStatusModel UpdateUser(RegistrationModel user)
        //{
        //    return repo.updateUser(user);
        //}

        //public ResponseStatusModel RemoveUser(int Id)
        //{
        //    return repo.RemoveUser(Id);
        //}
    }
}
