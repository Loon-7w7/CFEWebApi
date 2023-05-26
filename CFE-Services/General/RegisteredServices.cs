using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFE_Services.General
{
    /// <summary>
    /// Clase que contiene las lista de los servicios que se registraran
    /// </summary>
    public class RegisteredServices
    {
        public static List<Type> Services() 
        {
            return new List<Type> 
            {
                typeof(Repositorio<>)
            };
        }
    }
}
