using BLL.IService;
using DAL.Entities;
using DAL.Models.TeamVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Football.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }
        [HttpPost("AddNewTeam")]
        public async Task<IActionResult> AddNewTeam([FromForm]TeamVM teamVM)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var result = await _teamService.CreateTeamAsync(teamVM);
            return Ok(result);
        }
        [HttpDelete("DeleteTeam")]
        public async Task<IActionResult> DeleteTeam(int TeamId)
        {
            if(TeamId <=0 && TeamId == null)
            {
                return BadRequest("TeamId is Not Valid");
            }
            var result = await _teamService.DeleteTeamAsync(TeamId);
            return Ok(result);
        }
        [HttpGet("GetAllTeamInLeague")]
        public async Task<IActionResult> GetAllTeamInLeague(int league)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var result = await _teamService.GetAllTeamAsync(league);
            return Ok(result);  
        }
        [HttpGet("GetTeam")]
        public async Task<IActionResult> GetTeam(int TeamId)
        {
            if (TeamId <= 0 && TeamId == null)
            {
                return BadRequest("TeamId is Not Valid");
            }
            var result = await _teamService.GetTeamAsync(TeamId);
            return Ok(result);
        }
        [HttpPost("UpdateTeam")]
        public async Task<IActionResult> UpdateTeam(int TeamId,[FromForm]TeamUpdateVM teamVM)
        {
            if(!ModelState.IsValid) { return BadRequest(ModelState); }
            if (TeamId <= 0 && TeamId == null)
            {
                return BadRequest("TeamId is Not Valid");
            }
            var result = await _teamService.UpdateTeamAsync(TeamId,teamVM);
            return Ok(result);
        }
    }
}
