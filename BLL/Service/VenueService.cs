using BLL.IService;
using DAL.Entities;
using DAL.IRepo;
using DAL.Models.SheardVM;
using DAL.Models.VenueVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class VenueService : IVenueService
    {
        private readonly IVenueRepo _venueRepo;

        public VenueService(IVenueRepo venueRepo)
        {
            _venueRepo = venueRepo;
        }

        public async Task<Response<Venue>> CreateVenuesAsync(VenueVM VenuesVM)
        {
            try
            {
                Venue venue = new Venue();
                venue.VenueName = VenuesVM.VenueName;
                venue.Capacity = VenuesVM.Capacity;
                venue.Location = VenuesVM.Location;
                venue.ContactInfo = VenuesVM.ContactInfo;
                venue.Delete = false;

                var result = await _venueRepo.CreateVenueRepo(venue);

                return result;
            }
            catch (Exception e)
            {
                return new Response<Venue>
                {
                    success = false,
                    statuscode = "500",
                    message = e.Message
                };
            }
        }

        public async Task<Response<Venue>> DeleteVenuesAsync(int Id)
        {
            try
            {
                var result = await _venueRepo.DeleteVenueRepo(Id);
                return result;
            }
            catch (Exception e)
            {
                return new Response<Venue>
                {
                    success = false,
                    statuscode = "500",
                    message = e.Message
                };
            }
        }

        public async Task<Response<Venue>> GetAllVenuesAsync(int groupCount)
        {
            try
            {
                var result = await _venueRepo.GetAllVenueRepo(groupCount);
                return result;
            }
            catch (Exception e)
            {
                return new Response<Venue>
                {
                    success = false,
                    statuscode = "500",
                    message = e.Message
                };
            }
        }

        public async Task<Response<Venue>> GetVenuesAsync(int Id)
        {
            try
            {
                var result = await _venueRepo.GetVenueRepo(Id);
                return result;
            }
            catch (Exception e)
            {
                return new Response<Venue>
                {
                    success = false,
                    statuscode = "500",
                    message = e.Message
                };
            }
        }

        public async Task<Response<Venue>> UpdateVenuesAsync(int Id, VenueVM VenuesVM)
        {
            try
            {
                Venue venue = new Venue();
                venue.VenueName = VenuesVM.VenueName;
                venue.Capacity = VenuesVM.Capacity;
                venue.Location = VenuesVM.Location;
                venue.ContactInfo = VenuesVM.ContactInfo;

                var result = await _venueRepo.UpdateVenueRepo(Id, venue);
                return result;
            }
            catch (Exception e)
            {
                return new Response<Venue>
                {
                    success = false,
                    statuscode = "500",
                    message = e.Message
                };
            }
        }
    }
}
