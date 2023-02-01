using Employee.Service;
using Employeemodel;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;  
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Employee.Controllers
{
    public class LocationController : Controller
    {
        public static string ServerURL = ConfigurationManager.AppSettings["ServerURL"].ToString();


        //LocationService ls = new LocationService();
        ResponseStatusModel response = new ResponseStatusModel();
        // GET: Location
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LocationPartial()
        {
            //xml format
            var xmlData = Transaction.GetXML("/GetLocationList").Content;
            XDocument xDocument = XDocument.Parse(xmlData);
            string Default = "http://schemas.datacontract.org/2004/07/Employeemodel";
            XmlSerializer serializer = new XmlSerializer(typeof(LocationModelViewModel), Default);
            LocationModelViewModel view = (LocationModelViewModel)serializer.Deserialize(xDocument.CreateReader());
            return PartialView("LocationPartial", view);


        //json format
        // var result = JsonConvert.DeserializeObject<LocationModelViewModel>(Transaction.Get("/GetLocationList").Content);
        // //ResponseStatusModel res = new ResponseStatusModel();
        //// res = result.response;
        // if(result !=null && result.LocationList != null)
        // {
        //     return PartialView("LocationPartial", result);
        // }
        // return PartialView("LocationPartial");
        }

        [HttpPost]
        public ActionResult AddLocationName(LocModel temp)
        {
            //using xml
            string xmlcontent = string.Empty;
            var xmlserializer = new XmlSerializer(typeof(LocModel));
            using (var writer = new StringWriter())
            {
                xmlserializer.Serialize(writer, temp);
                xmlcontent = writer.ToString();
            }
            var xmlresult = Transaction.PostXML("/AddLocationName", xmlcontent).Content;
            XDocument document = XDocument.Parse(xmlresult);
            string abd = "http://schemas.datacontract.org/2004/07/Employeemodel";
            XmlSerializer serializer = new XmlSerializer(typeof(ResponseStatusModel),abd);
            response = (ResponseStatusModel)serializer.Deserialize(document.CreateReader());
            return Json(response, JsonRequestBehavior.AllowGet);

            //using json
            //var result = JsonConvert.DeserializeObject<ResponseStatusModel>(Transaction.Post("/AddLocationName",temp).Content);
            //response = result;
            //if(result != null)
            //{
            //    return Json(response, JsonRequestBehavior.AllowGet);
            //}
            //return Json(response, JsonRequestBehavior.AllowGet);
            //ResponseStatusModel response = new ResponseStatusModel();
            //    response = ls.AddLocationName(temp);
            //    return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ViewLocationName(LocModel model)
        {
           
            LocationModelViewModel view = new LocationModelViewModel();

            var result = JsonConvert.DeserializeObject<LocationModelViewModel>(Transaction.Get("/ViewLocationName?Id=" + model.Id).Content);
            return Json(result, JsonRequestBehavior.AllowGet);

            //LocationModelViewModel tmvm = new LocationModelViewModel();
            //tmvm.LocationModels = ls.ViewLocations(Id);
            //return Json(tmvm, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult RemoveLocationName(LocModel md)
        {
            var result = JsonConvert.DeserializeObject<ResponseStatusModel>(Transaction.Get("/RemoveLocationName?Id=" + md.Id).Content);
            response = result;
            if(result != null)
            {
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            return Json(response, JsonRequestBehavior.AllowGet);
            //ResponseStatusModel response = new ResponseStatusModel();
            //response = ls.RemoveLoation(Id);
            //return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdateLocationName(LocModel temp)
        {
            LocationModelViewModel view = new LocationModelViewModel();
            var result = JsonConvert.DeserializeObject<ResponseStatusModel>(Transaction.Post("/UpdateLocationName", temp).Content);
            response = result;
            if(result != null)
            {
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            return Json(response, JsonRequestBehavior.AllowGet);
            //ResponseStatusModel response = new ResponseStatusModel();
            //response = ls.UpdateLocation(temp);
            //return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}
