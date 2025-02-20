using Business.Interfaces;
using Business.Services;
using Domain.Dtos;
using Domain.UpdateDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController(IRoleService roleService) : ControllerBase
{
    private readonly IRoleService _roleService = roleService;

    // CRUD

    [HttpPost]
    public async Task<IActionResult> Create(RoleDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        var result = await _roleService.CreateRoleAsync(dto);

        return result != false ? Created("", result) : Problem("Something went wrong.");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _roleService.GetRolesAsync();
        return result != null ? Ok(result) : NotFound("Was not found");

    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _roleService.GetRoleByIdAsync(id);
        return result != null ? Ok(result) : NotFound("Was not found");

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, RoleUpdateDto updatedDto)
    {
        var result = await _roleService.UpdateRoleAsync(updatedDto);
        return result == true ? Ok(result) : NotFound("Not found");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _roleService.DeleteRoleAsync(id);
        return result == true ? Ok(result) : NotFound("Can't find or delete");

    }
}
