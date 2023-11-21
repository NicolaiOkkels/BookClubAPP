using BookClubApp.DataAccess.Entities;

namespace BookClubApp.Business.Services
{
    public interface IBookClubService
    {
        Task<IEnumerable<BookClub>> GetBookClubsAsync();
    }
}