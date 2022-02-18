using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PermitApplications.Core.BaseModel.Base;
using PermitApplications.Core.BaseModel.BaseDto;
using PermitApplications.Persistence.Contexts.Khensys;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermitApplications.Services.Base
{
    public class ServiceBase<TEntity, TEntityDto> : IServiceBase<TEntity, TEntityDto> where TEntity : class, IBase
      where TEntityDto : class, IBaseDto
    {
        public readonly IMapper _mapper;
        public readonly DbSet<TEntity> _repository;
        public KhensysDbContext Context { get; }
        public IQueryable<TEntity> Query { get => _repository.AsQueryable(); }

        public ServiceBase(IMapper mapper, KhensysDbContext context)
        {
            Context = context;
            _mapper = mapper;
            _repository = Context.Set<TEntity>();
        }

        #region CRUD Operations

        public async Task<IList<TEntityDto>> GetAllAsync()
        {
            var entities = await Query.ToListAsync();
            return _mapper.Map<IList<TEntityDto>>(entities);
        }

        public async Task<TEntityDto> GetByIdAsync(int id)
        {
            TEntity entity = await Query.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == default)
                return null;

            return _mapper.Map<TEntityDto>(entity);
        }

        public async Task<TEntityDto> SaveAsync(TEntityDto entityDto)
        {
            TEntity entity = _mapper.Map<TEntity>(entityDto);

            _repository.Add(entity);
            await Context.SaveChangesAsync();

            return _mapper.Map<TEntityDto>(entity);
        }

        public async Task<TEntityDto> UpdateAsync(int id, TEntityDto entityDto)
        {
            TEntity entity = await Query.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == default)
                return null;

            _mapper.Map(entityDto, entity);

            _repository.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;

            await Context.SaveChangesAsync();

            return _mapper.Map(entity, entityDto);
        }

        public async Task<TEntityDto> DeleteAsync(int id)
        {
            TEntity entity = await Query.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == default)
                return null;

            _repository.Remove(entity);
            await Context.SaveChangesAsync();

            return _mapper.Map<TEntityDto>(entity);
        }

        #endregion
    }
}
