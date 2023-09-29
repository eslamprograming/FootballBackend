using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Match
    {
        [Key]

        public int MatchID { get; set; }
        public DateTime? MatchDate { get; set; }
        public int? HomeTeamID { get; set; }
        public Team? HomeTeam { get; set; }
        //public int AwayTeamID { get; set; }
        public string? AwayTeamName { get; set; }
        public int? HomeTeamScore { get; set; }
        public int? AwayTeamScore { get; set; }
        public string? Location { get; set; }
        public string? RefereeName { get; set; }
        public int? LeagueID { get; set; }
        public League? League { get; set; }
        public Venue? Venue { get; set; }
        public bool? Delete { get; set; }

    }
}
