using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employeemodel
{
    public class LoginMasterModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Active { get; set; }
    }

    public class LoginResponseModel
    {
        public ResponseStatusModel response { get; set; }
        public RegistrationModel RegistrationMaster { get; set; }
    }
}
