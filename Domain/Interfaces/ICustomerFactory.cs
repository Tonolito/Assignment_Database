using Data.Entities;
using Domain.Dtos;
using Domain.Models;

namespace Domain.Interfaces;

public interface ICustomerFactory
{
    CustomerDto CreateCustomerDto();

    CustomerUpdateDto CreateCustomerUpdateDto(CustomerUpdateDto customerUpdateDto);

    CustomerEntity CreateCustomerEntity(CustomerDto customerDto);

    Customer CreateCustomer(CustomerEntity customerEntity);

}
