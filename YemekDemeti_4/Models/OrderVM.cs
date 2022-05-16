using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YemekDemeti_4.Models
{
    public class OrderVM
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public System.DateTime OrderTime { get; set; }
        public string RestaurantName { get; set; }
        public int RestaurantID { get; set; }
        public bool Confirmed { get; set; }
        public bool Delivered { get; set; }
        public int Score { get; set; }
        public int AddressID { get; set; }
    }
}