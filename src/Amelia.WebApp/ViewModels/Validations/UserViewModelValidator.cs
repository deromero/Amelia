using FluentValidation;

namespace Amelia.WebApp.ViewModels.Validations
{
    public class UserViewModelValidator : AbstractValidator<UserViewModel>
    {
        public UserViewModelValidator()
        {
            RuleFor(user => user.Username).NotEmpty().WithMessage("Username cannot be empty");
            RuleFor(user => user.Email).NotEmpty().WithMessage("Email cannot be empty");
        }
    }
}