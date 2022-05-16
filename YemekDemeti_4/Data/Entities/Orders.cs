using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YemekDemeti_4.Data.Entities
{
    public class Orders
    {
        [Key]
        public int ID { get; set; }

        public int CustomerID { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customers Customers { get; set; }

        public DateTime OrderTime { get; set; }

        public string RestaurantName { get; set; }

        public int RestaurantID { get; set; }

        public bool Confirmed { get; set; }

        public bool Delivered { get; set; }

        public int Score { get; set; }

        public int AddressID { get; set; }

    }
}