using FunTranslation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Domain.Entities
{
    public class PastTranslation : CommonEntity
    {
        public string OriginalText { get; set; }
        public string TranslatedText { get; set; }

        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }

    }
}