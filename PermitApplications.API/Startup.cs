using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PermitApplications.BusinessLayer.IoC;
using PermitApplications.Core.IoC;
using PermitApplications.Core.Models;
using PermitApplications.Persistence.IoC;
using System;

namespace PermitApplications.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            #region Adding Settings Sections
            
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            
            #endregion

            #region CORS
            
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllPolicy",
                      builder =>
                      {
                          builder
                                 .AllowAnyHeader()
                                 .AllowAnyMethod()
                                 .AllowCredentials();

                          //TODO: remove this line for production
                          builder.SetIsOriginAllowed(x => true);
                          builder.WithExposedHeaders("Token-Expired");
                      });
            });
            
            #endregion

            #region IoC Registry
            
            services.AddCoreRegistry();
            services.AddPersistenceRegistry(Configuration);
            services.AddBusinessLayerRegistry();
            services.AddServicesRegistry(Configuration);
            
            #endregion

            #region Adding External Libs
            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen();

            #endregion

            #region Api config

            services.AddCors(options => options.AddPolicy("AllowAnyOrigin", builder => builder.AllowAnyOrigin()));
            services.AddControllers(o => o.EnableEndpointRouting = false);

            #endregion
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAllPolicy");

            app.UseSwagger();

            app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "Khensys API V1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseMvc();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
