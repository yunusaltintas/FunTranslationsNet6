using FunTranslation.Application.Interfaces.IRepository;
using FunTranslation.Domain.Entities;
using FunTranslation.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Persistence.Repository
{
    public class LanguageRepository : BaseRepository<Language>, ILanguageRepository
    {
        public LanguageRepository(FunTranslateDbContext context) : base(context)
        {
        }
    }
}
