using CFE_Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFE_Domain.Material
{
    /// <summary>
    /// Entidad de materiales
    /// </summary>
    public class Material : GeneralEntity
    {
        /// <summary>
        /// Codigo del material
        /// </summary>
        public long Code {get; set; }
        /// <summary>
        /// Nombre del material
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Area del material
        /// </summary>
        public string Area { get; set; }
        /// <summary>
        /// Gerarquia del material
        /// </summary>
        public string Hierarchy { get; set; }
        /// <summary>
        /// Unidad de medida del material
        /// </summary>
        public UnitEmun Unit { get; set; }
        /// <summary>
        /// Precio por unidad del material
        /// </summary>
        public double unirPrice { get; set; }
    }
}
