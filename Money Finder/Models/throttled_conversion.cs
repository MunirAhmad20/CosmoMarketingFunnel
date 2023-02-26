using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Money_Finder.Models
{
    public class throttled_conversion
    {
        [Key]
        public string throttled_conversionid { get; set; }
        public string today { get; set; }
        public string yesterday { get; set; }
        public string current_month { get; set; }
        public string last_month { get; set; }
        public string trending_percentage { get; set; }
    }
}
