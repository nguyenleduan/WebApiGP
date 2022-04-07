using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGP.Data
{
    [Table("User")]
    public class User
    {   [Key]
        public Guid idUser { get; set; }
        [Required]
        [MaxLength(100)]
        public String name { get; set; }
        public String address { get; set; }   
        public String phone { get; set; }  
        [Range(0,double.MaxValue)]
        public double count { get; set; }  

    }
}
