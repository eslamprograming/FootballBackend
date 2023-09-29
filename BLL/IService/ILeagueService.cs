using DAL.Entities;
using DAL.Models.SheardVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models.League;

namespace BLL.IService
{
    public interface ILeagueService
    {
        Task<Response<League>> CreateLeagueAsync(LeagueVM LeagueVM);
        Task<Response<League>> UpdateLeagueAsync(int Id, LeagueVM LeagueVM);
        Task<Response<League>> DeleteLeagueAsync(int Id);
        Task<Response<League>> GetLeagueAsync(int Id);
        Task<Response<League>> GetAllLeagueAsync(int groupCount);
    }
}
