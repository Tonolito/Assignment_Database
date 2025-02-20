using Business.Interfaces;
using Data.Entities;
using Data.Interfaces;
using Domain.Dtos;
using Domain.Interfaces;
using Domain.Models;
using Domain.UpdateDtos;
using System.Diagnostics;

namespace Business.Services;

public class ProjectService(IProjectRepository projectRepository, IProjectFactory projectFactory) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;
    private readonly IProjectFactory _projectFactory = projectFactory;

    public async Task<bool> CreateProjectAsync(ProjectDto projectDto)
    {
        try
        {
            ProjectEntity projectEntity = _projectFactory.CreateProjectEntity(projectDto);

            var result = await _projectRepository.CreateAsync(projectEntity);
            if (result == null)
            {
                return false;
            }

            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Project Service CreateProjectAsync Error:{ex}");
            return false;
        }
    }

    public async Task<IEnumerable<Project>> GetProjectsAsync()
    {
        try
        {
            var projectEntities = await _projectRepository.GetAllAsync();
            return projectEntities.Select(_projectFactory.CreateProject);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Customer Service GetProjectsAsync Error:{ex}");
            return [];
        }
    }

    public async Task<Project> GetProjectByIdAsync(int id)
    {
        try
        {
            var projectEntity = await _projectRepository.GetAsync(x => x.Id == id);
            return _projectFactory.CreateProject(projectEntity);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Customer Service GetCustomerByIdAsync Error:{ex}");
            return null!;
        }
    }

    public async Task<Project> GetProjectByProjectNumberAsync(string projectNumber)
    {
        try
        {
            var projectEntity = await _projectRepository.GetAsync(x => x.ProjectNumber == projectNumber);
            return _projectFactory.CreateProject(projectEntity);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Customer Service GetProjectByProjectNumberAsync Error:{ex}");
            return null!;
        }
    }

    public async Task<bool> UpdateProjectAsync(ProjectUpdateDto updateDto)
    {
        try
        {
            var existingProjectEntity = await _projectRepository.GetAsync(x => x.Id == updateDto.Id);
            if (existingProjectEntity == null)
            {
                return false;  // Om projektet inte finns, returnera false
            }

            // Uppdatera projektet
            existingProjectEntity.ProjectNumber = updateDto.ProjectNumber;
            existingProjectEntity.Title = updateDto.Title;
            existingProjectEntity.Description = updateDto.Description;
            existingProjectEntity.StartDate = updateDto.StartDate;
            existingProjectEntity.EndDate = updateDto.EndDate;
            existingProjectEntity.TotalPrice = updateDto.TotalPrice;
            existingProjectEntity.StatusId = updateDto.StatusId;
            existingProjectEntity.UserId = updateDto.UserId;
            existingProjectEntity.ServiceId = updateDto.ServiceId;
            existingProjectEntity.CustomerId = updateDto.CustomerId;

            // Uppdatera projektet i databasen
            var updatedEntity = await _projectRepository.UpdateAsync(x => x.Id == updateDto.Id, existingProjectEntity!);

            if (updatedEntity == null)
            {
                return false;  // Misslyckades att uppdatera
            }

            return true;
        }
        catch (Exception ex)
        {
           
            return false;
        }
    }

    public async Task<bool> DeleteProjectAsync(int id)
    {
        var result = await _projectRepository.DeleteAsync(x => x.Id == id);
        return result;
    }
}
