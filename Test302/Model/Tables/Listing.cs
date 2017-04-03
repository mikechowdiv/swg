﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Tables
{
   public class Listing
    {
        public int ListingId { get; set; }
        public string UserId { get; set; }
        public string StateId { get; set; }
        public int MakesId { get; set; }
        public int Year { get; set; }
        public string City { get; set; }
        public decimal Rate { get; set; }
        public decimal Mileage { get; set; }
        public bool isNew { get; set; }
        public bool isManual { get; set; }
        public string ListingDescription { get; set; }
        public string ImageFileName { get; set; }
    }
}
