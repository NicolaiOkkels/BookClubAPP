using BookClubApp.DataAccess.Entities;

namespace BookClubApp.DataAccess.Repositories
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetMembersAsync();
        Task<Member> GetMemberByEmailAsync(string email);
        Task<Member> AddMemberAsync(Member member);
    }
}
