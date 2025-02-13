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
            FirstName = customerContactDto.FirstName,
            LastName = customerContactDto.LastName,
            Email = customerContactDto.Email,   
            PhoneNumber = customerContactDto.PhoneNumber,
        };
    }
    
    public CustomerContact CreateCustomerContact(CustomerContactEntity customerContactEntity)
    {
        return new CustomerContact()
        {
            FirstName = customerContactEntity.FirstName,
            LastName = customerContactEntity.LastName,
            Email = customerContactEntity.Email,
            PhoneNumber = customerContactEntity.PhoneNumber,
        };
    }
}
