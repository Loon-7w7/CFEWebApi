using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFE_Services.Excepciones
{
    /// <summary>
    /// Excepción que se lanza cuando una lista está vacía.
    /// </summary>
    public class EmptyListException : Exception
    {
        /// <summary>
        /// Constructor de la excepción EmptyListException.
        /// </summary>
        /// <param name="message">Mensaje de error.</param>
        public EmptyListException(string message) : base(message)
        {
        }
    }
}
