using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGP.Models
{
    public class User: InfoUSer
    {
        public Guid Id { get; set; } 
    }
    public class InfoUSer
    {
        public String Name { get; set; }
        public String Address { get; set; }
        public double Count { get; set; }

    }
}
