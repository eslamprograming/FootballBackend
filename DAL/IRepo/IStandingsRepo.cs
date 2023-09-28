using DAL.Entities;
using DAL.Models.SheardVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepo
{
    public interface IStandingsRepo
    {
        Task<Response<Standings>> CreateStandingsRepo(Standings Standings);
        Task<Response<Standings>> UpdateStandingsRepo(int Id, Standings Standings);
        Task<Response<Standings>> DeleteStandingsRepo(int Id);
        Task<Response<Standings>> GetStandingsRepo(int Id);
        Task<Response<Standings>> GetAllStandingsRepo();
    }
}
