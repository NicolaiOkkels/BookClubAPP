using Microsoft.EntityFrameworkCore;
using BookClubApp.DataAccess.Entities;

namespace BookClubApp.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Member> Members { get; set; }
        public DbSet<BookClub> BookClubs { get; set; }
        // public DbSet<Book> Books { get; set; }
        // public DbSet<Meeting> Meetings { get; set; }
        // public DbSet<MeetingBook> MeetingBooks { get; set; }
        // public DbSet<MeetingMember> MeetingMembers { get; set; }
    }
}