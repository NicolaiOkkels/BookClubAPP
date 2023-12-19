using System.ComponentModel.DataAnnotations;

namespace BookClubApp.DataAccess.Entities
{
    public class BookClub
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Type { get; set; }
        public int? LibrariesId { get; set; }
        public Libraries? Libraries { get; set; }
        public required string Genre { get; set; }
        public required bool IsOpen { get; set; }
        public Book? Book { get; set; }
        public int? MemberId { get; set; }
        public Member? Member { get; set; }
    }
}