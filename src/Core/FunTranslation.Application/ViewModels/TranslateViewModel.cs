using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Application.ViewModels
{
    public class TranslateViewModel
    {
        public int LanguageId { get; set; }
        public string? LanguageName { get; set; }
        public string OriginalText { get; set; }
        public string? TranslatedText { get; set; }
    }
}
