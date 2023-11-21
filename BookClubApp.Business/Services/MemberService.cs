
using BookClubApp.DataAccess.Entities;
using BookClubApp.DataAccess.Repositories;

namespace BookClubApp.Business.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<IEnumerable<Member>> GetMemberAsync()
        {
            return await _memberRepository.GetMembersAsync();
        }
    }
}