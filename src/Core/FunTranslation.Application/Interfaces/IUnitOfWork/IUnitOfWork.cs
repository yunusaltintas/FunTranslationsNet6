using FunTranslation.Application.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Application.Interfaces.IUnitOfWork
{
    public interface IUnitOfWork
    {
        ILanguageRepository LanguageRepository { get; }
        IPastTranslationRepository PastTranslationRepository { get; }

        Task CommitAsync();
        void Commit();
    }
}
