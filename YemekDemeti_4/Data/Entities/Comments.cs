using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YemekDemeti_4.Data.Entities
{
    public class Comments
    {
        [Key]
        public int ID { get; set; }
        public int RestaurantID { get; set; }
        [ForeignKey("RestaurantID")]
        public virtual Restaurants Restaurants { get; set; }


        [Required]
        public string _Comment { get; set; }

        public bool Confirm { get; set; }
        public bool Submitted { get; set; }

        public int OrderID { get; set; }
        [ForeignKey("OrderID")]
        public virtual Orders Orders { get; set; }

        public int Score { get; set; }

    }
}