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
using Amelia.WebApp.ViewModels.Mappings;
using Amelia.WebApp.Core;
using Amelia.Data.Repositories;
using Amelia.WebApp.Models.Auth;
using Microsoft.IdentityModel.Tokens;
using Amelia.Data.Contexts;
using Amelia.Domain.Contracts.Repositories;
using Amelia.Services;
using Amelia.Domain.Contracts.Services;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Amelia.Data.Initializer;
using System.Security.Claims;
using Amelia.WebApp.Models.Services;
using Amelia.WebApp.Models.Contracts;

[assembly: UserSecretsId("aspnet-TestApp-ce345b64-19cf-4972-b34f-d16f2e7976ed")]
namespace Amelia.WebApp
{
    public class Startup
    {
        //TODO: This SecretKey must be retrieved from Environment Settings.
        private const string SecretKey = "thisisthesecretkeyfordevelopmentforameliapm";
        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
        private static string _applicationPath = string.Empty;
        private static string _contentRootPath = string.Empty;
        public Startup(IHostingEnvironment env)
        {
            _applicationPath = env.WebRootPath;
            _contentRootPath = env.ContentRootPath;

            var builder = new ConfigurationBuilder()
                .SetBasePath(_contentRootPath)
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
                b => b.MigrationsAssembly("Amelia.WebApp"));
            });

            //Add Repositories
            AddRepositories(services);
            AddServices(services);
            AutoMapperConfiguration.Configure();

            // Enable Cors
            services.AddCors();

            AddAutenticationServices(services);
            services.AddAuthentication();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, "Admin");
                });
            });

            // Add framework services.
            services.AddOptions();
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
            app.UseFileServer();

            var provider = new PhysicalFileProvider(
                Path.Combine(_contentRootPath, "node_modules")
            );
            var _fileServerOptions = new FileServerOptions();
            _fileServerOptions.RequestPath = "/node_modules";
            _fileServerOptions.StaticFileOptions.FileProvider = provider;
            _fileServerOptions.EnableDirectoryBrowsing = true;
            app.UseFileServer(_fileServerOptions);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true
            });

            app.UseCors(builder =>
                 builder.AllowAnyOrigin()
                 .AllowAnyHeader()
                 .AllowAnyMethod());


            app.UseMvc(routes =>
 {
     routes.MapRoute(
         name: "default",
         template: "{controller=Home}/{action=Index}/{id?}");

                // Uncomment the following line to add a route for porting Web API 2 controllers.
                //routes.MapWebApiRoute("DefaultApi", "api/{controller}/{id?}");
            });

            DbInitializer.Initialize(app.ApplicationServices);
        }

        public static void Main(string[] args)
        {
           var config = new ConfigurationBuilder()
                .AddCommandLine(args)
                .AddEnvironmentVariables(prefix: "ASPNETCORE_")
                .Build();

            var host = new WebHostBuilder()
                .UseConfiguration(config)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }


        private void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();

        }

        private void AddServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }

        private void AddAutenticationServices(IServiceCollection services)
        {
            services.AddScoped<IMembershipService, MembershipService>();
            services.AddScoped<IEncryptionService, EncryptionService>();
        }
    }
}
