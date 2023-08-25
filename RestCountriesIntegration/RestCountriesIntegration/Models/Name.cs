namespace RestCountriesIntegration.Models;

public class Name
{
    public string Common { get; init; }

    public string Official { get; init; }

    public Dictionary<string, NativeName> NativeName { get; init; }
}
