using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PermitApplications.Services.Permit;
using PermitApplications.Services.PermitType;

namespace PermitApplications.Persistence.IoC
{
    public static class ServicesRegistry
    {
        public static void AddServicesRegistry(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IPermitService, PermitService>();
            services.AddTransient<IPermitTypeService, PermitTypeService>();
        }
    }
}
