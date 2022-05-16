using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YemekDemeti_4.Models
{
    public class RestaurantVM
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [Required(ErrorMessage = "isim giriniz")]
        public string AdminName { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public int DistrictID { get; set; }
        public string Role { get; set; }
    }
}