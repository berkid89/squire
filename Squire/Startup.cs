using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Squire.BusinessLogic.Services;
using Squire.BusinessLogic.Services.Interfaces;
using Squire.BusinessLogic.Settings;
using Squire.Core.Middlewares;

namespace Squire
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        private readonly ILogger logger;
        private readonly ISettings settings;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();

            settings = new Settings(Configuration);
            logger = configureLogger(settings);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(p => settings);
            services.AddSingleton(p => logger);

            services.AddScoped<IDataAccess, DataAccess>();
            services.AddScoped<IWidgetService, WidgetService>();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true,
                    ReactHotModuleReplacement = true
                });
            }

            app.UseStaticFiles();

            app.UseGlobalErrorHandler(env.IsDevelopment());

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "api/v1/{controller}/{action}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }

        private ILogger configureLogger(ISettings settings)
        {
            return new LoggerConfiguration()
              .Enrich.FromLogContext()
              .MinimumLevel.Verbose()
              .WriteTo.ColoredConsole(settings.Logging.LogLevel, "{NewLine}{Timestamp:HH:mm:ss} [{Level}] ({CorrelationToken}) {Message}{NewLine}{Exception}")
              .WriteTo.MongoDB(settings.ConnectionString + settings.Database, "logs", settings.Logging.LogLevel)
              .CreateLogger();
        }
    }
}
