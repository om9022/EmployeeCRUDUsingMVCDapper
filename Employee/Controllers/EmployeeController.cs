using EmployeeBAL;
using EmployeeDAL;
using Employeemodel;
using LocationBAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Employee.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeService service = new EmployeeService();
        LocationService ls = new LocationService();
        // GET: Employee
        [HttpGet]
        public ActionResult Index()
        {
            List<LocModel> LocatioModelList = ls.GetLocationNameDropdownList();
            var stringTemp = "";
            foreach (var item in LocatioModelList)
            {
                stringTemp += "<Option>" + item.Location + "</option>";
            }
            ViewBag.LocationModelList = stringTemp;
            return View();
        }
      
        [HttpGet]
        public ActionResult EmployeePartial(){
            EmployeeViewModelView tmvm = new EmployeeViewModelView(); 
            tmvm.EmplModelList = service.GetEmployeeList();
            return PartialView("EmployeePartial", tmvm);
        }

        [HttpPost]
        public ActionResult AddEmployeeName(EmpModel user)
        {
            //var files = user.multiFiles;
            //foreach (var file in user.multiFiles)
            //{
            //    var ext = Path.GetExtension(user.FilePath);
            //    if ( file.ContentLength > 0  &&(file != null || ext.ToLower() == ".jpg" || ext.ToLower() == ".jpeg" || ext.ToLower() == ".png"))
            //    {
            //        file.SaveAs(Path.Combine(Server.MapPath("~/Models/"),Guid.NewGuid()+Path.GetExtension(file.FileName)));
            //    }
            //}

            var file = user.ImageFile;
            var ext = Path.GetExtension(user.FilePath);
            if (file != null || ext.ToLower() == ".jpg" || ext.ToLower() == ".jpeg" || ext.ToLower() == ".png")
            {
                file.SaveAs(Server.MapPath("~/Models/") + file.FileName);
            }
            ResponseStatusModel response = new ResponseStatusModel();
            response = service.AddEmployee(user);
            return Json(response, file.FileName, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult ViewemployeeName(int id)
        {
            EmployeeViewModelView evmv = new EmployeeViewModelView();
            try
            {
                evmv.EmpModel = service.ViewemployeeName(id);
                return Json(evmv, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(evmv, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult RemoveEmployeeName(int Id)
        {
            ResponseStatusModel response = new ResponseStatusModel();
            response = service.RemoveEmployee(Id);
            var filePath = Server.MapPath("~/Models/") + response.DeleteFile;
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            response = service.RemoveEmployee(Id);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateEmployee(EmpModel temp)
        {       
                ResponseStatusModel response = new ResponseStatusModel();
                response = service.UpdateEmployee(temp);
                return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}