using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Employeemodel
{
    public class ExcelReadModel
    {
        public string Name { get; set; }
        public string RollNo { get; set; }
        public string Email { get; set; }

        public HttpPostedFileBase excelFile { get; set; }
        public string excelName { get; set; }
    }
    public class ExcelReadModelView
    {
        public List<ExcelReadModel> ListExcel { get; set; }
    }
}

