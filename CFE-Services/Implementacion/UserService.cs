using CFE_Domain.Enum;
using CFE_Domain.Usuario;
using CFE_Requets.Usuario;
using CFE_Responses.Usuario;
using CFE_Services.Repositorios;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CFE_Services.Implementacion
{
    public class UserService : IUserRepository
    {
        /// <summary>
        /// Repositorio de usuarios
        /// </summary>
        private readonly IRepository<Usuario> _userRepository;
        private readonly IConfiguration _configuration;
        /// <summary>
        /// Contrctor de usuarios
        /// </summary>
        /// <param name="userRepository">Repositorio de usuarios</param>
        public UserService (IRepository<Usuario> userRepository, IConfiguration configuration) 
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        /// <summary>
        /// realiza la utentificacion del usuario
        /// </summary>
        /// <param name="request">datos del usuario</param>
        /// <returns></returns>
        public async Task<AuthUsuarioResponse> AuthGetToken(AuthUsuarioRequest request)
        {
            Usuario? usuario = await _userRepository.SearchFirst(expresion: (x => x.Username == request.Username && x.Password == request.Password)) ;
            if (usuario != null) 
            {
                var secretKey = _configuration.GetSection("Jwt:SecretKey").Value;
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
                var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, request.Username),
                new Claim(ClaimTypes.Role, request.Password)
            };
                var token = new JwtSecurityToken(
                    issuer: _configuration.GetSection("Jwt:Issuer").Value,
                    audience: _configuration.GetSection("Jwt:Audience").Value,
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(24),  // Tiempo de expiración del token
                    signingCredentials: signingCredentials
                );
                AuthUsuarioResponse Response = new AuthUsuarioResponse()
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                };
                return Response;
            }
            else 
            {
                throw new Exception("Usuario no encontrado");
            }
        }
    }
}
