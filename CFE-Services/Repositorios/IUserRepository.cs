using CFE_Requets.Usuario;
using CFE_Responses.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFE_Services.Repositorios
{
    /// <summary>
    /// Repositorio de usuarios
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// realiza la utentificacion del usuario
        /// </summary>
        /// <param name="request">datos del usuario</param>
        /// <returns></returns>
        Task<AuthUsuarioResponse> AuthGetToken(AuthUsuarioRequest request);
    }
}
