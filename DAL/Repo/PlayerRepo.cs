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
    public class PlayerRepo : IPlayerRepo
    {
        private readonly ApplicationDbContext db;

        public PlayerRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Response<Player>> CreatePlayerRepo(Player Player)
        {
            try
            {
                await db.AddAsync(Player);
                await db.SaveChangesAsync();
                return new Response<Player>
                {
                    success = true,
                    statuscode="201",
                    Value=Player
                };
            }
            catch (Exception e)
            {
                return new Response<Player>
                {
                    success = false,
                    message = e.Message
                };
            }
        }

        public async Task<Response<Player>> DeletePlayerRepo(int Id)
        {
            try
            {
                var player = await db.Players.Where(n => n.PlayerID == Id && n.Delete == false).SingleOrDefaultAsync();
                if (player == null)
                {
                    return new Response<Player>
                    {
                        success = false,
                        statuscode = "400",
                        message = "this player can not found"
                    };
                }
                player.Delete=true;
                await db.SaveChangesAsync();
                return new Response<Player>
                {
                    success = true,
                    statuscode="200"
                };
            }
            catch (Exception e)
            {
                return new Response<Player>
                {
                    success = false,
                    message = e.Message
                };
            }
        }

        public async Task<Response<Player>> GetAllPlayerRepo(int groupCount)
        {
            try
            {
                var AllPlayerCount = await db.Players.Where(n => n.Delete == false).CountAsync();
                int group;
                if (AllPlayerCount % 10 == 0)
                {
                    group = AllPlayerCount / 10;
                }
                group = (AllPlayerCount / 10) + 1;
                var AllPlayerData = await db.Players.Where(n => n.Delete == false).Skip((groupCount - 1) * 10).Take(10).ToListAsync();

                return new Response<Player>
                {
                    success = true,
                    statuscode="200",
                    values=AllPlayerData,
                    groups=group
                };
            }
            catch (Exception e)
            {
                return new Response<Player>
                {
                    success = false,
                    message = e.Message
                };
            }
        }

        public async Task<Response<Player>> GetPlayerRepo(int Id)
        {
            try
            {
                var player = await db.Players.Where(n => n.PlayerID == Id && n.Delete == false).SingleOrDefaultAsync();
                if (player == null)
                {
                    return new Response<Player>
                    {
                        success = false,
                        statuscode = "400",
                        message = "this player can not found"
                    };
                }
                return new Response<Player>
                {
                    success = true,
                    statuscode="200",
                    Value=player
                };
            }
            catch (Exception e)
            {
                return new Response<Player>
                {
                    success = false,
                    message = e.Message
                };
            }
        }

        public async Task<Response<Player>> UpdatePlayerRepo(int Id, Player Player)
        {
            try
            {
                var player = await db.Players.Where(n => n.PlayerID == Id && n.Delete == false).SingleOrDefaultAsync();
                if (player == null)
                {
                    return new Response<Player>
                    {
                        success = false,
                        statuscode = "400",
                        message = "this player can not found"
                    };
                }
                player.FirstName = Player.FirstName;
                player.LastName = Player.LastName;
                player.DateOfBirth = Player.DateOfBirth;
                player.Nationality = Player.Nationality;
                player.Position = Player.Position;
                player.ShirtNumber = Player.ShirtNumber;
                player.CurrentTeamID = Player.CurrentTeamID;
                player.CurrentTeam = Player.CurrentTeam;

                await db.SaveChangesAsync();

                return new Response<Player>
                {
                    success = true,
                    statuscode="200"
                };
            }
            catch (Exception e)
            {
                return new Response<Player>
                {
                    success = false,
                    message = e.Message
                };
            }
        }
    }
}
