using BookClubApp.Business.Services;
using BookClubApp.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BookClubApp.Business.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpPost("AddRating")]
        public async Task<IActionResult> AddRating([FromBody] Rating rating)
        {
            try
            {
                await _ratingService.AddRatingAsync(rating);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("avg/{bookId}")]
        public async Task<IActionResult> GetAverageRating(int bookId)
        {
            try
            {
                var averageRating = await _ratingService.GetAverageRatingAsync(bookId);
                return Ok(averageRating);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
