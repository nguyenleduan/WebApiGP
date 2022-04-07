using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGP.Data
{
    [Table("LocationDied")]
    public class LocationDied
    {

        [Key]
        [Required]
        public long idLocationDied { get; set; } 
        public long idLocationDiedDetail { get; set; } 
    }
}
