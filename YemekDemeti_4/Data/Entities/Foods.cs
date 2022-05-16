using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace YemekDemeti_4.Data.Entities
{
    public class Foods
    {
        [Key]
        public int ID { get; set; }
        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public virtual Categories Categories { get; set; }
    }
}