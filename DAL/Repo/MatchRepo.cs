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
                return new Response<Match>
                {
                    success = true
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
                return new Response<Match>
                {
                    success = true
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

        public async Task<Response<Match>> GetAllMatchRepo()
        {
            try
            {
                return new Response<Match>
                {
                    success = true
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
                return new Response<Match>
                {
                    success = true
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
                return new Response<Match>
                {
                    success = true
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
