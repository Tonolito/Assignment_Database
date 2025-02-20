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

public class CustomerContactService(ICustomerContactRepository customerContactRepository, ICustomerContactFactory customerContactFactory) : ICustomerContactService
{
    private readonly ICustomerContactRepository _customerContactRepository = customerContactRepository;
    private readonly ICustomerContactFactory _customerContactFactory = customerContactFactory;

    public async Task<bool> CreateCustomerContactAsync(CustomerContactDto customerContactDto)
    {
        try
        {
            CustomerContactEntity customerContactEntity = _customerContactFactory.CreateCustomerContactEntity(customerContactDto);

            var result = await _customerContactRepository.CreateAsync(customerContactEntity);
            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"CustomerContact Service CreateCustomerContactAsync Error:{ex}");
            return false;
        }
    }

    public async Task<IEnumerable<CustomerContact>> GetCustomerContactsAsync()
    {
        try
        {
            var customerContactEntities = await _customerContactRepository.GetAllAsync();
            return customerContactEntities.Select(_customerContactFactory.CreateCustomerContact);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"CustomerContact Service GetCustomerContactsAsync Error:{ex}");
            return [];
        }
    }

    public async Task<CustomerContact> GetCustomerContactByIdAsync(int id)
    {
        try
        {
            var customerContactEntity = await _customerContactRepository.GetAsync(x => x.Id == id);
            return _customerContactFactory.CreateCustomerContact(customerContactEntity);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"CustomerContact Service GetCustomerContactById Error:{ex}");
            return null!;
        }
    }

    public async Task<bool> UpdateCustomerContactAsync(CustomerContactUpdateDto CustomerContactupdateDto)
    {
        try
        {
            var existingEntity = await _customerContactRepository.GetAsync(x => x.Id == CustomerContactupdateDto.CustomerContactId);
            if (existingEntity == null)
            {
                return false;
            }

            existingEntity.FirstName = CustomerContactupdateDto.FirstName;
            existingEntity.LastName = CustomerContactupdateDto.LastName;
            existingEntity.CustomerId = CustomerContactupdateDto.CustomerId;
            existingEntity.Email = CustomerContactupdateDto.Email;
            existingEntity.PhoneNumber = CustomerContactupdateDto.PhoneNumber;
            var updatedEntity = await _customerContactRepository.UpdateAsync(x => x.Id == CustomerContactupdateDto.CustomerContactId, existingEntity!);

            var customer = _customerContactFactory.CreateCustomerContact(updatedEntity);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"CustomerContact Service UpdateCustomerContactAsync Error:{ex}");
            return false;
        }
    }

    public async Task<bool> DeleteCustomerContactAsync(int id)
    {
        var result = await _customerContactRepository.DeleteAsync(x => x.Id == id);
        return result;
    }
}
