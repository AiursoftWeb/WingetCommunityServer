public class ResponseCaptureAndLogMiddleware
{
    private readonly RequestDelegate _next;

    public ResponseCaptureAndLogMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var request = context.Request;
        var response = context.Response;
        var body = response.Body;
        var buffer = new MemoryStream();
        response.Body = buffer;
        await _next(context);
        buffer.Seek(0, SeekOrigin.Begin);
        var reader = new StreamReader(buffer);
        var responseBody = await reader.ReadToEndAsync();
        var path = request.Path;
        var method = request.Method;
        Console.WriteLine($"RSP {method} {path}");
        if (responseBody.Length > 0)
        {
            Console.WriteLine(responseBody);
        }
        buffer.Seek(0, SeekOrigin.Begin);
        await buffer.CopyToAsync(body);
        response.Body = body;
    }
}