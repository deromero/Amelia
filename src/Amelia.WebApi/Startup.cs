using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Amelia.WebApi.Models.Contracts.Repositories;
using Amelia.WebApi.ViewModels.Mappings;
using Amelia.WebApi.Core;
using Amelia.Data.Repositories;
using Amelia.WebApi.Data;

namespace Amelia.WebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {


            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<AmeliaContext>(options =>
            {
                options.UseSqlServer(Configuration["Data:AmeliaConnection:ConnectionString"],
                b => b.MigrationsAssembly("Amelia.WebApi"));
            });

            //Add Repositories
            AddRepositories(services);


            AutoMapperConfiguration.Configure();
            // Enable Cors
            services.AddCors();

            // Add framework services.
            services.AddMvc()
            .AddJsonOptions(options =>
            {
                // Force camel case to JSON
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseStaticFiles();

            app.UseCors(builder =>
                builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());


            app.UseExceptionHandler(
                          builder =>
                          {
                              builder.Run(
                                async context =>
                                {
                                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                    context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                                    var error = context.Features.Get<IExceptionHandlerFeature>();
                                    if (error != null)
                                    {
                                        context.Response.AddApplicationError(error.Error.Message);
                                        await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
                                    }
                                });
                          });

            app.UseMvc();
        }

        private void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
        }

    }
}
