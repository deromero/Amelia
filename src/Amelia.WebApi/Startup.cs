using System.Net;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json.Serialization;
using Amelia.WebApi.ViewModels.Mappings;
using Amelia.WebApi.Core;
using Amelia.Data.Repositories;
using Amelia.WebApi.Models.Auth;
using Microsoft.IdentityModel.Tokens;
using Amelia.Data.Contexts;
using Amelia.Domain.Contracts.Repositories;
using Amelia.Services;
using Amelia.Domain.Contracts.Services;

[assembly: UserSecretsId("aspnet-TestApp-ce345b64-19cf-4972-b34f-d16f2e7976ed")]
namespace Amelia.WebApi
{
    public class Startup
    {
        //TODO: This SecretKey must be retrieved from Environment Settings.
        private const string SecretKey = "thisisthesecretkeyfordevelopmentforameliapm";
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
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
            AddServices(services);

            AutoMapperConfiguration.Configure();

            // Enable Cors
            services.AddCors();

            // Add framework services.
            services.AddOptions();

            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));
            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                .RequireAuthenticatedUser()
                                .Build();
            })
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

        private void AddServices(IServiceCollection services){
            services.AddScoped<IUserService, UserService>();
        }
    }
}
