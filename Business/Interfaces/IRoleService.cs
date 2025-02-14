using Domain.Dtos;
using Domain.Models;

namespace Business.Interfaces
{
    public interface IRoleService
    {
        Task<bool> CreateRoleAsync(RoleDto roleDto);
        Task<bool> DeleteRoleAsync(int id);
        Task<Role> GetRoleByIdAsync(int id);
        Task<IEnumerable<Role>> GetRolesAsync();
    }
}