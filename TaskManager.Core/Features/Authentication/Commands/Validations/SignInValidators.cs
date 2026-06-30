using FluentValidation;
using TaskManager.Core.Features.Authentication.Commands.Models;

namespace TaskManager.Core.Features.Authentication.Commands.Validations
{
    public class SignInValidator : AbstractValidator<SigninCommand>
    {
        public SignInValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username is required.")
                .MinimumLength(3).WithMessage("Username must be at least 3 characters long.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
        }
    }
}
