using BookClubApp.DataAccess.Entities;

namespace BookClubApp.Business.Services
{
    public interface IRatingService
    {
        Task AddRatingAsync(Rating rating);
        Task<double> GetAverageRatingAsync(int bookId);
    }
}