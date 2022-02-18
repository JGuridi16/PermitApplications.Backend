using PermitApplications.Core.BaseModel.Base;
using PermitApplications.Core.BaseModel.BaseDto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermitApplications.Services.Base
{
    public interface IServiceBase<TEntity, TEntityDto> where TEntity : class, IBase
        where TEntityDto : class, IBaseDto
    {
        IQueryable<TEntity> Query { get; }
        Task<IList<TEntityDto>> GetAllAsync();

        Task<TEntityDto> GetByIdAsync(int id);
        Task<TEntityDto> SaveAsync(TEntityDto entityDto);
        Task<TEntityDto> UpdateAsync(int id, TEntityDto entityDto);
        Task<TEntityDto> DeleteAsync(int id);
    }
}
