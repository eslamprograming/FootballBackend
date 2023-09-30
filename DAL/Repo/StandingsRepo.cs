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
    public class StandingsRepo : IStandingsRepo
    {
        private readonly ApplicationDbContext db;

        public StandingsRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Response<Standings>> CreateStandingsRepo(Standings Standings)
        {
            try
            {
                var team = await db.Standings.Where(n => n.TeamID == Standings.TeamID).SingleOrDefaultAsync();
                if (team == null)
                {
                    await db.Standings.AddAsync(Standings);
                }
                else
                {
                    team.LeagueID = Standings.LeagueID;
                    team.TeamID = Standings.TeamID;
                    team.Wins += Standings.Wins;
                    team.Draws += Standings.Draws;
                    team.Losses += Standings.Losses;
                    team.GoalsFor += Standings.GoalsFor;
                    team.GoalsAgainst += Standings.GoalsAgainst;
                    team.Points += Standings.Points;
                }



                await db.SaveChangesAsync();
                return new Response<Standings>
                {
                    success = true
                    ,statuscode="201",
                    Value=Standings
                };
            }
            catch (Exception e)
            {
                return new Response<Standings>
                {
                    success = false,
                    message = e.Message
                };
            }
        }

        public async Task<Response<Standings>> DeleteStandingsRepo(int Id)
        {
            try
            {
                var standing = await db.Standings.Where(n => n.StandingID == Id && n.Delete == false).SingleOrDefaultAsync();
                if (standing == null)
                {
                    return new Response<Standings>
                    {
                        success = false,
                        statuscode = "400",
                        message = "this player can not found"
                    };
                }
                standing.Delete = true;
                await db.SaveChangesAsync();
                return new Response<Standings>
                {
                    success = true,
                    statuscode="200"
                };
            }
            catch (Exception e)
            {
                return new Response<Standings>
                {
                    success = false,
                    message = e.Message
                };
            }
        }

        public async Task<Response<Standings>> GetAllStandingsRepo(int groupCount)
        {
            try
            {
                var AllStandingCount = await db.Standings.Where(n => n.Delete == false).CountAsync();
                int group;
                if (AllStandingCount % 10 == 0)
                {
                    group = AllStandingCount / 10;
                }
                group = (AllStandingCount / 10) + 1;
                var AllStandingData = await db.Standings.Where(n => n.Delete == false).Skip((groupCount - 1) * 10).Take(10).ToListAsync();

                return new Response<Standings>
                {
                    success = true,
                    statuscode="200",
                    values=AllStandingData,
                    groups=group
                };
            }
            catch (Exception e)
            {
                return new Response<Standings>
                {
                    success = false,
                    message = e.Message
                };
            }
        }

        public async Task<Response<Standings>> GetStandingsRepo(int Id)
        {
            try
            {
                var standing = await db.Standings.Where(n => n.StandingID == Id && n.Delete == false).SingleOrDefaultAsync();
                if (standing == null)
                {
                    return new Response<Standings>
                    {
                        success = false,
                        statuscode = "400",
                        message = "this player can not found"
                    };
                }
                return new Response<Standings>
                {
                    success = true,
                    statuscode="200",
                    Value=standing
                };
            }
            catch (Exception e)
            {
                return new Response<Standings>
                {
                    success = false,
                    message = e.Message
                };
            }
        }

        public async Task<Response<Standings>> UpdateStandingsRepo(int Id, Standings Standings)
        {
            try
            {
                var standing = await db.Standings.Where(n => n.StandingID == Id && n.Delete == false).SingleOrDefaultAsync();
                if (standing == null)
                {
                    return new Response<Standings>
                    {
                        success = false,
                        statuscode = "400",
                        message = "this player can not found"
                    };
                }
                standing.LeagueID = Standings.LeagueID;
                standing.League = Standings.League;
                standing.TeamID = Standings.TeamID;
                standing.Team = Standings.Team;
                standing.Wins = Standings.Wins;
                standing.Draws = Standings.Draws;
                standing.Losses = Standings.Losses;
                standing.Points = Standings.Points;
                standing.GoalsFor = Standings.GoalsFor;
                standing.GoalsAgainst = Standings.GoalsAgainst;

                await db.SaveChangesAsync();
                return new Response<Standings>
                {
                    success = true,
                    statuscode="200",
                };
            }
            catch (Exception e)
            {
                return new Response<Standings>
                {
                    success = false,
                    message = e.Message
                };
            }
        }
    }
}
