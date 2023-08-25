namespace RestCountriesIntegration.Models;

public class CountryName
{
    public string Common { get; init; }

    public string Official { get; init; }

    public Dictionary<string, NativeName> NativeName { get; init; }
}
