using BLL.IService;
using DAL.Entities;
using DAL.IRepo;
using DAL.Models.SheardVM;
using DAL.Models.StandingsVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class StandingsService : IStandingsService
    {
        private readonly IStandingsRepo _standingsRepo;

        public StandingsService(IStandingsRepo standingsRepo)
        {
            _standingsRepo = standingsRepo;
        }

        public async Task<Response<Standings>> CreateStandingssAsync(StandingsVM StandingssVM)
        {
            try
            {
                Standings standings = new Standings();
                standings.LeagueID = StandingssVM.LeagueID;
                standings.TeamID = StandingssVM.TeamID;
                standings.Wins = StandingssVM.Wins;
                standings.Draws = StandingssVM.Draws;
                standings.Losses = StandingssVM.Losses;
                standings.Points = StandingssVM.Points;
                standings.GoalsFor = StandingssVM.GoalsFor;
                standings.GoalsAgainst = StandingssVM.GoalsAgainst;
                standings.Delete = false;

                var result = await _standingsRepo.CreateStandingsRepo(standings);

                return result;
            }
            catch (Exception e)
            {
                return new Response<Standings>
                {
                    success = false,
                    statuscode = "500",
                    message = e.Message
                };
            }
        }

        public async Task<Response<Standings>> DeleteStandingssAsync(int Id)
        {
            try
            {
                var result = await _standingsRepo.DeleteStandingsRepo(Id);

                return result;
            }
            catch (Exception e)
            {
                return new Response<Standings>
                {
                    success = false,
                    statuscode = "500",
                    message = e.Message
                };
            }
        }

        public async Task<Response<Standings>> GetAllStandingssAsync(int groupCount)
        {
            try
            {
                var result = await _standingsRepo.GetAllStandingsRepo(groupCount);

                return result;
            }
            catch (Exception e)
            {
                return new Response<Standings>
                {
                    success = false,
                    statuscode = "500",
                    message = e.Message
                };
            }
        }

        public async Task<Response<Standings>> GetStandingssAsync(int Id)
        {
            try
            {
                var result = await _standingsRepo.GetStandingsRepo(Id);
                return result;
            }
            catch (Exception e)
            {
                return new Response<Standings>
                {
                    success = false,
                    statuscode = "500",
                    message = e.Message
                };
            }
        }

        public async Task<Response<Standings>> UpdateStandingssAsync(int Id, StandingsVM StandingssVM)
        {
            try
            {
                Standings standings = new Standings();
                standings.LeagueID = StandingssVM.LeagueID;
                standings.TeamID = StandingssVM.TeamID;
                standings.Wins = StandingssVM.Wins;
                standings.Draws = StandingssVM.Draws;
                standings.Losses = StandingssVM.Losses;
                standings.Points = StandingssVM.Points;
                standings.GoalsFor = StandingssVM.GoalsFor;
                standings.GoalsAgainst = StandingssVM.GoalsAgainst;

                var result= await _standingsRepo.UpdateStandingsRepo(Id, standings);
                return result;
            }
            catch (Exception e)
            {
                return new Response<Standings>
                {
                    success = false,
                    statuscode = "500",
                    message = e.Message
                };
            }
        }
    }
}
