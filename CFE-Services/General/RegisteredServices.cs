using CFE_Services.Implementacion;
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
        /// <summary>
        /// Lista de servicios
        /// </summary>
        /// <returns></returns>
        public static List<ServicesEntity> Services() 
        {
            return new List<ServicesEntity> 
            {
                new ServicesEntity{Irepositorio = typeof(IRepository<>), repositorio = typeof(Repositorio<>)},
                new ServicesEntity{Irepositorio = typeof(IMaterialRepository), repositorio = typeof(MaterialService)},
                new ServicesEntity{Irepositorio = typeof(IUserRepository),repositorio = typeof(UserService)},
                new ServicesEntity{Irepositorio = typeof(IDevicesRepository), repositorio = typeof(DeviceServices)},
                new ServicesEntity{Irepositorio = typeof(IAmoutMatrialRepository), repositorio = typeof(AmountServies)}
            };
        }
    }
}
