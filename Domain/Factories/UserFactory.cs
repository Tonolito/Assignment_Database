using Data.Entities;
using Domain.Dtos;

namespace Domain.Factories;

public static class UserFactory
{

    public static UserDto CreateUserDto()
    {
        return new UserDto();
    }

    public static UserEntity CreateUserEntity(UserDto userDto)
    {
        return new UserEntity()
        {

            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Email = userDto.Email,
            RoleId = userDto.RoleId,

        };
    }

    public static User


}
