using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGP.Data
{
    [Table("IDGiaPha")]
    public class IDGiaPha
    {
        [Key]
        [Required]
        public long idGiaPha { get; set; }
        [Required] 
        public string pass { get; set; } 
        [Required]
        public string author { get; set; }
        //public virtual ICollection<Admin> Admins { get; set; }
        //public virtual ICollection<ManagerIDGiaPha> ManagerIDGiaPhas { get; set; }
    }
}
