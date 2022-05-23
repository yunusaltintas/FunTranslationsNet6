using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Application.ViewModels.Validator
{
    public class LoginInputValidator : AbstractValidator<UserSignInViewModel>
    {
        public LoginInputValidator()
        {
            RuleFor(o => o.UserName).NotEmpty().NotNull();
            RuleFor(o => o.Password).NotEmpty().NotNull();
        }
    }
}
