using BookClubApp.DataAccess.Data;
using BookClubApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookClubApp.DataAccess.Repositories
{
    public class MembershipRepository : IMembershipRepository
    {
        private readonly ApplicationDbContext _context;
        public MembershipRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Membership> AddMembershipAsync(Membership membership)
        {
            _context.Memberships.Add(membership);
            await _context.SaveChangesAsync();
            return membership;
        }

        public async Task<IEnumerable<Membership>> GetMembershipsAsync()
        {
            return await _context.Memberships.ToListAsync();
        }
    }
}