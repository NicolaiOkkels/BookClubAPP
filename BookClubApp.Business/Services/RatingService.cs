using BookClubApp.DataAccess.Entities;
using BookClubApp.DataAccess.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BookClubApp.Business.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepository _ratingRepository;

        public RatingService(IRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public async Task AddRatingAsync(Rating rating)
        {
            if (rating.Score < 1 || rating.Score > 5)
            {
                throw new ArgumentException("Rating score skal være mellem 1 og 5.");
            }

            var existingRating = await _ratingRepository.GetRatingAsync(rating.MemberId, rating.BookId);
            if (existingRating != null)
            {
                throw new InvalidOperationException("Denne bog er allerede blevet anmeldt");
            }

            await _ratingRepository.AddRatingAsync(rating);
        }

        public async Task<double> GetAverageRatingAsync(int bookId)
        {
            var ratings = await _ratingRepository.GetRatingsForBookAsync(bookId);
            if (ratings.Any())
            {
                return ratings.Average(r => r.Score);
            }
            return 0;
        }

        public async Task<Rating> GetRatingAsync(int memberId, int bookId)
        {
            return await _ratingRepository.GetRatingAsync(memberId, bookId);
        }

        public async Task UpdateRatingAsync(Rating rating)
        {
            await _ratingRepository.UpdateRatingAsync(rating);
        }
    }
}