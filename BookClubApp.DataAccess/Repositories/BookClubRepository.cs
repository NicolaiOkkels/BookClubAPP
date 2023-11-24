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

        public async Task<BookClub> CreateBookClubAsync(BookClub bookClub)
        {
            _context.BookClubs.Add(bookClub);
            await _context.SaveChangesAsync();
            return bookClub;
        }

        public Task DeleteBookClubAsync(int id)
        {
            throw new NotImplementedException();
        }


        public async Task<BookClub> GetBookClubByIdAsync(int id)
        {
            return await _context.BookClubs.FirstOrDefaultAsync(bookClub => bookClub.Id == id);
        }

        public async Task<IEnumerable<BookClub>> GetBookClubsAsync()
        {
            return await _context.BookClubs.ToListAsync();
        }

        public Task<BookClub> UpdateBookClubAsync(int id, BookClub bookClub)
        {
            throw new NotImplementedException();
        }
    }
}