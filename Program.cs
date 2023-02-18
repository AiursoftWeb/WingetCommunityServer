using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
});

var app = builder.Build();
//app.UseMiddleware<HelloWorldMiddleware>();
app.UseRouting();
app.MapDefaultControllerRoute();
app.Run();

public class HelloWorldMiddleware
{
    private readonly RequestDelegate _next;

    public HelloWorldMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var path = context.Request.Path.ToString();
        Console.WriteLine(path);
        if (context.Request.Method == "POST")
        {
            var stream = context.Request.Body;
            var body = await new StreamReader(stream).ReadToEndAsync();
        }
        await _next.Invoke(context);
    }
}