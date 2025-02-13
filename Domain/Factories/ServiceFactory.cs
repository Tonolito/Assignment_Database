using Data.Entities;
using Domain.Dtos;
using Domain.Interfaces;
using Domain.Models;
using Domain.UpdateDtos;

namespace Domain.Factories;

public class ServiceFactory : IServiceFactory
{
    public ServiceDto CreateServiceDto()
    {
        return new ServiceDto();
    }

    public ServiceUpdateDto CreateServiceUpdateDto(ServiceUpdateDto serviceUpdateDto)
    {
        return new ServiceUpdateDto()
        {
            ServiceName = serviceUpdateDto.ServiceName,
            Price = serviceUpdateDto.Price,
            
        };
    }

    public ServiceEntity CreateServiceEntity(ServiceDto serviceDto)
    {
        return new ServiceEntity()
        {
           ServiceName = serviceDto.ServiceName,
           Price = serviceDto.Price,
        };
    }

    public Service CreateService(ServiceEntity serviceEntity)
    {
        return new Service()
        {
            ServiceName= serviceEntity.ServiceName,
            Price = serviceEntity.Price,

        };
    }

}
