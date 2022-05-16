using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YemekDemeti_4.Data.Entities
{
    public class RestaurantSpecificFood :Foods
    {
        public int RestaurantID { get; set; }

        [Required]
        [StringLength(30)]
        public string RestaurantSpecificName { get; set; }

        [Required]
        public decimal RestaurantSpecificUnicPrice { get; set; }


        public string RestaurantSpecificImage { get; set; }
        public int NumberOfSales { get; set; }
    }
}