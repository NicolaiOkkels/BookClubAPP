using BookClubApp.Business.Services;
using BookClubApp.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookClubApp.Business.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    [EnableCors("AllowSpecificOrigin")]
    public class BookClubController : ControllerBase
    {
        private readonly IBookClubService _bookClubService;
        private readonly IRoleService _roleService;
        private readonly IMembershipService _membershipService;
        private readonly ILogger<BookClubController> _logger;

        public BookClubController(IBookClubService bookClubService, IRoleService roleService, IMembershipService membershipService, ILogger<BookClubController> logger) // Add logger to the constructor
        {
            _bookClubService = bookClubService;
            _roleService = roleService;
            _membershipService = membershipService;
            _logger = logger;
        }

        [HttpGet("getclubs")]
        public async Task<IActionResult> GetBookClubs()
        {
            _logger.LogInformation("Getting all book clubs");
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
            var memberId = bookClub.MemberId;
            if (memberId == null)
            {
                return BadRequest("Member not found");
            }
            var roleId = await _roleService.GetRoleIdByNameAsync("Owner");
            if (roleId == null)
            {
                return BadRequest("Role not found");
            }
            var createdBookClub = await _bookClubService.CreateBookClubAsync(bookClub, memberId.Value, roleId.Value);
            return CreatedAtAction(nameof(GetBookClubById), new { id = createdBookClub.Id }, createdBookClub);
        }



        [HttpPut("updateclub/{id}")]
        public async Task<IActionResult> UpdateBookClub(int id, BookClub bookClub)
        {
            var updatedBookClub = await _bookClubService.UpdateBookClubAsync(id, bookClub);
            return Ok(updatedBookClub);
        }

        [HttpGet("bookclubs/sorted")]
        public async Task<IActionResult> GetSortedBookClubs(string sortBy = "genre", string? genre = null, string? type = null)
        {
            var bookClubs = await _bookClubService.GetBookClubsAsync();

            Console.WriteLine("book club:" + bookClubs.Count());

            var filteredBookClubs = bookClubs;

            if (!string.IsNullOrEmpty(genre))
            {
                filteredBookClubs = filteredBookClubs.Where(bc => bc.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(type))
            {
                filteredBookClubs = filteredBookClubs.Where(bc => bc.Type.Equals(type, StringComparison.OrdinalIgnoreCase));
            }

            Console.WriteLine("filter: " + filteredBookClubs);

            // Apply sorting
            IEnumerable<BookClub> sortedBookClubs;
            switch (sortBy.ToLower())
            {
                case "type":
                    sortedBookClubs = filteredBookClubs.OrderBy(bc => bc.Type);
                    break;
                case "genre":
                    sortedBookClubs = filteredBookClubs.OrderBy(bc => bc.Genre);
                    break;
                default:
                    sortedBookClubs = filteredBookClubs;
                    break;
            }
            Console.WriteLine(sortedBookClubs);
            return Ok(sortedBookClubs);
        }

        [HttpDelete("deleteclub/{id}")]
        public async Task<IActionResult> DeleteBookClub(int id)
        {
            try
            {
                await _bookClubService.DeleteBookClubAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}