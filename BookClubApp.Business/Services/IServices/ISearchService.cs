using BookClubApp.DataAccess.Entities;

namespace BookClubApp.Business.Services
{
    public interface ISearchService
    {
       Task<IEnumerable<Book>> SearchBookAsync(string query);
       Task<Book> GetBookByIdentifier(string identifier);
    }
}