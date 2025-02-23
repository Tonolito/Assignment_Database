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

public class UnitService(IUnitRepository unitRepository, IUnitFactory unitFactory) : IUnitService
{
    private readonly IUnitRepository _unitRepository = unitRepository;
    private readonly IUnitFactory _unitFactory = unitFactory;

    public async Task<bool> CreateUnitAsync(UnitDto dto)
    {
        await _unitRepository.BeginTransactionAsync();
        try
        {
            UnitEntity unitEntity = _unitFactory.CreateUnitEntity(dto);

            var result = await _unitRepository.CreateAsync(unitEntity);
            if (result == false)
            {
                return false;
            }
            await _unitRepository.SaveAsync();

            await _unitRepository.CommitTransactionAsync();
            return true;
        }
        catch (Exception ex)
        {
            await _unitRepository.RollbackTransactionAsync();
            Debug.WriteLine($"Unit Service CreateUnitAsync Error:{ex}");
            return false;
        }
    }

    public async Task<IEnumerable<Unit>> GetUnitAsync()
    {
        try
        {
            var unitEntities = await _unitRepository.GetAllAsync();
            return unitEntities.Select(_unitFactory.CreateUnit);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unit Service GetUnitAsync Error:{ex}");
            return [];
        }
    }

    public async Task<Unit> GetUnitById(int id)
    {
        try
        {
            var unitEntity = await _unitRepository.GetAsync(x => x.Id == id);
            return _unitFactory.CreateUnit(unitEntity);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unit Service GetUnitById Error:{ex}");
            return null!;
        }
    }
    public async Task<bool> UpdateUnitAsync(UnitUpdateDto updateDto)
    {
        try
        {
            var exstingEntity = await  _unitRepository.GetAsync(x => x.Id == updateDto.UnitId);
            if (exstingEntity == null)
            {
                return false;
            }


            exstingEntity.Id = updateDto.UnitId;
            exstingEntity.UnitName = updateDto.UnitName;
            



            var updatedEntity = await _unitRepository.UpdateAsync(x => x.Id == updateDto.UnitId, exstingEntity!);
            await _unitRepository.SaveAsync();

            
            if (updatedEntity == null)
            {
                return false;
            }

            await _unitRepository.CommitTransactionAsync();
            return true;
        }
        catch (Exception ex)
        {
            await _unitRepository.RollbackTransactionAsync();
            Debug.WriteLine(ex);
            return false;
        }
    }

    public async Task<bool> DeleteUnitAsync(int id)
    {
        await _unitRepository.BeginTransactionAsync();
        try
        {
            var result = await _unitRepository.DeleteAsync(x => x.Id == id);
            await _unitRepository.SaveAsync();
            await _unitRepository.CommitTransactionAsync();
            return result;
        }
        catch (Exception ex)
        {
            await _unitRepository.RollbackTransactionAsync();
            Debug.WriteLine($"{ex.Message}");
            return false; 
        }
    }
}
