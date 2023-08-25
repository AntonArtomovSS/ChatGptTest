using Microsoft.AspNetCore.Mvc;
using RestCountriesIntegration.Contracts;

namespace RestCountriesIntegration.Controllers;

[ApiController]
[Route("[controller]")]
public class CountriesController : ControllerBase
{
    private readonly ICountriesService _countriesService;

    public CountriesController(ICountriesService countriesService)
    {
        _countriesService = countriesService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCountries(string? nameFilter, int? populationInMillionsFilter, string? sortingDirection, int? pageSize)
    {
        var countries = await _countriesService.GetAll(nameFilter, populationInMillionsFilter, sortingDirection, pageSize);

        return Ok(countries);
    }
}
