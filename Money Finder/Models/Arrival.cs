using System;
using System.ComponentModel.DataAnnotations;

namespace Money_Finder.Models
{
    public class Arrival
    {
        [Key]
        public Guid ArrivalId { get; set; }
        public string SessionId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Url { get; set; }
        public string IpAddress { get; set; }
    }
}
