namespace RestCountriesIntegration.Models;

using System.Collections.Generic;

public class Country
{
    public CountryName Name { get; init; }

    public IEnumerable<string> Tld { get; init; }

    public string Cca2 { get; init; }

    public string Ccn3 { get; init; }

    public string Cca3 { get; init; }

    public string Cioc { get; init; }

    public bool Independent { get; init; }

    public string Status { get; init; }

    public bool UnMember { get; init; }

    public Dictionary<string, Currency> Currencies { get; init; }

    public IDD Idd { get; init; }

    public IEnumerable<string> Capital { get; init; }

    public IEnumerable<string> AltSpellings { get; init; }

    public string Region { get; init; }

    public string Subregion { get; init; }

    public Dictionary<string, string> Languages { get; init; }

    public Dictionary<string, Translation> Translations { get; init; }

    public IEnumerable<double> Latlng { get; init; }

    public bool Landlocked { get; init; }

    public IEnumerable<string> Borders { get; init; }

    public double Area { get; init; }

    public Dictionary<string, Demonym> Demonyms { get; init; }

    public string Flag { get; init; }

    public Maps Maps { get; init; }

    public long Population { get; init; }

    public string Fifa { get; init; }

    public Car Car { get; init; }

    public IEnumerable<string> Timezones { get; init; }

    public IEnumerable<string> Continents { get; init; }

    public FlagsAndCoat Flags { get; init; }

    public FlagsAndCoat CoatOfArms { get; init; }

    public string StartOfWeek { get; init; }

    public CapitalInfo CapitalInfo { get; init; }

    public PostalCode PostalCode { get; init; }
}
