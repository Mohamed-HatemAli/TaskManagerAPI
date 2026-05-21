using FluentValidation;
using TaskManager.Core.Features.User.Commands.Models;

namespace TaskManager.Core.Features.User.Commands.Validations
{
    public class AddUserValidations : AbstractValidator<AddUserCommand>
    {
        public AddUserValidations()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Full name is required");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Valid email is required");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6);
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Passwords do not match");
        }
    }
}
