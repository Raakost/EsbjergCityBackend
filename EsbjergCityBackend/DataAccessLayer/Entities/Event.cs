﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Event : AbstractId
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public DateTime DateOfEvent { get; set; }
    }
}
        