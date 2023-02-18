var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();
app.MapDefaultControllerRoute();
app.Run();
