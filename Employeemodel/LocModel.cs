using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employeemodel
{
    public class LocModel
    {
        public int Id { get; set; }
        public int SrNo { get; set; }
        public string Location { get; set; }
        public int Active { get; set; }
    }

    public class LocationModelViewModel
    {
        public List<LocModel> LocationList { get; set; }
        public ResponseStatusModel response { get; set; }

        public LocModel LocationModels { get; set; }

    }
}
