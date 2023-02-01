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
        public  string FilePath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        public List<HttpPostedFileBase> multiFiles { get; set; }
        public string FileName { get; set; }
        public List<string> UploadedFiles { get; set; }
    }

    public class EmployeeViewModelView
    {
        public List<EmpModel> EmplModelList { get; set; }
        public ResponseStatusModel response { get; set; }
        public EmpModel EmpModels { get; set; }
    }
    public class EmpModelAPI
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Location { get; set; }
        public int Status { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public List<string> UploadedFiles { get; set; }
    }
}
