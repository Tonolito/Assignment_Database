using Domain.Dtos;
using Domain.Models;
using Domain.UpdateDtos;

namespace Business.Interfaces
{
    public interface IStatusTypeService
    {
        Task<bool> CreateStatusTypeAsync(StatusTypeDto statusTypeDto);
        Task<bool> DeleteStatusTypeAsync(int id);
        Task<bool> UpdateServiceAsync(StatusTypeUpdateDto statusTypeUpdateDto);
        Task<StatusType> GetStatusTypeById(int id);
        Task<IEnumerable<StatusType>> GetStatusTypesAsync();
    }
}