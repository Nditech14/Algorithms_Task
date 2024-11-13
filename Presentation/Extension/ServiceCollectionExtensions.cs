using Application.Interfaces;
using Application.Log;
using Application.Services;
using Infrastructure.Abstraction;
using Infrastructure.Repositories;

namespace Presentation.Extension
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICountryRepository, CountryRepository>()
                     .AddScoped<ICountryService, CountryService>()
                      .AddMemoryCache()
                      .AddScoped(typeof(ILoggerService<>), typeof(LoggerService<>));


        }
    }
}
