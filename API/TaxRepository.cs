using System;
using System.Collections.Generic;
using System.Linq;
using TaxAPI.Models;
using TaxDB;
using TaxDB.Models;

namespace TaxAPI
{
    public class TaxRepository : ITaxRepository
    {
        private TaxDBContext Db { get; set; }

        public TaxRepository(TaxDBContext db)
        {
            Db = db;
        }

        public double GetTaxRate(string municipality, DateTime date)
        {
            var selectedRate = -1d;
            if (Db.Municipalities.Any(a => a.Name.ToUpper() == municipality.ToUpper()))
            {
                var rates = Db.TaxRates.
                    Where(a => a.Municipality.Name.ToUpper() == municipality.ToUpper()).OrderBy(a => a.Rate);

                foreach (var rate in rates)
                {
                    switch (rate.Period)
                    {
                        case Period.DAILY:
                            if (rate.FromDate == date)
                                selectedRate = rate.Rate;
                        break;
                        case Period.WEEKLY:
                            if (rate.FromDate <= date && rate.ToDate <= date)
                                selectedRate = rate.Rate;
                            break;
                        case Period.MONTHLY:
                            if (rate.FromDate <= date && rate.ToDate <= date)
                                selectedRate = rate.Rate;
                            break;
                        case Period.YEARLY:
                            if (rate.FromDate <= date && rate.ToDate <= date)
                                selectedRate = rate.Rate;
                            break;
                        default:
                            break;
                    }

                    if (selectedRate > -1) 
                        break;
                }                
            }
            return selectedRate;
        }

        public IEnumerable<TaxRateDto> GetAllTaxRates(string municipality)
        {
            if (Db.Municipalities.Any(a => a.Name.ToUpper() == municipality.ToUpper()))
            {
                var rates = Db.TaxRates.
                    Where(a => a.Municipality.Name.ToUpper() == municipality.ToUpper()).OrderBy(a => a.Rate).
                    Select(r => new TaxRateDto { Id = r.Id, Period = r.Period, FromDate = r.FromDate, ToDate = r.ToDate, Rate = r.Rate});

                return rates;
            }
            return new List<TaxRateDto>();
        }

        public void CreateTaxRate(NewTaxRateDto newTaxRateDto)
        {
            var municipality = Db.Municipalities.FirstOrDefault(m => m.Name.ToUpper() == newTaxRateDto.Municipality);

            if (municipality != null) 
            {
                Db.TaxRates.Add(new TaxRate
                {
                    MunicipalityId = municipality.Id,
                    Period = newTaxRateDto.Period,
                    FromDate = newTaxRateDto.FromDate,
                    ToDate = newTaxRateDto.ToDate,
                    Rate = newTaxRateDto.Rate
                });
            }
            else
            {
                Db.Municipalities.Add(
                    new Municipality
                    {
                        Name = newTaxRateDto.Municipality,
                        TaxRates = new List<TaxRate> {
                            new TaxRate
                            {
                                Period = newTaxRateDto.Period,
                                FromDate = newTaxRateDto.FromDate,
                                ToDate = newTaxRateDto.ToDate,
                                Rate = newTaxRateDto.Rate
                            }
                        }
                    });
            }
            Db.SaveChanges();
        }

        public void UpdateTaxRate(UpdateTaxRateDto updateTaxRateDto)
        {
            var taxRate = Db.TaxRates.First(r => r.Id == updateTaxRateDto.Id);
            taxRate.Period = updateTaxRateDto.Period;
            taxRate.FromDate = updateTaxRateDto.FromDate;
            taxRate.ToDate = updateTaxRateDto.ToDate;
            taxRate.Rate = updateTaxRateDto.Rate;

            Db.SaveChanges();
        }

        public void DeleteTaxRate(int id)
        {
            var taxRate = Db.TaxRates.First(r => r.Id == id);
            Db.TaxRates.Remove(taxRate);

            Db.SaveChanges();
        }
    }
}
