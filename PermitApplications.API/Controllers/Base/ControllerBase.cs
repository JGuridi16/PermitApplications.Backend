using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PermitApplications.Core.BaseModel.Base;
using PermitApplications.Core.BaseModel.BaseDto;
using PermitApplications.Services.Base;
using System.Net;
using System.Threading.Tasks;

namespace PermitApplications.API.Controllers.Base
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ControllerBase<TEntity, TEntityDto> : ControllerBase, IControllerBase
            where TEntity : class, IBase
            where TEntityDto : class, IBaseDto
    {
        public IMapper _mapper { get; set; }
        protected readonly IServiceBase<TEntity, TEntityDto> _service;

        public ControllerBase(IServiceBase<TEntity, TEntityDto> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        #region CRUD Operations

        [HttpGet]
        public virtual async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();

            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById(int id)
        {
            TEntityDto dto = await _service.GetByIdAsync(id);

            if (dto == null)
                return NotFound();

            return Ok(dto);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Post([FromBody] TEntityDto entityDto)
        {
            entityDto = await _service.SaveAsync(entityDto);
            return Ok(entityDto);
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Put([FromRoute] int id, [FromBody] TEntityDto entityDto)
        {
            if (entityDto.Id != id)
                return BadRequest();

            entityDto = await _service.UpdateAsync(id, entityDto);

            if (entityDto == null)
                return NotFound();

            return Ok(entityDto);
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            TEntityDto entityDto = await _service.DeleteAsync(id);

            if (entityDto == null)
                return NotFound();

            return Ok(entityDto);
        }

        #endregion
    }
}
