﻿using RestCountriesIntegration.Models;

namespace RestCountriesIntegration.Contracts;

public interface ICountriesService
{
    Task<IReadOnlyCollection<Country>> GetAll();
}
