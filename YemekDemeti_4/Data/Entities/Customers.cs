using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YemekDemeti_4.Data.Entities
{
    public class Customers
    {
        [Key]
        public int ID { get; set; }

        [StringLength(20)]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        public string Image { get; set; }
        public string Role { get; set; }

        [MinLength(8),MaxLength(8)]
        public string GSM { get; set; }
    }
}