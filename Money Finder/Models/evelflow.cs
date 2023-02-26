using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Money_Finder.Models
{
    public class evelflow
    {
        [Key]
        public string eveflowid { get; set; }
       
     
        public virtual revenue revenue { get; set; }
        public virtual throttled_conversion throttled_conversion { get; set; }
        public virtual approved_conversion approved_conversion { get; set; }
        public virtual view_through_conversion view_through_conversion { get; set; }
        public virtual unique_click unique_click { get; set; }
        public virtual duplicate_click duplicate_click { get; set; }
        public virtual invalid_click invalid_click { get; set; }
        public virtual ctr ctr { get; set; }
        public virtual impression impression { get; set; }
        public virtual gross_click gross_click { get; set; }
        public virtual gross_sales gross_sales { get; set; }
        public virtual cpm cpm { get; set; }
        public virtual rpm rpm { get; set; }
        public virtual rpc rpc { get; set; }
        public virtual cpc cpc { get; set; }
        public virtual epc epc { get; set; }
        public virtual evr evr { get; set; }
        public virtual cvr cvr { get; set; }
        public virtual events events { get; set; }
        public virtual conversion conversion { get; set; }
        public virtual click click { get; set; }
        public virtual margin margin { get; set; }
        public virtual profit profit { get; set; }
        public virtual payout payout { get; set; }

      
        public virtual affiliates affiliates { get; set; }
        public virtual advertisers advertisers { get; set; }
        public virtual account_manager account_manager { get; set; }
        public virtual account_executive account_executive { get; set; }
        public virtual labels Labels { get; set; }


    }

}
