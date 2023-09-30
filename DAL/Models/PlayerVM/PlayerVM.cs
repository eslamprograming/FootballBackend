using DAL.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.PlayerVM
{
    public class PlayerVM
    {
        [Required(ErrorMessage ="Enter First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter Last Name")]

        public string LastName { get; set; }
        [Required(ErrorMessage = "Enter Player Photo")]

        public IFormFile PlayerPhoto { get; set; }
        [Required(ErrorMessage = "Enter DateOfBirth")]

        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Enter Nationality")]

        public string Nationality { get; set; }
        [Required(ErrorMessage = "Enter Position")]

        public string Position { get; set; }
        [Required(ErrorMessage = "Enter Shirt Number")]

        public int ShirtNumber { get; set; }
        [Required(ErrorMessage = "Enter Current Team")]

        public int CurrentTeamID { get; set; }
        
    }
}
