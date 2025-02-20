using Business.Interfaces;
using Business.Services;
using Domain.Dtos;
using Domain.UpdateDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UnitController(IUnitService unitService) : ControllerBase
{
    private readonly IUnitService _unitService = unitService;

    [HttpPost]
    public async Task<IActionResult> Create(UnitDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        var result = await _unitService.CreateUnitAsync(dto);

        return result != false ? Created("", result) : Problem("Something went wrong.");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _unitService.GetUnitAsync();
        return result != null ? Ok(result) : NotFound("Was not found");

    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _unitService.GetUnitById(id);
        return result != null ? Ok(result) : NotFound("Was not found");

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UnitUpdateDto updatedDto)
    {
        var result = await _unitService.UpdateUnitAsync(updatedDto);
        return result == true ? Ok(result) : NotFound("Not found");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _unitService.DeleteUnitAsync(id);
        return result == true ? Ok(result) : NotFound("Can't find or delete");

    }
}
