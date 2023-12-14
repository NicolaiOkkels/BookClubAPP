using BookClubApp.DataAccess.Data;
using BookClubApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookClubApp.DataAccess.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();   
            return book;
        }

        public Task DeleteBookAsync(Book book)
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetBookByIdentifierAsync(string identifier)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }
    }

}