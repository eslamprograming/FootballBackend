using BLL.IService;
using BLL.Service;
using DAL.Models.Match;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Football.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _matchService;

        public MatchController(IMatchService matchService)
        {
            _matchService = matchService;
        }
        [HttpPost("AddNewMatch")]
        public async Task<IActionResult> AddNewMatch([FromForm]MatchVM MatchVM)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var result = await _matchService.CreateMatchsAsync(MatchVM);
            return Ok(result);
        }
        [HttpDelete("DeleteMatch")]
        public async Task<IActionResult> DeleteMatch(int MatchId)
        {
            if (MatchId >= 0 && MatchId == null)
            {
                return BadRequest("Match is not valid");
            }
            var result = await _matchService.DeleteMatchsAsync(MatchId);
            return Ok(result);
        }
        [HttpGet("GetAllMatch")]
        public async Task<IActionResult> GetAllMatch(int GroupCount)
        {
            if (GroupCount >= 0 && GroupCount == null)
            {
                return BadRequest("GroupCount is not valid");
            }
            var result = await _matchService.GetAllMatchsAsync(GroupCount);
            return Ok(result);
        }
        [HttpGet("GetMatch")]
        public async Task<IActionResult> GetMatch(int MatchId)
        {
            if (MatchId >= 0 && MatchId == null)
            {
                return BadRequest("Match is not valid");
            }
            var result = await _matchService.GetMatchsAsync(MatchId);
            return Ok(result);
        }
        [HttpPut("UpdateMatch")]
        public async Task<IActionResult> UpdateMatch(int MatchId,[FromForm] UpdateMatchVM Match)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            if (MatchId >= 0 && MatchId == null)
            {
                return BadRequest("Match is not valid");
            }
            var result = await _matchService.UpdateMatchsAsync(MatchId, Match);

            return Ok(result);
        }
    }
}
