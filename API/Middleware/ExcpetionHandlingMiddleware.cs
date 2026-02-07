using System.Net;
using System.Text.Json;
using ConferenceBookingDomain;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger <ExceptionHandlingMiddleware> _logger;
    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = context.Response;
        response.ContentType = "application/json";

        response.StatusCode = exception switch
        {
            BookingConflictException => StatusCodes.Status422UnprocessableEntity,
            InvalidBookingException => StatusCodes.Status400BadRequest,
            RoomNotFoundException or BookingNotFoundException => StatusCodes.Status404NotFound,
           // ForbiddenAccessException => StatusCodes.Status403Forbidden, 
            //InvalidUserException => StatusCodes.Status401Unauthorized,

            _ => StatusCodes.Status500InternalServerError
        };

        var payload = new
        {
            error = exception.GetType().Name,
            detail = exception.Message,
            innerMessage = exception.InnerException?.Message
        };

        return response.WriteAsync(JsonSerializer.Serialize(payload));
    }


    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
            
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred during the request.");
            await HandleExceptionAsync(context, ex);
        }
    }
}