using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Queries
{
    public class ListingShortItem
    {
        public int ListingId { get; set; }
        public string UserId { get; set; }
        public decimal Rate { get; set; }
       // public string StateId { get; set; }
       public int Year { get; set; }
      public string City { get; set; }
       //public string Makes { get; set; }
        public string ImageFileName { get; set; }
    }
}
