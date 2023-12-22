using BookClubApp.DataAccess.Entities;

namespace BookClubApp.Business.Services
{
    public interface IBookClubService
    {
        Task<IEnumerable<BookClub>> GetBookClubsAsync();
        Task<BookClub> GetBookClubByIdAsync(int id);
        Task<BookClub> CreateBookClubAsync(BookClub bookClub, int ownerId, int roleId);
        Task<BookClub> UpdateBookClubAsync(int id, BookClub bookClub);
        Task DeleteBookClubAsync(int id);
        Task<IEnumerable<BookClub>> GetBookClubsByEmailAsync(string email);
        Task<Membership> JoinBookClubAsync(int bookClubId, int memberId, int roleId);
    }
}