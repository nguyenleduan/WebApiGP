using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGP.Data
{
    [Table("Family")]
    public class Family
    { 

        [Key]
        [Required]
        public long idFamily { get; set; }
        public long bigIdFamily { get; set; }
        [Required]
        public long idGiaPha { get; set; } 
        public long idLocationHome { get; set; }  


        //asd
        //[ForeignKey("idClientDeail")]
        //public ClientDeail ClientDeail { get; set; }
        //[ForeignKey("idLocationHome")]
        //public LocationHome LocationHome { get; set; }

        //// 
        // public virtual ICollection<Client> Client { get; set; }

    }
}
