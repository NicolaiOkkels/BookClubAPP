using Microsoft.EntityFrameworkCore;
using BookClubApp.DataAccess.Models;

namespace BookClubApp.DataAccess.Data
{
    public class BookClubContext : DbContext
    {
        public BookClubContext(DbContextOptions<BookClubContext> options)
            : base(options)
        {
        }

        public DbSet<BookClub> BookClubs { get; set; }
    }
}