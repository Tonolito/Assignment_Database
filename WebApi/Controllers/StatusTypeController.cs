using Business.Interfaces;
using Business.Services;
using Data.Interfaces;
using Domain.Dtos;
using Domain.UpdateDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatusTypeController(IStatusTypeService statusTypeService) : ControllerBase
{
    private readonly IStatusTypeService _statusTypeService = statusTypeService;

    // CRUD

    [HttpPost]
    public async Task<IActionResult> Create(StatusTypeDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        var result = await _statusTypeService.CreateStatusTypeAsync(dto);

        return result != false ? Created("", result) : Problem("Something went wrong.");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _statusTypeService.GetStatusTypesAsync();
        return result != null ? Ok(result) : NotFound("Was not found");

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, StatusTypeUpdateDto updatedDto)
    {
        var result = await _statusTypeService.UpdateServiceAsync(updatedDto);
        return result == true ? Ok(result) : NotFound("Not found");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _statusTypeService.DeleteStatusTypeAsync(id);
        return result == true ? Ok(result) : NotFound("Can't find or delete");

    }
}
