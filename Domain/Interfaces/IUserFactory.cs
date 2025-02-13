using Data.Entities;
using Domain.Dtos;
using Domain.Models;
using Domain.UpdateDtos;

namespace Domain.Interfaces;

public interface IUserFactory
{
    UserDto CreateUserDto();

    UserUpdateDto CreateUserUpdateDto(UserUpdateDto userUpdateDto);

    UserEntity CreateUserEntity(UserDto userDto);

    User CreateUser(UserEntity userEntity);
}
