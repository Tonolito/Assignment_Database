using Domain.Dtos;
using Domain.Models;
using Domain.UpdateDtos;

namespace Business.Interfaces
{
    public interface IRoleService
    {
        Task<bool> CreateRoleAsync(RoleDto roleDto);
        Task<bool> DeleteRoleAsync(int id);
        Task<Role> GetRoleByIdAsync(int id);
        Task<bool> UpdateRoleAsync(RoleUpdateDto updateDto);
        Task<IEnumerable<Role>> GetRolesAsync();
    }
}