using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Money_Finder.Models
{
    public class transaction
    {
        [Key]
        public int Id { get; set; }

        public string transactionid { get; set; }

    }
}
