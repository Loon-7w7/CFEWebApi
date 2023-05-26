using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFE_Requets.Usuario
{
    /// <summary>
    /// peticion de autnetificacion de usuario
    /// </summary>
    public class AuthUsuarioRequest
    {
        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Contraseña del usuario
        /// </summary>
        public string Password { get; set; }
    }
}
