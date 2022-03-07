using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TaxAPI.Models;

namespace TaxAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        private ITaxRepository TaxRepository { get; set; }

        public TaxController(ITaxRepository taxRepository)
        {
            TaxRepository = taxRepository;
        }

        [HttpGet("{municipality}")]
        public IEnumerable<TaxRateDto> Get(string municipality)
        {
            return TaxRepository.GetAllTaxRates(municipality);
        }

        [HttpGet("municipality={municipality}&date={date}")]
        public double Get(string municipality, DateTime date)
        {
            return TaxRepository.GetTaxRate(municipality, date);
        }

        // POST api/<TaxController>
        [HttpPost]
        public void Post([FromBody] NewTaxRateDto newTaxRateDto)
        {
            TaxRepository.CreateTaxRate(newTaxRateDto);
        }

        // PUT api/<TaxController>
        [HttpPut]
        public void Put([FromBody] UpdateTaxRateDto updateTaxRateDto)
        {
            TaxRepository.UpdateTaxRate(updateTaxRateDto);
        }

        // DELETE api/<TaxController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            TaxRepository.DeleteTaxRate(id);
        }
    }
}
