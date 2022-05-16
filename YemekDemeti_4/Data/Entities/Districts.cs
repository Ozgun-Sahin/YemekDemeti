using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YemekDemeti_4.Data.Entities
{
    public class Districts
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public int CityID { get; set; }

        [ForeignKey("CityID")]
        public virtual Cities Cities { get; set; }

    }
}