using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Employeemodel
{
    public class  EmpModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Location { get; set; }
        public int Status { get; set; }
        public string FilePath { get; set; }
        public HttpPostedFileWrapper ImageFile { get; set; }
       // public List<HttpPostedFileWrapper> multiFiles { get; set; }
        public string FileName { get; set; }
    }

    public class EmployeeViewModelView
    {
        public List<EmpModel> EmplModelList { get; set; }
        public ResponseStatusModel response { get; set; }
        public EmpModel EmpModel { get; set; }
        
    }

}
