namespace BookClubApp.DataAccess.Entities
{
    public class Vote
{
    public int Id { get; set; }
    public int PollId { get; set; }
    public Poll? Poll { get; set; }
    public int BookId { get; set; }
    public Book? Book { get; set; }
}
}