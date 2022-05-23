using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Application.ViewModels.Validator
{
    public class LanguageCreateValidator : AbstractValidator<LanguageCreateViewModel>
    {
        public LanguageCreateValidator()
        {
            RuleFor(o => o.LanguageName).NotEmpty().NotNull();
        }
    }
}
