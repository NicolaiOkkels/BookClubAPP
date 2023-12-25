
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

        public async Task<IEnumerable<Membership>> GetAllMembershipsAsync()
        {
            return await _membershipRepository.GetAllMembershipsAsync();
        }

        public async Task<Membership> AddMembershipAsync(Membership membership)
        {
            return await _membershipRepository.AddMembershipAsync(membership);
        }

        public async Task<IEnumerable<Membership>> GetMembershipsByEmailAsync(string email)
        {
            return await _membershipRepository.GetMembershipsByEmailAsync(email);
        }

        public async Task DeleteMembershipAsync(Membership membership)
        {
            await _membershipRepository.DeleteMembershipAsync(membership);
        }

        public async Task<Membership> GetMembershipAsync(int bookClubId, int value)
        {
            return await _membershipRepository.GetMembershipAsync(bookClubId, value);
        }
    }
}