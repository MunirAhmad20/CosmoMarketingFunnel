using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Money_Finder.Models
{
    public class affiliateinfo
    {
        [Key]
        public string revenueid { get; set; }
    

        public int network_affiliate_id { get; set; }
        public int network_id { get; set; }
        public string name { get; set; }
        public string account_status { get; set; }
        public int network_employee_id { get; set; }
        public string internal_notes { get; set; }
        public bool has_notifications { get; set; }
        public int network_traffic_source_id { get; set; }
        public int account_executive_id { get; set; }
        public int adress_id { get; set; }
        public string default_currency_id { get; set; }
        public bool is_contact_address_enabled { get; set; }
        public bool enable_media_cost_tracking_links { get; set; }
        public int time_created { get; set; }
        public int time_saved { get; set; }
        public int referrer_id { get; set; }
    }
}
