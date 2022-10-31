using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITWORXAcademy.Products.Assignment.Entities
{
    public class Response<T> where T:class
    {
        public Response()
        {
            Success = true;
            Messages = new List<string>();
        }
        public bool Success { get; set; }
        public List<T> Results { get; set; }
        public List<string> Messages { get; set; }
    }
}
