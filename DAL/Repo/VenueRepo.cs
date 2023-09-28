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
    public class VenueRepo : IVenueRepo
    {
        private readonly ApplicationDbContext db;

        public VenueRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Response<Venue>> CreateVenueRepo(Venue Venue)
        {
            try
            {
                return new Response<Venue>
                {
                    success = true
                };
            }
            catch (Exception e)
            {
                return new Response<Venue>
                {
                    success = false,
                    message = e.Message
                };
            }
        }

        public async Task<Response<Venue>> DeleteVenueRepo(int Id)
        {
            try
            {
                return new Response<Venue>
                {
                    success = true
                };
            }
            catch (Exception e)
            {
                return new Response<Venue>
                {
                    success = false,
                    message = e.Message
                };
            }
        }

        public async Task<Response<Venue>> GetAllVenueRepo()
        {
            try
            {
                return new Response<Venue>
                {
                    success = true
                };
            }
            catch (Exception e)
            {
                return new Response<Venue>
                {
                    success = false,
                    message = e.Message
                };
            }
        }

        public async Task<Response<Venue>> GetVenueRepo(int Id)
        {
            try
            {
                return new Response<Venue>
                {
                    success = true
                };
            }
            catch (Exception e)
            {
                return new Response<Venue>
                {
                    success = false,
                    message = e.Message
                };
            }
        }

        public async Task<Response<Venue>> UpdateVenueRepo(int Id, Venue Venue)
        {
            try
            {
                return new Response<Venue>
                {
                    success = true
                };
            }
            catch (Exception e)
            {
                return new Response<Venue>
                {
                    success = false,
                    message = e.Message
                };
            }
        }
    }
}
