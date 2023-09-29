using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Standings
    {
        [Key]
        public int StandingID { get; set; }
        public int? LeagueID { get; set; }
        public League? League { get; set; }
        public int? TeamID { get; set; }
        public Team? Team { get; set; }
        public int? Wins { get; set; }
        public int? Draws { get; set; }
        public int? Losses { get; set; }
        public int? Points { get; set; }
        public int? GoalsFor { get; set; }
        public int? GoalsAgainst { get; set; }
        public bool? Delete { get; set; }

    }
}
