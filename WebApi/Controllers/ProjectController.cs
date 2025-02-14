using Business.Interfaces;
using Business.Services;
using Domain.Dtos;
using Domain.UpdateDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectController(IProjectService projectService) : ControllerBase
{
    private readonly IProjectService _projectService = projectService;


    // CRUD

    [HttpPost]
    public async Task<IActionResult> Create(ProjectDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        var result = await _projectService.CreateProjectAsync(dto);

        return result != false ? Created("", result) : Problem("Something went wrong.");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _projectService.GetProjectsAsync();
        return result != null ? Ok(result) : NotFound("Was not found");

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ProjectUpdateDto updatedDto)
    {
        var result = await _projectService.UpdateProjectAsync(updatedDto);
        return result == true ? Ok(result) : NotFound("Not found");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _projectService.DeleteProjectAsync(id);
        return result == true ? Ok(result) : NotFound("Can't find or delete");

    }
}
