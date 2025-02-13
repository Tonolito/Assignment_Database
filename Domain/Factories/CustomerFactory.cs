using Data.Entities;
using Domain.Dtos;
using Domain.Interfaces;
using Domain.Models;
using Domain.UpdateDtos;

namespace Domain.Factories;

public class CustomerFactory : ICustomerFactory
{
    public CustomerDto CreateCustomerDto()
    {
        return new CustomerDto();
    }
    
   public CustomerUpdateDto CreateCustomerUpdateDto(CustomerUpdateDto customerUpdateDto)
    {
        return new CustomerUpdateDto()
        {
            CustomerName = customerUpdateDto.CustomerName,
            CompanyName = customerUpdateDto.CompanyName,
        };
    }

    public CustomerEntity CreateCustomerEntity(CustomerDto customerDto)
    {
        return new CustomerEntity()
        {
            CustomerName = customerDto.CustomerName,
            CompanyName = customerDto.CompanyName,
        };
    }

    public Customer CreateCustomer(CustomerEntity customerEntity)
    {
        return new Customer()
        {
           
            CustomerName = customerEntity.CustomerName,
            CompanyName = customerEntity.CompanyName,
        };
    }
}
