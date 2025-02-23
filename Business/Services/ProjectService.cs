using Business.Interfaces;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
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
        await _projectRepository.BeginTransactionAsync();

        try
        {
            ProjectEntity projectEntity = _projectFactory.CreateProjectEntity(projectDto);

            var result = await _projectRepository.CreateAsync(projectEntity);
            if (result == false)
            {
                return false;
            }
            await _projectRepository.SaveAsync();


            await _projectRepository.CommitTransactionAsync();
            return true;
        }
        catch (Exception ex)
        {
            await _projectRepository.RollbackTransactionAsync();

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
        await _projectRepository.BeginTransactionAsync();

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

            await _projectRepository.SaveAsync();

            await _projectRepository.CommitTransactionAsync();

            if (updatedEntity == null)
            {
                return false;  // Misslyckades att uppdatera
            }

            return true;
        }
        catch (Exception ex)
        {
           await _projectRepository.RollbackTransactionAsync();
            Debug.WriteLine($"Customer Service UpdateProjectAsync Error:{ex}");

            return false;
        }
    }

    public async Task<bool> DeleteProjectAsync(int id)
    {
        await _projectRepository.BeginTransactionAsync();

        try
        {
            var result = await _projectRepository.DeleteAsync(x => x.Id == id);

            await _projectRepository.SaveAsync();
            await _projectRepository.CommitTransactionAsync();
            return result;
        }
        catch (Exception ex)
        {
            await _projectRepository.RollbackTransactionAsync();
            Debug.WriteLine($"Customer Service DeleteProjectAsync Error:{ex}");

            return false;
        }
        
    }
}
