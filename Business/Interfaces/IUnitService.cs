using Domain.Dtos;
using Domain.Models;

namespace Business.Interfaces
{
    public interface IUnitService
    {
        Task<bool> CreateUnitAsync(UnitDto dto);
        Task<bool> DeleteUnitAsync(int id);
        Task<IEnumerable<Unit>> GetUnitAsync();
        Task<Unit> GetUnitById(int id);
    }
}