// -----------------------------------------------------------
// Input Validation with FluentValidation
// -----------------------------------------------------------

using FluentValidation;

public class CreateTaskRequestValidator : AbstractValidator<CreateTaskRequest>
{
    public CreateTaskRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(200).WithMessage("Title must be 200 characters or less.");

        RuleFor(x => x.Description)
            .MaximumLength(2000).WithMessage("Description must be 2000 characters or less.")
            .When(x => x.Description is not null);

        RuleFor(x => x.DueDate)
            .GreaterThan(DateTime.UtcNow).WithMessage("Due date must be in the future.")
            .When(x => x.DueDate.HasValue);
    }
}

public class UpdateTaskRequestValidator : AbstractValidator<UpdateTaskRequest>
{
    public UpdateTaskRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(200).WithMessage("Title must be 200 characters or less.");

        RuleFor(x => x.Description)
            .MaximumLength(2000).WithMessage("Description must be 2000 characters or less.")
            .When(x => x.Description is not null);

        RuleFor(x => x.DueDate)
            .GreaterThan(DateTime.UtcNow).WithMessage("Due date must be in the future.")
            .When(x => x.DueDate.HasValue);
    }
}

// -----------------------------------------------------------
// Validation in an endpoint (Minimal API)
// -----------------------------------------------------------

// See TaskEndpoints.cs for full example. Key pattern:
//
// private static async Task<Results<Created<TaskResponse>, ValidationProblem>> Create(
//     CreateTaskRequest request,
//     IValidator<CreateTaskRequest> validator,
//     ITaskService taskService)
// {
//     var validationResult = await validator.ValidateAsync(request);
//     if (!validationResult.IsValid)
//     {
//         return TypedResults.ValidationProblem(validationResult.ToDictionary());
//     }
//     var task = await taskService.CreateAsync(request);
//     return TypedResults.Created($"/api/tasks/{task.Id}", task);
// }
