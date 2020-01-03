using AspNetCoreIdentity.Extensions;
using KissLog;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreIdentity.Config
{
    /*
     .AddTransiente()
     Objetos transitórios são sempre diferentes; uma nova instância é fornecida para todos os controladores e todos os serviços.

     .AddScoped()
     Objetos com escopo são os mesmos em uma solicitação, mas diferentes entre solicitações diferentes.

     .AddSingleton()
     Objetos singleton são os mesmos para todos os objetos e todos os pedidos.
      */
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationHandler, PermissaoNecessariaHandler>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(context => Logger.Factory.Get());

            services.AddScoped<AuditoriaFilter>();

            return services;
        }
    }
}
