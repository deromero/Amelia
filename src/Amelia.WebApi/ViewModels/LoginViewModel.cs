using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Amelia.WebApi.ViewModels.Validations;

namespace Amelia.WebApi.ViewModels
{
    public class LoginViewModel : IValidatableObject
    {
        public string Username { get; set; }
        public string Password { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            var validator = new LoginViewModelValidator();
            var result = validator.Validate(this);

            return result.Errors.Select(item =>
                new ValidationResult(item.ErrorMessage, new[] { item.PropertyName }));
        }
    }
}