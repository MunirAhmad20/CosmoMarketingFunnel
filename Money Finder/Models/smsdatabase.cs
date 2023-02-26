using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Money_Finder.Models
{
    public class SmsDataBase
    {
        [Key]
        public int SmsDataBaseId { get; set; }

        public string Gmail { get; set; }
        public string Phone { get; set; }
        public string Optin { get; set; }
        public string OptOut { get; set; }
    }
}
