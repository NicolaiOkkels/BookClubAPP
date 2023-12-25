using System.Collections.Generic;
using BookClubApp.DataAccess.Entities;

namespace BookClubApp.DataAccess.Repositories
{
    public interface IBookClubRepository
    {
        Task<IEnumerable<BookClub>> GetBookClubsAsync();     
        Task<BookClub> GetBookClubByIdAsync(int id);
        Task<BookClub> CreateBookClubAsync(BookClub bookClub);
        Task<BookClub> UpdateBookClubAsync(int id, BookClub bookClub);
        Task DeleteBookClubAsync(int id);
        //Task<IEnumerable<BookClub>> GetBookClubsByEmailAsync(string email);
    }
}