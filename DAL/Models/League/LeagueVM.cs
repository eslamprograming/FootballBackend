using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.League
{
    public class LeagueVM
    {
        [Required(ErrorMessage ="Enter League Name")]
        public string LeagueName { get; set; }
        [Required(ErrorMessage = "Enter League Logo")]

        public IFormFile LeagueLogo { get; set; }
        [Required(ErrorMessage = "Enter Season")]

        public string Season { get; set; }
        [Required(ErrorMessage = "Enter Start Date")]

        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Enter End Date")]

        public DateTime EndDate { get; set; }
    }
}
