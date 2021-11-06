using BoxTI.Challenge.CovidTracking.Models.Entities;
using BoxTI.Challenge.CovidTracking.Services.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryRegistryController : ControllerBase
    {
        private readonly IExternalCovidService _serviceCovid;

        public CountryRegistryController(IExternalCovidService serviceCovid)
        {
            _serviceCovid = serviceCovid;
        }

        [HttpGet("covidRegistry/{name}")]
        public async Task<IActionResult> GetCovidRegistry(string name)
        {
            try
            {
                if (name.Length == 0)
                {
                    return NotFound();
                }

                return Ok(await _serviceCovid.getCountryCovidRegistry(name));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

    }
}
