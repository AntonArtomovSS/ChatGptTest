using RestCountriesIntegration.Models;

namespace RestCountriesIntegration.Contracts;

public interface ICountriesCollection : IReadOnlyCollection<Country>
{
    void FilterByName(string nameFilter);

    void FilterByPopulation(int populationInMillionsFilter);

    void SortByName(string sortingDirection);

    void ApplyPagination(int pageSize);
}
