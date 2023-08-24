﻿using Microsoft.AspNetCore.Mvc;
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
    public async Task<IActionResult> GetCountries(string? param1, string? param2, string? param3, int? intParam)
    {
        var countries = await _countriesService.GetAll();

        return Ok(countries);
    }
}