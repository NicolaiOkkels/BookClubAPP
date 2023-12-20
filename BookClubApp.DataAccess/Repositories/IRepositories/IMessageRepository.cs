using System.Collections.Generic;
using BookClubApp.DataAccess.Entities;

namespace BookClubApp.DataAccess.Repositories
{
    public interface IMessageRepository
    {
        Task<Message> GetMessageByIdAsync(int id);
        Task<Message> AddMessageAsync(Message message);
        Task DeleteMessageAsync(Message message);
        Task<IEnumerable<Message>> GetMessagesAsync();
        Task<Message> UpdateMessageAsync(int id, Message message);
        Task SaveChangesAsync();
    }
}