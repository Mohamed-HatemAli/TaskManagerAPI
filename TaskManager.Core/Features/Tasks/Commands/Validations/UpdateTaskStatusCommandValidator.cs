using FluentValidation;
using TaskManager.Core.Features.Tasks.Commands.Models;

namespace TaskManager.Core.Features.Tasks.Commands.Validations
{
    public class UpdateTaskStatusCommandValidator : AbstractValidator<UpdateTaskStatusCommand>
    {
        public UpdateTaskStatusCommandValidator()
        {
            RuleFor(x => x.projectId)
                .GreaterThan(0).WithMessage("Project ID must be greater than 0.");

            RuleFor(x => x.taskId)
                .GreaterThan(0).WithMessage("Task ID must be greater than 0.");

            RuleFor(x => x.newStatus)
                .IsInEnum().WithMessage("Invalid task status value.");
        }
    }
}
