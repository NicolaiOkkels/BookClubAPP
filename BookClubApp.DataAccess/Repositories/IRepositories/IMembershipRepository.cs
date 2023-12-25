using BookClubApp.DataAccess.Entities;

namespace BookClubApp.DataAccess.Repositories
{
    public interface IMembershipRepository
    {
        Task<IEnumerable<Membership>> GetAllMembershipsAsync();
        Task<Membership> AddMembershipAsync(Membership membership);
        Task<IEnumerable<Membership>> GetMembershipsByEmailAsync(string email);
        Task<Membership> DeleteMembershipAsync(Membership membership);
        Task<Membership> GetMembershipAsync(int bookClubId, int value);
    }
}