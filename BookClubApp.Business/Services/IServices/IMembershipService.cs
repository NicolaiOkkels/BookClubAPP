using BookClubApp.DataAccess.Entities;

namespace BookClubApp.Business.Services
{
    public interface IMembershipService
    {
        Task<Membership> AddMembershipAsync(Membership membership);
        Task<IEnumerable<Membership>> GetMembershipsAsync();
    }
}