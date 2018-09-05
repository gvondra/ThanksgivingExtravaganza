using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExtravaganzaAPI.Models
{
    public class Menu
    {
        public int MenuId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
        public DateTime CreateTimestamp { get; set; }
        public DateTime UpdateTimestamp { get; set; }
    }
}
