using BLL.IService;
using DAL.Entities;
using DAL.IRepo;
using DAL.Models.Match;
using DAL.Models.SheardVM;
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

        public MatchService(IMatchRepo matchRepo)
        {
            _matchRepo = matchRepo;
        }

        public async Task<Response<Match>> CreateMatchsAsync(MatchVM MatchsVM)
        {
            try
            {
                Match match = new Match();
                match.MatchDate = MatchsVM.MatchDate;
                match.HomeTeamID = MatchsVM.HomeTeamID;
                match.AwayTeamName = MatchsVM.AwayTeamName;
                match.HomeTeamScore = MatchsVM.HomeTeamScore;
                match.AwayTeamScore = MatchsVM.AwayTeamScore;
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

        public async Task<Response<Match>> UpdateMatchsAsync(int Id, MatchVM MatchsVM)
        {
            try
            {
                Match match = new Match();
                match.MatchDate = MatchsVM.MatchDate;
                match.HomeTeamID = MatchsVM.HomeTeamID;
                match.AwayTeamName = MatchsVM.AwayTeamName;
                match.HomeTeamScore = MatchsVM.HomeTeamScore;
                match.AwayTeamScore = MatchsVM.AwayTeamScore;
                match.Location = MatchsVM.Location;
                match.RefereeName = MatchsVM.RefereeName;
                match.LeagueID = MatchsVM.LeagueID;
                match.VenueId = MatchsVM.VenueId;

                var result=await _matchRepo.UpdateMatchRepo(Id,match);
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
