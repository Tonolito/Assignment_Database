using Data.Entities;
using Domain.Dtos;
using Domain.Interfaces;
using Domain.Models;
using Domain.UpdateDtos;

namespace Domain.Factories;

public class CustomerContactFactory : ICustomerContactFactory
{
    

    public CustomerContactDto CreateCustomerContactDto()
    {
        return new CustomerContactDto();
    }

    public CustomerContactUpdateDto CreateCustomerContactUpdateDto(CustomerContactUpdateDto customerContactUpdateDto)
    {
        return new CustomerContactUpdateDto()
        {
            FirstName = customerContactUpdateDto.FirstName,
            LastName = customerContactUpdateDto.LastName,
            Email = customerContactUpdateDto.Email,
            PhoneNumber = customerContactUpdateDto.PhoneNumber,
        };
    }
    public CustomerContactEntity CreateCustomerContactEntity(CustomerContactDto customerContactDto)
    {
        return new CustomerContactEntity()
        {
            // ID?
            FirstName = customerContactDto.FirstName,
            LastName = customerContactDto.LastName,
            Email = customerContactDto.Email,   
            PhoneNumber = customerContactDto.PhoneNumber,
            CustomerId = customerContactDto.CustomerId,
        };
    }
    
    public CustomerContact CreateCustomerContact(CustomerContactEntity customerContactEntity)
    {
        return new CustomerContact()
        {
            // ID?
            FirstName = customerContactEntity.FirstName,
            LastName = customerContactEntity.LastName,
            Email = customerContactEntity.Email,
            PhoneNumber = customerContactEntity.PhoneNumber,
            CustomerName = customerContactEntity.Customer.CustomerName
        };
    }
}
