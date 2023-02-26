using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Money_Finder.Models
{
    public class OfferStates
    {
        [Key]
        public int OfferStatesId { get; set; }
        public string OfferId { get; set; }
        public string OfferType { get; set; }
        public string States { get; set; }
        public string Status { get; set; }
       

        
    }
}
