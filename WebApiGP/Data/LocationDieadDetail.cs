using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGP.Data
{
    [Table("LocationDieadDetail")]
    public class LocationDieadDetail
    {
        [Key]
        [Required]
        public long idLocationDiedDetail { get; set; }
        public string name { get; set; }
        public double longitude { get; set; }
        public double latiude { get; set; }
    }
}
