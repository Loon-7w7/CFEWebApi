using CFE_Domain.Material;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFE_Domain.Devices
{
    /// <summary>
    /// Entidad de dispositivos
    /// </summary>
    public class Devices:GeneralEntity
    {
        /// <summary>
        /// Nombre del dispositivo
        /// </summary>
        public string name {get;set;}
        /// <summary>
        /// voltage del dispositivo
        /// </summary>
        public int voltage { get;set;}
        /// <summary>
        /// si es pesado
        /// </summary>
        public bool isHeavy { get;set;}
        /// <summary>
        /// is es semi aislado
        /// </summary>
        public bool isSemiInsulated {get;set;}
        /// <summary>
        /// lista de materiales
        /// </summary>
        public List<AmountMaterial> materials { get;set;}
    }
}
