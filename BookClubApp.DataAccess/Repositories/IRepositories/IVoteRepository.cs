using System.Collections.Generic;
using BookClubApp.DataAccess.Entities;

namespace BookClubApp.DataAccess.Repositories
{
    public interface IVoteRepository
    {
        Task AddVoteAsync(Vote vote);
        Task<Vote> GetVoteIdByBookIdAndPollIdAsync(int bookId, int pollId);
    }
}