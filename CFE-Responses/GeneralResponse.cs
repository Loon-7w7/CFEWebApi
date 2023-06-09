using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFE_Responses
{
    /// <summary>
    /// Respuesta general para los ednpoints
    /// </summary>
    public class GeneralResponse
    {
        /// <summary>
        /// Indicacion de quue fue exitoda la conexion
        /// </summary>
        public bool success { get; set; }
        /// <summary>
        /// Mensaje dinamico de la respuesta
        /// </summary>
        public dynamic Message { get; set; }
    }
}
