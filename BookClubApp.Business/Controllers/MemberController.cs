using System.Security.Claims;
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

}
