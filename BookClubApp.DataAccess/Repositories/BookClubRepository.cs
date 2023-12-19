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
        public async Task<IEnumerable<BookClub>> GetBookClubsByEmailAsync(string email)
        {
            Console.WriteLine("before");

            var t = await _context.BookClubs
                        .Include(bookClub => bookClub.Member)
                        .Where(bookClub => bookClub.Member.Email == email)
                        .ToListAsync();
            Console.WriteLine("after");   
            Console.WriteLine(t.ToString());        

            return t;
        }

        public async Task<BookClub> UpdateBookClubAsync(int id, BookClub bookClub)
        {
            // Retrieve the existing book club from the database
            var existingBookClub = await _context.BookClubs.FindAsync(id);

            if (existingBookClub == null)
            {
                // Handle the case where the book club doesn't exist
                throw new ArgumentException("Book club with the provided id doesn't exist.");
            }

            // Update the properties of the existing book club
            existingBookClub.Name = bookClub.Name;
            existingBookClub.Description = bookClub.Description;
            existingBookClub.Type = bookClub.Type;
            existingBookClub.LibrariesId = bookClub.LibrariesId;
            existingBookClub.Genre = bookClub.Genre;
            existingBookClub.IsOpen = bookClub.IsOpen;


            // Save the changes back to the database
            await _context.SaveChangesAsync();

            return existingBookClub;
        }
    }
}