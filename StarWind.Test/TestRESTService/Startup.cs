using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Serilog;
using TestRESTService.Infrastrucutre;
using System.Reflection;
using System.IO;
using TestCommon;
using System.Collections.Generic;

namespace TestRESTService
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
            services.AddMemoryCache();
            services.AddMvc();
            services.AddAutoMapper(config => config.AddProfile(new ClientProfile()), typeof(Startup));
        }

        public void ConfigureDevelopment(IApplicationBuilder app)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .CreateLogger();
            Log.Information("Running DEV Environment");

            ConfigureAlways(app);
        }

        public void ConfigureProduction(IApplicationBuilder app)
        {
            Log.Logger = new LoggerConfiguration()
               .ReadFrom.Configuration(Configuration)
               .CreateLogger();
            Log.Information("Running Prod Environment");

            ConfigureAlways(app);
        }

        public void ConfigureAlways(IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseMvc(cfg =>
            {
                cfg.MapRoute("Default",
                    "{controller}/{action}/{id?}",
                    new { controller = "Client", action = "Index" });
            });
        }
    }
}

