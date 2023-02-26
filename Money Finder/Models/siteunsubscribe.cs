using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Money_Finder.Models
{
    public class SiteUnSubscribe
    {
        [Key]
        public int SiteUnSubscribeId { get; set; }
       
        public string Email { get; set; }
    }
}
