using AutoMapper;
using BoxTI.Challenge.CovidTracking.API.Models.Models;
using BoxTI.Challenge.CovidTracking.Models.Entities;
using BoxTI.Challenge.CovidTracking.Services.CountryRegistryService;
using BoxTI.Challenge.CovidTracking.Services.CSVService;
using BoxTI.Challenge.CovidTracking.Services.Services;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IBaseService<CountryRegistry> _baseService;
        private readonly ICountryRegistryService _crService;
        private readonly ICsvService _csvService;
        private readonly IMapper _mapper;

        public CountryRegistryController(ICovidService serviceCovid, 
                                         ICountryRegistryService crService, 
                                         IBaseService<CountryRegistry> baseService,
                                         ICsvService csvService,
                                         IMapper mapper)
        {
            _serviceCovid = serviceCovid;
            _baseService = baseService;
            _crService = crService;
            _csvService = csvService;
            _mapper = mapper;
        }

        // GET: api/CountryRegistry/saveCountriesRegistry
        /// <summary>
        /// Realiza a chamada à API externa e busca os dados dos países: 
        /// Brazil, Netherlands, Nigeria, Australia e World e salva os registros
        /// no banco de dados
        /// </summary>
        /// <returns>ActionResult</returns>
        [HttpGet("SaveCountriesRegistry")]
        [Authorize(Roles = "admin")]
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

        //GET: api/CountryRegistry/getOrderedActiveCases
        /// <summary>
        /// Retorna o registro de todos os países ordenado pelo campo
        /// de ActiveCases
        /// </summary>
        /// <returns>Lista de Objetos CountryRegistry</returns>
        [HttpGet("GetOrderedActiveCases")]
        [Authorize]
        public async Task<IActionResult> GetOrderedActiveCases()
        {
            try
            {
                return Ok(await _crService.GetOrderedByActiveCases());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET: api/CountryRegistry
        /// <summary>
        /// Retorna todos os registros dos países do banco
        /// </summary>
        /// <returns>Lista de Objetos CountryRegistry</returns>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<CountryRegistryResult> results = new List<CountryRegistryResult>();
                foreach (var result in await _baseService.Get())
                {
                    results.Add(_mapper.Map<CountryRegistryResult>(result));
                }

                return Ok(results);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        //GET: api/CountryRegistry/10
        /// <summary>
        /// Retorna um único registro do banco
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objeto CountryRegistry</returns>
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                return Ok(_mapper.Map<CountryRegistryResult>(await _baseService.GetById(id)));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        //PUT: api/CountryRegistry/10
        /// <summary>
        /// Atualiza os dados do registro de um país do banco
        /// </summary>
        /// <remarks>
        ///     Exemplo de request:
        ///         PUT api/CountryRegistry/10
        ///         {
        ///             "name": "Brazil",
        ///             "activeCases": 1000000,
        ///             "newCases": 6115,
        ///             "newDeaths": 30,
        ///             "totalCases": 21880439,
        ///             "totalDeaths": 609447,
        ///             "totalRecovered": 21062218,
        ///             "lastUpdate": "2021-11-08T13:21:31.832Z",
        ///             "id": 10
        ///         }
        /// </remarks>
        /// <param name="id"></param>
        /// <param name="countryRegistry"></param>
        /// <returns>ActionResult</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Put(int id, CountryRegistry countryRegistry)
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

        //DELETE: api/CountryRegistry/10
        /// <summary>
        /// Deleta o registro de um país do banco
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ActionResult</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
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

        //GET: api/CountryRegistry/exportCountryRegistryToCsv/10
        /// <summary>
        /// Realiza a exportação dos dados do registro de um país
        /// para o formato de CSV para dentro da pasta do projeto
        /// </summary>
        /// <param name="id"></param>
        /// <returns>String</returns>
        [HttpGet("ExportCountryRegistryToCsv/{id}")]
        [Authorize]
        public async Task<IActionResult> ExportCountryRegistryToCsv(int id)
        {
            try
            {
                var cr = await _baseService.GetById(id);
                if(cr == null)
                    return NotFound();
                
                return Ok(await _csvService.ExportCountriesRegistryToCsv(cr));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
