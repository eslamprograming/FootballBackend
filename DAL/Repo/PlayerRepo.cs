using DAL.Data;
using DAL.Entities;
using DAL.IRepo;
using DAL.Models.SheardVM;
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
                return new Response<Player>
                {
                    success = true
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
                return new Response<Player>
                {
                    success = true
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

        public async Task<Response<Player>> GetAllPlayerRepo()
        {
            try
            {
                return new Response<Player>
                {
                    success = true
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
                return new Response<Player>
                {
                    success = true
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
                return new Response<Player>
                {
                    success = true
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
