using Business.Interfaces;
using Data.Entities;
using Data.Interfaces;
using Domain.Dtos;
using Domain.Interfaces;
using Domain.Models;
using System.Diagnostics;

namespace Business.Services;

public class RoleService(IRoleRepository roleRepository, IRoleFactory roleFactory) : IRoleService
{
    private readonly IRoleRepository _roleRepository = roleRepository;
    private readonly IRoleFactory _roleFactory = roleFactory;

    public async Task<bool> CreateRoleAsync(RoleDto roleDto)
    {
        try
        {
            RoleEntity roleEntity = _roleFactory.CreateRoleEntity(roleDto);

           var result = await _roleRepository.CreateAsync(roleEntity);

            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Role Service CreateRoleAsync Error:{ex}");
            return false;
        }
    }

    public async Task<IEnumerable<Role>> GetRolesAsync()
    {
        try
        {
            var roleEntities = await _roleRepository.GetAllAsync();
            return roleEntities.Select(_roleFactory.CreateRole);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Customer Service GetRolesAsync Error:{ex}");
            return [];
        }
    }
    public async Task<Role> GetRoleByIdAsync(int id)
    {
        try
        {
            var RoleEntity = await _roleRepository.GetAsync(x => x.Id == id);
            return _roleFactory.CreateRole(RoleEntity);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Customer Service GetRoleByIdAsync Error:{ex}");
            return null!;
        }
    }
    public async Task<bool> DeleteRoleAsync(int id)
    {
        var result = await _roleRepository.DeleteAsync(x => x.Id == id);
        return result;
    }
}
    
