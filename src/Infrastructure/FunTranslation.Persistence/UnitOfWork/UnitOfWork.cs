using FunTranslation.Application.Interfaces.IRepository;
using FunTranslation.Application.Interfaces.IUnitOfWork;
using FunTranslation.Persistence.Context;
using FunTranslation.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FunTranslateDbContext _context;

        private LanguageRepository _languageRepository;
        private PastTranslationRepository _pastTranslationRepository;

        public UnitOfWork(FunTranslateDbContext context)
        {
            _context = context;
        }

        public ILanguageRepository LanguageRepository => _languageRepository = _languageRepository ?? new LanguageRepository(_context);

        public IPastTranslationRepository PastTranslationRepository => _pastTranslationRepository = _pastTranslationRepository ?? new PastTranslationRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
