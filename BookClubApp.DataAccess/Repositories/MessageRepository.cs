using BookClubApp.DataAccess.Data;
using BookClubApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BookClubApp.DataAccess.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<MessageRepository> _logger;

        public MessageRepository(ApplicationDbContext context, ILogger<MessageRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Message> AddMessageAsync(Message message)
        {
            _logger.LogInformation("bookClubId in AddMessageAsync: {bookClubId}", message.BookClubId);

            var bookClub = await _context.BookClubs.FindAsync(message.BookClubId);
            if (bookClub == null)
            {
                throw new Exception($"No book club found with ID {message.BookClubId}");
            }

           // message.BookClub = bookClub;
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
            return message;
        }

        public Task DeleteMessageAsync(Message message)
        {
            return Task.FromResult(_context.Messages.Remove(message));
        }

        public async Task<Message> GetMessageByIdAsync(int id)
        {
            var message = await _context.Messages.FirstOrDefaultAsync(m => m.Id == id);
            if (message == null)
            {
                throw new Exception($"No message found with ID {id}");
            }
            return message;
        }

        public async Task<IEnumerable<Message>> GetMessagesAsync()
        {
            return await _context.Messages.ToListAsync();
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public async Task<Message> UpdateMessageAsync(int id, Message message)
        {
            _context.Messages.Update(message);
            await _context.SaveChangesAsync();
            return message;
        }
    }
}