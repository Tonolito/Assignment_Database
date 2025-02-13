using Data.Entities;
using Data.Interfaces;
using Domain.Dtos;
using Domain.Interfaces;
using Domain.Models;
using System.Diagnostics;

namespace Business.Services;

public class UnitService(IUnitRepository unitRepository, IUnitFactory unitFactory)
{
    private readonly IUnitRepository _unitRepository = unitRepository;
    private readonly IUnitFactory _unitFactory = unitFactory;

    public async Task<bool> CreateUnitAsync(UnitDto dto)
    {
        try
        {
            UnitEntity unitEntity = _unitFactory.CreateUnitEntity(dto);

            await _unitRepository.CreateAsync(unitEntity);

            return true;
        }
        catch (Exception ex)
        {
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

    public async Task<bool> DeleteUnitAsync(int id)
    {
        var result = await _unitRepository.DeleteAsync(x => x.Id == id);
        return result;
    }
}
