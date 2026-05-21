using FluentValidation;
using TaskManager.Core.Features.Projects.Commands.Models;

namespace TaskManager.Core.Features.Projects.Commands.Validations
{
    public class EditProjectValidator : AbstractValidator<EditProjectCommand>
    {
        public EditProjectValidator()
        {
            ApplyValidationsRules();
        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id is required")
                .GreaterThan(0).WithMessage("Invalid Id");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name Must not Be Empty")
                .NotNull().WithMessage("Name Must not Be Null")
                .MaximumLength(100).WithMessage("Max Length is 100");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters");

            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("Invalid User Id");
        }


    }
}
