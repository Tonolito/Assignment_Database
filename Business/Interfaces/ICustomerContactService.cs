using Domain.Dtos;
using Domain.Models;
using Domain.UpdateDtos;

namespace Business.Interfaces
{
    public interface ICustomerContactService
    {
        Task<bool> CreateCustomerContactAsync(CustomerContactDto customerContactDto);
        Task<bool> DeleteCustomerContactAsync(int id);
        Task<CustomerContact> GetCustomerContactByIdAsync(int id);
        Task<IEnumerable<CustomerContact>> GetCustomerContactsAsync();
        Task<bool> UpdateCustomerContactAsync(CustomerContactUpdateDto CustomerContactupdateDto);
    }
}