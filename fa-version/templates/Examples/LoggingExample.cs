// -----------------------------------------------------------
// Structured Logging with Serilog
// -----------------------------------------------------------

// Program.cs setup (already shown, here for reference):
// builder.Host.UseSerilog((context, config) =>
//     config.ReadFrom.Configuration(context.Configuration));

// -----------------------------------------------------------
// Example: Logging in a service
// -----------------------------------------------------------

using Microsoft.Extensions.Logging;

public class TaskService : ITaskService
{
    private readonly AppDbContext _context;
    private readonly ILogger<TaskService> _logger;

    public TaskService(AppDbContext context, ILogger<TaskService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<TaskResponse?> GetByIdAsync(Guid id)
    {
        _logger.LogInformation("Retrieving task {TaskId}", id);

        var task = await _context.Tasks.FindAsync(id);

        if (task is null)
        {
            _logger.LogWarning("Task {TaskId} not found", id);
            return null;
        }

        return task.ToResponse();
    }

    public async Task<TaskResponse> CreateAsync(CreateTaskRequest request)
    {
        var task = new TaskItem
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            DueDate = request.DueDate,
            CreatedAt = DateTime.UtcNow
        };

        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();

        _logger.LogInformation(
            "Task {TaskId} created with title {TaskTitle}",
            task.Id, task.Title);

        return task.ToResponse();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task is null)
        {
            _logger.LogWarning("Attempted to delete non-existent task {TaskId}", id);
            return false;
        }

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Task {TaskId} deleted", id);
        return true;
    }
}

// -----------------------------------------------------------
// DON'T: Common logging mistakes
// -----------------------------------------------------------

// BAD: String interpolation (can't be searched, wastes memory)
// _logger.LogInformation($"User {userId} logged in");

// BAD: Logging sensitive data
// _logger.LogInformation("User {Email} logged in with password {Password}", email, password);

// BAD: Not using log levels correctly
// _logger.LogError("User not found");  // This is a Warning, not an Error

// GOOD: Structured logging with proper levels
// _logger.LogInformation("User {UserId} logged in from {IpAddress}", userId, ipAddress);
// _logger.LogWarning("Failed login attempt for {Email}", email);
// _logger.LogError(ex, "Failed to process payment {PaymentId}", paymentId);
