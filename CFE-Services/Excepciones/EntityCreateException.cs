using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFE_Services.Excepciones
{
    /// <summary>
    /// Excepción que se lanza cuando ocurre un error al crear una entidad.
    /// </summary>
    public class EntityCreateException : Exception
    {
        /// <summary>
        /// Constructor de la excepción EntityCreateException.
        /// </summary>
        /// <param name="message">Mensaje de error.</param>
        public EntityCreateException(string message) : base(message)
        {
        }
    }
}
