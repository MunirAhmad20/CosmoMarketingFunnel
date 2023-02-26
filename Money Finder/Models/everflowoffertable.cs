using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Money_Finder.Models
{
    public class everflowoffertable
    {
        [Key]
        public string id { get; set; }
        public List<Offer> offers { get; set; }
        public Paging paging { get; set; }
    }

    public class AccountManager
    {
        [Key]
        public string id { get; set; }
        public int network_employee_id { get; set; }
        public int network_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string full_name { get; set; }
        public string account_status { get; set; }
    }

    public class Country
    {
        [Key]
        public string id { get; set; }
        public int network_id { get; set; }
        public int network_targeting_country_id { get; set; }
        public int country_id { get; set; }
        public string label { get; set; }
        public string country_code { get; set; }
        public string targeting_type { get; set; }
        public string match_type { get; set; }
    }

    public class Offer
    {
        [Key]
        public string id { get; set; }
        public int network_offer_id { get; set; }
        public int network_id { get; set; }
        public int network_advertiser_id { get; set; }
        public string name { get; set; }
        public string offer_status { get; set; }
        public string thumbnail_url { get; set; }
        public string visibility { get; set; }
        public string network_advertiser_name { get; set; }
        public string category { get; set; }
        public int network_offer_group_id { get; set; }
        public int time_created { get; set; }
        public int time_saved { get; set; }
        public string payout { get; set; }
        public string revenue { get; set; }
        public string today_revenue { get; set; }
        public int daily_conversion_cap { get; set; }
        public int weekly_conversion_cap { get; set; }
        public int monthly_conversion_cap { get; set; }
        public int global_conversion_cap { get; set; }
        public int daily_payout_cap { get; set; }
        public int weekly_payout_cap { get; set; }
        public int monthly_payout_cap { get; set; }
        public int global_payout_cap { get; set; }
        public int daily_revenue_cap { get; set; }
        public int weekly_revenue_cap { get; set; }
        public int monthly_revenue_cap { get; set; }
        public int global_revenue_cap { get; set; }
        public int daily_click_cap { get; set; }
        public int weekly_click_cap { get; set; }
        public int monthly_click_cap { get; set; }
        public int global_click_cap { get; set; }
        public string destination_url { get; set; }
        public object labels { get; set; }
        public int today_clicks { get; set; }
        public bool is_force_terms_and_conditions { get; set; }
        public string project_id { get; set; }
        public object channels { get; set; }
        public Relationshippp relationship { get; set; }
        public string optimized_thumbnail_url { get; set; }
        public string currency_id { get; set; }
        public double revenue_amount { get; set; }
        public double payout_amount { get; set; }
        public double today_revenue_amount { get; set; }
        public int today_payout_amount { get; set; }
        public string payout_type { get; set; }
        public string revenue_type { get; set; }
        public int revenue_percentage { get; set; }
        public int payout_percentage { get; set; }
    }

    public class Paging
    {
        [Key]
        public string id { get; set; }
        public int page { get; set; }
        public int page_size { get; set; }
        public int total_count { get; set; }
    }

    public class Relationshippp
    {
        [Key]
        public string id { get; set; }
        public RemainingCaps remaining_caps { get; set; }
        public Ruleset ruleset { get; set; }
        public TrackingDomain tracking_domain { get; set; }
        public AccountManager account_manager { get; set; }
        public SalesManager sales_manager { get; set; }
    }

    public class RemainingCaps
    {
        [Key]
        public string id { get; set; }
        public int remaining_daily_payout_cap { get; set; }
        public int remaining_daily_revenue_cap { get; set; }
        public int remaining_daily_conversion_cap { get; set; }
        public int remaining_daily_click_cap { get; set; }
        public int remaining_weekly_payout_cap { get; set; }
        public int remaining_weekly_revenue_cap { get; set; }
        public int remaining_weekly_conversion_cap { get; set; }
        public int remaining_weekly_click_cap { get; set; }
        public int remaining_monthly_payout_cap { get; set; }
        public int remaining_monthly_revenue_cap { get; set; }
        public int remaining_monthly_conversion_cap { get; set; }
        public int remaining_monthly_click_cap { get; set; }
        public int remaining_global_payout_cap { get; set; }
        public int remaining_global_revenue_cap { get; set; }
        public int remaining_global_conversion_cap { get; set; }
        public int remaining_global_click_cap { get; set; }
    }

  

    public class Ruleset
    {
        [Key]
        public string id { get; set; }
        public int network_id { get; set; }
        public int network_ruleset_id { get; set; }
        public int time_created { get; set; }
        public int time_saved { get; set; }
        public List<object> platforms { get; set; }
        public List<object> device_types { get; set; }
        public List<object> os_versions { get; set; }
        public List<object> browsers { get; set; }
        public List<object> languages { get; set; }
        public List<Country> countries { get; set; }
        public List<object> regions { get; set; }
        public List<object> cities { get; set; }
        public List<object> dmas { get; set; }
        public List<object> mobile_carriers { get; set; }
        public List<object> connection_types { get; set; }
        public List<object> ips { get; set; }
        public bool is_block_proxy { get; set; }
        public bool is_use_day_parting { get; set; }
        public string day_parting_apply_to { get; set; }
        public int day_parting_timezone_id { get; set; }
        public List<object> days_parting { get; set; }
        public List<object> isps { get; set; }
        public List<object> brands { get; set; }
        public List<object> postal_codes { get; set; }
    }

    public class SalesManager
    {
        [Key]
        public string id { get; set; }
        public int network_employee_id { get; set; }
        public int network_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string full_name { get; set; }
        public string account_status { get; set; }
    }

    public class TrackingDomain
    {
        [Key]
        public string id { get; set; }
        public int network_tracking_domain_id { get; set; }
        public int network_id { get; set; }
        public string url { get; set; }
        public bool is_primary_domain { get; set; }
        public string domain_status { get; set; }
        public bool is_ssl_enabled { get; set; }
        public string notes { get; set; }
        public int time_created { get; set; }
        public int time_saved { get; set; }
        public string ownership { get; set; }
        public string html_static_redirect { get; set; }
        public string url_redirect { get; set; }
    }


}
