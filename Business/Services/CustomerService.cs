using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Domain.Dtos;
using Domain.Interfaces;
using Domain.Models;
using Domain.UpdateDtos;
using System.Diagnostics;

namespace Business.Services;

public class CustomerService(ICustomerRepository customerRepository, ICustomerFactory customerFactory)
{
    private readonly ICustomerRepository _customerRepository = customerRepository;
    private readonly ICustomerFactory _customerFactory = customerFactory;

    // https://youtu.be/qKxl0f6ZwqA
    public async Task<bool> CreateCustomerAsync(CustomerDto dto)
    {
        try
        {
            CustomerEntity customerEntity = _customerFactory.CreateCustomerEntity(dto);

            await _customerRepository.CreateAsync(customerEntity);

            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Customer Service CreateCustomerAsync Error:{ex}");
            return false;
        }
    }

    public async Task<IEnumerable<Customer>> GetCustomersAsync()
    {
        try
        {
            var customerEntities = await _customerRepository.GetAllAsync();
            return customerEntities.Select(_customerFactory.CreateCustomer);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Customer Service GetCustomerAsync Error:{ex}");
            return [];
        }
    }

    public async Task<Customer> GetCustomerById(int id)
    {
        try
        {
            var customerEntity = await _customerRepository.GetAsync(x => x.Id == id);
            return _customerFactory.CreateCustomer(customerEntity);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Customer Service GetCustomerById Error:{ex}");
            return null!;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="updateDto"></param>
    /// <returns></returns>
    public async Task<bool> UpdateCustomerAsync(CustomerUpdateDto updateDto)
    {
        try
        {
            var existingCustomerEntity = await _customerRepository.GetAsync(x => x.Id == updateDto.Id);
            if (existingCustomerEntity != null)
            {
                existingCustomerEntity.CustomerName = updateDto.CustomerName;
                existingCustomerEntity.CompanyName = updateDto.CompanyName;
            }

            var updatedEntity = await _customerRepository.UpdateAsync(x => x.Id == updateDto.Id, existingCustomerEntity!);

            var customer = _customerFactory.CreateCustomer(updatedEntity);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Customer Service UpdateCustomerAsync Error:{ex}");
            return false;
        }
    }

    public async Task<bool> DeleteCustomerAsync(int id)
    {
        var result = await _customerRepository.DeleteAsync(x => x.Id == id);
        return result;
    }
}


