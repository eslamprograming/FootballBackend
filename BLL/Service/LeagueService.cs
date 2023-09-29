using BLL.IService;
using DAL.Entities;
using DAL.IRepo;
using DAL.Models.League;
using DAL.Models.SheardVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class LeagueService : ILeagueService
    {
        private readonly ILeagueRepo _leagueRepo;

        public LeagueService(ILeagueRepo leagueRepo)
        {
            _leagueRepo = leagueRepo;
        }

        public async Task<Response<League>> CreateLeagueAsync(LeagueVM LeagueVM)
        {
            try
            {
                League league = new League();
                league.LeagueName=LeagueVM.LeagueName;
                league.Season = LeagueVM.Season;
                league.StartDate = LeagueVM.StartDate;
                league.EndDate = LeagueVM.EndDate;

                var result = await _leagueRepo.CreateLeagueRepo(league);

                return result;
            }
            catch (Exception e)
            {
                return new Response<League>
                {
                    success=false,
                    statuscode="500",
                    message=e.Message   
                };
            }
        }

        public async Task<Response<League>> DeleteLeagueAsync(int Id)
        {
            try
            {
                var result = await _leagueRepo.DeleteLeagueRepo(Id);
                return result;
            }
            catch (Exception e)
            {
                return new Response<League>
                {
                    success = false,
                    statuscode = "500",
                    message = e.Message
                };
            }
        }

        public async Task<Response<League>> GetAllLeagueAsync(int groupCount)
        {
            try
            {
                var result = await _leagueRepo.GetAllLeagueRepo(groupCount);
                return result;
            }
            catch (Exception e)
            {
                return new Response<League>
                {
                    success = false,
                    statuscode = "500",
                    message = e.Message
                };
            }
        }

        public async Task<Response<League>> GetLeagueAsync(int Id)
        {
            try
            {
                var result = await _leagueRepo.GetLeagueRepo(Id);
                return result;
            }
            catch (Exception e)
            {
                return new Response<League>
                {
                    success = false,
                    statuscode = "500",
                    message = e.Message
                };
            }
        }

        public async Task<Response<League>> UpdateLeagueAsync(int Id, LeagueVM LeagueVM)
        {
            try
            {
                League league = new League();
                league.LeagueName = LeagueVM.LeagueName;
                league.Season = LeagueVM.Season;
                league.StartDate = LeagueVM.StartDate;
                league.EndDate = LeagueVM.EndDate;
                var result=await _leagueRepo.UpdateLeagueRepo(Id, league);
                return result;
            }
            catch (Exception e)
            {
                return new Response<League>
                {
                    success = false,
                    statuscode = "500",
                    message = e.Message
                };
            }
        }
    }
}
