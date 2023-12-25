using BookClubApp.Business.Services;
using BookClubApp.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BookClubApp.Business.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    [EnableCors("AllowSpecificOrigin")]
    public class MembershipController : ControllerBase
    {
        private readonly IBookClubService _bookClubService;
        private readonly IRoleService _roleService;
        private readonly IMembershipService _membershipService;

        public MembershipController(IBookClubService bookClubService, IRoleService roleService, IMembershipService membershipService)
        {
            _bookClubService = bookClubService;
            _roleService = roleService;
            _membershipService = membershipService;
        }


        [HttpGet("mymemberships")]
        public async Task<IActionResult> GetMembershipsByEmail(string email)
        {
            Console.WriteLine(email);
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email is required");
            }

            var memberships = await _membershipService.GetMembershipsByEmailAsync(email);
            Console.WriteLine(memberships.ToString());
            return Ok(memberships);
        }
        [HttpGet("getAllMemberships")]
        public async Task<IActionResult> GetAllMembershipsAsync()
        {
            var memberships = await _membershipService.GetAllMembershipsAsync();
            return Ok(memberships);
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

        [HttpPost("leaveclub/{bookClubId}/{memberId}")]
        public async Task<IActionResult> LeaveBookClub(int bookClubId, int? memberId)
        {
            if (memberId == null)
            {
                return BadRequest("Member not found");
            }

            // Get the Membership object
            var membership = await _membershipService.GetMembershipAsync(bookClubId, memberId.Value);

            if (membership == null)
            {
                return BadRequest("Membership not found");
            }

            // Delete the Membership object from the database
            await _membershipService.DeleteMembershipAsync(membership);

            return Ok(membership);
        }




    }



}