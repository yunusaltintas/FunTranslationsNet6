using FunTranslation.Application.AuthenticatedUser;
using FunTranslation.Application.Interfaces.IRepository;
using FunTranslation.Application.Interfaces.IUnitOfWork;
using FunTranslation.Domain.Entities;
using FunTranslation.Persistence.Context;
using FunTranslation.Persistence.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Persistence
{
    public static class ServiceRegisration
    {
        public static void AddPersistanceServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<FunTranslateDbContext>(options => options.UseSqlServer(connectionString), ServiceLifetime.Scoped);
            services.AddTransient<UserResolverService>();

            services.AddScoped<IUnitOfWork, FunTranslation.Persistence.UnitOfWork.UnitOfWork>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ILanguageRepository, LanguageRepository>();
            services.AddScoped<IPastTranslationRepository, PastTranslationRepository>();
        }

        public static void DatabaseInitialize(this IApplicationBuilder builder)
        {

            using var serviceScope =
                builder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();

            using var context = serviceScope.ServiceProvider.GetService<FunTranslateDbContext>();

            if (context == null) return;
            DatabaseMigration(context);

            var roleContext = context.Set<AppRole>();
            var userContext = context.Set<AppUser>();

            var roles = roleContext.Select(p => p.Name).ToArray();
            var userList = userContext.ToList();

            foreach (var user in userList)
            {
                if (user.UserName == "yunus")
                {
                    _ = AssignRoles(serviceScope, user.Email, roles);
                }
                else
                {
                    _ = AssignRoles(serviceScope, user.Email, new string[] { "user" });
                }
            }

            context.SaveChanges();
        }

        public static IdentityResult AssignRoles(IServiceScope? serviceScope, string email, string[] roles)
        {
            UserManager<AppUser> _userManager = (UserManager<AppUser>)serviceScope.ServiceProvider.GetService(typeof(UserManager<AppUser>));
            AppUser user = _userManager.FindByEmailAsync(email).Result;
            var result = _userManager.AddToRolesAsync(user, roles).Result;

            return result;
        }

        private static void DatabaseMigration(FunTranslateDbContext context)
        {
            context.Database.Migrate();
        }


    }
}
