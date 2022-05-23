using FunTranslation.Application.ViewModels;
using FunTranslation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Application.Interfaces.IService
{
    public interface IPastTranslationService : IBaseService<PastTranslation>
    {
        Task<TranslateViewModel> Translate(TranslateViewModel model);
        IQueryable<PastTranslation> GetPastTranslation(PastTranslateRequestViewModel model);
    }
}
