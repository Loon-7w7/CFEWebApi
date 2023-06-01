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
        /// <returns>Regresa un token de autentificacion</returns>
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
                new Claim(ClaimTypes.Name, usuario.Username),
                new Claim(ClaimTypes.Role, usuario.Role.ToString()),
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
        /// <summary>
        /// Verifica si es valido el token para inicio de secion
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool isValidateToken(IsVlidateTokenRequest request)
        {
            var secretKey = _configuration.GetSection("Jwt:SecretKey").Value;
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),
                ValidateIssuer = false, // Si deseas validar el emisor, configúralo según tus necesidades
                ValidateAudience = false, // Si deseas validar la audiencia, configúralo según tus necesidades
            };
            ClaimsPrincipal principal;
            try
            {
                principal = tokenHandler.ValidateToken(request.Token, validationParameters, out var validatedToken);
                DateTime expirationDate = validatedToken.ValidTo;

                bool isExpired = expirationDate > DateTime.UtcNow;

                return isExpired;
            }
            catch (SecurityTokenException ex)
            {
                // Manejar la excepción en caso de token no válido
                // Puedes lanzar una excepción personalizada o tomar alguna otra acción
                throw new Exception("El token no es válido.", ex);
            }


        }
    }
}
