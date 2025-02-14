using Data.Entities;
using Domain.Dtos;
using Domain.Interfaces;
using Domain.Models;
using Domain.UpdateDtos;

namespace Domain.Factories;

public class UserFactory : IUserFactory
{

    public UserDto CreateUserDto()
    {
        return new UserDto();
    }

    public UserUpdateDto CreateUserUpdateDto(UserUpdateDto userUpdateDto)
    {
        return new UserUpdateDto()
        {
            FirstName = userUpdateDto.FirstName,
            LastName = userUpdateDto.LastName,
            Email = userUpdateDto.Email,
            RoleId = userUpdateDto.RoleId,
        };
    }

    public UserEntity CreateUserEntity(UserDto userDto)
    {
        return new UserEntity()
        {

            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Email = userDto.Email,
            RoleId = userDto.RoleId,

        };
    }

    public User CreateUser(UserEntity userEntity)
    {
        return new User()
        {
            FirstName = userEntity.FirstName,
            LastName = userEntity.LastName,
            Email = userEntity.Email,
            RoleName = userEntity.Role.RoleName,
            
        };
    }


}
