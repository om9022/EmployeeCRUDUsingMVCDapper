using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employeemodel
{
    public class ContryModel
    {
        public int ContryId { get; set; }
        public string ContryName { get; set; }
    }
    public class StateModel
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public int ContryId { get; set; }
    }
    public class CityModel
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }
    }
    public class StateCityViewModel
    {
        public List<ContryModel> ContryModelList { get; set; }
        public List<StateModel> StateModelList { get; set; }
        public List<CityModel> CityModelList { get; set; }
    }
   
}
