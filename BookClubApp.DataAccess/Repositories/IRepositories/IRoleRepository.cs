using System.Collections.Generic;
using BookClubApp.DataAccess.Entities;

namespace BookClubApp.DataAccess.Repositories
{
    public interface IRoleRepository
    {
        Task<int?> GetRoleIdByNameAsync(string roleName);
    }
}