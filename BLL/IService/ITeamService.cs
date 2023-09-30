using DAL.Entities;
using DAL.Models.SheardVM;
using DAL.Models.TeamVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IService
{
    public interface ITeamService
    {
        Task<Response<Team>> CreateTeamAsync(TeamVM teamVM);
        Task<Response<Team>> UpdateTeamAsync(int Id, TeamUpdateVM teamVM);
        Task<Response<Team>> DeleteTeamAsync(int Id);
        Task<Response<Team>> GetTeamAsync(int Id);
        Task<Response<Team>> GetAllTeamAsync(int leageuId);
    }
}
