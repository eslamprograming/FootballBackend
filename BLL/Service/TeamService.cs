using BLL.IService;
using DAL.Entities;
using DAL.IRepo;
using DAL.Models.SheardVM;
using DAL.Models.TeamVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepo _teamRepo;

        public TeamService(ITeamRepo teamRepo)
        {
            _teamRepo = teamRepo;
        }

        public async Task<Response<Team>> CreateTeamAsync(TeamVM teamVM)
        {
            try
            {
                Team team = new Team();
                team.TeamName=teamVM.TeamName;
                team.TeamLogo = teamVM.TeamLogo;
                team.FoundedYear = teamVM.FoundedYear;
                team.HomeCity = teamVM.HomeCity;
                team.HomeStadium = teamVM.HomeStadium;
                team.CoachName = teamVM.CoachName;
                team.LeagueId = teamVM.LeagueId;
                team.Delete = false;

                var result = await _teamRepo.CreateTeamRepo(team);

                return result;
            }
            catch (Exception e)
            {
                return new Response<Team>
                {
                    success = false,
                    statuscode = "500",
                    message = e.Message
                };
            }
        }

        public async Task<Response<Team>> DeleteTeamAsync(int Id)
        {
            try
            {
                var result = await _teamRepo.DeleteTeamRepo(Id);
                return result;
            }
            catch (Exception e)
            {
                return new Response<Team>
                {
                    success = false,
                    statuscode = "500",
                    message = e.Message
                };
            }
        }

        public async Task<Response<Team>> GetAllTeamAsync(int leageuId)
        {
            try
            {
                var result = await _teamRepo.GetAllTeamRepo(leageuId);

                return result;
            }
            catch (Exception e)
            {
                return new Response<Team>
                {
                    success = false,
                    statuscode = "500",
                    message = e.Message
                };
            }
        }

        public async Task<Response<Team>> GetTeamAsync(int Id)
        {
            try
            {
                var result = await _teamRepo.GetTeamRepo(Id);

                return result;
            }
            catch (Exception e)
            {
                return new Response<Team>
                {
                    success = false,
                    statuscode = "500",
                    message = e.Message
                };
            }
        }

        public async Task<Response<Team>> UpdateTeamAsync(int Id, TeamVM teamVM)
        {
            try
            {
                Team team = new Team();
                team.TeamName = teamVM.TeamName;
                team.TeamLogo = teamVM.TeamLogo;
                team.FoundedYear = teamVM.FoundedYear;
                team.HomeCity = teamVM.HomeCity;
                team.HomeStadium = teamVM.HomeStadium;
                team.CoachName = teamVM.CoachName;
                team.LeagueId = teamVM.LeagueId;
                team.Delete = false;

                var result = await _teamRepo.UpdateTeamRepo(Id, team);
                return result;
            }
            catch (Exception e)
            {
                return new Response<Team>
                {
                    success = false,
                    statuscode = "500",
                    message = e.Message
                };
            }
        }
    }
}
