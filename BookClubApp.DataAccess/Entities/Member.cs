
using System;

namespace BookClubApp.DataAccess.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public required string Email { get; set; }

    }
}
