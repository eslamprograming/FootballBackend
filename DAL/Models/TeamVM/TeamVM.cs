using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.TeamVM
{
    public class TeamVM
    {
        public string TeamName { get; set; }
        public string TeamLogo { get; set; }
        public int FoundedYear { get; set; }
        public string HomeCity { get; set; }
        public string HomeStadium { get; set; }
        public string CoachName { get; set; }
        public int LeagueId { get; set; }


    }
}
