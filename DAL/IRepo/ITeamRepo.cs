using DAL.Entities;
using DAL.Models.SheardVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepo
{
    public interface ITeamRepo
    {
        Task<Response<Team>> CreateTeamRepo(Team team); 
        Task<Response<Team>> UpdateTeamRepo(int Id,Team team);
        Task<Response<Team>> DeleteTeamRepo(int Id);
        Task<Response<Team>> GetTeamRepo(int Id);
        Task<Response<Team>> GetAllTeamRepo(League leageu);
    }
}
