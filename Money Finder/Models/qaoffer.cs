using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Money_Finder.Models
{
    public class QaOffer
    {
        [Key]
        public int QaOfferId { get; set; }
     

        public string QaTitle { get; set; }
        public string Option{ get; set; }
        public string Validation{ get; set; }
        public string RedirectLink { get; set; }
        public string Archive { get; set; }
        public string Priority { get; set; }
        public string PriorityIndex { get; set; }
        public string Date { get; set; }
        public string Notes { get; set; }
        public string Website { get; set; }
    }
}
