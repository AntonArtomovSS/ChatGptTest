using RestCountriesIntegration.Contracts;

namespace RestCountriesIntegration.Services;

public class CountriesService : ICountriesService
{
    private const string RestCountiresRoute = "https://restcountries.com/v3.1/";
    private readonly HttpClient _httpClient;

    public CountriesService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IReadOnlyCollection<object>> GetAll()
    {
        var response = await _httpClient.GetAsync($"{RestCountiresRoute}/all");

        response.EnsureSuccessStatusCode();

        var countries = await response.Content.ReadFromJsonAsync<IReadOnlyCollection<object>>();

        return countries ?? new List<object>();
    }
}