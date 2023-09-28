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
                return new Response<Standings>
                {
                    success = true
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
                return new Response<Standings>
                {
                    success = true
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

        public async Task<Response<Standings>> GetAllStandingsRepo()
        {
            try
            {
                return new Response<Standings>
                {
                    success = true
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
                return new Response<Standings>
                {
                    success = true
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
                return new Response<Standings>
                {
                    success = true
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
