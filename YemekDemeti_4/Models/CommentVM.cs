using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YemekDemeti_4.Models
{
    public class CommentVM
    {
        public int ID { get; set; }
        public int RestaurantID { get; set; }
        public string _Comment { get; set; }
        public bool Confirm { get; set; }
        public bool Submitted { get; set; }
        public int OrderID { get; set; }
        public int Score { get; set; }

    }
}