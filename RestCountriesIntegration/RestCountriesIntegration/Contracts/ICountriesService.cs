namespace RestCountriesIntegration.Contracts;

public interface ICountriesService
{
    Task<IReadOnlyCollection<object>> GetAll();
}