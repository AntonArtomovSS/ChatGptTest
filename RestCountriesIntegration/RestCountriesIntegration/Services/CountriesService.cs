using RestCountriesIntegration.Contracts;
using RestCountriesIntegration.Models;
using System.Text.Json;

namespace RestCountriesIntegration.Services;

public class CountriesService : ICountriesService
{
    private const string RestCountiresRoute = "https://restcountries.com/v3.1/";
    private static readonly JsonSerializerOptions JsonSerializerOptions;

    private readonly HttpClient _httpClient;

    static CountriesService()
    {
        JsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }

    public CountriesService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IReadOnlyCollection<Country>> GetAll(string? nameFilter)
    {
        var response = await _httpClient.GetAsync($"{RestCountiresRoute}/all");

        response.EnsureSuccessStatusCode();

        var jsonResponse = await response.Content.ReadAsStringAsync();

        var countries = JsonSerializer.Deserialize<IReadOnlyCollection<Country>>(jsonResponse, JsonSerializerOptions);

        if (countries is null || !countries.Any())
        {
            return new List<Country>();
        }

        if (!string.IsNullOrWhiteSpace(nameFilter))
        {
            countries = FilterByName(countries, nameFilter);
        }

        return countries;
    }

    private static IReadOnlyCollection<Country> FilterByName(IReadOnlyCollection<Country> countries, string nameFilter)
    {
        return countries
            .Where(country =>
                country?.Name?.Common is not null
                && country.Name.Common.Contains(nameFilter, StringComparison.InvariantCultureIgnoreCase))
            .ToList();
    }
}
