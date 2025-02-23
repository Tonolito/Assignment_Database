using Business.Interfaces;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Domain.Dtos;
using Domain.Interfaces;
using Domain.Models;
using Domain.UpdateDtos;
using System.Diagnostics;

namespace Business.Services;

public class RoleService(IRoleRepository roleRepository, IRoleFactory roleFactory) : IRoleService
{
    private readonly IRoleRepository _roleRepository = roleRepository;
    private readonly IRoleFactory _roleFactory = roleFactory;

    public async Task<bool> CreateRoleAsync(RoleDto roleDto)
    {
        await _roleRepository.BeginTransactionAsync();
        try
        {
            RoleEntity roleEntity = _roleFactory.CreateRoleEntity(roleDto);

           var result = await _roleRepository.CreateAsync(roleEntity);

            if (result == false)
            {
                return false;
            }
            else
            {
                await _roleRepository.SaveAsync();

                await _roleRepository.CommitTransactionAsync();
                return true;
            }
        }
        catch (Exception ex)
        {
            await _roleRepository.RollbackTransactionAsync();
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
    public async Task<bool> UpdateRoleAsync(RoleUpdateDto updateDto)
    {
        try
        {
            var exstingEntity = await _roleRepository.GetAsync(x => x.Id == updateDto.RoleId);
            if (exstingEntity == null)
            {
                return false;  
            }

            
            exstingEntity.Id = updateDto.RoleId;
            exstingEntity.RoleName = updateDto.RoleName;
            
            
            

            var updatedEntity = await _roleRepository.UpdateAsync(x => x.Id == updateDto.RoleId, exstingEntity!);

            await _roleRepository.SaveAsync();
            
            await _roleRepository.CommitTransactionAsync();
            if (updatedEntity == null)
            {
                return false;
            }

            return true;
        }
        catch (Exception ex)
        {
            await _roleRepository.RollbackTransactionAsync();
            Debug.WriteLine(ex);
            return false;
        }
    }
    public async Task<bool> DeleteRoleAsync(int id)
    {
        await _roleRepository.BeginTransactionAsync();
        try
        {
            var result = await _roleRepository.DeleteAsync(x => x.Id == id);

            await _roleRepository.SaveAsync();

            await _roleRepository.CommitTransactionAsync();
            return result;
        }
        catch(Exception ex) 
        {
            await _roleRepository.RollbackTransactionAsync();
            Debug.WriteLine(ex);
            return false;
        }
    }
}
    
