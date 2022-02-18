using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PermitApplications.API.Controllers.Base;
using PermitApplications.BusinessLayer.Entities;
using PermitApplications.Persistence.Entities;
using PermitApplications.Services.Permit;

namespace PermitApplications.API.Controllers.Permit
{
    [Route("api/[controller]")]
    public class PermitController : ControllerBase<Persistence.Entities.Permit, PermitDto>
    {
        public PermitController(IPermitService service, IMapper mapper, ILogger<PermitController> logger)
            : base(service, mapper)
        {
        }
    }
}
