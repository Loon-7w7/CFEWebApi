using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFE_Requets.Devices
{
    /// <summary>
    /// peticion para obtener díspositivos por id
    /// </summary>
    public class DeviceGetByID
    {
        /// <summary>
        /// Identificador del dispositivo
        /// </summary>
        public Guid Id { get; set; }
    }
}
