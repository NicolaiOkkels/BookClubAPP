using BookClubApp.DataAccess.Data;
using BookClubApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookClubApp.DataAccess.Repositories
{
    public class VoteRepository : IVoteRepository
    {
        private readonly ApplicationDbContext _context;

        public VoteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddVoteAsync(Vote vote)
        {
            await _context.Votes.AddAsync(vote);
            await _context.SaveChangesAsync();
        }

        public async Task<Vote> GetVoteIdByBookIdAndPollIdAsync(int bookId, int pollId)
        {
            var vote = await _context.Votes.FirstOrDefaultAsync(v => v.BookId == bookId && v.PollId == pollId);
            if (vote == null)
            {
                throw new Exception($"No vote found with book ID {bookId} and poll ID {pollId}");
            }
            return vote;
        }
    }
}