// -----------------------------------------------------------
// Error Handling with ProblemDetails
// -----------------------------------------------------------

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

// -----------------------------------------------------------
// 1. Global Exception Handler (Middleware)
// -----------------------------------------------------------

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception,
            "Unhandled exception for {Method} {Path}",
            httpContext.Request.Method,
            httpContext.Request.Path);

        var problemDetails = new ProblemDetails
        {
            Title = "Internal Server Error",
            Detail = "An unexpected error occurred. Please try again later.",
            Status = StatusCodes.Status500InternalServerError,
            Instance = httpContext.Request.Path
        };

        // NEVER expose exception details in production
        // Only add in Development:
        if (httpContext.RequestServices
            .GetRequiredService<IHostEnvironment>().IsDevelopment())
        {
            problemDetails.Extensions["exception"] = exception.Message;
            problemDetails.Extensions["stackTrace"] = exception.StackTrace;
        }

        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}

// -----------------------------------------------------------
// 2. Registration in Program.cs
// -----------------------------------------------------------

// builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
// builder.Services.AddProblemDetails();
//
// app.UseExceptionHandler();
// app.UseStatusCodePages();

// -----------------------------------------------------------
// 3. Returning ProblemDetails from Endpoints
// -----------------------------------------------------------

// 404 Not Found:
// TypedResults.NotFound(new ProblemDetails
// {
//     Title = "Not Found",
//     Detail = $"Task with ID {id} was not found.",
//     Status = StatusCodes.Status404NotFound,
//     Instance = $"/api/tasks/{id}"
// });

// 400 Validation Error (uses ValidationProblem):
// TypedResults.ValidationProblem(validationResult.ToDictionary());

// 409 Conflict:
// TypedResults.Conflict(new ProblemDetails
// {
//     Title = "Conflict",
//     Detail = "A task with this title already exists.",
//     Status = StatusCodes.Status409Conflict
// });

// -----------------------------------------------------------
// 4. Result Pattern (optional, cleaner service layer)
// -----------------------------------------------------------

public class Result<T>
{
    public T? Value { get; }
    public string? Error { get; }
    public bool IsSuccess { get; }

    private Result(T value)
    {
        Value = value;
        IsSuccess = true;
    }

    private Result(string error)
    {
        Error = error;
        IsSuccess = false;
    }

    public static Result<T> Success(T value) => new(value);
    public static Result<T> Failure(string error) => new(error);
}

// Usage in service:
// public async Task<Result<TaskResponse>> GetByIdAsync(Guid id)
// {
//     var task = await _context.Tasks.FindAsync(id);
//     return task is null
//         ? Result<TaskResponse>.Failure($"Task {id} not found")
//         : Result<TaskResponse>.Success(task.ToResponse());
// }
