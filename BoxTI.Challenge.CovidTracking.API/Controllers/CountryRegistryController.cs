using BoxTI.Challenge.CovidTracking.Models.Entities;
using BoxTI.Challenge.CovidTracking.Services.Services;
using Microsoft.AspNetCore.Mvc;
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

        public CountryRegistryController(ICovidService serviceCovid)
        {
            _serviceCovid = serviceCovid;
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

    }
}
