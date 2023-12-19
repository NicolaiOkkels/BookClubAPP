namespace BookClubApp.DataAccess.Entities
{
public class Rating
{
    public int MemberId { get; set; }
    public int BookId { get; set; }
    public int Score { get; set; }

    public virtual Member? Member { get; set; }
    public virtual Book? Book { get; set; }
}
}
