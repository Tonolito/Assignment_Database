using Data.Entities;
using Domain.Dtos;
using Domain.Models;
using Domain.UpdateDtos;

namespace Domain.Interfaces;

public interface ICustomerContactFactory
{
    CustomerContactDto CreateCustomerContactDto();

    CustomerContactUpdateDto CreateCustomerContactUpdateDto(CustomerContactUpdateDto customerContactUpdateDto);

    CustomerContactEntity CreateCustomerContactEntity(CustomerContactDto customerContactDto);

    CustomerContact CreateCustomerContact(CustomerContactEntity customerContactEntity);
}
