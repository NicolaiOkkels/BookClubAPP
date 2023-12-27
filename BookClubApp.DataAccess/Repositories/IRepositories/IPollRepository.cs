using System.Collections.Generic;
using BookClubApp.DataAccess.Entities;

namespace BookClubApp.DataAccess.Repositories
{
    public interface IPollRepository
    {
        Task<IEnumerable<Poll>> GetPollsAsync();     
        Task<Poll> GetPollByIdAsync(int id);
        Task<Poll> CreatePollAsync(Poll poll, List<int> bookIds);
        Task DeletePollAsync(int id);
        Task<Poll> GetPollAsync(int id);
    }
}