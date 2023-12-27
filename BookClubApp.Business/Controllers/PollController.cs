using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BookClubApp.DataAccess.Entities;
using BookClubApp.Business.Services;


namespace BookClubAPI.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class PollController : ControllerBase
{
    private readonly IPollService _pollService;

    public PollController(IPollService pollService)
    {
        _pollService = pollService;
    }

    [HttpGet("getpolls")]
    public async Task<IActionResult> GetPolls()
    {
        var polls = await _pollService.GetPollsAsync();
        return Ok(polls);
    }

    [HttpPost("addpoll")]
    public async Task<IActionResult> AddPoll([FromBody] Poll poll)
    {
        var createdPoll = await _pollService.AddPollAsync(poll, poll.PollBooks.Select(pb => pb.BookId).ToList());
        return CreatedAtAction(nameof(GetPoll), new { id = createdPoll.Id }, createdPoll);
    }

    [HttpGet("getpoll/{id}")]
    public async Task<IActionResult> GetPoll(int id)
    {
        var poll = await _pollService.GetPollAsync(id);
        if (poll == null)
        {
            return NotFound();
        }
        return Ok(poll);
    }

    [HttpDelete("deletepoll/{id}")]
    public async Task<IActionResult> DeletePoll(int id)
    {
        await _pollService.DeletePollAsync(id);
        return Ok();
    }
}