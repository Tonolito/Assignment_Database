using Business.Interfaces;
using Data.Interfaces;
using Domain.Dtos;
using Domain.UpdateDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerContactController(ICustomerContactService customerContactService) : ControllerBase
{
    private readonly ICustomerContactService _customerContactService = customerContactService;
    

    // CRUD

    [HttpPost]
    public async Task<IActionResult> Create(CustomerContactDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        var result = await _customerContactService.CreateCustomerContactAsync(dto);

        return result != false ? Created("", result) : Problem("Something went wrong.");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _customerContactService.GetCustomerContactByIdAsync(id);
        return result != null ? Ok(result) : NotFound("Was not found");
            
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CustomerContactUpdateDto updatedDto)
    {
        var result = await _customerContactService.UpdateCustomerContactAsync( updatedDto);
        return result == true ? Ok(result) : NotFound("Not found");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _customerContactService.DeleteCustomerContactAsync(id);
        return result == true ? Ok(result) : NotFound("Can't find or delete");

    }
}
