using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Money_Finder.Models
{
    public class Relationship
    {
        [Key]
        public string revueid { get; set; }

        public virtual labels Labels { get; set; }
        public virtual account_manager account_manager { get; set; }
    }
}
