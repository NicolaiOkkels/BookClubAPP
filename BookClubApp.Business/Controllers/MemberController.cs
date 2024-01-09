using System.Security.Claims;
using BookClubApp.Business.Services;
using BookClubApp.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookClubAPI.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]

public class MemberController : ControllerBase
{
    private readonly IMemberService _memberService;
    private readonly ILogger<MemberController> _logger;

    public MemberController(IMemberService memberService, ILogger<MemberController> logger)
    {
        _memberService = memberService;
        _logger = logger;
    }

    [HttpGet("getmembers")]
    public async Task<IActionResult> Get()
    {
        try
        {
            _logger.LogInformation("Getting all members");
            return Ok(await _memberService.GetMemberAsync());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting all members");
            throw new Exception(ex.Message);
        }
    }
    [HttpGet("getmemberbyemail")]
    public async Task<IActionResult> GetMemberByEmail(string email)
    {
        try
        {
            _logger.LogInformation("Getting member by email: {Email}", email);
            return Ok(await _memberService.GetMemberByEmailAsync(email));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting member by email: {Email}", email);
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

    [HttpGet("getmemberid")]
    public async Task<IActionResult> GetMemberIdByEmail(string email)
    {
        try
        {
            _logger.LogInformation("Getting member ID by email: {Email}", email);
            return Ok(await _memberService.GetMemberIdByEmailAsync(email));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting member ID by email: {Email}", email);
            throw new Exception(ex.Message);
        }
    }

}
