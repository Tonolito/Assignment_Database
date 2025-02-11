using Data.Entities;
using Domain.Dtos;
using Domain.Models;

namespace Domain.Factories;

public class ProjectFactory
{
    public static ProjectDto CreateProjectDto()
    {
        return new ProjectDto();
    }

    public static ProjectUpdateDto CreateProjectUpdateDto(ProjectUpdateDto projectUpdateDto)
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

    public static ProjectEntity CreateProjectEntity(ProjectDto projectDto)
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

    public static Project CreateProject(ProjectEntity projectEntity)
    {
        return new Project()
        {
            
            Title = projectEntity.Title,
            Description = projectEntity.Description,
            StartDate = projectEntity.StartDate,
            EndDate = projectEntity.EndDate,
            TotalPrice = projectEntity.TotalPrice,
            StatusId = projectEntity.StatusId,
            UserId = projectEntity.UserId,
            ServiceId = projectEntity.ServiceId,
            CustomerId = projectEntity.CustomerId,

        };
    }
}
