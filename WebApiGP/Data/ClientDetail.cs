using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGP.Data
{
    [Table("ClientDetail")]
    public class ClientDetail
    {
        [Key] 
        public long idClientDetail { get; set; } 
        public string firstName { get; set; } 
        public string lastName { get; set; }
        public string birthDay { get; set; }
        public string diedDay { get; set; }
        public string phone { get; set; }
        public string avatar { get; set; } 
        public Nullable<int> status { get; set; }
        public Nullable<long> idGiaPhaChild { get; set; } 
        public Nullable<long> idFamily { get; set; }
        public Nullable<long> idLocationDied { get; set; }
        public Nullable<long> idLocationHome { get; set; }


        //asd 
        //[ForeignKey("idLocationDied")]
        //public LocationDied LocationDied { get; set; } 
    }
}
