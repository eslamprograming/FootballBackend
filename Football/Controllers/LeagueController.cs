using BLL.IService;
using DAL.Entities;
using DAL.Models.League;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Football.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeagueController : ControllerBase
    {
        private readonly ILeagueService _leagueService;

        public LeagueController(ILeagueService leagueService)
        {
            _leagueService = leagueService;
        }

        [HttpPost("AddNewLeague")]
        //[Consumes("application/x-www-form-urlencoded")]
        public async Task<IActionResult> AddNewLeague([FromForm]LeagueVM leagueVM)
        {
            if(!ModelState.IsValid) { return BadRequest(ModelState); }
            var result = await _leagueService.CreateLeagueAsync(leagueVM);
            return Ok(result);
        }
        [HttpDelete("DeleteLeague")]
        public async Task<IActionResult> DeleteLeague(int LeagueId)
        {
            if (LeagueId >= 0 && LeagueId == null)
            {
                return BadRequest("League is not valid");
            }
            var result = await _leagueService.DeleteLeagueAsync(LeagueId);
            return Ok(result);
        }
        [HttpGet("GetAllLeague")]
        public async Task<IActionResult> GetAllLeague(int GroupCount)
        {
            if (GroupCount >= 0 && GroupCount == null)
            {
                return BadRequest("GroupCount is not valid");
            }
            var result= await _leagueService.GetAllLeagueAsync(GroupCount);
            return Ok(result);
        }
        [HttpGet("GetLeague")]
        public async Task<IActionResult> GetLeague(int LeagueId)
        {
            if (LeagueId >= 0 && LeagueId == null)
            {
                return BadRequest("League is not valid");
            }
            var result = await _leagueService.GetLeagueAsync(LeagueId);
            return Ok(result);
        }
        [HttpPut("UpdateLeague")]
        public async Task<IActionResult> UpdateLeague(int LeagueId,[FromForm]LeagueVM league)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            if (LeagueId >= 0 && LeagueId == null)
            {
                return BadRequest("League is not valid");
            }
            var result = await _leagueService.UpdateLeagueAsync(LeagueId,league);
            return Ok(result);
        }
    }
}
