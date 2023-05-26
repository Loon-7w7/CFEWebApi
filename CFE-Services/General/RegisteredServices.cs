using CFE_Services.Repositorios;
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
        public static List<ServicesEntity> Services() 
        {
            return new List<ServicesEntity> 
            {
                new ServicesEntity{Irepositorio = typeof(IRepository<>), repositorio = typeof(Repositorio<>)},
            };
        }
    }
}
