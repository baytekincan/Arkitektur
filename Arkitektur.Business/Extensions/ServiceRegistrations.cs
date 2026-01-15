using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Arkitektur.Business.Extensions
{
    public static class ServiceRegistrations
    {
        public static IServiceCollection AddServicesExtension(this IServiceCollection services)
        {

            services.Scan(opt => opt
            .FromAssemblyOf<BusinessAssembly>()
            .AddClasses(x => x.Where(t => t.Name.EndsWith("Service")))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
