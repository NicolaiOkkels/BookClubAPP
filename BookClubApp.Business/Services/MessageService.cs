using BookClubApp.DataAccess.Entities;
using BookClubApp.DataAccess.Repositories;

namespace BookClubApp.Business.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<IEnumerable<Message>> GetMessagesAsync()
        {
            return await _messageRepository.GetMessagesAsync();
        }

        public async Task<Message> GetMessageByIdAsync(int id)
        {
            return await _messageRepository.GetMessageByIdAsync(id);
        }

        public async Task<Message> AddMessageAsync(Message message)
        {
            return await _messageRepository.AddMessageAsync(message);
        }

        public async Task DeleteMessageAsync(Message message)
        {
            await _messageRepository.DeleteMessageAsync(message);
        }

        public async Task<Message> UpdateMessageAsync(int id, Message message)
        {
            return await _messageRepository.UpdateMessageAsync(id, message);
        }
    }
}