using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Money_Finder.Models
{
    public class gross_sales
    {
        [Key]
        public string gross_salesid { get; set; }
        public string today { get; set; }
        public string yesterday { get; set; }
        public string current_month { get; set; }
        public string last_month { get; set; }
        public string trending_percentage { get; set; }
    }
}
