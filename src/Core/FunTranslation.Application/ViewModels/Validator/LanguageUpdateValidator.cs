using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Application.ViewModels.Validator
{
    internal class LanguageUpdateValidator : AbstractValidator<LanguageUpdateViewModel>
    {
        public LanguageUpdateValidator()
        {
            RuleFor(o => o.LanguageName).NotEmpty().NotNull();
        }
    }
}
