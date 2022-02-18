using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace PermitApplications.API.Controllers.Base
{
    public interface IControllerBase
    {
        IMapper _mapper { get; set; }
        UnprocessableEntityObjectResult UnprocessableEntity(object error);
    }
}
