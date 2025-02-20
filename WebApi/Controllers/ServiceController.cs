using Business.Interfaces;
using Business.Services;
using Domain.Dtos;
using Domain.UpdateDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServiceController(IServiceService serviceService) : ControllerBase
{
    private readonly IServiceService _serviceService = serviceService;


    // CRUD

    [HttpPost]
    public async Task<IActionResult> Create(ServiceDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        var result = await _serviceService.CreateServiceAsync(dto);

        return result != false ? Created("", result) : Problem("Something went wrong.");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _serviceService.GetServiceAsync();
        return result != null ? Ok(result) : NotFound("Was not found");

    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _serviceService.GetServiceById(id);
        return result != null ? Ok(result) : NotFound("Was not found");

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ServiceUpdateDto updatedDto)
    {
        var result = await _serviceService.UpdateServiceAsync(updatedDto);
        return result == true ? Ok(result) : NotFound("Not found");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _serviceService.DeleteServiceContactAsync(id);
        return result == true ? Ok(result) : NotFound("Can't find or delete");

    }
}
