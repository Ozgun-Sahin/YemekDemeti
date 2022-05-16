using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YemekDemeti_4.Data.Entities
{
    public class Restaurants
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        public string Image { get; set; }
        public double Score { get; set; }
        public int DistrictID { get; set; }
        [ForeignKey("DistrictID")]
        public virtual Districts Districts { get; set; }

        [Required]
        [StringLength(20)]
        public string AdminName { get; set; }

        [Required]
        public String Password { get; set; }
        public string Role { get; set; }
    }
}