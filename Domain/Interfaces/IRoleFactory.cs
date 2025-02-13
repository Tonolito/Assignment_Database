using Data.Entities;
using Domain.Dtos;
using Domain.Models;

namespace Domain.Interfaces;

public interface IRoleFactory
{
    RoleDto CreateProjectDto();

    RoleEntity CreateRoleEntity(RoleDto roleDto);

    Role CreateRole(RoleEntity roleEntity);
}
