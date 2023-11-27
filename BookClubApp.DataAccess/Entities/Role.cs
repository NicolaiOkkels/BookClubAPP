using System.Collections.ObjectModel;

namespace BookClubApp.DataAccess.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public virtual ICollection<Membership> Memberships { get; set; }
    }
}
