using DAL.Entities;
using DAL.Models.SheardVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepo
{
    public interface IVenueRepo
    {
        Task<Response<Venue>> CreateVenueRepo(Venue Venue);
        Task<Response<Venue>> UpdateVenueRepo(int Id, Venue Venue);
        Task<Response<Venue>> DeleteVenueRepo(int Id);
        Task<Response<Venue>> GetVenueRepo(int Id);
        Task<Response<Venue>> GetAllVenueRepo(int groupCount);
    }
}
