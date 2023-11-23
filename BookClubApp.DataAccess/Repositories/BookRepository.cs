using BookClubApp.DataAccess.Data;
using BookClubApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookClubApp.DataAccess.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context){
            _context = context;
        }

        public async Task AddBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task<Book> GetBookByIdentifierAsync(string identifier)
        {
            return await _context.Books.FirstOrDefaultAsync(book => book.Identifier == identifier);
        }
    }

}