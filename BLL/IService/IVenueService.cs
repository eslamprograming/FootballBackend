using DAL.Entities;
using DAL.Models.VenueVM;
using DAL.Models.SheardVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IService
{
    public interface IVenueService
    {
        Task<Response<Venue>> CreateVenuesAsync(VenueVM VenuesVM);
        Task<Response<Venue>> UpdateVenuesAsync(int Id, VenueVM VenuesVM);
        Task<Response<Venue>> DeleteVenuesAsync(int Id);
        Task<Response<Venue>> GetVenuesAsync(int Id);
        Task<Response<Venue>> GetAllVenuesAsync(int groupCount);
    }
}
