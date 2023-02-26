using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Money_Finder.Models
{
    public  class account_manager
    {
        [Key]
        public string dfd { get; set; }

        

        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string work_phone { get; set; }
        public string cell_phone { get; set; }
        public string instant_messaging_id { get; set; }
        public string instant_messaging_identifier { get; set; }
    }
}
