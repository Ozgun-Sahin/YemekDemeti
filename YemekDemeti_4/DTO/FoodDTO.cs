using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YemekDemeti_4.DTO
{
    public class FoodDTO
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }

        public int RestaurantID { get; set; }

        [Required(ErrorMessage ="İsim Giriniz")]
        [StringLength(30)]
        public string RestaurantSpecificName { get; set; }

        [Required(ErrorMessage = "Fiyat Giriniz")]
        public decimal RestaurantSpecificUnicPrice { get; set; }
        public string RestaurantSpecificImage { get; set; }
        public int NumberOfSales { get; set; }

        public string Discriminator { get; set; }
    }
}