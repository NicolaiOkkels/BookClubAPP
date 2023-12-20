using BookClubApp.DataAccess.Entities;

namespace BookClubApp.Business.Services
{
    public interface IMessageService
    {
        Task<Message> AddMessageAsync(Message message);
        Task DeleteMessageAsync(Message message);
        Task<Message> GetMessageByIdAsync(int id);
        Task<IEnumerable<Message>> GetMessagesAsync();
        Task<Message> UpdateMessageAsync(int id, Message message);
    }
}