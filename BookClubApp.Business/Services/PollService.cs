using BookClubApp.DataAccess.Entities;
using BookClubApp.DataAccess.Repositories;

namespace BookClubApp.Business.Services
{
    public class PollService : IPollService
    {
        private readonly IPollRepository _pollRepository;
        public PollService(IPollRepository pollRepository)
        {
            _pollRepository = pollRepository;
        }

        public async Task<Poll> AddPollAsync(Poll poll, List<int> bookIds)
        {
            return await _pollRepository.CreatePollAsync(poll, bookIds);
        }

        public async Task DeletePollAsync(int id)
        {
            await _pollRepository.DeletePollAsync(id);
        }

        public async Task<Poll> GetPollByIdAsync(int id)
        {
            return await _pollRepository.GetPollByIdAsync(id);
        }

        public async Task<IEnumerable<Poll>> GetPollsAsync()
        {
            return await _pollRepository.GetPollsAsync();
        }
            public async Task<Poll> GetPollAsync(int id)
    {
        return await _pollRepository.GetPollAsync(id);
    }
    }
}