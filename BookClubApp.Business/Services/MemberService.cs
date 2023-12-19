
using BookClubApp.DataAccess.Entities;
using BookClubApp.DataAccess.Repositories;
using Microsoft.Data.SqlClient;

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

        public async Task<Member> GetMemberByEmailAsync(string email)
    {
        return await _memberRepository.GetMemberByEmailAsync(email);
    }

    public async Task<Member> AddMemberAsync(Member member)
    {
        var existingMember = await GetMemberByEmailAsync(member.Email);
        if (existingMember == null)
        {
            return await _memberRepository.AddMemberAsync(member);
        }

        return existingMember; 
    }

        public async Task<int> GetMemberIdByEmailAsync(string email)
        {
            return await _memberRepository.GetMemberIdByEmailAsync(email);
        }
    }
}