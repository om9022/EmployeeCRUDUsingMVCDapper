using EmployeeBAL;
using Employeemodel;
using System;
using System.Web.Mvc;

namespace Employee.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeService service = new EmployeeService();
        // GET: Employee
        
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EmployeePartial()
        {
            EmployeeViewModelView tmvm = new EmployeeViewModelView(); 
            tmvm.EmplModelList = service.GetEmployeeList();
            return PartialView("EmployeePartial", tmvm);
        }


        [HttpPost]
        public ActionResult AddEmployeeName(EmpModel temp)
        {
            ResponseStatusModel response = new ResponseStatusModel();
                response = service.AddEmployee(temp);
                return Json(response, JsonRequestBehavior.AllowGet);
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