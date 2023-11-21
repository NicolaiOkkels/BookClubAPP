using BookClubApp.DataAccess.Data;
using BookClubApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookClubApp.DataAccess.Repositories
{
    public class BookClubRepository : IBookClubRepository
    {
        private readonly ApplicationDbContext _context;

        public BookClubRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BookClub>> GetBookClubsAsync()
        {
            return await _context.BookClubs.ToListAsync();
        }
    }
}