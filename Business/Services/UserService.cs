﻿using Business.Interfaces;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Domain.Dtos;
using Domain.Factories;
using Domain.Interfaces;
using Domain.Models;
using Domain.UpdateDtos;
using System.Diagnostics;

namespace Business.Services;

public class UserService(IUserRepository repository, IUserFactory userFactory) : IUserService
{
    private readonly IUserRepository _repository = repository;
    private readonly IUserFactory _userFactory = userFactory;

    public async Task<bool> CreateUserAsync(UserDto dto)
    {
        await _repository.BeginTransactionAsync();
        try
        {
            UserEntity entity = _userFactory.CreateUserEntity(dto);

            var result = await _repository.CreateAsync(entity);

            if (result == false)
            {
                return false;
            }
            else
            {
                await _repository.SaveAsync();
                await _repository.CommitTransactionAsync();
                return true;
            }
        }
        catch (Exception ex)
        {
            await _repository.RollbackTransactionAsync();
            Debug.WriteLine($"User Service CreateUserEntity Error:{ex}");
            return false;
        }
    }

    public async Task<IEnumerable<User>> GetUsersAsync()
    {
        try
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(_userFactory.CreateUser);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"User Service GetUsersAsync Error:{ex}");
            return [];
        }
    }

    public async Task<User> GetUserById(int id)
    {
        try
        {
            var entity = await _repository.GetAsync(x => x.Id == id);
            return _userFactory.CreateUser(entity);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"User Service GetUserById Error:{ex}");
            return null!;
        }
    }

    public async Task<bool> UpdateUserAsync(UserUpdateDto updateDto)
    {
        await _repository.BeginTransactionAsync();
        try
        {

            var existingEntity = await _repository.GetAsync(x => x.Id == updateDto.UserId);
            if (existingEntity == null)
            {
                return false;
            }
            Console.WriteLine($"Updating User: {existingEntity.Id}, RoleId: {existingEntity.RoleId}");

            existingEntity.Id = updateDto.UserId;
            existingEntity.FirstName = updateDto.FirstName;
            existingEntity.LastName = updateDto.LastName;
            existingEntity.Email = updateDto.Email;
            existingEntity.RoleId = updateDto.RoleId;

            var updatedEntity = await _repository.UpdateAsync(x => x.Id == updateDto.UserId, existingEntity!);
            await _repository.SaveAsync();
            var customer = _userFactory.CreateUser(updatedEntity);
            
            await _repository.CommitTransactionAsync();
            return true;
        }
        catch (Exception ex)
        {
            await _repository.RollbackTransactionAsync();
            Debug.WriteLine($"User Service UpdateUserAsync Error:{ex}");
            return false;
        }
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        await _repository.BeginTransactionAsync();
        try
        {
            var result = await _repository.DeleteAsync(x => x.Id == id);

            await _repository.SaveAsync();

            await _repository.CommitTransactionAsync();
            return result;
        }
        catch (Exception ex)
        {
            await _repository.RollbackTransactionAsync();
            Debug.WriteLine($"User Service UpdateUserAsync Error:{ex}");
            return false;
        }
       
    }
}
