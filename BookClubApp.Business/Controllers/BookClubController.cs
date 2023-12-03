using BookClubApp.Business.Services;
using BookClubApp.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookClubApp.Business.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class BookClubController : ControllerBase
    {
        private readonly IBookClubService _bookClubService;

        public BookClubController(IBookClubService bookClubService)
        {
            _bookClubService = bookClubService;
        }

        [HttpGet("getclubs")]
        public async Task<IActionResult> GetBookClubs()
        {
            var bookClubs = await _bookClubService.GetBookClubsAsync();
            return Ok(bookClubs);
        }

        [HttpGet("getclub/{id}")]
        public async Task<IActionResult> GetBookClubById(int id)
        {
            var bookClub = await _bookClubService.GetBookClubByIdAsync(id);
            return Ok(bookClub);
        }
        [HttpPost("createclub")]
        public async Task<IActionResult> CreateBookClub(BookClub bookClub)
        {
            var createdBookClub = await _bookClubService.CreateBookClubAsync(bookClub);
            return CreatedAtAction(nameof(GetBookClubById), new {id = createdBookClub.Id}, createdBookClub);
        }

    }
}