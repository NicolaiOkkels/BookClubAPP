using BookClubApp.DataAccess.Entities;

namespace BookClubApp.DataAccess.Repositories
{
    public interface IMembershipRepository
    {
        Task<IEnumerable<Membership>> GetMembershipsAsync();
        Task<Membership> AddMembershipAsync(Membership membership);
    }
}