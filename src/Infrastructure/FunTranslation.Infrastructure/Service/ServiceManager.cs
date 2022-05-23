using AutoMapper;
using FunTranslation.Application.Extension;
using FunTranslation.Application.Interfaces.IRepository;
using FunTranslation.Application.Interfaces.IService;
using FunTranslation.Application.Interfaces.IUnitOfWork;
using FunTranslation.Application.SystemModels;
using FunTranslation.Domain.Entities;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Infrastructure.Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ILanguageService> _lazyLanguageService;
        private readonly Lazy<IPastTranslationService> _lazyPastTranslationService;
        public ServiceManager(
            IUnitOfWork unitOfWork,
            IBaseRepository<Language> baseServiceLanguage,
            IBaseRepository<PastTranslation> baseServicePastTranslation,
            IOptions<FunTranslationSystemModel> options,
            IMapper mapper,
            IRestExtension restExtension)
        {
            _lazyLanguageService = new Lazy<ILanguageService>(() => new LanguageService(
                unitOfWork,
                baseServiceLanguage));

            _lazyPastTranslationService = new Lazy<IPastTranslationService>(() => new PastTranslationService(
                unitOfWork,
                baseServicePastTranslation,
                options,
                mapper,
                restExtension));
        }
        public ILanguageService LanguageService => _lazyLanguageService.Value;
        public IPastTranslationService PastTranslationService => _lazyPastTranslationService.Value;

    }
}
