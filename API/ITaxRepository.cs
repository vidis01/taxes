using System;
using System.Collections.Generic;
using TaxAPI.Models;

namespace TaxAPI
{
    public interface ITaxRepository
    {
        double GetTaxRate(string municipality, DateTime date);
        IEnumerable<TaxRateDto> GetAllTaxRates(string municipality);
        void CreateTaxRate(NewTaxRateDto newTaxRateDto);
        void UpdateTaxRate(TaxRateDto taxRateDto);
        void DeleteTaxRate(int id);
    }
}
