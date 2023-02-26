using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Money_Finder.Models
{
    public class Offers
    {
        [Key]
        public int OffersId { get; set; }
        public string Image { get; set; }
        public string OfferName { get; set; }
        public string RedirectLink { get; set; }
   
       
        public string Archive { get; set; }

        public string Date { get; set; }
        public string Notes { get; set; }
        public string Website { get; set; }

    }
}
