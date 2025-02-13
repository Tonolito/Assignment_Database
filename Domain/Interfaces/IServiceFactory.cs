using Data.Entities;
using Domain.Dtos;
using Domain.Models;
using Domain.UpdateDtos;

namespace Domain.Interfaces;

public interface IServiceFactory
{
    ServiceDto CreateServiceDto();

    ServiceUpdateDto CreateServiceUpdateDto(ServiceUpdateDto serviceUpdateDto);

    ServiceEntity CreateServiceEntity(ServiceDto serviceDto);

    Service CreateService(ServiceEntity serviceEntity);
}
