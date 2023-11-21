using BookClubApp.DataAccess.Entities;

namespace BookClubApp.Business.Services
{
    public interface IMemberService
    {
        Task<IEnumerable<Member>> GetMemberAsync();
    }
}