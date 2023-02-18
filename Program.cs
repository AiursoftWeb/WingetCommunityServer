var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddControllers();

var app = builder.Build();
app.UseMiddleware<HelloWorldMiddleware>();
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
        await _next.Invoke(context);
    }
}