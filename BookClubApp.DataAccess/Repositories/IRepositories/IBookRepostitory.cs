using System.Collections.Generic;
using BookClubApp.DataAccess.Entities;

namespace BookClubApp.DataAccess.Repositories
{
    public interface IBookRepository
    {
        Task<Book> GetBookByIdentifierAsync(int id);
        Task<Book> AddBookAsync(Book book);
        Task DeleteBookAsync(Book book);
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> UpdateBookAsync(int id, Book book);
        Task SaveChangesAsync();
    }
}