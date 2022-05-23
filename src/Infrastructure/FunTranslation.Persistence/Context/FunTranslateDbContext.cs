using FunTranslation.Application.AuthenticatedUser;
using FunTranslation.Domain.Common;
using FunTranslation.Domain.Entities;
using FunTranslation.Domain.EntityTypeBuilder;
using FunTranslation.Domain.Seeds;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Persistence.Context
{
    public class FunTranslateDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        private int _userId;
        public FunTranslateDbContext(DbContextOptions<FunTranslateDbContext> dbContext, UserResolverService userService) : base(dbContext)
        {
            _userId = userService.GetUserId();
        }

        public DbSet<Language> Languages { get; set; }
        public DbSet<PastTranslation> PastTranslations { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.
                Entries<CommonEntity>();

            foreach (var data in datas)
            {
                switch (data.State)
                {
                    case EntityState.Added:
                        data.Entity.CreateDate = DateTime.Now;
                        data.Entity.CreateUserId = _userId;
                        break;
                    case EntityState.Modified:
                        data.Entity.UpdateDate = DateTime.Now;
                        data.Entity.UpdateUserId = _userId;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            var datas = ChangeTracker.
                Entries<CommonEntity>();

            foreach (var data in datas)
            {
                switch (data.State)
                {
                    case EntityState.Added:
                        data.Entity.CreateDate = DateTime.Now;
                        data.Entity.CreateUserId = _userId;
                        break;
                    case EntityState.Modified:
                        data.Entity.UpdateDate = DateTime.Now;
                        data.Entity.UpdateUserId = _userId;
                        break;
                }
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new LanguageTypeBuilder())
                .ApplyConfiguration(new PastTranslationTypeBuilder());

            modelBuilder
               .ApplyConfiguration(new RoleSeedData())
               .ApplyConfiguration(new UserSeedData())
               .ApplyConfiguration(new LanguageSeedData());

            base.OnModelCreating(modelBuilder);
        }
    }
}
