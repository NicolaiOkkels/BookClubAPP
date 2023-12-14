using System.Collections.Generic;
using BookClubApp.DataAccess.Entities;

namespace BookClubApp.DataAccess.Repositories
{
    public interface IBookRepository
    {
        Task<Book> GetBookByIdentifierAsync(string identifier);
        Task<Book> AddBookAsync(Book book);
        Task DeleteBookAsync(Book book);
        Task<IEnumerable<Book>> GetBooksAsync();
    }
}