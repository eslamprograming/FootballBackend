using BLL.IService;
using BLL.Service;
using DAL.Models.StandingsVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Football.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StandingsController : ControllerBase
    {
        private readonly IStandingsService _standingsService;

        public StandingsController(IStandingsService standingsService)
        {
            _standingsService = standingsService;
        }
        [HttpPost("AddNewStandings")]
        public async Task<IActionResult> AddNewStandings([FromForm] StandingsVM StandingsVM)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var result = await _standingsService.CreateStandingssAsync(StandingsVM);
            return Ok(result);
        }
        [HttpDelete("DeleteStandings")]
        public async Task<IActionResult> DeleteStandings(int StandingsId)
        {
            if (StandingsId >= 0 && StandingsId == null)
            {
                return BadRequest("Standings is not valid");
            }
            var result = await _standingsService.DeleteStandingssAsync(StandingsId);
            return Ok(result);
        }
        [HttpGet("GetAllStandings")]
        public async Task<IActionResult> GetAllStandings(int GroupCount)
        {
            if (GroupCount >= 0 && GroupCount == null)
            {
                return BadRequest("GroupCount is not valid");
            }
            var result = await _standingsService.GetAllStandingssAsync(GroupCount);
            return Ok(result);
        }
        [HttpGet("GetStandings")]
        public async Task<IActionResult> GetStandings(int StandingsId)
        {
            if (StandingsId >= 0 && StandingsId == null)
            {
                return BadRequest("Standings is not valid");
            }
            var result = await _standingsService.GetStandingssAsync(StandingsId);
            return Ok(result);
        }
        [HttpPut("UpdateStandings")]
        public async Task<IActionResult> UpdateStandings(int StandingsId,[FromForm] StandingsVM Standings)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            if (StandingsId >= 0 && StandingsId == null)
            {
                return BadRequest("Standings is not valid");
            }
            var result = await _standingsService.UpdateStandingssAsync(StandingsId, Standings);
            return Ok(result);
        }
    }
}
