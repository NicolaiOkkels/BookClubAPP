using BookClubApp.Business.Services;
using BookClubApp.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookClubAPI.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]

public class MemberController : ControllerBase
{
    private readonly IMemberService _memberService;

    public MemberController(IMemberService memberService)

    {
        _memberService = memberService;
    }

    [HttpGet("getmembers")]
    public async Task<IActionResult> Get()
    {
        try
        {
            return Ok(await _memberService.GetMemberAsync());
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

    }
    [HttpGet("getmemberbyemail")]
    public async Task<IActionResult> GetMemberByEmail(string email)
    {
        try
        {
            return Ok(await _memberService.GetMemberByEmailAsync(email));
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    [HttpPost("addmember")]
    public async Task<IActionResult> AddMember(Member member)
    {
        try
        {
            return Ok(await _memberService.AddMemberAsync(member));
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

}
