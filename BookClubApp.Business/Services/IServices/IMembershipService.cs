using BookClubApp.DataAccess.Entities;

namespace BookClubApp.Business.Services
{
    public interface IMembershipService
    {
        Task<Membership> AddMembershipAsync(Membership membership);
        Task DeleteMembershipAsync(Membership membership);
        Task<Membership> GetMembershipAsync(int bookClubId, int value);
        Task<IEnumerable<Membership>> GetAllMembershipsAsync();
        Task<IEnumerable<Membership>> GetMembershipsByEmailAsync(string email);
    }
}