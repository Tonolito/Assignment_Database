using Data.Repositories;
using Domain.Dtos;
using Domain.Models;

namespace Business.Services;

public class CustomerService(CustomerRepository customerRepository)
{
    private readonly CustomerRepository _customerRepository = customerRepository;

    // https://youtu.be/qKxl0f6ZwqA

    public async Task<bool> CreateCustomerAsync(CustomerDto dto)
    {

    }

    public async Task<IEnumerable<Customer>> GetCustomerAsync()
    {

    }
    
    public async Task<Customer> GetCustomerById(int id)
    {

    }

    public async Task<bool> UpdateCustomerAsync()
    {

    }

    public async Task<bool> DeleteCustomerAsync()
}
