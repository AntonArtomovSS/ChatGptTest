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

    public async Task<IReadOnlyCollection<Country>> GetAll(string? nameFilter, int? populationInMillionsFilter, string? sortingDirection, int? pageSize)
    {
        var response = await _httpClient.GetAsync($"{RestCountiresRoute}/all");

        response.EnsureSuccessStatusCode();

        CountriesCollection countries = await GetCountriesFromResponse(response);

        if (!string.IsNullOrWhiteSpace(nameFilter))
        {
            countries = countries.FilterByName(nameFilter);
        }

        if (populationInMillionsFilter.HasValue)
        {
            countries = countries.FilterByPopulation(populationInMillionsFilter.Value);
        }

        if (!string.IsNullOrWhiteSpace(sortingDirection))
        {
            countries = countries.SortByName(sortingDirection);
        }

        if (pageSize.HasValue)
        {
            countries = countries.ApplyPagination(pageSize.Value);
        }

        return countries;
    }

    private static async Task<CountriesCollection> GetCountriesFromResponse(HttpResponseMessage response)
    {
        var jsonResponse = await response.Content.ReadAsStringAsync();

        if (string.IsNullOrWhiteSpace(jsonResponse))
        {
            return new CountriesCollection();
        }

        IEnumerable<Country> countries = JsonSerializer.Deserialize<IEnumerable<Country>>(jsonResponse, JsonSerializerOptions);

        if (countries is null || !countries.Any())
        {
            return new CountriesCollection();
        }

        return new CountriesCollection(countries);
    }
}
