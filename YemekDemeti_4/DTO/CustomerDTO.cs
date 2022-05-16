using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YemekDemeti_4.DTO
{
    public class CustomerDTO
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Lütfen Bir Ad Giriniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen Bir Şifre Giriniz")]
        public string Password { get; set; }

        public string Image { get; set; }

        public string Role { get; set; }

        [Required(ErrorMessage = "Lütfen Bir Telefon Giriniz")]
        [MaxLength(8,ErrorMessage = "Lütfen Geçerli Bir Telefon Numarası Giriniz")]
        [MinLength(8,ErrorMessage = "Lütfen Geçerli Bir Telefon Numarası Giriniz")]
        public string GSM { get; set; }
 
    }
}