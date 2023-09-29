using DAL.Entities;
using DAL.Models.StandingsVM;
using DAL.Models.SheardVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IService
{
    public interface IStandingsService
    {
        Task<Response<Standings>> CreateStandingssAsync(StandingsVM StandingssVM);
        Task<Response<Standings>> UpdateStandingssAsync(int Id, StandingsVM StandingssVM);
        Task<Response<Standings>> DeleteStandingssAsync(int Id);
        Task<Response<Standings>> GetStandingssAsync(int Id);
        Task<Response<Standings>> GetAllStandingssAsync(int groupCount);
    }
}
