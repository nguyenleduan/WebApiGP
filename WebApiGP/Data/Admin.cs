using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGP.Data
{
    [Table("Admin")]
    public class Admin
    {

        [Key]
        [Required]
        public long idAdmin { get; set; }
        [Required]
        public long idGiaPha { get; set; }
        [Required]
        public string phone { get; set; }

        // khoa ngoai
        //[ForeignKey("idGiaPha")]
        //public IDGiaPha IDGiaPha { get; set; }
    }
}
