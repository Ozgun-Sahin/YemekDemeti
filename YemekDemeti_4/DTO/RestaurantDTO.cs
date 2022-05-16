using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YemekDemeti_4.DTO
{
    public class RestaurantDTO
    {
        
        public int ID { get; set; }

        [Required(ErrorMessage ="Restoran İsim Giriniz")]
        [StringLength(20)]
        public string Name { get; set; }
        public string Image { get; set; }
        public double Score { get; set; }
        public int DistrictID { get; set; }
        

        [Required(ErrorMessage ="İsim Giriniz")]
        [StringLength(20)]
        public string AdminName { get; set; }

        [Required(ErrorMessage ="Şifre Giriniz")]
   
        public string Password { get; set; }
        public string Role { get; set; }
    }
}