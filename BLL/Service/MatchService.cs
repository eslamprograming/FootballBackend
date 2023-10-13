using BLL.IService;
using DAL.Entities;
using DAL.IRepo;
using DAL.Models.Match;
using DAL.Models.SheardVM;
using DAL.Models.StandingsVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class MatchService : IMatchService
    {
        private readonly IMatchRepo _matchRepo;
        private readonly IStandingsService _standingsService;
        public MatchService(IMatchRepo matchRepo, IStandingsService standingsService)
        {
            _matchRepo = matchRepo;
            _standingsService = standingsService;
        }

        public async Task<Response<Match>> CreateMatchsAsync(MatchVM MatchsVM)
        {
            try
            {
                Match match = new Match();
                match.MatchDate = MatchsVM.MatchDate;
                match.HomeTeamID = MatchsVM.HomeTeamID;
                match.AwayTeamID = MatchsVM.AwayTeamID;
                match.Location = MatchsVM.Location;
                match.RefereeName = MatchsVM.RefereeName;
                match.LeagueID = MatchsVM.LeagueID;
                match.VenueId = MatchsVM.VenueId;
                match.Delete = false;

                var result = await _matchRepo.CreateMatchRepo(match);

                return result;
            }
            catch (Exception e)
            {
                return new Response<Match>
                {
                    success = false,
                    statuscode = "500",
                    message = e.Message
                };
            }
        }

        public async Task<Response<Match>> DeleteMatchsAsync(int Id)
        {
            try
            {
                var result = await _matchRepo.DeleteMatchRepo(Id);
                return result;
            }
            catch (Exception e)
            {
                return new Response<Match>
                {
                    success = false,
                    statuscode = "500",
                    message = e.Message
                };
            }
        }

        public async Task<Response<Match>> GetAllMatchsAsync(int groupCount)
        {
            try
            {
                var result = await _matchRepo.GetAllMatchRepo(groupCount);
                return result;
            }
            catch (Exception e)
            {
                return new Response<Match>
                {
                    success = false,
                    statuscode = "500",
                    message = e.Message
                };
            }
        }

        public async Task<Response<Match>> GetMatchsAsync(int Id)
        {
            try
            {
                var result=await _matchRepo.GetMatchRepo(Id);
                return result;
            }
            catch (Exception e)
            {
                return new Response<Match>
                {
                    success = false,
                    statuscode = "500",
                    message = e.Message
                };
            }
        }

        public async Task<Response<Match>> UpdateMatchsAsync(int Id, UpdateMatchVM MatchsVM)
        {
            try
            {
                Match match = new Match();
                match.MatchDate = MatchsVM.MatchDate;
                match.HomeTeamID = MatchsVM.HomeTeamID;
                match.AwayTeamID = MatchsVM.AwayTeamID;
                match.HomeTeamScore = MatchsVM.HomeTeamScore;
                match.AwayTeamScore = MatchsVM.AwayTeamScore;
                match.Location = MatchsVM.Location;
                match.RefereeName = MatchsVM.RefereeName;
                match.LeagueID = MatchsVM.LeagueID;
                match.VenueId = MatchsVM.VenueId;

                var result=await _matchRepo.UpdateMatchRepo(Id,match);
                if (result.success)
                {
                    StandingsVM standingsVM = new StandingsVM();
                    StandingsVM standingsVMAyway = new StandingsVM();

                    standingsVM.LeagueID=MatchsVM.LeagueID;
                    standingsVMAyway.LeagueID=MatchsVM.LeagueID;

                    standingsVMAyway.TeamID = MatchsVM.AwayTeamID;
                    standingsVM.TeamID = MatchsVM.HomeTeamID;

                    if(MatchsVM.HomeTeamScore > MatchsVM.AwayTeamScore)
                    {
                        standingsVM.Wins = 1;
                        standingsVM.Points = 3;

                        standingsVMAyway.Losses = 1;
                        standingsVMAyway.Points = 0;

                    }
                    else if(MatchsVM.HomeTeamScore== MatchsVM.AwayTeamScore)
                    {
                        standingsVM.Draws = 1;
                        standingsVMAyway.Draws = 1;
                        standingsVMAyway.Points = 1;
                        standingsVM.Points = 1;
                    }
                    else
                    {
                        standingsVM.Losses = 1;
                        standingsVMAyway.Wins = 1;
                        standingsVMAyway.Points = 3;
                        standingsVM.Points = 0;

                    }
                    standingsVM.GoalsFor = MatchsVM.HomeTeamScore;
                    standingsVM.GoalsAgainst = MatchsVM.AwayTeamScore;

                    standingsVMAyway.GoalsAgainst = MatchsVM.HomeTeamScore;
                    standingsVMAyway.GoalsFor = MatchsVM.AwayTeamScore;

                    var resultstandings = await _standingsService.CreateStandingssAsync(standingsVM);
                    var resultstandings2 = await _standingsService.CreateStandingssAsync(standingsVMAyway);

                }
                return result;
            }
            catch (Exception e)
            {
                return new Response<Match>
                {
                    success = false,
                    statuscode = "500",
                    message = e.Message
                };
            }
        }
    }
}
