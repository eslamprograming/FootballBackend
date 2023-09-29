using DAL.Entities;
using DAL.Models.SheardVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepo
{
    public interface ILeagueRepo
    {
        Task<Response<League>> CreateLeagueRepo(League League);
        Task<Response<League>> UpdateLeagueRepo(int Id, League League);
        Task<Response<League>> DeleteLeagueRepo(int Id);
        Task<Response<League>> GetLeagueRepo(int Id);
        Task<Response<League>> GetAllLeagueRepo(int groupCount);
    }
}
