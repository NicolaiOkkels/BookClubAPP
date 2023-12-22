
using BookClubApp.DataAccess.Entities;
using BookClubApp.DataAccess.Repositories;
using Microsoft.Data.SqlClient;

namespace BookClubApp.Business.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly IMembershipRepository _membershipRepository;
        public MembershipService(IMembershipRepository membershipRepository)
        {
            _membershipRepository = membershipRepository;
        }

        public async Task<IEnumerable<Membership>> GetMembershipsAsync()
        {
            return await _membershipRepository.GetMembershipsAsync();
        }

        public async Task<Membership> AddMembershipAsync(Membership membership)
        {
            return await _membershipRepository.AddMembershipAsync(membership);
        }
    }
}