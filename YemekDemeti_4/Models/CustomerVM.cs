using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YemekDemeti_4.Models
{
    public class CustomerVM
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Lütfen kullanıcı adınızı giriniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Lütfen şifrenizi giriniz")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Image { get; set; }
        public string Role { get; set; }

        [Required(ErrorMessage ="Lütfen telefon numaranızı giriniz")]
        public int Phone { get; set; }

    }
}