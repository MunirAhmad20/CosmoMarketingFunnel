using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Money_Finder.Models
{
    public class offersinfo
    {

        [Key]
        public int Id { get; set; }
        public int network_offer_id { get; set; }
        public int network_id { get; set; }
        public int network_advertiser_id { get; set; }
        public int network_offer_group_id { get; set; }
        public string name { get; set; }
        public string thumbnail_url { get; set; }
        public int network_category_id { get; set; }
        public string internal_notes { get; set; }
        public string destination_url { get; set; }
        public string server_side_url { get; set; }
        public bool is_view_through_enabled { get; set; }
        public string view_through_destination_url { get; set; }
        public string preview_url { get; set; }
        public string offer_status { get; set; }
        public string currency_id { get; set; }
        public int caps_timezone_id { get; set; }
        public string project_id { get; set; }
        public string date_live_until { get; set; }
        public string html_description { get; set; }
        public bool is_using_explicit_terms_and_conditions { get; set; }
        public string terms_and_conditions { get; set; }
        public bool is_force_terms_and_conditions { get; set; }
        public bool is_caps_enabled { get; set; }
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
        public string redirect_mode { get; set; }
        public bool is_using_suppression_list { get; set; }
        public int suppression_list_id { get; set; }
        public bool is_must_approve_conversion { get; set; }
        public bool is_allow_duplicate_conversion { get; set; }
        public bool is_duplicate_filter_enabled { get; set; }
        public string duplicate_filter_targeting_action { get; set; }
        public int network_tracking_domain_id { get; set; }
        public bool is_use_secure_link { get; set; }
        public bool is_seo_friendly { get; set; }
        public bool is_allow_deep_link { get; set; }
        public bool is_session_tracking_enabled { get; set; }
        public string session_tracking_start_on { get; set; }
        public int session_tracking_lifespan_hour { get; set; }
        public int session_tracking_minimum_lifespan_second { get; set; }
        public bool is_view_through_session_tracking_enabled { get; set; }
        public int view_through_session_tracking_lifespan_minute { get; set; }
        public int view_through_session_tracking_minimal_lifespan_second { get; set; }
        public bool is_block_already_converted { get; set; }
        public string already_converted_action { get; set; }
        public bool is_fail_traffic_enabled { get; set; }
        public string redirect_routing_method { get; set; }
        public string redirect_internal_routing_type { get; set; }
        public string visibility { get; set; }
        public int time_created { get; set; }
        public int time_saved { get; set; }
        public string conversion_method { get; set; }
        public bool is_whitelist_check_enabled { get; set; }
        public bool is_use_scrub_rate { get; set; }
        public string scrub_rate_status { get; set; }
        public int scrub_rate_percentage { get; set; }
        public string session_definition { get; set; }
        public int session_duration { get; set; }
        public string app_identifier { get; set; }
        public bool is_description_plain_text { get; set; }
        public bool is_use_direct_linking { get; set; }
        public bool is_email_attribution_enabled { get; set; }
        public bool is_email_attribution_window_enabled { get; set; }
        public int email_attribution_window_minute { get; set; }
        public string email_attribution_window_type { get; set; }
        public Relationships relationship { get; set; }
    }

 
    public class Categoryy
    {
        [Key]
        public int Id { get; set; }
        public int network_category_id { get; set; }
        public int network_id { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public int time_created { get; set; }
        public int time_saved { get; set; }
    }

    public class Channelss
    {
        [Key]
        public int Id { get; set; }
        public int total { get; set; }
    
    }

    public class Entryy
    {
        [Key]
        public int Id { get; set; }
        public int network_offer_payout_revenue_id { get; set; }
        public int network_id { get; set; }
        public int network_offer_id { get; set; }
        public string entry_name { get; set; }
        public string payout_type { get; set; }
        public double payout_amount { get; set; }
        public int payout_percentage { get; set; }
        public string revenue_type { get; set; }
        public int revenue_amount { get; set; }
        public int revenue_percentage { get; set; }
        public bool is_default { get; set; }
        public bool is_private { get; set; }
        public bool is_postback_disabled { get; set; }
        public bool is_enforce_caps { get; set; }
        public int time_created { get; set; }
        public int global_advertiser_event_id { get; set; }
        public bool is_must_approve_conversion { get; set; }
        public bool is_allow_duplicate_conversion { get; set; }
        public bool is_email_attribution_default_event { get; set; }
    }

    public class Labelss
    {
        [Key]
        public int Id { get; set; }
        public int total { get; set; }

    }

    public class PayoutRevenuee
    {
        [Key]
        public int Id { get; set; }
        public int total { get; set; }

    }

    public class Relationshipp
    {
        [Key]
        public int Id { get; set; }
        public Categoryy category { get; set; }
        public Labelss labels { get; set; }
        public PayoutRevenuee payout_revenue { get; set; }
        public string encoded_value { get; set; }
        public bool is_locked_currency { get; set; }
        public Channelss channels { get; set; }
        public bool is_locked_caps_timezone { get; set; }
        public RequirementKpiss requirement_kpis { get; set; }
        public RequirementTrackingParameterss requirement_tracking_parameters { get; set; }
    }

    public class RequirementKpiss
    {
        [Key]
        public int Id { get; set; }
        public int total { get; set; }
     
    }

    public class RequirementTrackingParameterss
    {
        [Key]
        public int Id { get; set; }
        public int total { get; set; }
    
    }

  


}
