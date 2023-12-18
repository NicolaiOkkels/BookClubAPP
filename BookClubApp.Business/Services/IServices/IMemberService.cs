using BookClubApp.DataAccess.Entities;

namespace BookClubApp.Business.Services
{
    public interface IMemberService
    {
        Task<Member?> AddMemberAsync(Member member);
        Task<IEnumerable<Member>> GetMemberAsync();
        Task<Member?> GetMemberByEmailAsync(string email);
    }
}