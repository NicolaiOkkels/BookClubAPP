namespace BookClubApp.DataAccess.Entities
{
    public class Book
    {
        public int Id { get; set; } // Primary key
        public string? Identifier { get; set; } // ac:identifier
        public string? ISBN { get; set; } // dc:identifier
        public string? Title { get; set; } // dc:title
        public string? Description { get; set; } // dc:description
        public string? Publisher { get; set; } // dc:publisher
        public int PublicationYear { get; set; } // dc:date
        public string? Language { get; set; } // dc:language
        public string? Pages { get; set; } //dcterms:extent
    }
}