using Amazon.Runtime;
using Amazon.S3;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Arkitektur.Business.Extensions
{
    public static class ServiceRegistrations
    {
        public static IServiceCollection AddServicesExtension(this IServiceCollection services, IConfiguration configuration)
        {

            services.Scan(opt => opt
            .FromAssemblyOf<BusinessAssembly>()
            .AddClasses(x => x.Where(t => t.Name.EndsWith("Service")))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            var awsOptions = configuration.GetAWSOptions();
            awsOptions.Credentials = new BasicAWSCredentials(
                configuration["AWS:AccessKey"],
                configuration["AWS:SecretKey"]
                );

            services.AddDefaultAWSOptions(awsOptions);
            services.AddAWSService<IAmazonS3>();

            return services;
        }
    }
}
