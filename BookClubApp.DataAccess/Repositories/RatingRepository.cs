using BookClubApp.DataAccess.Data;
using BookClubApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookClubApp.DataAccess.Repositories
{
    public class RatingRepository : IRatingRepository
    {
        private readonly ApplicationDbContext _context;

        public RatingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddRatingAsync(Rating rating)
        {
            _context.Ratings.Add(rating);
            await _context.SaveChangesAsync();
        }

        public async Task<Rating> GetRatingAsync(int memberId, int bookId)
        {
            var rating = await _context.Ratings.FirstOrDefaultAsync(r => r.MemberId == memberId && r.BookId == bookId);
            return rating ?? throw new InvalidOperationException("Ingen anmeldse.");
        }

        public async Task<IEnumerable<Rating>> GetRatingsForBookAsync(int bookId)
        {
            return await _context.Ratings.Where(r => r.BookId == bookId).ToListAsync();
        }
    }
}