namespace Aiursoft.WingetCommunityServer.Middlewares;

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
        Console.WriteLine($"REQ {method} {path}");
        if (requestBody.Length > 0)
        {
            Console.WriteLine(requestBody);
        }
        buffer.Seek(0, SeekOrigin.Begin);
        request.Body = buffer;
        await _next(context);
    }
}