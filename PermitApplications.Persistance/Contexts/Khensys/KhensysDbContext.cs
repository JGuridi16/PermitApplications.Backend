using Microsoft.EntityFrameworkCore;
using PermitApplications.Persistence.Entities;

namespace PermitApplications.Persistence.Contexts.Khensys
{
    public class KhensysDbContext : BaseDbContext
    {
        public KhensysDbContext(DbContextOptions<KhensysDbContext> options)
            : base(options)
        {
        }

        #region Tables

        public virtual DbSet<Permit> Permit { get; set; }
        public virtual DbSet<PermitType> PermitType { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
