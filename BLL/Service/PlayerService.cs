using BLL.IService;
using DAL.Entities;
using DAL.IRepo;
using DAL.Models.PlayerVM;
using DAL.Models.SheardVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepo _playerRepo;

        public PlayerService(IPlayerRepo playerRepo)
        {
            _playerRepo = playerRepo;
        }

        public async Task<Response<Player>> CreatePlayersAsync(PlayerVM PlayersVM)
        {
            try
            {
                Player player = new Player();
                player.FirstName=PlayersVM.FirstName;
                player.LastName = PlayersVM.LastName;
                player.DateOfBirth = PlayersVM.DateOfBirth;
                player.Nationality = PlayersVM.Nationality;
                player.Position = PlayersVM.Position;
                player.ShirtNumber = PlayersVM.ShirtNumber;
                player.CurrentTeamID = PlayersVM.CurrentTeamID;
                player.Delete = false;

                var result = await _playerRepo.CreatePlayerRepo(player);

                return result;
            }
            catch (Exception e)
            {
                return new Response<Player>
                {
                    success = false,
                    statuscode = "500",
                    message = e.Message
                };
            }
        }

        public async Task<Response<Player>> DeletePlayersAsync(int Id)
        {
            try
            {
                var result = await _playerRepo.DeletePlayerRepo(Id);

                return result;
            }
            catch (Exception e)
            {
                return new Response<Player>
                {
                    success = false,
                    statuscode = "500",
                    message = e.Message
                };
            }
        }

        public async Task<Response<Player>> GetAllPlayersAsync(int groupCount)
        {
            try
            {
                var result = await _playerRepo.GetAllPlayerRepo(groupCount);
                return result;
            }
            catch (Exception e)
            {
                return new Response<Player>
                {
                    success = false,
                    statuscode = "500",
                    message = e.Message
                };
            }
        }

        public async Task<Response<Player>> GetPlayersAsync(int Id)
        {
            try
            {
                var result = await _playerRepo.GetPlayerRepo(Id);
                return result;
            }
            catch (Exception e)
            {
                return new Response<Player>
                {
                    success = false,
                    statuscode = "500",
                    message = e.Message
                };
            }
        }

        public async Task<Response<Player>> UpdatePlayersAsync(int Id, PlayerVM PlayersVM)
        {
            try
            {
                Player player = new Player();
                player.FirstName = PlayersVM.FirstName;
                player.LastName = PlayersVM.LastName;
                player.DateOfBirth = PlayersVM.DateOfBirth;
                player.Nationality = PlayersVM.Nationality;
                player.Position = PlayersVM.Position;
                player.ShirtNumber = PlayersVM.ShirtNumber;
                player.CurrentTeamID = PlayersVM.CurrentTeamID;
                player.Delete = false;

                var result= await _playerRepo.UpdatePlayerRepo(Id,player);
                return result;
            }
            catch (Exception e)
            {
                return new Response<Player>
                {
                    success = false,
                    statuscode = "500",
                    message = e.Message
                };
            }
        }
    }
}
