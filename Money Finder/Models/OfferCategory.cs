using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Money_Finder.Models
{
    public class OfferCategory
    {

        [Key]
        public int OfferCategoryid { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
    }
}
