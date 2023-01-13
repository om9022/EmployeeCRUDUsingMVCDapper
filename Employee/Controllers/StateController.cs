using Employee.Service;
using Employeemodel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee.Controllers
{
    public class StateController : Controller
    {
        // GET: State
        public ActionResult Index()
        {
            var result = JsonConvert.DeserializeObject<StateCityViewModel>(Transaction.Get("/GetContryList").Content);
            var stringTemp = "";
            if (result.ContryModelList != null)
            {
                foreach (var item in result.ContryModelList)
                {
                    stringTemp += String.Format("<option value={0}>{1}</option>", item.ContryId, item.ContryName);
                }
                ViewBag.ContryModelList = stringTemp;
            }
            return View();
        }
        
        [HttpGet]
        public ActionResult GetStateList(int ContryId)
        {
            var result = JsonConvert.DeserializeObject<StateCityViewModel>(Transaction.Get("/GetStateList?ContryId="+ ContryId).Content);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetCityList(int StateId)
        {
            var result = JsonConvert.DeserializeObject<StateCityViewModel>(Transaction.Get("/GetCityList?StateId=" + StateId).Content);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}