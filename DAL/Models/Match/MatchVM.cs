﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Match
{
    public class MatchVM
    {
        public DateTime MatchDate { get; set; }
        public int HomeTeamID { get; set; }
        public int AwayTeamID { get; set; }
        public string Location { get; set; }
        public string RefereeName { get; set; }
        public int LeagueID { get; set; }
        public int VenueId { get; set; }
    }
}
