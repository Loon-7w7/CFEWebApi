using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFE_Services.Excepciones
{
    /// <summary>
    /// Excepción que se lanza cuando ocurre un error al actualizar una entidad.
    /// </summary>
    public class EntityUpdateException : Exception
    {
        /// <summary>
        /// Constructor de la excepción EntityUpdateException.
        /// </summary>
        /// <param name="message">Mensaje de error.</param>
        public EntityUpdateException(string message) : base(message)
        {
        }
    }
}
