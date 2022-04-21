using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGP.Data
{
    [Table("AdminFamily")]
    public class AdminFamily
    {


        [Key]
        [Required]
        public long idAdminFamily { get; set; } 

        public string phone { get; set; }

        [Required]
        public long idFamily { get; set; }

        [Required]
        public long idGiaPha { get; set; }
        //asd
        //[ForeignKey("idGiaPha")]
        //public IDGiaPha IDGiaPha { get; set; }
        //[ForeignKey("idFamily")]
        //public Family Family { get; set; }

        // 
        /// public virtual ICollection<ClientManager> ClientManagers { get; set; }
    }
}
