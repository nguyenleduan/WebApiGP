using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGP.Data
{
    [Table("LocationHome")]
    public class LocationHome
    {
        [Key]
        [Required]
        public long idLocationHome { get; set; }
        public string name { get; set; }  
        public double longitude { get; set; }  
        public double latiude { get; set; }  
    }
}
