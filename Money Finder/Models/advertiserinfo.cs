using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Money_Finder.Models
{
    public class advertiserinfo
    {
        [Key]
        public string revenueid { get; set; }
    

        public int network_advertiser_id { get; set; }
        public int network_id { get; set; }
        public string name { get; set; }
        public string account_status { get; set; }
        public int network_employee_id { get; set; }
        public string internal_notes { get; set; }
        public string sales_manager_id { get; set; }
        public string default_currency_id { get; set; }
        public string platform_name { get; set; }
        public string platform_url { get; set; }
        public string platform_username { get; set; }
        public int reporting_timezone_id { get; set; }
        public string accounting_contact_email { get; set; }
        public string verification_token { get; set; }
        public string offer_id_macro { get; set; }
        public int time_created { get; set; }
        public int time_saved { get; set; }
        public bool has_notifications { get; set; }

        public int network_traffic_source_id { get; set; }
        public int account_executive_id { get; set; }
        public int adress_id { get; set; }
       
        public bool is_contact_address_enabled { get; set; }
        public bool enable_media_cost_tracking_links { get; set; }
        public string email_attribution_method { get; set; }
        public string attribution_method { get; set; }
        public virtual account_manager account_manager { get; set; }
        public virtual labels labels { get; set; }
    }
}
