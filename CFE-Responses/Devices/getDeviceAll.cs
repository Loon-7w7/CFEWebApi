using CFE_Domain.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFE_Responses.Devicess
{
    /// <summary>
    /// Respues para obtener una lsita de dispositivos
    /// </summary>
    public class getDeviceAll
    {
        /// <summary>
        /// Lista de dispositivos
        /// </summary>
        public List<Devices> devices { get; set; }
    }
}
