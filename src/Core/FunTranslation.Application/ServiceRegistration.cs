using FunTranslation.Application.SystemModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FunTranslation.Application.Extension;
using RestSharp;

namespace FunTranslation.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationRegistration(this IServiceCollection services)
        {
            var assm = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(assm);
            services.AddSingleton<RestClient>();
            services.AddSingleton<IRestExtension, RestExtension>();
        }
    }
}
