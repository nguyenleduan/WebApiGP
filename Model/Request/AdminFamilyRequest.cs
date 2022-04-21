using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGP.Models.Request
{
    public class AdminFamilyRequest
    { 
        public string phone { get; set; } 
        public long idFamily { get; set; } 
        public long idGiaPha { get; set; }
    }
}
