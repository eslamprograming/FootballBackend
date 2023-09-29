using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.VenueVM
{
    public class VenueVM
    {
        public string VenueName { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }
        public string ContactInfo { get; set; }
    }
}
