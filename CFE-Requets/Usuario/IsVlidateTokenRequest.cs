using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFE_Requets.Usuario
{
    /// <summary>
    /// peticion para validar token
    /// </summary>
    public class IsVlidateTokenRequest
    {
        /// <summary>
        /// Token a validar
        /// </summary>
        public string Token { get; set; }
    }
}
