using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFE_Services.Excepciones
{
    /// <summary>
    /// Excepción que se lanza cuando ocurre un error al eliminar una entidad.
    /// </summary>
    public class EntityDeleteException : Exception
    {
        /// <summary>
        /// Constructor de la excepción EntityDeleteException.
        /// </summary>
        /// <param name="message">Mensaje de error.</param>
        public EntityDeleteException(string message) : base(message)
        {
        }
    }
}
