using Domain.Dtos;
using Domain.Models;
using Domain.UpdateDtos;

namespace Business.Interfaces
{
    public interface ICustomerService
    {
        Task<bool> CreateCustomerAsync(CustomerDto dto);
        Task<bool> DeleteCustomerAsync(int id);
        Task<Customer> GetCustomerById(int id);
        Task<IEnumerable<Customer>> GetCustomersAsync();
        Task<bool> UpdateCustomerAsync(CustomerUpdateDto updateDto);
    }
}