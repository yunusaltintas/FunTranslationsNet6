using FunTranslation.Application.Interfaces.IService;
using FunTranslation.Domain.Entities;
using FunTranslation.Infrastructure.Service;
using FunTranslation.Persistence.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunTranslation.Infrastructure
{
    public static class ServiceRegisration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {

            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped<IPastTranslationService, PastTranslationService>();
            services.AddScoped<ILanguageService, LanguageService>();



            services.AddIdentity<AppUser, AppRole>(p =>
            {
                p.Password.RequireDigit = false;
                p.Password.RequiredLength = 3;
                p.Password.RequireLowercase = false;
                p.Password.RequireNonAlphanumeric = false;
                p.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<FunTranslateDbContext>();
            services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme,
            opt =>
            {
                opt.LoginPath = "/Login/Index";
                opt.LogoutPath = "/Login/Logout";
                opt.Cookie = new CookieBuilder
                {
                    Name = "AspNetCoreIdentityCookieYEA",
                    HttpOnly = true,
                    SecurePolicy = CookieSecurePolicy.Always
                };
                opt.SlidingExpiration = true;
                opt.ExpireTimeSpan = TimeSpan.FromMinutes(120);
            });


        }

    }
}
