using GlobalErrorHandling.Classes.ErrorHandling;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GlobalErrorHandling
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //Inject our custom error filter
            services.AddSingleton<ExceptionHandlingFilter>();
            //inject our custom middleware
            services.AddSingleton<ExceptionMiddleware>();
            //attach our filter as a service over all actions
            services.AddMvc(options =>
            {
                options.Filters.Add(new ServiceFilterAttribute(typeof(ExceptionHandlingFilter)));
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            //activate our custom middleware
            app.UseMiddleware<ExceptionMiddleware>();

            app.UseMvc();
        }
    }
}
