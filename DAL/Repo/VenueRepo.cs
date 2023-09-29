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
                await db.Venues.AddAsync(Venue);
                await db.SaveChangesAsync();
                return new Response<Venue>
                {
                    success = true,
                    statuscode="200",
                    Value=Venue
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
                var venue = await db.Venues.Where(n => n.VenueID == Id && n.Delete == false).SingleOrDefaultAsync();
                if (venue == null)
                {
                    return new Response<Venue>
                    {
                        success = false,
                        statuscode = "400",
                        message = "this venue can not found"
                    };
                }
                venue.Delete = true;
                await db.SaveChangesAsync();
                return new Response<Venue>
                {
                    success = true,
                    statuscode="200"
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

        public async Task<Response<Venue>> GetAllVenueRepo(int groupCount)
        {
            try
            {
                var AllVenueCount = await db.Venues.Where(n => n.Delete == false).CountAsync();
                int group;
                if (AllVenueCount % 10 == 0)
                {
                    group = AllVenueCount / 10;
                }
                group = (AllVenueCount / 10) + 1;
                var AllVenueData = await db.Venues.Where(n => n.Delete == false).Skip((groupCount - 1) * 10).Take(10).ToListAsync();

                return new Response<Venue>
                {
                    success = true,
                    statuscode="200",
                    values=AllVenueData,
                    groups=group
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
                var venue = await db.Venues.Where(n => n.VenueID == Id && n.Delete == false).SingleOrDefaultAsync();
                if (venue == null)
                {
                    return new Response<Venue>
                    {
                        success = false,
                        statuscode = "400",
                        message = "this venue can not found"
                    };
                }
                return new Response<Venue>
                {
                    success = true,
                    statuscode="200",
                    Value= venue
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
                var venue = await db.Venues.Where(n => n.VenueID == Id && n.Delete == false).SingleOrDefaultAsync();
                if (venue == null)
                {
                    return new Response<Venue>
                    {
                        success = false,
                        statuscode = "400",
                        message = "this venue can not found"
                    };
                }
                venue.VenueName = Venue.VenueName;
                venue.Capacity = Venue.Capacity;
                venue.Location = Venue.Location;
                venue.ContactInfo = Venue.ContactInfo;

                db.SaveChangesAsync();

                return new Response<Venue>
                {
                    success = true,
                    statuscode="200"
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
