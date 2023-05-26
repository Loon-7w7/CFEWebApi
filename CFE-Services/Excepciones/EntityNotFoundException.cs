using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFE_Services.Excepciones
{

    /// <summary>
    /// Excepción que se lanza cuando no se encuentra una entidad.
    /// </summary>
    public class EntityNotFoundException : Exception
    {
        /// <summary>
        /// Constructor de la excepción EntityNotFoundException.
        /// </summary>
        /// <param name="message">Mensaje de error.</param>
        public EntityNotFoundException(string message) : base(message)
        {
        }
    }

}
