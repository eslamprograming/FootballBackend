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
    public class LeagueRepo : ILeagueRepo
    {
        private readonly ApplicationDbContext db;

        public LeagueRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public Task<Response<League>> CreateLeagueRepo(League League)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<League>> DeleteLeagueRepo(int Id)
        {
            try
            {
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

        public async Task<Response<League>> GetAllLeagueRepo()
        {
            try
            {
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

        public async Task<Response<League>> GetLeagueRepo(int Id)
        {
            try
            {
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

        public async Task<Response<League>> UpdateLeagueRepo(int Id, League League)
        {
            try
            {
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
    }
}
