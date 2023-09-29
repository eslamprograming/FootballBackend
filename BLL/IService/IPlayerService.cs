using DAL.Entities;
using DAL.Models.Players;
using DAL.Models.PlayerVM;
using DAL.Models.SheardVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IService
{
    public interface IPlayerService
    {
        Task<Response<Player>> CreatePlayersAsync(PlayerVM PlayersVM);
        Task<Response<Player>> UpdatePlayersAsync(int Id, PlayerVM PlayersVM);
        Task<Response<Player>> DeletePlayersAsync(int Id);
        Task<Response<Player>> GetPlayersAsync(int Id);
        Task<Response<Player>> GetAllPlayersAsync(int groupCount);
    }
}
