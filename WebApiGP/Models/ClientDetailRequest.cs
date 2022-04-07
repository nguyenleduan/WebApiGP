using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGP.Models
{
    public class ClientDetailRequest
    { 
        public string  firstName { get; set; }
        public string lastName { get; set; }
        public string birthDay { get; set; }
        public string diedDay { get; set; }
        public string phone { get; set; }
        public string avatar { get; set; }
        public int? status { get; set; }
        public long? idGiaPhaChild { get; set; }
        public long? idFamily { get; set; }
        public long? idLocationDied { get; set; }
        public long? idLocationHome { get; set; } 
    }
}
