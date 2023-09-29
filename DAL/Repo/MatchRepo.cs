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
    public class MatchRepo : IMatchRepo
    {
        private readonly ApplicationDbContext db;

        public MatchRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Response<Match>> CreateMatchRepo(Match Match)
        {
            try
            {
                await db.Matches.AddAsync(Match);
                await db.SaveChangesAsync();
                return new Response<Match>
                {
                    success = true,
                    statuscode="200",
                    Value=Match
                };
            }
            catch (Exception e)
            {
                return new Response<Match>
                {
                    success = false,
                    message = e.Message
                };
            }
        }

        public async Task<Response<Match>> DeleteMatchRepo(int Id)
        {
            try
            {
                var Match = await db.Matches.Where(n => n.MatchID == Id && n.Delete == false).SingleOrDefaultAsync();
                if (Match == null)
                {
                    return new Response<Match>
                    {
                        success = false,
                        statuscode = "400",
                        message = "this match can not found"
                    };
                }
                Match.Delete = true;
                await db.SaveChangesAsync();
                return new Response<Match>
                {
                    success = true,
                    statuscode="200"
                };
            }
            catch (Exception e)
            {
                return new Response<Match>
                {
                    success = false,
                    message = e.Message
                };
            }
        }

        public async Task<Response<Match>> GetAllMatchRepo(int groupCount)
        {
            try
            {
                var AllMatchCount = await db.Matches.Where(n => n.Delete == false).CountAsync();
                int group;
                if (AllMatchCount % 10 == 0)
                {
                    group = AllMatchCount / 10;
                }
                group = (AllMatchCount / 10) + 1;
                var AllMatchData = await db.Matches.Where(n => n.Delete == false).Skip((groupCount - 1) * 10).Take(10).ToListAsync();

                return new Response<Match>
                {
                    success = true,
                    statuscode="200",
                    values= AllMatchData,
                    groups=group
                };
            }
            catch (Exception e)
            {
                return new Response<Match>
                {
                    success = false,
                    message = e.Message
                };
            }
        }

        public async Task<Response<Match>> GetMatchRepo(int Id)
        {
            try
            {
                var Match = await db.Matches.Where(n => n.MatchID == Id && n.Delete == false).SingleOrDefaultAsync();
                if (Match == null)
                {
                    return new Response<Match>
                    {
                        success = false,
                        statuscode = "400",
                        message = "this match can not found"
                    };
                }
                return new Response<Match>
                {
                    success = true,
                    statuscode="200",
                    Value=Match
                };
            }
            catch (Exception e)
            {
                return new Response<Match>
                {
                    success = false,
                    message = e.Message
                };
            }
        }

        public async Task<Response<Match>> UpdateMatchRepo(int Id, Match Match)
        {
            try
            {
                var match = await db.Matches.Where(n => n.MatchID == Id && n.Delete == false).SingleOrDefaultAsync();
                if (match == null)
                {
                    return new Response<Match>
                    {
                        success = false,
                        statuscode = "400",
                        message = "this match can not found"
                    };
                }
                match.MatchDate = Match.MatchDate;
                match.HomeTeamID = Match.HomeTeamID;
                match.HomeTeam = Match.HomeTeam;
                match.AwayTeamName = Match.AwayTeamName;
                match.HomeTeamScore = Match.HomeTeamScore;
                match.AwayTeamScore = Match.AwayTeamScore;
                match.Location = Match.Location;
                match.RefereeName = Match.RefereeName;
                match.LeagueID = Match.LeagueID;
                match.League = Match.League;
                match.Venue = Match.Venue;

                return new Response<Match>
                {
                    success = true,
                    statuscode="200",
                };
            }
            catch (Exception e)
            {
                return new Response<Match>
                {
                    success = false,
                    message = e.Message
                };
            }
        }
    }
}
