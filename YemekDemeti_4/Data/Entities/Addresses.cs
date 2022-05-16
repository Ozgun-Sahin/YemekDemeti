using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YemekDemeti_4.Data.Entities
{
    public class Addresses
    {
        [Key]
        public int ID { get; set; }

        public int CustomerID { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Customers Customers { get; set; }

        
        public int CityID { get; set; }
        [ForeignKey("CityID")]
        public virtual Cities Cities { get; set; }

        public int  DistrictID { get; set; }

        [ForeignKey("DistrictID")]
        public virtual Districts Districts { get; set; }

        [Required]
        public string AddressLine1 { get; set; }

        [Required]
        public string AdressTitle { get; set; }
    }
}