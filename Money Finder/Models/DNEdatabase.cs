using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Money_Finder.Models
{
    public class DneDataBase
    {
        [Key]
        public int DneDataBaseId { get; set; }

        public string Gmail { get; set; }
    }
}
