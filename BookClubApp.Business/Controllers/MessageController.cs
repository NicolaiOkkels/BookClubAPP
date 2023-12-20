using BookClubApp.Business.Services;
using BookClubApp.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookClubApp.Business.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;
        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("GetMessages")]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessages(int bookClubId)
        {
            var messages = await _messageService.GetMessagesAsync();
            return messages
                .Where(m => m.BookClubId == bookClubId)
                .OrderByDescending(m => m.Date)
                .ToList();
        }

        [HttpPost("AddMessage")]
        public async Task<ActionResult<Message>> PostMessage(Message message)
        {
            await _messageService.AddMessageAsync(message);

            return CreatedAtAction(nameof(GetMessages), new { id = message.Id }, message);
        }


    }
}