using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PermitApplications.API.Controllers.Base;
using PermitApplications.BusinessLayer.Entities;
using PermitApplications.Services.PermitType;

namespace PermitApplications.API.Controllers.PermitType
{
    [Route("api/[controller]")]
    public class PermitTypeController : ControllerBase<Persistence.Entities.PermitType, PermitTypeDto>
    {
        public PermitTypeController(IPermitTypeService service, IMapper mapper, ILogger<PermitTypeController> logger)
            : base(service, mapper)
        {
        }
    }
}
