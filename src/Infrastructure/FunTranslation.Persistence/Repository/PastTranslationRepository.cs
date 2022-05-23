using FunTranslation.Application.Interfaces.IRepository;
using FunTranslation.Domain.Entities;
using FunTranslation.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Persistence.Repository
{
    public class PastTranslationRepository : BaseRepository<PastTranslation>, IPastTranslationRepository
    {
        public PastTranslationRepository(FunTranslateDbContext context) : base(context)
        {
        }
    }
}
