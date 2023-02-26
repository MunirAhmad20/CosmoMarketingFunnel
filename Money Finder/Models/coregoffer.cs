using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Money_Finder.Models
{
    public class CoregOffer
    {
        [Key]
        public int CoregOfferId { get; set; }
        public string AffliateId { get; set; }
        public string OfferId { get; set; }
        public string Image { get; set; }
        public string OfferTitle { get; set; }
        public string DiscriptionA { get; set; }
        public string DiscriptionB { get; set; }
        public string LowerTitle { get; set; }
        public string Validation { get; set; }
        public string Switch { get; set; }
        public string BudgetDuration { get; set; }
        public string Budget { get; set; }
        public string LeadCapDuration { get; set; }
        public string LeadCap { get; set; }

        public string Archive { get; set; }
        public string Priority { get; set; }
        public string PriorityIndex { get; set; }
        public string Date { get; set; }
        public string Notes { get; set; }
        public string Website { get; set; }
    }
}
