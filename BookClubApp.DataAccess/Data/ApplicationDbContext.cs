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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Membership>().HasKey(m=> new {m.MemberId, m.BookClubId, m.RoleId});
            modelBuilder.Entity<Rating>().HasKey(r => new { r.MemberId, r.BookId });

            // Dummy data
            modelBuilder.Entity<Book>().HasData(
                new { Id = 1, Identifier = "A123", ISBN = "978-3-16-148410-0", Title = "Sample Book 1", Description = "Description of Book 1", Publisher = "Publisher 1", PublicationYear = 2020, Language = "English", Pages = "300" },
                new { Id = 2, Identifier = "B456", ISBN = "978-1-23-456789-7", Title = "Sample Book 2", Description = "Description of Book 2", Publisher = "Publisher 2", PublicationYear = 2021, Language = "Spanish", Pages = "250" }
            );

            modelBuilder.Entity<Member>().HasData(
                new { Id = 1, Name = "John Doe", BirthDate = new DateTime(1980, 1, 1), Email = "john.doe@example.com" },
                new { Id = 2, Name = "Jane Smith", BirthDate = new DateTime(1990, 5, 20), Email = "jane.smith@example.com" }
            );

            modelBuilder.Entity<Role>().HasData(
                new { Id = 1, Name = UserRole.Member.ToString()},
                new { Id = 2, Name = UserRole.Owner.ToString()}
            );

            modelBuilder.Entity<BookClub>().HasData(
              new { Id = 1, Name = "Book Club 1", Description = "Description of Book Club 1", Type = ClubType.Online.ToString(), LibrariesId = 1, Genre = Genres.Fiction.ToString(), IsOpen = true},
            new { Id = 2, Name = "Book Club 2", Description = "Description of Book Club 2", Type = ClubType.Local.ToString(), LibrariesId = 2, Genre = Genres.NonFiction.ToString(), IsOpen = false }
);



            modelBuilder.Entity<Membership>().HasData(
                new { MemberId = 1, RoleId = 1, BookClubId = 1 },
                new { MemberId = 2, RoleId = 2, BookClubId = 1 }
            );
            
            modelBuilder.Entity<Rating>().HasData(
                new Rating { Id = 1, MemberId = 1, BookId = 1, Score = 5 },
                new Rating { Id = 2, MemberId = 1, BookId = 2, Score = 4 }
            );

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
                }
            );

        }
    }
}