using BookClubApp.Business.Services;
using BookClubApp.DataAccess.Entities;
using Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

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

        public BookClubController(IBookClubService bookClubService, IRoleService roleService, IMembershipService membershipService)
        {
            _bookClubService = bookClubService;
            _roleService = roleService;
            _membershipService = membershipService;
        }

        [HttpGet("getclubs")]
        public async Task<IActionResult> GetBookClubs()
        {
            var bookClubs = await _bookClubService.GetBookClubsAsync();
            return Ok(bookClubs);
        }

        [HttpGet("mybookclubs")]
        public async Task<IActionResult> GetBookClubsByEmail(string email)
        {
            Console.WriteLine(email);
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email is required");
            }

            var bookClubs = await _bookClubService.GetBookClubsByEmailAsync(email);
            Console.WriteLine(bookClubs.ToString());
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

        [HttpPost("joinclub/{bookClubId}/{memberId}")]
        public async Task<IActionResult> JoinBookClub(int bookClubId, int? memberId)
        {
            if (memberId == null)
            {
                return BadRequest("Member not found");
            }
            var roleId = await _roleService.GetRoleIdByNameAsync("Member");
            if (roleId == null)
            {
                return BadRequest("Role not found");
            }

            // Create a new Membership object
            var membership = new Membership
            {
                BookClubId = bookClubId,
                MemberId = memberId.Value,
                RoleId = roleId.Value
            };

            // Save the new Membership object to the database
            await _membershipService.AddMembershipAsync(membership);

            return Ok(membership);
        }

        [HttpPut("updateclub/{id}")]
        public async Task<IActionResult> UpdateBookClub(int id, BookClub bookClub)
        {
            var updatedBookClub = await _bookClubService.UpdateBookClubAsync(id, bookClub);
            return Ok(updatedBookClub);
        }

        [HttpGet("bookclubs/sorted")]
        public async Task<IActionResult> GetSortedBookClubs(string sortBy = "genre", bool isOpen = true, string? genre = null, string? type = null)
        {
            var bookClubs = await _bookClubService.GetBookClubsAsync();

            Console.WriteLine("book club:" + bookClubs.Count());

            var filteredBookClubs = bookClubs.Where(bc => bc.IsOpen == isOpen);

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
    }
}