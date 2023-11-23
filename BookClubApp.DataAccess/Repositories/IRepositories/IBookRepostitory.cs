using System.Collections.Generic;
using BookClubApp.DataAccess.Entities;

namespace BookClubApp.DataAccess.Repositories
{
    public interface IBookRepository
    {
        Task<Book> GetBookByIdentifierAsync(string identifier);
        Task AddBookAsync(Book book);
    }
}