using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookClubApp.DataAccess.Entities
{
    public class Membership
    {
        public int MemberId { get; set; }
        public int RoleId { get; set; }
        public int BookClubId { get; set; }
        public Member Member  { get; set; }
        public BookClub BookClub  { get; set; }
        public Role Role { get; set; }
    }
}