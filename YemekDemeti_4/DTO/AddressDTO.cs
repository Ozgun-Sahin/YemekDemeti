using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YemekDemeti_4.DTO
{
    public class AddressDTO
    {
        [Key]
        public int ID { get; set; }

        public int CustomerID { get; set; }

        public int CityID { get; set; }
   
        public int DistrictID { get; set; }

        [Required(ErrorMessage ="Adres giriniz")]
        public string AddressLine1 { get; set; }

        [Required(ErrorMessage ="Başlık Giriniz")]
        public string AdressTitle { get; set; }
    }
}