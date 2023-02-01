using System;

namespace Employeemodel
{
    public class ResponseStatusModel
    {
        public int n { get; set; }
        public string Msg { get; set; }
        public string Status { get; set; }
        public string DeleteFile { get; set; }

        public static explicit operator ResponseStatusModel(string v)
        {
            throw new NotImplementedException();
        }
    }
}