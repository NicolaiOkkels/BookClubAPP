using BookClubApp.DataAccess.Entities;

namespace BookClubApp.DataAccess.Repositories
{
    public interface IRatingRepository
    {
        Task<Rating> GetRatingAsync(int memberId, int bookId);
        Task AddRatingAsync(Rating rating);
        Task<IEnumerable<Rating>> GetRatingsForBookAsync(int bookId);
        Task UpdateRatingAsync(Rating rating);
    }
}