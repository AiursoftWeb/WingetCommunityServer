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
            app.UseMiddleware<RequestCaptureAndLogMiddleware>();
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

public class RequestCaptureAndLogMiddleware
{
    private readonly RequestDelegate _next;

    public RequestCaptureAndLogMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var request = context.Request;
        var body = request.Body;
        var buffer = new MemoryStream();
        await body.CopyToAsync(buffer);
        buffer.Seek(0, SeekOrigin.Begin);
        var reader = new StreamReader(buffer);
        var requestBody = await reader.ReadToEndAsync();
        var path = request.Path;
        var method = request.Method;
        Console.WriteLine($"{method} {path}");
        if (requestBody.Length > 0)
        {
            Console.WriteLine(requestBody);
        }
        buffer.Seek(0, SeekOrigin.Begin);
        request.Body = buffer;
        await _next(context);
    }
}
