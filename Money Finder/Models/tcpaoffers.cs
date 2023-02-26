using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Money_Finder.Models
{
    public class TcpaOffers
    {
        [Key]
        public int TcpaOffersId { get; set; }
      
        public string OfferName { get; set; }
       
        public string Archive { get; set; }

        public string Description { get; set; }
        public string BulletPoint { get; set; }
        public string Date { get; set; }
      

    }
}
