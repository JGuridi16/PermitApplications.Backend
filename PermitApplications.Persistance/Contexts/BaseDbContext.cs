using Microsoft.EntityFrameworkCore;
using PermitApplications.Core.BaseModel.Base;
using PermitApplications.Persistence.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace PermitApplications.Persistence.Contexts
{
    public abstract class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public override int SaveChanges()
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateSoftDeleteStatuses();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permit>().HasQueryFilter(p => !p.Deleted);
            modelBuilder.Entity<PermitType>().HasQueryFilter(pt => !pt.Deleted);
            base.OnModelCreating(modelBuilder);
        }

        private void UpdateSoftDeleteStatuses()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["Deleted"] = false;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["Deleted"] = true;
                        break;
                }
            }
        }
    }
}
