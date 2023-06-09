using CFE_Domain.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFE_Responses.Devicess
{
    /// <summary>
    /// Respuesa para obtener un dispositivo por su id
    /// </summary>
    public class GetDeviceByidResponse
    {
        /// <summary>
        /// Dispositivo
        /// </summary>
        public Devices device { get; set; }
    }
}
