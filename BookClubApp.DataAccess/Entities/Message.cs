using System.ComponentModel.DataAnnotations.Schema;

namespace BookClubApp.DataAccess.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public int BookClubId { get; set; }
    }
}