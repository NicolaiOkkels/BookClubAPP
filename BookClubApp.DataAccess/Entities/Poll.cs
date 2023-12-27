using System.Collections.Generic;

namespace BookClubApp.DataAccess.Entities
{
    public class Poll
    {
        public int Id { get; set; }
        public int BookClubId { get; set; }
        public BookClub? BookClub { get; set; }
        public List<PollBook> PollBooks { get; set; } = new List<PollBook>();
    }
}