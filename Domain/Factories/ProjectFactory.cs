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
            // Sätta projectnumber?,
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
            
            Title = projectEntity.Title,
            Description = projectEntity.Description,
            StartDate = projectEntity.StartDate,
            EndDate = projectEntity.EndDate,
            TotalPrice = projectEntity.TotalPrice,
            StatusName = projectEntity.Status.StatusName,
            UserName = projectEntity.User.FirstName,
            ServiceName = projectEntity.Service.ServiceName,
            CustomerName = projectEntity.Customer.CustomerName,

        };
    }
}
