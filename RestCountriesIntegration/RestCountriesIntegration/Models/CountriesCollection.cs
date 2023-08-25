using RestCountriesIntegration.Contracts;
using System.Collections;

namespace RestCountriesIntegration.Models;

public class CountriesCollection : ICountriesCollection
{
    private const int OneMillion = 1_000_000;

    private List<Country> _countries;

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

    public void FilterByName(string nameFilter)
    {
        _countries = _countries
            .Where(country =>
                country?.Name?.Common is not null
                && country.Name.Common.Contains(nameFilter, StringComparison.InvariantCultureIgnoreCase))
            .ToList();
    }

    public void FilterByPopulation(int populationInMillionsFilter)
    {
        _countries = _countries
            .Where(country => country.Population < populationInMillionsFilter * OneMillion)
            .ToList();
    }

    public void SortByName(string sortingDirection)
    {
        _countries = sortingDirection.Trim().ToLower() switch
        {
            "ascend" => _countries.OrderBy(c => c.Name.Common).ToList(),
            "descend" => _countries.OrderByDescending(c => c.Name.Common).ToList(),
            _ => throw new ArgumentOutOfRangeException(nameof(sortingDirection), "Invalid sorting direction. Only 'ascend' or 'descend' are allowed.")
        };
    }

    public void ApplyPagination(int pageSize)
    {
        if (pageSize <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size should be greater than 0.");
        }

        _countries = _countries
            .Take(pageSize)
            .ToList();
    }
}
