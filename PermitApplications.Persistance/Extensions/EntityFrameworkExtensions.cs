using Microsoft.EntityFrameworkCore;
using PermitApplications.Core.BaseModel.Base;
using PermitApplications.Persistence.Contexts.Khensys;

namespace PermitApplications.Persistence.Extensions
{
    public static class EntityFrameworkExtensions
    {
        public static void Modify<TEntity>(this DbSet<TEntity> set, TEntity entity, KhensysDbContext context) where TEntity : class, IBase
        {
            set.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
