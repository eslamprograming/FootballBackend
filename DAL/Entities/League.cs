using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class League
    {
        [Key]

        public int LeagueID { get; set; }
        public string LeagueName { get; set; }
        public string Season { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<Match> Matches { get; set; } 
        public ICollection<Standings> Standings { get; set; } 
        public ICollection<Team> Teams { get; set; }    
        public bool Delete { get; set; }
    }
}
