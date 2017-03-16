using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Amelia.WebApp.ViewModels.Validations;

namespace Amelia.WebApp.ViewModels
{
    public class RegistrationViewModel : IValidatableObject
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new UserViewModelValidator();
            var result = validator.Validate(this);

            return result.Errors.Select(item =>
                new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }

    }
}