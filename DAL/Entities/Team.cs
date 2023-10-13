using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Team
    {
        [Key]
        public int TeamID { get; set; }
        public string? TeamName { get; set; }
        public string? TeamLogo { get; set; }
        public int? FoundedYear { get; set; }
        public string? HomeCity { get; set; }
        public string? HomeStadium { get; set; }
        public string? CoachName { get; set; }
        public virtual ICollection<Player>? Players { get; set; }
        [JsonIgnore]
        public virtual ICollection<Match>? HomeMatches { get; set; }
        public int? LeagueId { get; set; }
        [ForeignKey("LeagueId")]
        public virtual League? League { get; set; }
        [JsonIgnore]
        public virtual ICollection<Match> AwayMatches { get; set; }
        public bool? Delete { get; set; }
    }
}
