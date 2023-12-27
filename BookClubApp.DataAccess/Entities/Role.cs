using System.ComponentModel.DataAnnotations;

namespace BookClubApp.DataAccess.Entities
{
    public class Role
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
    }
}