using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGP.Data
{
    [Table("ManagerIDGiaPha")]
    public class ManagerIDGiaPha
    {

        [Key]
        [Required]
        public long idManagerIDGiaPha { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string phone { get; set; }


        [Required]
        public long idGiaPha { get; set; }

        //asd
        //[ForeignKey("idGiaPha")]
        //public IDGiaPha IDGiaPha { get; set; } 
    }
}
