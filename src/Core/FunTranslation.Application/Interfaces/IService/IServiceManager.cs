using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Application.Interfaces.IService
{
    public interface IServiceManager
    {
        ILanguageService LanguageService { get; }
        IPastTranslationService PastTranslationService { get; }
    }
}
