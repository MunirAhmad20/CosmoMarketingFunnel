using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Money_Finder.Models
{
    public class PopUp
    {
        [Key]
        public int PopUpId { get; set; }
        public string AffliateId { get; set; }
        public string OfferId { get; set; }
        public string Image { get; set; }
        public string OfferName { get; set; }
        public string RedirectLink { get; set; }
        public string Archive { get; set; }
        public string BudgetDuration { get; set; }
        public string Budget { get; set; }
        public string LeadCapDuration { get; set; }
        public string LeadCap { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; }
        public string PriorityIndex { get; set; }
        public string Switch { get; set; }
        public string Date { get; set; }
        public string Notes { get; set; }
        public string Website { get; set; }
    }
}
