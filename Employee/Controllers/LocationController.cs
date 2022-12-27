using Employeemodel;
using LocationBAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee.Controllers
{
    public class LocationController : Controller
    {
        LocationService ls = new LocationService();
        // GET: Location
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LocationPartial()
        {
            LocationModelViewModel tmvm = new LocationModelViewModel();

                tmvm.LocationList = ls.GetLocationList();
                return PartialView("LocationPartial", tmvm);
          

        }

        [HttpPost]
        public ActionResult AddLocationName(LocModel temp)
        {
            ResponseStatusModel response = new ResponseStatusModel();
                response = ls.AddLocationName(temp);
                return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ViewLocationName(int Id)
        {
            LocationModelViewModel tmvm = new LocationModelViewModel();

                tmvm.LocationModels = ls.ViewLocations(Id);
                return Json(tmvm, JsonRequestBehavior.AllowGet);
        

        }

        [HttpGet]
        public ActionResult RemoveLocationName(int Id)
        {
            ResponseStatusModel response = new ResponseStatusModel();
 
                response = ls.RemoveLoation(Id);
                return Json(response, JsonRequestBehavior.AllowGet);
  
        }

        [HttpPost]
        public ActionResult UpdateLocationName(LocModel temp)
        {
            ResponseStatusModel response = new ResponseStatusModel();

                response = ls.UpdateLocation(temp);
                return Json(response, JsonRequestBehavior.AllowGet); 

        }
    }
}
