using EmployeeBAL;
using Employeemodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee.Controllers
{
    public class RegistrationController : Controller
    {
        RegistrationService service = new RegistrationService();
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UserPartial()
        {
            RegistrationViewModel md = new RegistrationViewModel();
            md.RegistrationModelList = service.GetUserList();
            return PartialView("UserPartial", md);
        }
        [HttpPost]
        public ActionResult AddUser(RegistrationModel user)
        {
            ResponseStatusModel res = new ResponseStatusModel();
            res = service.AddUser(user);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        //[HttpGet]
        //public ActionResult ViewUser(int Id)
        //{
        //    RegistrationViewModel md = new RegistrationViewModel();

        //    md.RegModels = service.ViewUserList(Id);
        //    return Json(md, JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        //public ActionResult UpdateUser(RegistrationModel model)
        //{
        //    ResponseStatusModel response = new ResponseStatusModel();
        //    response = service.UpdateUser(model);
        //    return Json(model, JsonRequestBehavior.AllowGet);
        //}

        //[HttpGet]
        //public ActionResult RemoveUser(int Id)
        //{
        //    ResponseStatusModel res = new ResponseStatusModel();
        //    res = service.RemoveUser(Id);
        //    return Json(res, JsonRequestBehavior.AllowGet);
        //}


    }
}