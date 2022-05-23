using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Application.ViewModels.Validator
{
    internal class TranslateValidator : AbstractValidator<TranslateViewModel>
    {
        public TranslateValidator()
        {
            RuleFor(o => o.OriginalText).NotEmpty().NotNull();
            RuleFor(o => o.LanguageName).NotEmpty().NotNull();
            //RuleFor(o => o.LanguageId).NotNull();
        }
    }
}
