using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Domain.Dtos;
using Domain.Factories;
using Domain.Interfaces;
using Domain.Models;
using System.Diagnostics;

namespace Business.Services;

public class ProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly IProjectFactory _projectFactory;
    public async Task<bool> CreateProjectAsync(ProjectDto dto)
    {
        try
        {
            ProjectEntity projectEntity = _projectFactory.CreateProjectEntity(dto);

            await _projectRepository.CreateAsync(projectEntity);

            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Project Service CreateProject Error:{ex}");
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

    public async Task<Project> GetCustomerByIdAsync(int id)
    {
        try
        {
            var customerEntity = await _projectRepository.GetAsync(x => x.Id == id);
            return _projectFactory.CreateProject(customerEntity);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Customer Service GetCustomerByIdAsync Error:{ex}");
            return null!;
        }
    }

    public async Task<bool> UpdateProjectAsync(ProjectUpdateDto updateDto)
    {
        try
        {
            var existingProjectEntity = await _projectRepository.GetAsync(x => x.Id == updateDto.Id);
            if (existingProjectEntity != null)
            {
                existingProjectEntity.Title = updateDto.Title;
                existingProjectEntity.Description = updateDto.Description;
                existingProjectEntity.StartDate = updateDto.StartDate;
                existingProjectEntity.EndDate = updateDto.EndDate;
                existingProjectEntity.TotalPrice = updateDto.TotalPrice;
                existingProjectEntity.StatusId = updateDto.StatusId;
                existingProjectEntity.UserId = updateDto.UserId;
                existingProjectEntity.ServiceId = updateDto.ServiceId;
                existingProjectEntity.CustomerId = updateDto.CustomerId;
            }

            var updatedEntity = await _projectRepository.UpdateAsync(x => x.Id == updateDto.Id, existingProjectEntity!);

            var customer = _projectFactory.CreateProject(updatedEntity);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Customer Service UpdateProjectAsync Error:{ex}");
            return false;
        }
    }

    public async Task<bool> DeleteCustomerAsync(int id)
    {
        var result = await _projectRepository.DeleteAsync(x => x.Id == id);
        return result;
    }
}
