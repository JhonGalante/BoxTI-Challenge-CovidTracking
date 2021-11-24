using AutoMapper;
using BoxTI.Challenge.CovidTracking.API.Auth;
using BoxTI.Challenge.CovidTracking.API.Models.Models;
using BoxTI.Challenge.CovidTracking.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BoxTI.Challenge.CovidTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(ITokenService tokenService, IUserService userService, IMapper mapper)
        {
            _tokenService = tokenService;
            _userService = userService;
            _mapper = mapper;
        }

        //POST: api/User/login
        /// <summary>
        /// Realizar login no sistema
        /// </summary>
        /// <remarks>
        ///     Exemplo de request:
        ///         POST api/User/login
        ///         {
        ///             "username": "jhongalante",
        ///             "password": "123"
        ///         }
        /// </remarks>
        /// <param name="model"></param>
        /// <returns>Retorna informações do usuário e token</returns>
        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Login([FromBody] Login model)
        {
            //Recupera o usuário
            var user = _userService.GetUser(model.Username, model.Password);

            //Verifica se o usuário existe
            if(user == null)
            {
                return NotFound(new { message = "Usuário ou senha inválidos" });
            }

            //Gera o token
            var token = _tokenService.GenerateToken(user);

            //Retorna os dados
            return new
            {
                user = _mapper.Map<LoginResult>(user),
                token = token
            };
        }

        /// <summary>
        /// Criação de novo usuário
        /// </summary>
        /// <remarks>
        ///     Exemplo de request:
        ///         POST api/User/createUser
        ///         {
        ///             "username": "jhongalante",
        ///             "password": "123"
        ///         }
        /// </remarks>
        /// <param name="model"></param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        [Route("createUser")]
        [AllowAnonymous]
        public async Task<ActionResult> CreateUser([FromBody] Login model)
        {
            var user = await _userService.CreateUser(model.Username, model.Password);

            //Verifica se o usuário existe
            if (user == null)
            {
                return BadRequest(new { message = "Usuário já cadastrado" });
            }

            return Ok("Usuário cadastrado com sucesso!");
        }
    }
}
