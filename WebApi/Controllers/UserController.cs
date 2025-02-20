using Business.Interfaces;
using Domain.Dtos;
using Domain.UpdateDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
    IUserService _userService = userService;

    [HttpPost]
    public async Task<IActionResult> Create(UserDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        var result = await _userService.CreateUserAsync(dto);

        return result != false ? Created("", result) : Problem("Something went wrong.");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _userService.GetUsersAsync();
        return result != null ? Ok(result) : NotFound("Was not found");

    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _userService.GetUserById(id);
        return result != null ? Ok(result) : NotFound("Was not found");

    }
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UserUpdateDto updatedDto)
    {
        var result = await _userService.UpdateUserAsync(updatedDto);
        return result == true ? Ok(result) : NotFound("Not found");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _userService.DeleteUserAsync(id);
        return result == true ? Ok(result) : NotFound("Can't find or delete");

    }
}
