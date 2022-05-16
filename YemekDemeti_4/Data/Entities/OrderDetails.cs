using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YemekDemeti_4.Data.Entities
{
    public class OrderDetails
    {
        [Key]
        [Column(Order = 1)]
        public int OrderID { get; set; }
        [ForeignKey("OrderID")]
        public virtual Orders Orders { get; set; }


        [Key]
        [Column(Order = 2)]
        public int FoodID { get; set; }
        [ForeignKey("FoodID")]
        public virtual Foods Foods { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }
    }
}