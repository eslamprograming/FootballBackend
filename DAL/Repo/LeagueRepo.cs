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
    public class LeagueRepo : ILeagueRepo
    {
        private readonly ApplicationDbContext db;

        public LeagueRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Response<League>> CreateLeagueRepo(League League)
        {
            try
            {
                await db.Leagues.AddAsync(League);
                await db.SaveChangesAsync();
                return new Response<League>
                {
                    success = true,
                    statuscode="201",
                    Value = League
                };
            }
            catch (Exception e)
            {
                return new Response<League>
                {
                    success = false,
                    message = e.Message
                };
            }
        }

        public async Task<Response<League>> DeleteLeagueRepo(int Id)
        {
            try
            {
                var League = await db.Leagues.Where(n => n.LeagueID == Id && n.Delete == false).SingleOrDefaultAsync();
                if (League == null)
                {
                    return new Response<League>
                    {
                        success=false,
                        statuscode="400",
                        message="Your League is not found"
                    };
                }
                League.Delete=true;
                await db.SaveChangesAsync();
                return new Response<League>
                {
                    success = true
                };
            }
            catch (Exception e)
            {
                return new Response<League>
                {
                    success = false,
                    message = e.Message
                };
            }
        }

        public async Task<Response<League>> GetAllLeagueRepo(int groupCount)
        {
            try
            {
                var AllLeagueCount = await db.Leagues.Where(n => n.Delete == false).CountAsync();
                int group;
                if (AllLeagueCount % 10 == 0)
                {
                    group=AllLeagueCount/ 10;   
                }
                group = (AllLeagueCount / 10) + 1;
                var AllLeafueData=await db.Leagues.Where(n=>n.Delete==false)
                    .Skip((groupCount - 1)*10).Take(10).ToListAsync();  
                return new Response<League>
                {
                    success = true,
                    statuscode="200",
                    values=AllLeafueData,
                    groups=group
                };
            }
            catch (Exception e)
            {
                return new Response<League>
                {
                    success = false,
                    message = e.Message
                };
            }
        }

        public async Task<Response<League>> GetLeagueRepo(int Id)
        {
            try
            {
                var league = await db.Leagues.Where(n => n.LeagueID == Id && n.Delete == false).Include(n=>n.Teams).SingleOrDefaultAsync();
                if (league == null)
                {
                    return new Response<League>
                    {
                        success = false,
                        statuscode = "400",
                        message = "This league can not found"
                    };
                }

                return new Response<League>
                {
                    success = true,
                    statuscode="200",
                    Value=league
                };
            }
            catch (Exception e)
            {
                return new Response<League>
                {
                    success = false,
                    message = e.Message
                };
            }
        }

        public async Task<Response<League>> UpdateLeagueRepo(int Id, League League)
        {
            try
            {
                var league = await db.Leagues.Where(n => n.LeagueID == Id && n.Delete == false).SingleOrDefaultAsync();
                if (league == null)
                {
                    return new Response<League>
                    {
                        success = false,
                        statuscode = "400",
                        message = "This league can not found"
                    };
                }
                league.LeagueName = League.LeagueName;
                league.Season = League.Season;
                league.StartDate = League.StartDate;
                league.EndDate = League.EndDate;

                await db.SaveChangesAsync();
                return new Response<League>
                {
                    success = true,
                    statuscode="200",
                };
            }
            catch (Exception e)
            {
                return new Response<League>
                {
                    success = false,
                    message = e.Message
                };
            }
        }
    }
}
