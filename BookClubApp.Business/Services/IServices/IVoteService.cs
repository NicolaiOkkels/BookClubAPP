using BookClubApp.DataAccess.Entities;

namespace BookClubApp.Business.Services
{
    public interface IVoteService
    {
        Task<Vote?> AddVoteAsync(Vote vote);
        Task<Vote> GetVoteIdByBookIdAndPollIdAsync(int bookId, int pollId);
    }
}