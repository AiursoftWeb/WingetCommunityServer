using Aiursoft.WebTools.Models;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Reflection;

namespace Aiursoft.WingetCommunityServer
{
    public class Startup : IWebStartup
    {
        public void ConfigureServices(IConfiguration configuration, IWebHostEnvironment environment, IServiceCollection services)
        {
            services
                .AddMemoryCache()
                .AddHttpClient();
            services
                .AddControllers()
                .AddApplicationPart(Assembly.GetExecutingAssembly())
                .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

        }

        public void Configure(WebApplication app)
        {
            app.UseRouting();
            app.MapDefaultControllerRoute();
        }
    }
}
