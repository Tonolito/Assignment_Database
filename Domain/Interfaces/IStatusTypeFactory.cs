using Data.Entities;
using Domain.Dtos;
using Domain.Models;

namespace Domain.Interfaces;

public interface IStatusTypeFactory
{
    StatusTypeDto CreateStatusTypeDto();

    StatusTypeEntity CreateStatusTypeEntity(StatusTypeDto statusTypeDto);

    StatusType CreateStatusType(StatusTypeEntity statusTypeEntity);
}
