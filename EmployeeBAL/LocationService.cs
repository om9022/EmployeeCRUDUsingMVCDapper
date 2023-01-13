//using Employeemodel;
//using LocationDAL;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LocationBAL
//{
//    public class LocationService
//    {
//        LocationRepository repo = new LocationRepository();

//        public List<LocModel> GetLocationList()
//        {
//            return repo.GetLocationList();
//        }

//        public LocModel ViewLocations(int Id)
//        {
//            return repo.ViewLocations(Id);
//        }

//        public ResponseStatusModel AddLocationName(LocModel model)
//        {
//            return repo.AddLocation(model);
//        }
//        public ResponseStatusModel UpdateLocation(LocModel md)
//        {
//            return repo.UpdateLocation(md);
//        }

//        public ResponseStatusModel RemoveLoation(int Id)
//        {
//            return repo.RemoveLocation(Id);
//        }

//        public List<LocModel> GetLocationNameDropdownList()
//        {
//            return repo.GetLocationNameDropdownList();
//        }
//    }
//}
