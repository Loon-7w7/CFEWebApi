using CFE_Domain.Devices;
using CFE_Requets.Devices;
using CFE_Responses.Devicess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFE_Services.Repositorios
{
    /// <summary>
    /// Repositorio de los servicios de los dispositivos
    /// </summary>
    public interface IDevicesRepository
    {
        /// <summary>
        /// Crea un dispositivo
        /// </summary>
        /// <param name="request">datos del dispositivo</param>
        /// <returns></returns>
        Task<bool> Add(CreateDevicesRequest request);
        /// <summary>
        /// optiene todos los dispositivos
        /// </summary>
        /// <returns></returns>
        Task<getDeviceAll> GetAll();
        /// <summary>
        /// Optiene dispositivos por id
        /// </summary>
        /// <param name="resquest"></param>
        /// <returns></returns>
        Task<GetDeviceByidResponse> GetById(DeviceGetByID resquest);
    }
}
