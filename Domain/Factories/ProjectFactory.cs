using Data.Entities;
using Domain.Dtos;
using Domain.Interfaces;
using Domain.Models;
using Domain.UpdateDtos;

namespace Domain.Factories;

public class ProjectFactory : IProjectFactory
{
    public ProjectDto CreateProjectDto()
    {
        return new ProjectDto();
    }

    public ProjectUpdateDto CreateProjectUpdateDto(ProjectUpdateDto projectUpdateDto)
    {
        return new ProjectUpdateDto()
        {
            ProjectNumber = projectUpdateDto.ProjectNumber,
            Title = projectUpdateDto.Title,
            Description = projectUpdateDto.Description,
            StartDate = projectUpdateDto.StartDate,
            EndDate = projectUpdateDto.EndDate,
            TotalPrice = projectUpdateDto.TotalPrice,
            StatusId = projectUpdateDto.StatusId,
            UserId = projectUpdateDto.UserId,
            ServiceId = projectUpdateDto.ServiceId,
            CustomerId = projectUpdateDto.CustomerId,
        };
    }

    public ProjectEntity CreateProjectEntity(ProjectDto projectDto)
    {
        return new ProjectEntity()
        {
            ProjectNumber= projectDto.ProjectNumber,
            Title = projectDto.Title,
            Description = projectDto.Description,
            StartDate = projectDto.StartDate,
            EndDate = projectDto.EndDate,
            TotalPrice = projectDto.TotalPrice,
            StatusId = projectDto.StatusId,
            UserId = projectDto.UserId,
            ServiceId = projectDto.ServiceId,
            CustomerId = projectDto.CustomerId,
        };
    }

    public Project CreateProject(ProjectEntity projectEntity)
    {
     
        return new Project()
        {
            ProjectId = projectEntity.Id,
            ProjectNumber = projectEntity.ProjectNumber,
            Title = projectEntity.Title,
            Description = projectEntity.Description,
            StartDate = projectEntity.StartDate,
            EndDate = projectEntity.EndDate,
            TotalPrice = projectEntity.TotalPrice,
            StatusId = projectEntity.StatusId,
            StatusName = projectEntity.Status.StatusName,
            UserId = projectEntity.UserId,
            UserName = projectEntity.User.FirstName,
            ServiceId = projectEntity.ServiceId,
            ServiceName = projectEntity.Service.ServiceName,
            CustomerId = projectEntity.CustomerId,
            CustomerName = projectEntity.Customer.CustomerName,

        };
    }
}
