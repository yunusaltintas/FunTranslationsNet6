using FunTranslation.Application.Interfaces.IRepository;
using FunTranslation.Application.Interfaces.IService;
using FunTranslation.Application.Interfaces.IUnitOfWork;
using FunTranslation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Infrastructure.Service
{
    public class LanguageService : BaseService<Language>, ILanguageService
    {
        public LanguageService(IUnitOfWork unitOfWork, IBaseRepository<Language> repository) : base(unitOfWork, repository)
        {
        }
        
    }
}
