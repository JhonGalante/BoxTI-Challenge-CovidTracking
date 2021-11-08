using BoxTI.Challenge.CovidTracking.Models.Entities;
using BoxTI.Challenge.CovidTracking.Services.CountryRegistryService;
using BoxTI.Challenge.CovidTracking.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryRegistryController : ControllerBase
    {
        private readonly ICovidService _serviceCovid;
        private readonly IBaseService<CountryRegistry> _baseService;
        private readonly ICountryRegistryService _crService;

        public CountryRegistryController(ICovidService serviceCovid, ICountryRegistryService crService, IBaseService<CountryRegistry> baseService)
        {
            _serviceCovid = serviceCovid;
            _baseService = baseService;
            _crService = crService;
        }

        [HttpGet("saveCountriesRegistry")]
        public async Task<IActionResult> SaveCountriesRegistry()
        {
            try
            {
                return Ok(await _serviceCovid.SaveCountriesRegistry());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("getOrderedActiveCases")]
        public IActionResult GetOrderedActiveCases()
        {
            try
            {
                return Ok(_crService.getOrderedByActiveCases());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await _baseService.Get());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _baseService.GetById(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CountryRegistry countryRegistry)
        {
            if (id != countryRegistry.Id)
            {
                return BadRequest();
            }

            try
            {
                await _baseService.Update(countryRegistry);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cr = await _baseService.GetById(id);

            if(cr == null)
            {
                return NotFound();
            }

            try
            {
                await _baseService.Delete(cr);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
