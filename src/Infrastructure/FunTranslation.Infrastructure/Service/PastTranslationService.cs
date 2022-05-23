using AutoMapper;
using FunTranslation.Application.Dtos;
using FunTranslation.Application.Extension;
using FunTranslation.Application.Interfaces.IRepository;
using FunTranslation.Application.Interfaces.IService;
using FunTranslation.Application.Interfaces.IUnitOfWork;
using FunTranslation.Application.SystemModels;
using FunTranslation.Application.ViewModels;
using FunTranslation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FunTranslation.Infrastructure.Service
{
    public class PastTranslationService : BaseService<PastTranslation>, IPastTranslationService
    {
        private readonly FunTranslationSystemModel _funTranslationSystemModel;
        private readonly IMapper _mapper;
        private readonly IRestExtension _restExtension;

        public PastTranslationService(IUnitOfWork unitOfWork,
            IBaseRepository<PastTranslation> repositoryPastTranslation,
            IOptions<FunTranslationSystemModel> options,
            IMapper mapper,
            IRestExtension restExtension)
            : base(unitOfWork, repositoryPastTranslation)
        {
            _funTranslationSystemModel = options.Value;
            _mapper = mapper;
            _restExtension = restExtension;
        }

        public async Task<TranslateViewModel?> Translate(TranslateViewModel model)
        {
            string originalText = HttpUtility.UrlEncode(model.OriginalText);

            var language = await _unitOfWork.LanguageRepository.GetByIdAsync(model.LanguageId);
            string Url = string.Format(_funTranslationSystemModel.LanguageTextUrl, language.LanguageName.ToLower(), originalText);

            string uri = string.Concat(_funTranslationSystemModel.BaseUrl, Url);
            var query = await _restExtension.Get(uri);

            if (!query.IsSuccessful)
            {
                var ErrorString = JsonConvert.DeserializeObject<ErrorDto>(query.Content);
            }
            else
            {
                var translationDto = JsonConvert.DeserializeObject<TranslationDto>(query.Content);

                translationDto.Contents.LanguageId = model.LanguageId;

                var result = await SavePastTranslationed(translationDto);

                return _mapper.Map<TranslateViewModel>(result);
            }
            return null;
        }

        public IQueryable<PastTranslation> GetPastTranslation(PastTranslateRequestViewModel? model)
        {
            var result = _unitOfWork.PastTranslationRepository.Query();

            if (!string.IsNullOrEmpty(model?.LanguageId))
            {
                result = result.Where(i => i.LanguageId == Convert.ToInt32(model.LanguageId));
            }
            if(!string.IsNullOrEmpty(model?.UserId))
            {
                result = result.Where(i => i.CreateUserId == Convert.ToInt32(model.UserId));
            }

            return result.Include(i=>i.Language);
        }
            
        private async Task<PastTranslation> SavePastTranslationed(TranslationDto model) => await AddAsync(_mapper.Map<PastTranslation>(model.Contents));
    }
}
