using BookClubApp.DataAccess.Entities;
using BookClubApp.DataAccess.Repositories;

namespace BookClubApp.Business.Services
{
    public class VoteService : IVoteService
    {
        private readonly IVoteRepository _voteRepository;

    
        public VoteService(IVoteRepository voteRepository)
        {
            _voteRepository = voteRepository;
        }

        public async Task<Vote> AddVoteAsync(Vote vote)
        {
            await _voteRepository.AddVoteAsync(vote);
            return vote;
        }

        public async Task<Vote> GetVoteIdByBookIdAndPollIdAsync(int bookId, int pollId)
        {
            var returnedVote = await _voteRepository.GetVoteIdByBookIdAndPollIdAsync(bookId, pollId);
            return returnedVote;
        }

    }
}