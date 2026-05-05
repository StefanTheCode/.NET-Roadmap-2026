// -----------------------------------------------------------
// Endpoints - Minimal API style
// -----------------------------------------------------------

using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

public static class TaskEndpoints
{
    public static void MapTaskEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/tasks")
            .WithTags("Tasks")
            .RequireAuthorization()
            .RequireRateLimiting("fixed");

        group.MapGet("/", GetAll);
        group.MapGet("/{id:guid}", GetById);
        group.MapPost("/", Create);
        group.MapPut("/{id:guid}", Update);
        group.MapDelete("/{id:guid}", Delete);
    }

    // GET /api/tasks?page=1&pageSize=10
    private static async Task<Ok<PagedResponse<TaskResponse>>> GetAll(
        [AsParameters] GetTasksRequest request,
        ITaskService taskService)
    {
        var result = await taskService.GetAllAsync(request.Page, request.PageSize);
        return TypedResults.Ok(result);
    }

    // GET /api/tasks/{id}
    private static async Task<Results<Ok<TaskResponse>, NotFound<ProblemDetails>>> GetById(
        Guid id,
        ITaskService taskService)
    {
        var result = await taskService.GetByIdAsync(id);

        return result is not null
            ? TypedResults.Ok(result)
            : TypedResults.NotFound(new ProblemDetails
            {
                Title = "Not Found",
                Detail = $"Task with ID {id} was not found.",
                Status = StatusCodes.Status404NotFound,
                Instance = $"/api/tasks/{id}"
            });
    }

    // POST /api/tasks
    private static async Task<Results<Created<TaskResponse>, ValidationProblem>> Create(
        CreateTaskRequest request,
        IValidator<CreateTaskRequest> validator,
        ITaskService taskService)
    {
        var validationResult = await validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return TypedResults.ValidationProblem(validationResult.ToDictionary());
        }

        var task = await taskService.CreateAsync(request);
        return TypedResults.Created($"/api/tasks/{task.Id}", task);
    }

    // PUT /api/tasks/{id}
    private static async Task<Results<Ok<TaskResponse>, NotFound<ProblemDetails>, ValidationProblem>> Update(
        Guid id,
        UpdateTaskRequest request,
        IValidator<UpdateTaskRequest> validator,
        ITaskService taskService)
    {
        var validationResult = await validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return TypedResults.ValidationProblem(validationResult.ToDictionary());
        }

        var result = await taskService.UpdateAsync(id, request);

        return result is not null
            ? TypedResults.Ok(result)
            : TypedResults.NotFound(new ProblemDetails
            {
                Title = "Not Found",
                Detail = $"Task with ID {id} was not found.",
                Status = StatusCodes.Status404NotFound,
                Instance = $"/api/tasks/{id}"
            });
    }

    // DELETE /api/tasks/{id}
    private static async Task<Results<NoContent, NotFound<ProblemDetails>>> Delete(
        Guid id,
        ITaskService taskService)
    {
        var deleted = await taskService.DeleteAsync(id);

        return deleted
            ? TypedResults.NoContent()
            : TypedResults.NotFound(new ProblemDetails
            {
                Title = "Not Found",
                Detail = $"Task with ID {id} was not found.",
                Status = StatusCodes.Status404NotFound,
                Instance = $"/api/tasks/{id}"
            });
    }
}

// -----------------------------------------------------------
// Request / Response DTOs
// -----------------------------------------------------------

public record CreateTaskRequest(string Title, string? Description, DateTime? DueDate);
public record UpdateTaskRequest(string Title, string? Description, DateTime? DueDate, bool IsCompleted);
public record TaskResponse(Guid Id, string Title, string? Description, DateTime? DueDate, bool IsCompleted, DateTime CreatedAt);
public record GetTasksRequest(int Page = 1, int PageSize = 10);
public record PagedResponse<T>(IEnumerable<T> Items, int TotalCount, int Page, int PageSize);
