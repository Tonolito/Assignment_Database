using Domain.Dtos;
using Domain.Models;
using Domain.UpdateDtos;

namespace Business.Interfaces
{
    public interface IServiceService
    {
        Task<bool> CreateServiceAsync(ServiceDto serviceDto);
        Task<bool> DeleteServiceContactAsync(int id);
        Task<IEnumerable<Service>> GetServiceAsync();
        Task<Service> GetServiceById(int id);
        Task<bool> UpdateServiceAsync(ServiceUpdateDto serviceUpdateDto);
    }
}