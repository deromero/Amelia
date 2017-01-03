using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Amelia.WebApi.ViewModels.Validations;

namespace Amelia.WebApi.ViewModels
{
    public class UserViewModel : IValidatableObject
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Password { get; set; }
        public int Email { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new UserViewModelValidator();
            var result = validator.Validate(this);

            return result.Errors.Select(item =>
                new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }

    }
}