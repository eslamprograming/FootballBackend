using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Player
    {
        [Key]

        public int PlayerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string Position { get; set; }
        public int ShirtNumber { get; set; }
        public int CurrentTeamID { get; set; }
        public Team CurrentTeam { get; set; }
        public bool Delete { get; set; }

    }
}
