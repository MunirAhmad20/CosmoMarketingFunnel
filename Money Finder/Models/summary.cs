using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Money_Finder.Models
{
    public class root
    {
        [Key]
        public string id { get; set; }
        public Summary summary { get; set; }
        public List<Performance> performance { get; set; }
        public bool incomplete_results { get; set; }
        public List<Table> table { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Column
    {
        [Key]
        public string cid { get; set; }
        public string column_type { get; set; }
        public string id { get; set; }
        public string label { get; set; }
    }

    public class Performance
    {
        [Key]
        public string id { get; set; }
        public string unix { get; set; }
        public Reporting reporting { get; set; }
    }

    public class Reporting
    {
        [Key]
        public string id { get; set; }
        public string imp { get; set; }
        public string total_click { get; set; }
        public string unique_click { get; set; }
        public string invalid_click { get; set; }
        public string duplicate_click { get; set; }
        public string gross_click { get; set; }
        public string ctr { get; set; }
        public string cv { get; set; }
        public string invalid_cv_scrub { get; set; }
        public string view_through_cv { get; set; }
        public string total_cv { get; set; }
        public string @event { get; set; }
        public string cvr { get; set; }
        public string evr { get; set; }
        public string cpc { get; set; }
        public string cpm { get; set; }
        public string cpa { get; set; }
        public string epc { get; set; }
        public string rpc { get; set; }
        public string rpa { get; set; }
        public string rpm { get; set; }
        public string payout { get; set; }
        public string revenue { get; set; }
        public string event_revenue { get; set; }
        public string gross_sales { get; set; }
        public string profit { get; set; }
        public string margin { get; set; }
        public string roas { get; set; }
        public string avg_sale_value { get; set; }
    }

   
    public class Summary
    {
        [Key]
        public string id { get; set; }
        public string imp { get; set; }
        public string total_click { get; set; }
        public string unique_click { get; set; }
        public string invalid_click { get; set; }
        public string duplicate_click { get; set; }
        public string gross_click { get; set; }
        public string ctr { get; set; }
        public string cv { get; set; }
        public string invalid_cv_scrub { get; set; }
        public string view_through_cv { get; set; }
        public string total_cv { get; set; }
        public string @event { get; set; }
        public string cvr { get; set; }
        public string evr { get; set; }
        public string cpc { get; set; }
        public string cpm { get; set; }
        public string cpa { get; set; }
        public string epc { get; set; }
        public string rpc { get; set; }
        public string rpa { get; set; }
        public string rpm { get; set; }
        public string payout { get; set; }
        public string revenue { get; set; }
        public string event_revenue { get; set; }
        public string gross_sales { get; set; }
        public string profit { get; set; }
        public string margin { get; set; }
        public string roas { get; set; }
        public string avg_sale_value { get; set; }
    }

    public class Table
    {
        [Key]
        public string id { get; set; }
        public List<Column> columns { get; set; }
        public Reporting reporting { get; set; }
        public List<object> usm_columns { get; set; }
    }


}
