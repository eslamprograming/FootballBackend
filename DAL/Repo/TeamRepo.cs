using DAL.Data;
using DAL.Entities;
using DAL.IRepo;
using DAL.Models.SheardVM;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class TeamRepo : ITeamRepo
    {
        private readonly ApplicationDbContext db;

        public TeamRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Response<Team>> CreateTeamRepo(Team team)
        {
            try
            {
                await db.teams.AddAsync(team);
                await db.SaveChangesAsync();
                return new Response<Team>
                {
                    success = true,
                    statuscode="201",
                    Value=team
                };
            }
            catch (Exception e)
            {
                return new Response<Team>
                {
                    success = false,
                    message = e.Message
                };
            }
        }

        public async Task<Response<Team>> DeleteTeamRepo(int Id)
        {
            try
            {
                var team = await db.teams.Where(n=>n.TeamID==Id&&n.Delete==false).SingleOrDefaultAsync();   
                if(team == null)
                {
                    return new Response<Team>
                    {
                        success = false,
                        statuscode = "400",
                        message = "this team can not found"
                    };
                }
                team.Delete = true;
                await db.SaveChangesAsync();

                return new Response<Team>
                {
                    success = true,
                    statuscode="200"
                };
            }
            catch (Exception e)
            {
                return new Response<Team>
                {
                    success = false,
                    message = e.Message
                };
            }
        }

        public async Task<Response<Team>> GetAllTeamRepo(League leageu)
        {
            try
            {
                var AllTeam = await db.teams.Where(n => n.Delete == false&&n.League==leageu).ToListAsync();
                return new Response<Team>
                {
                    success = true,
                    statuscode="200",
                    values=AllTeam
                };
            }
            catch (Exception e)
            {
                return new Response<Team>
                {
                    success = false,
                    message = e.Message
                };
            }
        }

        public async Task<Response<Team>> GetTeamRepo(int Id)
        {
            try
            {
                var team = await db.teams.Where(n => n.TeamID == Id && n.Delete == false).SingleOrDefaultAsync();
                if (team == null)
                {
                    return new Response<Team>
                    {
                        success = false,
                        statuscode = "400",
                        message = "this team can not found"
                    };
                }
                return new Response<Team>
                {
                    success = true,
                    statuscode="200",
                    Value=team
                };
            }
            catch (Exception e)
            {
                return new Response<Team>
                {
                    success = false,
                    message = e.Message
                };
            }
        }

        public async Task<Response<Team>> UpdateTeamRepo(int Id, Team Team)
        {
            try
            {
                var team = await db.teams.Where(n => n.TeamID == Id && n.Delete == false).SingleOrDefaultAsync();
                if (team == null)
                {
                    return new Response<Team>
                    {
                        success = false,
                        statuscode = "400",
                        message = "this team can not found"
                    };
                }
                team.League = Team.League;
                team.TeamName = Team.TeamName;
                team.TeamLogo = Team.TeamLogo;
                team.FoundedYear = Team.FoundedYear;
                team.HomeCity = Team.HomeCity;
                team.HomeStadium = Team.HomeStadium;
                team.CoachName = Team.CoachName;

                await db.SaveChangesAsync();

                return new Response<Team>
                {
                    success = true,
                    statuscode="200",
                    Value=Team
                };
            }
            catch (Exception e)
            {
                return new Response<Team>
                {
                    success = false,
                    message = e.Message
                };
            }
        }
    }
}
