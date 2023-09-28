using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Venue
    {
        [Key]

        public int VenueID { get; set; }
        public string VenueName { get; set; }
        public int Capacity { get; set; }
        public string Location { get; set; }
        public string ContactInfo { get; set; }
        public ICollection<Match> Matches { get; set; }
        public bool Delete { get; set; }

    }
}
