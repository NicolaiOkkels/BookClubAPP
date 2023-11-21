using System.Collections.Generic;
using BookClubApp.DataAccess.Entities;

namespace BookClubApp.DataAccess.Repositories
{
    public interface IBookClubRepository
    {
        Task<IEnumerable<BookClub>> GetBookClubsAsync();        
    }
}