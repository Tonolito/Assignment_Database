using Domain.Dtos;
using Domain.Models;
using Domain.UpdateDtos;

namespace Business.Interfaces
{
    public interface IUnitService
    {
        Task<bool> CreateUnitAsync(UnitDto dto);
        Task<bool> DeleteUnitAsync(int id);
        Task<IEnumerable<Unit>> GetUnitAsync();
        Task<bool> UpdateUnitAsync(UnitUpdateDto updateDto);
        Task<Unit> GetUnitById(int id);
    }
}