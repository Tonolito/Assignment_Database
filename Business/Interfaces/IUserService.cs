using Domain.Dtos;
using Domain.Models;
using Domain.UpdateDtos;

namespace Business.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(UserDto dto);
        Task<bool> DeleteUserAsync(int id);
        Task<User> GetUserById(int id);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<bool> UpdateUserAsync(UserUpdateDto updateDto);
    }
}