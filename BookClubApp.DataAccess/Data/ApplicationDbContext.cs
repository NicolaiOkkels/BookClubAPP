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

            modelBuilder.Entity<Libraries>().HasData(
                new
                {
                    Id = 1,
                    LibrarieNumber = 700300,
                    LibrarieName = "Poster vedr. sproglige minoriteter Det Kgl. Bibliotek",
                    LibrarieAddress = "Christians Brygge 8",
                    LibrarieZipCode = 1219,
                    LibrarieCity = "København K",
                    PhoneNumber = "33474747",
                    Email = "kb@kb.dk"
                },
                new
                {
                    Id = 2,
                    LibrarieNumber = 700400,
                    LibrarieName = "Dansk Centralbibliotek for Sydslesvig e.V.",
                    LibrarieAddress = "Norderstrasse 59, 24939 Flensburg",
                    LibrarieZipCode = 6330,
                    LibrarieCity = "Padborg",
                    PhoneNumber = "+4946186970",
                    Email = "dcb@dcbib.dk"
                },
                new 
                {
                    Id = 3,
                    LibrarieNumber = 710100,
                    LibrarieName = "Københavns Biblioteker",
                    LibrarieAddress = "Krystalgade 15",
                    LibrarieZipCode = 1172,
                    LibrarieCity = "København K",
                    PhoneNumber = "33663000",
                    Email = "bibliotek@kff.kk.dk"
                },
                new 
                {
                    Id = 4,
                    LibrarieNumber = 714700,
                    LibrarieName = "Biblioteket Frederiksberg",
                    LibrarieAddress = "Falkonér Plads 3",
                    LibrarieZipCode = 2000,
                    LibrarieCity = "Frederiksberg",
                    PhoneNumber = "38211800",
                    Email = "biblioteket@frederiksberg.dk"
                },
                new 
                {
                    Id = 5,
                    LibrarieNumber = 715100,
                    LibrarieName = "Ballerup Bibliotekerne",
                    LibrarieAddress = "Banegårdspladsen 1",
                    LibrarieZipCode = 2750,
                    LibrarieCity = "Ballerup",
                    PhoneNumber = "44773333",
                    Email = "dcb@dcbib.dk"
                }
            );

        }
    }
}