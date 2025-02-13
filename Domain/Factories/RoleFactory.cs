using Data.Entities;
using Domain.Dtos;
using Domain.Interfaces;
using Domain.Models;

namespace Domain.Factories;

public class RoleFactory : IRoleFactory
{
    public RoleDto CreateProjectDto()
    {
        return new RoleDto();
    }

    public RoleEntity CreateRoleEntity(RoleDto roleDto)
    {
        return new RoleEntity()
        {
            RoleName = roleDto.RoleName,
        };
    }

    public Role CreateRole(RoleEntity roleEntity)
    {
        return new Role()
        {
            RoleName = roleEntity.RoleName,
        };
    }

}
