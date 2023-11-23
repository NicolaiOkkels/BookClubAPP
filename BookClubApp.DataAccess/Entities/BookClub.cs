namespace BookClubApp.DataAccess.Entities
{
    public class BookClub
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Type { get; set; }
        public required string Region { get; set; }
        public ICollection<Book> Books { get; set; }
        public ICollection<Member> Members { get; set; }    
    }
}