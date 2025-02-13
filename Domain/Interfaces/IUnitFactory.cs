using Data.Entities;
using Domain.Dtos;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUnitFactory
    {

        UnitDto CreateUnitDto();

        UnitEntity CreateUnitEntity(UnitDto unitDto);

        Unit CreateUnit(UnitEntity unitEntity);

    }
}