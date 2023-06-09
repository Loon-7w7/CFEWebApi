using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFE_Domain.Material
{
    /// <summary>
    /// Datos para dar cantidad a los materiales
    /// </summary>
    public class AmountMaterial:GeneralEntity
    {
        /// <summary>
        /// Matrial
        /// </summary>
        public Material material {get; set;}
        /// <summary>
        /// cantidad de material
        /// </summary>
        public int amount { get; set;}
    }
}
