using BookClubApp.DataAccess.Entities;

namespace BookClubApp.Business.Services
{
    public interface ISearchService
    {
        Task<Book> GetBookByIdentifierAsync(int id);
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> AddBookAsync(Book book);
        Task<Book> UpdateBookAsync(int id, Book book);
        Task DeleteBookAsync(Book book);

    }
}