using System.Collections.Generic;
using System.Linq;
using BookClubApp.DataAccess.Data;
using BookClubApp.DataAccess.Models;

namespace BookClubApp.DataAccess.Repositories
{
    public class BookClubRepository : IBookClubRepository
    {
        private readonly BookClubContext _context;

        public BookClubRepository(BookClubContext context)
        {
            _context = context;
        }

        public IEnumerable<BookClub> GetAllBookClubs()
        {
            return _context.BookClubs.ToList();
        }
    }
}