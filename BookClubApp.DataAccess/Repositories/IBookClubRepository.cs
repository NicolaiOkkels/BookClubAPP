using System.Collections.Generic;
using BookClubApp.DataAccess.Models;

namespace BookClubApp.DataAccess.Repositories
{
    public interface IBookClubRepository
    {
        IEnumerable<BookClub> GetAllBookClubs();
    }
}