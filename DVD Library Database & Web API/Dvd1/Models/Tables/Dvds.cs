﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Tables
{
    public class Dvds
    {
        public int dvdId { get; set; }
        public string title { get; set; }
        public string releaseYear { get; set; }
        public string director { get; set; }
        public string rating { get; set; }
        public string notes { get; set; }

    }
}
