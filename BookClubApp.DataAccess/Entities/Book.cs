namespace BookClubApp.DataAccess.Entities
{
    public class Book
    {
        public int Id { get; set; } // Primary key
        public string Title { get; set; }
        public string Author { get; set; }
        public string CoverImage { get; set; }
        public string Pid { get; set; }
        public string MaterialType { get; set; }
    }
}