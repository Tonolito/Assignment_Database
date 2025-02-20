using Data.Entities;
using Domain.Dtos;
using Domain.Interfaces;
using Domain.Models;

namespace Domain.Factories;

public class StatusTypeFactory : IStatusTypeFactory
{
    public StatusTypeDto CreateStatusTypeDto()
    {
        return new StatusTypeDto();
    }

    public StatusTypeEntity CreateStatusTypeEntity(StatusTypeDto statusTypeDto)
    {
        return new StatusTypeEntity()
        {
            StatusName = statusTypeDto.StatusName,
        };
    }

    public StatusType CreateStatusType(StatusTypeEntity statusTypeEntity)
    {
        return new StatusType()
        {
            StatusTypeId = statusTypeEntity.Id,
            StatusName = statusTypeEntity.StatusName,
        };
    }
}
