using BookClubApp.DataAccess.Entities;

namespace BookClubApp.Business.Services
{
 public interface IRoleService
{
    Task<int?> GetRoleIdByNameAsync(string roleName);
}   
}