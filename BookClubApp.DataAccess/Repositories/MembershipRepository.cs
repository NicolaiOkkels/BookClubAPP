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

        public async Task<Membership> DeleteMembershipAsync(Membership membership)
        {
            _context.Memberships.Remove(membership);
            await _context.SaveChangesAsync();
            return membership;
        }

        public async Task<Membership> GetMembershipAsync(int bookClubId, int value)
        {
            var membership = await _context.Memberships
                                    .Include(membership => membership.Member)
                                    .Include(membership => membership.BookClub)
                                    .Include(membership => membership.Role)
                                    .FirstOrDefaultAsync(membership => membership.MemberId == value && membership.BookClubId == bookClubId);

            return membership;
        }

        public async Task<IEnumerable<Membership>> GetAllMembershipsAsync()
        {
            var memberships = await _context.Memberships
                        .Include(membership => membership.Member)
                        .Include(membership => membership.BookClub)
                        .Include(membership => membership.Role)
                        .ToListAsync();

            return memberships;
        }
        public async Task<IEnumerable<Membership>> GetMembershipsByEmailAsync(string email)
        {
            var memberships = await _context.Memberships
                                    .Include(membership => membership.Member)
                                    .Include(membership => membership.BookClub)
                                    .Include(membership => membership.Role) // Include Role information
                                    .Where(membership => membership.Member.Email == email)
                                    .ToListAsync();

            return memberships;
        }
    }
}