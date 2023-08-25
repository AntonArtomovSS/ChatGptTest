using RestCountriesIntegration.Models;

namespace RestCountriesIntegrationUnitTests;

public class CountriesCollectionTests
{
    [Fact]
    public void FilterByName_MatchesSubstring_ReturnsFilteredCountries()
    {
        var countries = new CountriesCollection(new List<Country>
        {
            new Country { Name = new CountryName { Common = "Canada" } },
            new Country { Name = new CountryName { Common = "Cameroon" } },
            new Country { Name = new CountryName { Common = "Cambodia" } },
            new Country { Name = new CountryName { Common = "Australia" } }
        });

        var result = countries.FilterByName("Cam");

        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void FilterByName_NoMatch_ReturnsEmptyCollection()
    {
        var countries = new CountriesCollection(new List<Country>
        {
            new Country { Name = new CountryName { Common = "Canada" } },
            new Country { Name = new CountryName { Common = "Cameroon" } }
        });

        var result = countries.FilterByName("Zambia");

        Assert.Empty(result);
    }

    [Fact]
    public void FilterByName_CaseInsensitive_ReturnsFilteredCountries()
    {
        var countries = new CountriesCollection(new List<Country>
        {
            new Country { Name = new CountryName { Common = "Canada" } }
        });

        var result = countries.FilterByName("cAnAdA");

        Assert.Single(result);
    }

    [Fact]
    public void FilterByPopulation_LessThanValue_ReturnsFilteredCountries()
    {
        var countries = new CountriesCollection(new List<Country>
        {
            new Country { Population = 500000 },
            new Country { Population = 2000000 },
            new Country { Population = 1500000 }
        });

        var result = countries.FilterByPopulation(2); // 2 million

        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void FilterByPopulation_AllLessThanValue_ReturnsAllCountries()
    {
        var countries = new CountriesCollection(new List<Country>
        {
            new Country { Population = 500000 },
            new Country { Population = 1500000 }
        });

        var result = countries.FilterByPopulation(3); // 3 million

        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void SortByName_Ascending_ReturnsSortedCountries()
    {
        var countries = new CountriesCollection(new List<Country>
        {
            new Country { Name = new CountryName { Common = "Canada" } },
            new Country { Name = new CountryName { Common = "Australia" } }
        });

        var result = countries.SortByName("ascend");

        Assert.Equal("Australia", result.First().Name.Common);
    }

    [Fact]
    public void SortByName_Descending_ReturnsSortedCountries()
    {
        var countries = new CountriesCollection(new List<Country>
        {
            new Country { Name = new CountryName { Common = "Canada" } },
            new Country { Name = new CountryName { Common = "Australia" } }
        });

        var result = countries.SortByName("descend");

        Assert.Equal("Canada", result.First().Name.Common);
    }

    [Fact]
    public void SortByName_InvalidDirection_ThrowsException()
    {
        var countries = new CountriesCollection(new List<Country>
        {
            new Country { Name = new CountryName { Common = "Canada" } }
        });

        var resultCall = () => countries.SortByName("invalid");

        Assert.Throws<ArgumentOutOfRangeException>(resultCall);
    }

    [Fact]
    public void ApplyPagination_ValidSize_ReturnsPaginatedCountries()
    {
        var pageSize = 2;
        var countries = new CountriesCollection(new List<Country>
        {
            new Country { Name = new CountryName { Common = "Canada" } },
            new Country { Name = new CountryName { Common = "Australia" } },
            new Country { Name = new CountryName { Common = "Austria" } }
        });

        var result = countries.ApplyPagination(pageSize);

        Assert.Equal(pageSize, result.Count);
    }

    [Fact]
    public void ApplyPagination_SizeGreaterThanCount_ReturnsAllCountries()
    {
        var pageSize = 5;
        var countries = new CountriesCollection(new List<Country>
        {
            new Country { Name = new CountryName { Common = "Canada" } },
            new Country { Name = new CountryName { Common = "Australia" } }
        });

        var result = countries.ApplyPagination(pageSize);

        Assert.Equal(countries.Count, result.Count);
    }

    [Fact]
    public void ApplyPagination_InvalidSize_ThrowsException()
    {
        var pageSize = 0;
        var countries = new CountriesCollection(new List<Country>
        {
            new Country { Name = new CountryName { Common = "Canada" } }
        });

        var resultCall = () => countries.ApplyPagination(pageSize);

        Assert.Throws<ArgumentOutOfRangeException>(resultCall);
    }
}
