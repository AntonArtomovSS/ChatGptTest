using RestCountriesIntegration.Models;

namespace RestCountriesIntegration.Contracts;

public interface ICountriesCollection : IReadOnlyCollection<Country>
{
    CountriesCollection FilterByName(string nameFilter);

    CountriesCollection FilterByPopulation(int minPopulationInMillions);

    CountriesCollection SortByName(string sortingDirection);

    CountriesCollection ApplyPagination(int pageSize);
}
