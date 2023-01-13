
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Employee.Service
{
    public class Transaction
    {
        public static string ServerURL = ConfigurationManager.AppSettings["ServerURL"].ToString();
        public static IRestResponse Get(string relativePath)
        {
            var client = new RestClient(ServerURL + relativePath);
            var request = new RestRequest(Method.GET);
            return client.Execute(request);
        }

        public static IRestResponse Post(string relativePath, object data)
        {
            var client = new RestClient(ServerURL + relativePath);
            var request = new RestRequest(Method.POST);
            request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);
            return client.Execute(request);
        }

        public static IRestResponse GetXML(string relativePath)
        {
            IRestClient restClient = new RestClient();
            IRestRequest request = new RestRequest(ServerURL + "/GetLocationList");
            request.AddHeader("Accept", "application/xml");
            return restClient.Execute(request);
        }
    }
}