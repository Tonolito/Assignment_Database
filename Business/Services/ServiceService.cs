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

public class ServiceService(IServiceRepository serviceRepository, IServiceFactory serviceFactory) : IServiceService
{

    private readonly IServiceRepository _serviceRepository = serviceRepository;
    private readonly IServiceFactory _serviceFactory = serviceFactory;

    public async Task<bool> CreateServiceAsync(ServiceDto serviceDto)
    {
        try
        {
            ServiceEntity serviceEntity = _serviceFactory.CreateServiceEntity(serviceDto);

            var result = await _serviceRepository.CreateAsync(serviceEntity);
            if (result == null)
            {
                return false;
            }

            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Service Service CreateServiceAsync Error:{ex}");
            return false;
        }
    }

    public async Task<IEnumerable<Service>> GetServiceAsync()
    {
        try
        {
            var serviceEntities = await _serviceRepository.GetAllAsync();
            return serviceEntities.Select(_serviceFactory.CreateService);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Service Service GetServiceAsync Error:{ex}");
            return [];
        }
    }

    public async Task<Service> GetServiceById(int id)
    {
        try
        {
            var serviceEntity = await _serviceRepository.GetAsync(x => x.Id == id);
            return _serviceFactory.CreateService(serviceEntity);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Service Service GetServiceById Error:{ex}");
            return null!;
        }
    }

    public async Task<bool> UpdateServiceAsync(ServiceUpdateDto serviceUpdateDto)
    {
        try
        {
            var existingServiceEntity = await _serviceRepository.GetAsync(x => x.Id == serviceUpdateDto.Id);
            if (existingServiceEntity != null)
            {

            }

            var updatedEntity = await _serviceRepository.UpdateAsync(x => x.Id == serviceUpdateDto.Id, existingServiceEntity!);

            var customer = _serviceFactory.CreateService(updatedEntity);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Service Service UpdateServiceAsync Error:{ex}");
            return false;
        }
    }

    public async Task<bool> DeleteServiceContactAsync(int id)
    {
        var result = await _serviceRepository.DeleteAsync(x => x.Id == id);
        return result;
    }
}
