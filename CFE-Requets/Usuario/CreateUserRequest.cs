using CFE_Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFE_Requets.Usuario
{
    /// <summary>
    /// Peticion para crear un usuario
    /// </summary>
    public class CreateUserRequest
    {
        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Contraseña del usuario
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Rol del usuario
        /// </summary>
        public UserRole Role { get; set; }
    }
}
