using BookClubApp.Business.Services;
using BookClubApp.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookClubApp.Business.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
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
                var existingRating = await _ratingService.GetRatingAsync(rating.MemberId, rating.BookId);

                if (existingRating == null)
                {
                    // If no such rating exists, create a new one
                    await _ratingService.AddRatingAsync(rating);
                }
                else
                {
                    // If a rating from the same member for the same book already exists, update it
                    existingRating.Score = rating.Score;
                    await _ratingService.UpdateRatingAsync(existingRating);
                }

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
