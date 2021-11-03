using BoxTI.Challenge.CovidTracking.Models.Entities;
using BoxTI.Challenge.CovidTracking.Services.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BoxTI.Challenge.CovidTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryRegistryController : ControllerBase
    {
        private readonly IBaseService<CountryRegistry> _service;

        public CountryRegistryController(IBaseService<CountryRegistry> service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CountryRegistry countryRegistry)
        {
            if(countryRegistry == null)
            {
                return NotFound();
            }
            return Execute(() => _service.Add(countryRegistry).Id);
        }

        [HttpPut]
        public IActionResult Update([FromBody] CountryRegistry countryRegistry)
        {
            if (countryRegistry == null)
            {
                return NotFound();
            }
            return Execute(() => _service.Update(countryRegistry));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            Execute(() => {
                _service.Delete(id);
                return true;
            });
            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _service.Get());
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }
            return Execute(() => _service.GetById(id));
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    }
}
