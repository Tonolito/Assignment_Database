using Data.Entities;
using Domain.Dtos;
using Domain.Interfaces;
using Domain.Models;

namespace Domain.Factories;

public class UnitFactory : IUnitFactory
{
    public UnitDto CreateUnitDto()
    {
        return new UnitDto();
    }

    public UnitEntity CreateUnitEntity(UnitDto unitDto)
    {
        return new UnitEntity()
        {
            UnitName = unitDto.UnitName,
        };
    }

    public Unit CreateUnit(UnitEntity unitEntity)
    {
        return new Unit()
        {
            UnitName = unitEntity.UnitName,
        };
    }
}
