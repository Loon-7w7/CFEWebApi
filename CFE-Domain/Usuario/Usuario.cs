using CFE_Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFE_Domain.Usuario
{
    /// <summary>
    /// Entidad de Usuarios
    /// </summary>
    public class Usuario : GeneralEntity
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
