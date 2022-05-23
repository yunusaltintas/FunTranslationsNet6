using FunTranslation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Domain.Entities
{
    public class Language : CommonEntity
    {
        public string LanguageName { get; set; }

        public ICollection<PastTranslation> PastTranslations { get; set; }
    }
}
