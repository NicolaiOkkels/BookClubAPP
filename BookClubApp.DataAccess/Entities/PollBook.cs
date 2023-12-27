namespace BookClubApp.DataAccess.Entities
{
    public class PollBook
    {
        public int PollId { get; set; }
        public Poll? Poll { get; set; }

        public int BookId { get; set; }
        public Book? Book { get; set; }
    }
}