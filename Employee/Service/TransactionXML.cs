//using Employeemodel;
//using RestSharp;
//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Linq;
//using System.Web;

//namespace Employee.Service
//{
//    public class TransactionXML
//    {
//        public static string ServerURL = ConfigurationManager.AppSettings["ServerURL"].ToString();
//        IRestClient restClient = new RestClient();
//        IRestRequest restRequest = new RestRequest(ServerURL);
//        IRestResponse<List<LocModel>> restResponse = RestClient.Get();



//        public static IRestResponse Get(string relativePath)
//        {
//            var deserializerVar = new RestSharp.Deserializers.DotNetXmlDeserializer();


//            var client = new RestClient(ServerURL + relativePath);
            
//            var request = new RestRequest(Method.GET);
//            request.AddHeader("Accept", "application/xml");
//            //IRestResponse<LocModel> restResponse = client.Get<LocModel>(request);
//            IRestResponse restResponse = client.Get(request);
//            LocModel data = deserializerVar.Deserialize<LocModel>(restResponse);

//            return client.Execute(request);
//        }


//    }


//}