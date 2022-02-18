using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PermitApplications.BusinessLayer.Entities;
using PermitApplications.Persistence.Contexts.Khensys;
using PermitApplications.Services.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PermitApplications.Services.Permit
{
    public interface IPermitService : IServiceBase<Persistence.Entities.Permit, PermitDto>
    {
    }

    public class PermitService : ServiceBase<Persistence.Entities.Permit, PermitDto>, IPermitService
    {
        public PermitService(IMapper mapper, KhensysDbContext context)
            : base(mapper, context)
        {
        }

        public override async Task<IList<PermitDto>> GetAllAsync()
        {
            var entities = await Query
                .Include(x => x.PermitType)
                .ToListAsync();

            return _mapper.Map<IList<PermitDto>>(entities);
        }

        public override async Task<PermitDto> GetByIdAsync(int id)
        {
            var entity = await Query
                .Include(x => x.PermitType)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == default)
                return null;

            return _mapper.Map<PermitDto>(entity);
        }
    }
}
