using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YemekDemeti_4.Models
{
    public class FoodVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal UnicPrice { get; set; }
        public string image { get; set; }
        public int CategoryID { get; set; }

        public string Discriminator { get; set; }

    }
}