using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Money_Finder.Models
{
    public class account_executive
    {
        [Key]

        public string eveflowid { get; set; }
        public int network_employee_id { get; set; }
        public int network_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string full_name { get; set; }
        public string account_status { get; set; }

    }
}
