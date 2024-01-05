using Microsoft.EntityFrameworkCore;
using BookClubApp.DataAccess.Entities;
using Enums;

namespace BookClubApp.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Member> Members { get; set; }
        public DbSet<BookClub> BookClubs { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Libraries> Libraries { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Poll> Polls { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<PollBook> PollBook { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Membership>().HasKey(m => new { m.MemberId, m.BookClubId, m.RoleId });
            modelBuilder.Entity<Rating>().HasKey(r => new { r.MemberId, r.BookId });
            modelBuilder.Entity<PollBook>().HasKey(pb => new { pb.PollId, pb.BookId });

            // Load data from Excel
            var librariesData = ExcelDataLoader.LoadDataFromExcel("../publiclibraries.csv");

            // Seed the data
            modelBuilder.Entity<Libraries>().HasData(librariesData);

        }
    }
}