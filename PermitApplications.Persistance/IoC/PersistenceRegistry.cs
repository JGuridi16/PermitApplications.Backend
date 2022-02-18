using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PermitApplications.Core.Models;
using PermitApplications.Persistence.Contexts.Khensys;

namespace PermitApplications.Persistence.IoC
{
    public static class PersistenceRegistry
    {
        public static void AddPersistenceRegistry(this IServiceCollection services, IConfiguration configuration)
        {
            var settings = configuration.GetSection("AppSettings").Get<AppSettings>();

            services.AddDbContext<KhensysDbContext>(op => op.UseSqlServer(settings.DefaultConnection));
        }
    }
}
