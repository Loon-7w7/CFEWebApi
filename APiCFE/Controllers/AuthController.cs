using CFE_Requets.Usuario;
using CFE_Responses.Usuario;
using CFE_Services.Repositorios;
using Microsoft.AspNetCore.Mvc;

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
        
        [HttpPost]
        public async Task<IActionResult> Auth([FromBody] AuthUsuarioRequest request)
        {
            AuthUsuarioResponse response = await repository.AuthGetToken(request);
            return Ok(response);
        }
    }
}
