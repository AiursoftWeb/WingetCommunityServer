using Aiursoft.WebTools.Models;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Aiursoft.DocGenerator.Services;
using Aiursoft.DbTools.Sqlite;
using Aiursoft.WingetCommunityServer.Data;
using WingetCommunityServer.Models.Configuration;
using WingetCommunityServer.Services;

namespace Aiursoft.WingetCommunityServer
{
    public class Startup : IWebStartup
    {
        public void ConfigureServices(IConfiguration configuration, IWebHostEnvironment environment, IServiceCollection services)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            services.AddAiurSqliteWithCache<WingetServerDbContext>(connectionString);

            var serverConfig = configuration.GetSection("Server");
            services.Configure<ServerConfig>(serverConfig);
            services.AddTransient<InformationBuilder>();
            services.AddTransient<Searcher>();
            services
                .AddMemoryCache()
                .AddHttpClient();
            services
                .AddControllers()
                .AddApplicationPart(typeof(Startup).Assembly)
                .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });
        }

        public void Configure(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMiddleware<RequestCaptureAndLogMiddleware>();
                app.UseMiddleware<ResponseCaptureAndLogMiddleware>();
            }
            app.UseRouting();
            app.MapDefaultControllerRoute();
            app.UseAiursoftDocGenerator(options => 
            {
                // TODO: It may say input requires form encoded but actually it is JSON!
                options.Format = DocFormat.Markdown;
            });
        }
    }
}