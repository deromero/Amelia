using FluentValidation;

namespace Amelia.WebApi.ViewModels.Validations
{
    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(user => user.Username).NotEmpty().WithMessage("Username cannot be empty");
            RuleFor(user => user.Password).NotEmpty().WithMessage("Password cannot be empty");
        }
    }
}