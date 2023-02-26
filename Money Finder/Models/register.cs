using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Money_Finder.Models
{
    public class Register
    {
        [Key]
        public int RegisterId { get; set; }
   
        public string FirstName { get; set; }
        public string LeadId { get; set; }
        public string TransactionID { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CheckingAccount { get; set; }
        public string NetSpend { get; set; }
        public string DeviceId { get; set; }
        public string DeviceType { get; set; }
        public string IpAddress { get; set; }
        public string Forms { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Gender { get; set; }
        public string Dob { get; set; }
        public string Age { get; set; }
        public string Date { get; set; }
        public string SourceOne { get; set; }
        public string WebsiteId { get; set; }
        public string Archive { get; set; }
        


    }
}
