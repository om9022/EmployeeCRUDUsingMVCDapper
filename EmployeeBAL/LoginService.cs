using EmployeeDAL;
using Employeemodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBAL
{
    public class LoginService
    {
        LoginRepository login = new LoginRepository();

        public LoginResponseModel LoginDetails(string Name, string Password)
        {
            return login.LoginDetails(Name, Password);
        }

    }
}
