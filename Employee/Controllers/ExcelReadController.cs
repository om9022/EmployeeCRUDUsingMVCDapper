using Employeemodel;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Employee.Controllers
{
    public class ExcelReadController : Controller
    {

        // GET: ExcelRead
        public ActionResult Index()
        {

            return View();
        }

        //    public ActionResult ShowExcel(ExcelReadModel ExcelFileName)
        //    {
        //        var filename = Path.Combine(Server.MapPath("~/Uploads/"), ReadExcel ;
        //        List<ExcelReadModel> excel = new List<ExcelReadModel>();
        //        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        //        using (var stream = System.IO.File.Open(filename, FileMode.Open, FileAccess.Read))
        //        {
        //            using (var reader = ExcelReaderFactory.CreateReader(stream))
        //            {
        //                while (reader.Read())
        //                {
        //                    excel.Add(new ExcelReadModel()
        //                    {
        //                        Name = reader.GetValue(0).ToString(),
        //                        RollNo = reader.GetValue(1).ToString(),
        //                        Email = reader.GetValue(2).ToString(),
        //                    });
        //                }
        //            }
        //        }
        //        return Json(excel, JsonRequestBehavior.AllowGet);
        //    }


        [HttpPost]
        public ActionResult ShowExcel(ExcelReadModel model)
        {
            List<ExcelReadModel> users = new List<ExcelReadModel>();
            string ExcelPath = Path.Combine(Server.MapPath("~/Uploads/"),model.excelName);
            var filename = ExcelPath;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(filename, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        users.Add(new ExcelReadModel
                        {
                            Name = reader.GetValue(0).ToString(),
                            RollNo = reader.GetValue(1).ToString(),
                            Email = reader.GetValue(2).ToString(),
                           
                        });
                    }
                }
            }
            return Json(users, JsonRequestBehavior.AllowGet);
        }

    }

    
}


        