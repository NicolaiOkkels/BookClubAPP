using BookClubApp.Business.Services;
using BookClubApp.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookClubApp.Business.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class VoteController : ControllerBase
    {
        private readonly IVoteService _voteService;

        public VoteController(IVoteService voteService)
        {
            _voteService = voteService;
        }

        [HttpPost("AddVote")]
        public async Task<IActionResult> AddVote([FromBody] Vote vote)
        {
            return Ok(await _voteService.AddVoteAsync(vote));
        }

        [HttpGet("GetVote/{bookId}/{pollId}")]
        public async Task<IActionResult> GetVote(int bookId, int pollId)
        {
            try
            {
                var vote = await _voteService.GetVoteIdByBookIdAndPollIdAsync(bookId, pollId);
                return Ok(vote);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}