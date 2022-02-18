using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PermitApplications.Persistence.Extensions;
using PermitApplications.Persistence.Contexts.Khensys;

namespace PermitApplications.API.Config
{
    public static class EntityFrameworkConfig
    {
        public static IHost Seed(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<KhensysDbContext>();

                context
                    .SeedPermitTypes();

                context.SaveChanges();
            }
            return host;
        }
    }
}
