using BookClubApp.DataAccess.Entities;

namespace BookClubApp.Business.Services
{
    public interface IBookClubService
    {
        Task<IEnumerable<BookClub>> GetBookClubsAsync();
        Task<BookClub> GetBookClubByIdAsync(int id);
        Task<BookClub> CreateBookClubAsync(BookClub bookClub);
        Task<BookClub> UpdateBookClubAsync(int id, BookClub bookClub);
        Task DeleteBookClubAsync(int id);
    }
}