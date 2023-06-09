using CFE_Requets.Usuario;
using CFE_Responses;
using CFE_Responses.Usuario;
using CFE_Services.Repositorios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APiCFE.Controllers
{
    /// <summary>
    /// controlador de autentificacion
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// Repositorio de usuarios
        /// </summary>
        private readonly IUserRepository repository;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="userRepository">repositorio de usuarios</param>
        public AuthController(IUserRepository userRepository) 
        {
            repository = userRepository;
        }
        /// <summary>
        /// autentifica al usuario
        /// </summary>
        /// <param name="request">Regresa un token de autentificaccion</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Auth([FromBody] AuthUsuarioRequest request)
        {
            AuthUsuarioResponse response = await repository.AuthGetToken(request);
            return Ok(response);
        }
        [Authorize]
        [HttpPost("Validate")]
        public async  Task<IActionResult> VerificToken() 
        {
            string authorizationHeader = Request.Headers.Authorization.ToString();
            string token;
            if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
            {
               token  = authorizationHeader.Substring("Bearer ".Length);
               IsVlidateTokenRequest Req = new IsVlidateTokenRequest() { Token = token };
               bool response = repository.isValidateToken(Req);
                
                return Ok(response);
            }

            return BadRequest(false);

        }
        [Authorize(Roles = "Admin")]
        [HttpPost("Cretate")]
        public async Task<IActionResult> CreateUser([FromBody]CreateUserRequest resquest) 
        {
            GeneralResponse response = new GeneralResponse();
            response.success = await repository.CreateUser(resquest);
            if (response.success) 
            {
                response.Message = "Se creo el usario";
                return Ok(response); 
            }
            else 
            {
                response.Message = "No se puedo crear el usuario";
                return BadRequest(response); 
            }

        }
    }
}
