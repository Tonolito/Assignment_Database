using Business.Interfaces;
using Business.Services;
using Domain.Dtos;
using Domain.UpdateDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController(ICustomerService customerService) : ControllerBase
{
    private readonly ICustomerService _customerService = customerService;


    // CRUD

    [HttpPost]
    public async Task<IActionResult> Create(CustomerDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        var result = await _customerService.CreateCustomerAsync(dto);

        return result != false ? Created("", result) : Problem("Something went wrong.");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _customerService.GetCustomersAsync();
        return result != null ? Ok(result) : NotFound("Was not found");

    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _customerService.GetCustomerById(id);
        return result != null ? Ok(result) : NotFound("Was not found");

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CustomerUpdateDto updatedDto)
    {
        var result = await _customerService.UpdateCustomerAsync(updatedDto);
        return result == true ? Ok(result) : NotFound("Not found");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _customerService.DeleteCustomerAsync(id);
        return result == true ? Ok(result) : NotFound("Can't find or delete");

    }
}
