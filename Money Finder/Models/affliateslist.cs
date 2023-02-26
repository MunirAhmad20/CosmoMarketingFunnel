using Money_Finder.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Money_Finder.Models
{
    public class affliateslist
    {

        [Key]
        public string eveflowid { get; set; }
        public virtual affiliates affiliates { get; set; }
        //public virtual account_manager account_manager { get; set; }
        //public virtual account_executive account_executive { get; set; }
    
    }
}
