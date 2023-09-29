using DAL.Entities;
using DAL.Models.SheardVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.IRepo
{
    public interface IPlayerRepo
    {
        Task<Response<Player>> CreatePlayerRepo(Player Player);
        Task<Response<Player>> UpdatePlayerRepo(int Id, Player Player);
        Task<Response<Player>> DeletePlayerRepo(int Id);
        Task<Response<Player>> GetPlayerRepo(int Id);
        Task<Response<Player>> GetAllPlayerRepo(int groupCount);
    }
}
