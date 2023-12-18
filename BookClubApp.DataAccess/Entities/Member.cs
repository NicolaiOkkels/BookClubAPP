
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BookClubApp.DataAccess.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public required string Email { get; set; }
       // public virtual ICollection<Membership>? Memberships { get; set; }
    }
}
