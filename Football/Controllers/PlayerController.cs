using BLL.IService;
using DAL.Entities;
using DAL.Models.PlayerVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Football.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }
        [HttpPost("AddNewPlayer")]
        public async Task<IActionResult> AddNewPlayer([FromForm]PlayerVM playerVM)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _playerService.CreatePlayersAsync(playerVM);
            return Ok(result);
        }
        [HttpDelete("DeletePlayer")]
        public async Task<IActionResult> DeletePlayer(int PlayerId)
        {
            if (PlayerId <= 0 && PlayerId == null) return BadRequest("player is not valid");
            var result = await _playerService.DeletePlayersAsync(PlayerId);
            return Ok(result);
        }
        [HttpGet("GetAllPlayer")]
        public async Task<IActionResult> GetAllPlayer(int GroupCount)
        {
            if (GroupCount <= 0 && GroupCount == null) return BadRequest("player is not valid");
            var result = await _playerService.GetAllPlayersAsync(GroupCount);
            return Ok(result);
        }
        [HttpGet("GetPlayeInfo")]
        public async Task<IActionResult> GetPlayerInfo(int PlayerId)
        {
            if (PlayerId <= 0 && PlayerId == null) return BadRequest("player is not valid");
            var result = await _playerService.GetPlayersAsync(PlayerId);
            return Ok(result);
        }
        [HttpPut("UpdatePlayerInfo")]
        public async Task<IActionResult> UpdatePlayer(int PlayerId,[FromForm]PlayerVM playerVM)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            if (PlayerId <= 0 && PlayerId == null) return BadRequest("player is not valid");
            var result = await _playerService.UpdatePlayersAsync(PlayerId,playerVM);
            return Ok(result);
        }
    }
}
