using Employee.Service;
using EmployeeBAL;
using EmployeeDAL;
using Employeemodel;
using Newtonsoft.Json;
//using LocationBAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee.Controllers
{
    public class EmployeeController : Controller
    {
        //EmployeeService service = new EmployeeService();
        //LocationService ls = new LocationService();
        //EmployeeRepository rs = new EmployeeRepository();
        ResponseStatusModel response = new ResponseStatusModel();

        // GET: Employee
        [HttpGet]
        public ActionResult Index()
        {
            var result = JsonConvert.DeserializeObject<LocationModelViewModel>(Transaction.Get("/GetLocationDropDown").Content);
            var stringTemp = "";
            if(result.LocationList != null)
            {
                foreach(var item in result.LocationList)
                {
                    stringTemp += String.Format("<option value={0}>{1}</option>", item.Id, item.Location);
                }
                ViewBag.LocationModelList = stringTemp;
            }
            return View();

            //List<LocModel> LocatioModelList = ls.GetLocationNameDropdownList();
            //var stringTemp = "";
            //foreach (var item in LocatioModelList)
            //{
            //    stringTemp += "<Option>" + item.Location + "</option>";
            //}
            //ViewBag.LocationModelList = stringTemp;
            //return View();
        }

        [HttpGet]
        public ActionResult EmployeePartial()
        {
            var result = JsonConvert.DeserializeObject<EmployeeViewModelView>(Transaction.Get("/GetEmployeeList").Content);
            response = result.response;
            if(result != null && result.EmplModelList != null)
            {
               return PartialView("EmployeePartial", result);
            }
            return PartialView("EmployeePartial");


            //EmployeeViewModelView tmvm = new EmployeeViewModelView();
            //tmvm.EmplModelList = service.GetEmployeeList();
            //for (int i = 0; i < tmvm.EmplModelList.Count; i++)
            //{
            //    var images = new List<string>();
            //    tmvm.EmplModelList[i].UploadedFiles = new List<string>();
            //    images = tmvm.EmplModelList[i].FilePath.Split(',').ToList();
            //    tmvm.EmplModelList[i].UploadedFiles = images;
            //}
            //return PartialView("EmployeePartial", tmvm);
        }

        [HttpPost]
        public ActionResult AddEmployeeName(EmpModel user)
        {
            var userAPI = new EmpModelAPI();
            userAPI.Id = user.Id;
            userAPI.Name = user.Name;
            userAPI.Contact = user.Contact;
            userAPI.Status = user.Status;
            userAPI.Location = user.Location;
            userAPI.FilePath = user.FilePath;
            userAPI.FileName = user.FileName;
            userAPI.UploadedFiles = user.UploadedFiles;
            var result = JsonConvert.DeserializeObject<ResponseStatusModel>(Transaction.Post("/AddEmployee", userAPI).Content);
            response = result;
                var files = user.multiFiles;
                foreach (var file in user.multiFiles)
                {
                    //var ext = Path.GetExtension(user.FilePath);
                    if (file.ContentLength > 0)
                    {
                        string path = Server.MapPath("~/Models/"+file.FileName);
                        
                        file.SaveAs(Path.Combine(path));
                    }
                }
                return Json(response, JsonRequestBehavior.AllowGet);


            //var files = user.multiFiles;
            //foreach (var file in user.multiFiles)
            //{
            //    //var ext = Path.GetExtension(user.FilePath);
            //    if (file.ContentLength > 0)
            //    {
            //        file.SaveAs(Path.Combine(Server.MapPath("~/Models/"), file.FileName));
            //    }
            //}
            //    //ResponseStatusModel response = new ResponseStatusModel();
            //    //response = service.AddEmployee(user);
            //    //return Json(response, files[0].FileName, JsonRequestBehavior.AllowGet);



            //    //var files = user.multiFiles;
            //    //foreach (var file in user.multiFiles)
            //    //{
            //    //    //var ext = Path.GetExtension(user.FilePath);
            //    //    if (file.ContentLength > 0)
            //    //    {
            //    //        file.SaveAs(Path.Combine(Server.MapPath("~/Models/"), file.FileName));
            //    //    }
            //    //}

            //    //var file = user.ImageFile;
            //    //var ext = Path.GetExtension(user.FilePath);
            //    //if (file != null || ext.ToLower() == ".jpg" || ext.ToLower() == ".jpeg" || ext.ToLower() == ".png")
            //    //{
            //    //    file.SaveAs(Server.MapPath("~/Models/") + file.FileName);
            //    //}
            //    //ResponseStatusModel response = new ResponseStatusModel();
            //    //response = service.AddEmployee(user);
            //    //return Json(response, files[0].FileName, JsonRequestBehavior.AllowGet);
        
        }


        [HttpGet]
        public ActionResult ViewemployeeName(int Id)
        {
            EmployeeViewModelView view = new EmployeeViewModelView();
            var result = JsonConvert.DeserializeObject<EmployeeViewModelView>(Transaction.Get("/ViewEmployee?Id=" + Id).Content);
            return Json(result, JsonRequestBehavior.AllowGet);


            //EmployeeViewModelView evmv = new EmployeeViewModelView();
            //try
            //{
            //    evmv.EmpModel = service.ViewemployeeName(id);
            //    return Json(evmv, JsonRequestBehavior.AllowGet);
            //}
            //catch (Exception ex)
            //{
            //    return Json(evmv, JsonRequestBehavior.AllowGet);
            //}
        }
        [HttpGet]
        public ActionResult RemoveEmployeeName(EmpModel user)
        {
            var result = JsonConvert.DeserializeObject<ResponseStatusModel>(Transaction.Get("/RemoveEmployee?Id=" + user.Id).Content);
            response = result;
            if(result != null)
            {
                var imagesarry = new List<string>();
                imagesarry = response.DeleteFile.Split(',').ToList();

                for (int i = 0; i < imagesarry.Count; i++)
                {
                    string filePath = Server.MapPath("~/Models/") + imagesarry[i];
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            return Json(response, JsonRequestBehavior.AllowGet);

            //ResponseStatusModel response = new ResponseStatusModel();
            //response = service.RemoveEmployee(Id);
            //var imagesarry = new List<string>();
            //imagesarry = response.DeleteFile.Split(',').ToList();

            //for (int i = 0; i < imagesarry.Count; i++)
            //{
            //    string filePath = Server.MapPath("~/Models/") + imagesarry[i];
            //    if (System.IO.File.Exists(filePath))
            //    {
            //        System.IO.File.Delete(filePath);
            //    }
            //}
            //response = service.RemoveEmployee(Id);
            //return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateEmployee(EmpModel user)
        {
            var userAPI = new EmpModelAPI();
            userAPI.Id = user.Id;
            userAPI.Name = user.Name;
            userAPI.Contact = user.Contact;
            userAPI.Status = user.Status;
            userAPI.Location = user.Location;
            userAPI.FilePath = user.FilePath;
            userAPI.FileName = user.FileName;
            userAPI.UploadedFiles = user.UploadedFiles;

            var result = JsonConvert.DeserializeObject<ResponseStatusModel>(Transaction.Post("/UpdateEmployee", userAPI).Content);
            response = result;
            if (result != null)
            {
                var files = user.multiFiles;

                foreach (var file in user.multiFiles)
                {
                    var ext = Path.GetExtension(user.FilePath);
                    if ((file != null || file != null || ext.ToLower() == ".jpg" || ext.ToLower() == ".jpeg" || ext.ToLower() == ".png") && file.ContentLength > 0)
                    {
                        file.SaveAs(Path.Combine(Server.MapPath("~/Models/"), file.FileName));

                    }
                }
                return Json(response, JsonRequestBehavior.AllowGet);

            }
            return Json(response, JsonRequestBehavior.AllowGet);


            //ResponseStatusModel response = new ResponseStatusModel();
            //response = service.UpdateEmployee(temp);
            //return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}