using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Money_Finder.Models
{
    public class CcpaOptOut
    {
        [Key]
        public int CcpaOptOutId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string TypeRequest { get; set; }
        public string Message { get; set; }
        public string Archive { get; set; }
    }
}
