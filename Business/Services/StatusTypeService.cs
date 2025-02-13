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

public class StatusTypeService(IStatusTypeRepository statusTypeRepository, IStatusTypeFactory statusTypeFactory)
{
    private readonly IStatusTypeRepository _statusTypeRepository = statusTypeRepository;
    private readonly IStatusTypeFactory _statusTypeFactory = statusTypeFactory;

    public async Task<bool> CreateStatusTypeAsync(StatusTypeDto statusTypeDto)
    {
        try
        {
            StatusTypeEntity statusTypeEntity = _statusTypeFactory.CreateStatusEntity(statusTypeDto);

            await _statusTypeRepository.CreateAsync(statusTypeEntity);

            return true;
        }
        catch (Exception ex)
        {
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
        var result = await _statusTypeRepository.DeleteAsync(x => x.Id == id);
        return result;
    }
}
