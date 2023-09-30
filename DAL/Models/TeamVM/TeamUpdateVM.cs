using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.TeamVM
{
    public class TeamUpdateVM
    {
        [Required(ErrorMessage = "Enter Team Name")]
        public string TeamName { get; set; }
        
        [Required(ErrorMessage = "Enter Founded Year")]

        public int FoundedYear { get; set; }
        [Required(ErrorMessage = "Enter Home City")]

        public string HomeCity { get; set; }
        [Required(ErrorMessage = "Enter Home Stadium")]

        public string HomeStadium { get; set; }
        [Required(ErrorMessage = "Enter CoachName")]

        public string CoachName { get; set; }
        [Required(ErrorMessage = "Enter LeagueId")]

        public int LeagueId { get; set; }
    }
}
