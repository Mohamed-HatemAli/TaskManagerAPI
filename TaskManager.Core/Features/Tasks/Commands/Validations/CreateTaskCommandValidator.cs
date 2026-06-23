using FluentValidation;
using TaskManager.Core.Features.Tasks.Commands.Models;

namespace TaskManager.Core.Features.Tasks.Commands.Validations
{


    public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskCommandValidator()
        {
            RuleFor(x => x.ProjectId)
                .GreaterThan(0).WithMessage("Project ID must be greater than 0.");

            RuleFor(x => x.title)
                .NotEmpty().WithMessage("Task title is required.")
                .MaximumLength(100).WithMessage("Task title cannot exceed 100 characters.");

            RuleFor(x => x.isCompleted)
                .NotEmpty().WithMessage("Completion status is required.");
        }
    }
}
