using BookClubApp.DataAccess.Entities;
using BookClubApp.DataAccess.Repositories;

namespace BookClubApp.Business.Services
{
    public class RoleService : IRoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<int?> GetRoleIdByNameAsync(string roleName)
    {
        return await _roleRepository.GetRoleIdByNameAsync(roleName);
    }
}
}