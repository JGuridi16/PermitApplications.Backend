using AutoMapper;
using PermitApplications.BusinessLayer.Entities;
using PermitApplications.Persistence.Contexts.Khensys;
using PermitApplications.Services.Base;

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
    }
}
