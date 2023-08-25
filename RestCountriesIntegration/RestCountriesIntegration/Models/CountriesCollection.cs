using RestCountriesIntegration.Contracts;
using System.Collections;

namespace RestCountriesIntegration.Models;

public class CountriesCollection : ICountriesCollection
{
    private const int OneMillion = 1_000_000;

    private readonly List<Country> _countries;

    public CountriesCollection()
    {
        _countries = new List<Country>();
    }

    public CountriesCollection(IEnumerable<Country> countries)
    {
        _countries = countries.ToList();
    }

    public int Count => _countries.Count;

    public IEnumerator<Country> GetEnumerator() => _countries.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    public CountriesCollection FilterByName(string nameFilter)
    {
        var filteredCountries = _countries
            .Where(country =>
                country?.Name?.Common is not null
                && country.Name.Common.Contains(nameFilter, StringComparison.InvariantCultureIgnoreCase));

        return new CountriesCollection(filteredCountries);
    }

    public CountriesCollection FilterByPopulation(int minPopulationInMillions)
    {
        var filteredCountries = _countries
            .Where(country => country.Population < minPopulationInMillions * OneMillion);

        return new CountriesCollection(filteredCountries);
    }

    public CountriesCollection SortByName(string sortingDirection)
    {
        var sortedCountries = sortingDirection.Trim().ToLower() switch
        {
            "ascend" => _countries.OrderBy(c => c.Name.Common),
            "descend" => _countries.OrderByDescending(c => c.Name.Common),
            _ => throw new ArgumentOutOfRangeException(nameof(sortingDirection), "Invalid sorting direction. Only 'ascend' or 'descend' are allowed.")
        };

        return new CountriesCollection(sortedCountries);
    }

    public CountriesCollection ApplyPagination(int pageSize)
    {
        if (pageSize <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size should be greater than 0.");
        }

        var paginatedCountries = _countries
            .Take(pageSize)
            .ToList();

        return new CountriesCollection(paginatedCountries);
    }
}
