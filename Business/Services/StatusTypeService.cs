using Business.Interfaces;
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

public class StatusTypeService(IStatusTypeRepository statusTypeRepository, IStatusTypeFactory statusTypeFactory) : IStatusTypeService
{
    private readonly IStatusTypeRepository _statusTypeRepository = statusTypeRepository;
    private readonly IStatusTypeFactory _statusTypeFactory = statusTypeFactory;

    public async Task<bool> CreateStatusTypeAsync(StatusTypeDto statusTypeDto)
    {
        await _statusTypeRepository.BeginTransactionAsync();
        try
        {
            StatusTypeEntity statusTypeEntity = _statusTypeFactory.CreateStatusTypeEntity(statusTypeDto);

            var result = await _statusTypeRepository.CreateAsync(statusTypeEntity);
            if (result == false)
            {
                return false;
            }
            else
            {
                await _statusTypeRepository.SaveAsync();

                await _statusTypeRepository.CommitTransactionAsync();
                return true;

            }
        }
        catch (Exception ex)
        {
            await _statusTypeRepository.RollbackTransactionAsync();
            Debug.WriteLine($"StatusType Service CreateStatusTypeAsync Error:{ex}");
            return false;
        }
    }

    public async Task<IEnumerable<StatusType>> GetStatusTypesAsync()
    {
        try
        {
            var serviceEntities = await _statusTypeRepository.GetAllAsync();
            return serviceEntities.Select(_statusTypeFactory.CreateStatusType);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"StatusType Service GetStatusTypesAsync Error:{ex}");
            return [];
        }
    }
    public async Task<bool> UpdateServiceAsync(StatusTypeUpdateDto UpdateDto)
    {
        await _statusTypeRepository.BeginTransactionAsync();
        try
        {
            var existingEntity = await _statusTypeRepository.GetAsync(x => x.Id == UpdateDto.StatusTypeId);
            if (existingEntity == null)
            {
                return false;
            }
            existingEntity.StatusName = UpdateDto.StatusName;
            existingEntity.Id = UpdateDto.StatusTypeId;

            var updatedEntity = await _statusTypeRepository.UpdateAsync(x => x.Id == UpdateDto.StatusTypeId, existingEntity!);
            await _statusTypeRepository.SaveAsync();
            await _statusTypeRepository.CommitTransactionAsync();
            var statusType = _statusTypeFactory.CreateStatusType(updatedEntity);
            return true;
        }
        catch (Exception ex)
        {
            await _statusTypeRepository.RollbackTransactionAsync();

            Debug.WriteLine($"Service Service UpdateServiceAsync Error:{ex}");
            return false;
        }
    }

    public async Task<StatusType> GetStatusTypeById(int id)
    {
        try
        {
            var statusTypeEntity = await _statusTypeRepository.GetAsync(x => x.Id == id);
            return _statusTypeFactory.CreateStatusType(statusTypeEntity);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"StatusType Service GetStatusTypeById Error:{ex}");
            return null!;
        }
    }

    public async Task<bool> DeleteStatusTypeAsync(int id)
    {
        await _statusTypeRepository.BeginTransactionAsync();
        try
        {
            var result = await _statusTypeRepository.DeleteAsync(x => x.Id == id);
            await _statusTypeRepository.SaveAsync();

            await _statusTypeRepository.CommitTransactionAsync();
            return result;
        }
        catch (Exception ex)
        {
            await _statusTypeRepository.RollbackTransactionAsync();
            Debug.WriteLine(ex.Message);
            return false;
        }
    }
}
