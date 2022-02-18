using AutoMapper;
using PermitApplications.BusinessLayer.Entities;
using PermitApplications.Persistence.Contexts.Khensys;
using PermitApplications.Persistence.Entities;
using PermitApplications.Services.Base;

namespace PermitApplications.Services.PermitType
{
    public interface IPermitTypeService : IServiceBase<Persistence.Entities.PermitType, PermitTypeDto>
    {
    }

    public class PermitTypeService : ServiceBase<Persistence.Entities.PermitType, PermitTypeDto>, IPermitTypeService
    {
        public PermitTypeService(IMapper mapper, KhensysDbContext context)
            : base(mapper, context)
        {
        }
    }
}
