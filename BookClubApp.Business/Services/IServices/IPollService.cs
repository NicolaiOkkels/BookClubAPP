using BookClubApp.DataAccess.Entities;

namespace BookClubApp.Business.Services
{
    public interface IPollService
    {
    Task<Poll> AddPollAsync(Poll poll, List<int> bookIds);
    Task DeletePollAsync(int id);
    Task<Poll> GetPollAsync(int id);  // Add this line
    Task<Poll> GetPollByIdAsync(int id);
    Task<IEnumerable<Poll>> GetPollsAsync();
    }
}