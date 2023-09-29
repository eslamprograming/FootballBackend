using BLL.IService;
using BLL.Service;
using DAL.Models.VenueVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Football.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VenueController : ControllerBase
    {
        private readonly IVenueService _venueService;

        public VenueController(IVenueService venueService)
        {
            _venueService = venueService;
        }
        [HttpPost("AddNewVenue")]
        public async Task<IActionResult> AddNewVenue(VenueVM VenueVM)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var result = await _venueService.CreateVenuesAsync(VenueVM);
            return Ok(result);
        }
        [HttpDelete("DeleteVenue")]
        public async Task<IActionResult> DeleteVenue(int VenueId)
        {
            if (VenueId >= 0 && VenueId == null)
            {
                return BadRequest("Venue is not valid");
            }
            var result = await _venueService.DeleteVenuesAsync(VenueId);
            return Ok(result);
        }
        [HttpGet("GetAllVenue")]
        public async Task<IActionResult> GetAllVenue(int GroupCount)
        {
            if (GroupCount >= 0 && GroupCount == null)
            {
                return BadRequest("GroupCount is not valid");
            }
            var result = await _venueService.GetAllVenuesAsync(GroupCount);
            return Ok(result);
        }
        [HttpGet("GetVenue")]
        public async Task<IActionResult> GetVenue(int VenueId)
        {
            if (VenueId >= 0 && VenueId == null)
            {
                return BadRequest("Venue is not valid");
            }
            var result = await _venueService.GetAllVenuesAsync(VenueId);
            return Ok(result);
        }
        [HttpPut("UpdateVenue")]
        public async Task<IActionResult> UpdateVenue(int VenueId, VenueVM Venue)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            if (VenueId >= 0 && VenueId == null)
            {
                return BadRequest("Venue is not valid");
            }
            var result = await _venueService.UpdateVenuesAsync(VenueId, Venue);
            return Ok(result);
        }
    }
}
