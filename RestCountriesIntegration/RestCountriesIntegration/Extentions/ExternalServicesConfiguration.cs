using RestCountriesIntegration.Contracts;
using RestCountriesIntegration.Services;

namespace RestCountriesIntegration.Extentions;

internal static class ExternalServicesConfiguration
{
    public static IServiceCollection AddRestCountriesIntegration(this IServiceCollection services)
    {
        services.AddSingleton<ICountriesService, CountriesService>();

        return services;
    }
}
