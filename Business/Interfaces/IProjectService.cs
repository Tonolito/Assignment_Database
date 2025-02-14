using Domain.Dtos;
using Domain.Models;
using Domain.UpdateDtos;

namespace Business.Interfaces
{
    public interface IProjectService
    {
        Task<bool> CreateProjectAsync(ProjectDto projectDto);
        Task<bool> DeleteProjectAsync(int id);
        Task<Project> GetProjectByIdAsync(int id);
        Task<Project> GetProjectByProjectNumberAsync(string projectNumber);
        Task<IEnumerable<Project>> GetProjectsAsync();
        Task<bool> UpdateProjectAsync(ProjectUpdateDto updateDto);
    }
}