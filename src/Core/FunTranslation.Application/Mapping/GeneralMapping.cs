using AutoMapper;
using FunTranslation.Application.Dtos;
using FunTranslation.Application.ViewModels;
using FunTranslation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Application.Mapping
{
    public class GeneralMapping : Profile
    {

        public GeneralMapping()
        {
            CreateMap<Language, LanguageCreateViewModel>()
                .ReverseMap();

            CreateMap<Language, LanguageUpdateViewModel>()
                .ReverseMap();

            CreateMap<PastTranslation, Contents>()
                .ReverseMap();

            CreateMap<PastTranslation, TranslateViewModel>()
               .ReverseMap();


        }
    }
}
