using Data.Entities;
using Domain.Dtos;
using Domain.Models;
using Domain.UpdateDtos;

namespace Domain.Interfaces;

public interface IProjectFactory
{

    Project CreateProject(ProjectEntity projectEntity);

    ProjectDto CreateProjectDto();


    ProjectEntity CreateProjectEntity(ProjectDto projectDto);


    ProjectUpdateDto CreateProjectUpdateDto(ProjectUpdateDto projectUpdateDto);

}