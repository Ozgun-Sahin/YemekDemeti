using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YemekDemeti_4.Models
{
    public class AddressVM
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int CityID { get; set; }
        public string City { get; set; }
        public int DistrictID { get; set; }
        public string District { get; set; }
        public string AddressLine1 { get; set; }
        public string AdressTitle { get; set; }
    }
}