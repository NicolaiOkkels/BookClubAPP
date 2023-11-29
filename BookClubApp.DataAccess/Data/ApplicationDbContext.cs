using Microsoft.EntityFrameworkCore;
using BookClubApp.DataAccess.Entities;

namespace BookClubApp.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Member> Members { get; set; }
        public DbSet<BookClub> BookClubs { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Membership>().HasKey(m=> new {m.MemberId, m.BookClubId, m.RoleId});
            modelBuilder.Entity<Rating>().HasKey(r => new { r.MemberId, r.BookId });
        }
    }
}