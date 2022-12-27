using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employeemodel
{
    public class RegistrationModel
    {
        public int Id { get; set; }
        public int SrNo { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }      
        public int Active { get; set; }
       
    }

    public class RegistrationViewModel
    {
        public List<RegistrationModel> RegistrationModelList { get; set; }
        public ResponseStatusModel response { get; set; }
        public RegistrationModel RegModels { get; set; }
    }

   
}
