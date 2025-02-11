using Data.Entities;
using Domain.Dtos;
using Domain.Models;

namespace Domain.Factories;

public class CustomerFactory
{
    public static CustomerDto CreateCustomerDto()
    {
        return new CustomerDto();
    }
    
   public static CustomerUpdateDto CreateCustomerUpdateDto(CustomerUpdateDto customerUpdateDto)
    {
        return new CustomerUpdateDto()
        {
            CustomerName = customerUpdateDto.CustomerName,
            CompanyName = customerUpdateDto.CompanyName,
        };
    }

    public static CustomerEntity CreateCustomerEntity(CustomerDto customerDto)
    {
        return new CustomerEntity()
        {
            CustomerName = customerDto.CustomerName,
            CompanyName = customerDto.CompanyName,
        };
    }

    public static Customer CreateCustomer(CustomerEntity customerEntity)
    {
        return new Customer()
        {
           
            CustomerName = customerEntity.CustomerName,
            CompanyName = customerEntity.CompanyName,
        };
    }
}
